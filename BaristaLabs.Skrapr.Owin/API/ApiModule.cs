namespace BaristaLabs.Skrapr.Owin.API
{
    using System;
    using BaristaLabs.Skrapr.Common;
    using BaristaLabs.Skrapr.Owin.Authentication;
    using Nancy;
    using Nancy.Security;

    public class HomeModule : NancyModule
    {
        public HomeModule()
            : base("/Api")
        {
            this.RequiresAuthentication();

            Get[""] = _ =>
            {
                return Response.AsJson("Hello, world");
            };

            Get["/projects", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("CurrentUser was null.");

                var project = await Repository.ListProjectsAsync(skraprUser.UserProfile.UserId);

                return Response.AsJson(project);
            };

            Get["/logs/", true] = async (_, token) =>
            {
                var project = await Repository.GetProjectAsync("Administrator", "1234");
                return Response.AsJson(project);
            };
        }
    }
}
