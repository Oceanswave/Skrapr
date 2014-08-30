namespace BaristaLabs.Skrapr.Owin.Styles
{
    using BaristaLabs.Skrapr.Owin.Extensions;
    using Nancy;

    public class StylesModule : NancyModule
    {
        public StylesModule()
            : base("/styles")
        {
            Get["/styles.css"] = parameters =>
            {
                return this.ModuleFileResponse("styles.css");
            };

            Get["/styles.min.css"] = parameters =>
            {
                return this.ModuleFileResponse("styles.min.css");
            };

            Get["/font-awesome-4.1.0/fonts/{fileName*}"] = parameters =>
            {
                var fileName = ((string)parameters.fileName).Replace("/", "\\");
                fileName = fileName.Replace("..", "");
                return this.ModuleFileResponse("font-awesome-4.1.0\\fonts\\" + fileName);
            };

            Get["/bootstrap/fonts/{fileName*}"] = parameters =>
            {
                var fileName = ((string)parameters.fileName).Replace("/", "\\");
                fileName = fileName.Replace("..", "");
                return this.ModuleFileResponse("bootstrap\\fonts\\" + fileName);
            };
        }
    }
}
