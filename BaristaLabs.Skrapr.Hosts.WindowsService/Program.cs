namespace BaristaLabs.Skrapr.Hosts.WindowsService
{
    using Topshelf;

    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SkraprService>();
                x.RunAsLocalSystem();

                x.SetDescription("Hosts Skapr as a Windows Service");
                x.SetDisplayName("BaristaLabs - Skrapr Service");
                x.SetServiceName("BaristaLabs.Skrapr.Hosts.WindowsService");
            });
        }
    }
}
