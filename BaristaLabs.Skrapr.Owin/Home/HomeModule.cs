namespace BaristaLabs.Skrapr.Owin.Home
{
    using Nancy;
    using BaristaLabs.Skrapr.Owin.Extensions;

    public class HomeModule : NancyModule
    {
        public HomeModule()
            : base("")
        {
            Get[""] = _ =>
            {
                return View["index.html"];
            };

            Get["CardsByColor"] = _ =>
            {
                return View["cardsByColor.html"];
            };

            Get["CardDetails"] = _ =>
            {
                return View["cardDetails.html"];
            };

            //Script/CSS files

            Get["home.css"] = _ =>
            {
                return this.ModuleFileResponse("home.css");
            };

            Get["home.min.css"] = _ =>
            {
                return this.ModuleFileResponse("home.min.css");
            };

            Get["home.js"] = _ =>
            {
                return this.ModuleFileResponse("home.js");
            };

            Get["home.min.js"] = _ =>
            {
                return this.ModuleFileResponse("home.min.js");
            };

            Get["home.min.js.map"] = _ =>
            {
                return this.ModuleFileResponse("home.min.js.map");
            };

        }
    }
}
