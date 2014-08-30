namespace BaristaLabs.Skrapr.Owin
{
    using Newtonsoft.Json;

    public sealed class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            Formatting = Formatting.Indented;
        }
    }
}
