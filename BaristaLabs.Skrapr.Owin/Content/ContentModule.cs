namespace BaristaLabs.Skrapr.Owin.Content
{
    using BaristaLabs.Skrapr.Owin.Extensions;
    using Nancy;

    class ContentModule : NancyModule
    {
        public ContentModule()
            : base("/content")
        {
            //Components FFA
            Get["{fileName*}"] = parameters =>
            {
                var fileName = ((string)parameters.fileName).Replace("/", "\\");
                fileName = fileName.Replace("..", "");
                return this.RootFileResponse("content\\" + fileName);
            };
        }
    }
}
