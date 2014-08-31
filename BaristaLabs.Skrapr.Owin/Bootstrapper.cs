namespace BaristaLabs.Skrapr.Owin
{
    using Auth0;
    using BaristaLabs.Skrapr.Owin.Authentication;
    using Microsoft.Owin.Security.DataHandler.Encoder;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using Nancy.TinyIoc;
    using Newtonsoft.Json;
    using System.Configuration;
    using System.IdentityModel.Tokens;
    using System.Linq;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get
            {
#if DEBUG
                return new DebugRootPathProvider();
#else
                return base.RootPathProvider;
#endif
            }
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {

            Conventions.StaticContentsConventions.Add(
                  StaticContentConventionBuilder.AddDirectory("components")
              );

            base.ConfigureConventions(nancyConventions);
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.BeforeRequest.AddItemToStartOfPipeline(LoadCurrentUser);
        }

        private static Response LoadCurrentUser(NancyContext context)
        {
            //Obtain the bearer token from the authorization header if it exists.
            const string key = "Bearer ";
            string accessToken = null;

            if (context.Request.Headers.Authorization.StartsWith(key))
                accessToken = context.Request.Headers.Authorization.Substring(key.Length);

            if (string.IsNullOrWhiteSpace(accessToken))
                return null;

            try
            {
                //Obtain Auth0 settings from configuration.
                var clientId = ConfigurationManager.AppSettings["Skrapr_Auth0_ClientId"];
                var secret = ConfigurationManager.AppSettings["Skrapr_Auth0_Secret"];
                var domain = ConfigurationManager.AppSettings["Skrapr_Auth0_Domain"];

                //Validate the Bearer JWT.
                SecurityToken validatedSecurityToken;
                var securityTokenHandler = new JwtSecurityTokenHandler();

                securityTokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidIssuer = "https://" + domain + "/",
                    ValidAudience = clientId,
                    IssuerSigningKey = new InMemorySymmetricSecurityKey(TextEncodings.Base64Url.Decode(secret))
                }, out validatedSecurityToken);

                var jwt = validatedSecurityToken as JwtSecurityToken;

                if (jwt == null)
                    return null;

                var subClaim = jwt.Claims.FirstOrDefault(claim => claim.Type == "sub");

                if (subClaim == null)
                    return null;

                var c = new Client(clientId, secret, domain);
                var profile = c.GetUser(subClaim.Value);

                if (profile == null)
                    return null;

                context.CurrentUser = new Auth0User(profile);
            }
            catch
            {
                //Do Nothing..
            }

            return null;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<JsonSerializer>(new CustomJsonSerializer());
        }
    }
}
