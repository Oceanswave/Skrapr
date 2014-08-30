namespace BaristaLabs.Skrapr.Owin
{
    using Nancy;
    using System.IO;

    /// <summary>
    /// Nancy RootPathProvider that loads files from the debug folder to facilitate html file changes without rebuilds.
    /// </summary>
    public class DebugRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            //Hack to be able to edit files while the app is running in VS.
            var currentDirectory = Directory.GetCurrentDirectory();
            var di = new DirectoryInfo(currentDirectory);

            // ReSharper disable PossibleNullReferenceException
            return di.Parent.Parent.FullName + "\\BaristaLabs.Skrapr.Owin\\";
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
