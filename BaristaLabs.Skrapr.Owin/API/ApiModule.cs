namespace BaristaLabs.Skrapr.Owin.API
{
    using BaristaLabs.Skrapr.Common;
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
            : base("/Api")
        {
            Get[""] = _ =>
            {
                return Response.AsJson("Hello, world");
            };

            Get["/projects/{projectId}", true] = async (_, token) =>
            {
                string id = _.projectId;
                var project = await Repository.GetProjectAsync("Administrator", id);

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
