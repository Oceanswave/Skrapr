namespace BaristaLabs.Skrapr.Owin.API
{
    using BaristaLabs.Skrapr.Common;
    using BaristaLabs.Skrapr.Common.DomainModel;
    using BaristaLabs.Skrapr.Owin.Authentication;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;
    using System;

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
                    throw new InvalidOperationException("Current User was null.");

                var projects = await Repository.ListProjectsAsync(skraprUser.UserProfile.UserId);

                return Response.AsJson(projects);
            };

            Put["/projects", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("Current User was null.");

                var project = this.Bind<Project>();
                var result = await Repository.CreateOrUpdateProjectAsync(skraprUser.UserProfile.UserId, project);

                return Response.AsJson(result);
            };

            Get["/projects/{projectId}", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("Current User was null.");

                var project = await Repository.GetProjectAsync(skraprUser.UserProfile.UserId, (string)_.projectId);

                return Response.AsJson(project);
            };

            Delete["/projects/{projectId}", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("Current User was null.");

                var project = await Repository.DeleteProjectAsync(skraprUser.UserProfile.UserId, (string)_.projectId);

                return Response.AsJson(project);
            };

            Get["/projects/{projectId}/skraprs", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("Current User was null.");

                var skraprs = await Repository.ListSkraprsAsync((string)_.projectId);

                return Response.AsJson(skraprs);
            };

            Put["/projects/{projectId}/skraprs", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("Current User was null.");

                var skrapr = this.Bind<Skrapr>();
                var result = await Repository.CreateOrUpdateSkraprAsync(skraprUser.UserProfile.UserId, (string)_.projectId, skrapr);

                return Response.AsJson(result);
            };

            Get["/projects/{projectId}/skraprs/{skraprId}", true] = async (_, token) =>
            {
                var skraprUser = this.Context.CurrentUser as Auth0User;

                if (skraprUser == null)
                    throw new InvalidOperationException("CurrentUser was null.");

                var skrapr = await Repository.GetSkraprAsync((string)_.projectId, (string)_.skraprId);

                return Response.AsJson(skrapr);
            };

            Get["/logs/", true] = async (_, token) =>
            {
                var project = await Repository.GetProjectAsync("Administrator", "1234");
                return Response.AsJson(project);
            };
        }
    }
}
