namespace BaristaLabs.Skrapr.Owin.Dashboard
{
    using BaristaLabs.Skrapr.Owin.Extensions;
    using Nancy;

    public class DashboardModule : NancyModule
    {
        public DashboardModule()
            : base("/dashboard")
        {
            Get[""] = _ =>
            {
                return View["dashboard.html"];
            };

            Get["Projects"] = _ =>
            {
                return View["projects.html"];
            };

            Get["ProjectDetails"] = _ =>
            {
                return View["projectDetails.html"];
            };

            Get["ActiveTasks"] = _ =>
            {
                return View["activeTasks.html"];
            };

            //Script/CSS files

            Get["dashboard.css"] = _ =>
            {
                return this.ModuleFileResponse("dashboard.css");
            };

            Get["dashboard.min.css"] = _ =>
            {
                return this.ModuleFileResponse("dashboard.min.css");
            };

            Get["dashboard.js"] = _ =>
            {
                return this.ModuleFileResponse("dashboard.js");
            };

            Get["dashboard.min.js"] = _ =>
            {
                return this.ModuleFileResponse("dashboard.min.js");
            };

            Get["dashboard.min.js.map"] = _ =>
            {
                return this.ModuleFileResponse("dashboard.min.js.map");
            };
        }
    }
}
