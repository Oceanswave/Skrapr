namespace BaristaLabs.Skrapr.Owin.Components
{
    using BaristaLabs.Skrapr.Owin.Extensions;
    using Nancy;

    public class ComponentsModule : NancyModule
    {
        public ComponentsModule()
            : base("/components")
        {
            Get["components.js"] = _ =>
            {
                return this.ModuleFileResponse("components.js");
            };

            Get["components.min.js"] = _ =>
            {
                return this.ModuleFileResponse("components.min.js");
            };

            Get["components.min.js.map"] = _ =>
            {
                return this.ModuleFileResponse("components.min.js.map");
            };
        }
    }
}
