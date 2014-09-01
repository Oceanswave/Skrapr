namespace BaristaLabs.Skrapr.Owin.API
{
    using System;
    using BaristaLabs.Skrapr.Common;
    using BaristaLabs.Skrapr.Common.DomainModel;
    using BaristaLabs.Skrapr.Owin.Authentication;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;
    using Newtonsoft.Json;

    public class HomeModule : NancyModule
    {
        public HomeModule()
            : base("/Api")
        {
            this.RequiresAuthentication();

            Get["/projects", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("CurrentUser was null.");

                var project = await Repository.ListProjectsAsync(skraprUser.UserProfile.UserId);

                return Response.AsJson(project);
            };

            Put["/projects", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("CurrentUser was null.");

                var project = this.Bind<Project>();
                var result = await Repository.CreateOrUpdateProjectAsync(skraprUser.UserProfile.UserId, project);

                return Response.AsJson(result);
            };

            Get["/projects/{projectId}", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("CurrentUser was null.");

                var project = await Repository.GetProjectAsync(skraprUser.UserProfile.UserId, (string)_.projectId);

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
