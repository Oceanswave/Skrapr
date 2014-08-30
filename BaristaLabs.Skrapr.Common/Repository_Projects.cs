namespace BaristaLabs.Skrapr.Common
{
    using System.Reactive.Linq;
    using BaristaLabs.Skrapr.Common.DomainModel;
    using MyCouch;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Threading.Tasks;

    public partial class Repository
    {
        public static string ProjectsDatabaseName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("TheoryBox_Database_Cards");
            }
        }

        public static async Task<IList<Project>> ListProjectsAsync(string accountId)
        {
            using (var store = new MyCouchStore(GetDbClient(ProjectsDatabaseName)))
            {
                var existingCardResponse =
                    await store.Query<Project>(new Query("Projects")).Select(p => p.Value).ToList();

                return existingCardResponse;
            }
        }

        public static async Task<bool> ProjectExistsAsync(string accountId, string projectId)
        {
            using (var store = new MyCouchStore(GetDbClient(ProjectsDatabaseName)))
            {
                var existingCardResponse =
                    await store.ExistsAsync(projectId);

                return existingCardResponse;
            }
        }

        public static async Task<Project> GetProjectAsync(string accountId, string projectId)
        {
            using (var store = new MyCouchStore(GetDbClient(ProjectsDatabaseName)))
            {
                return await store.GetByIdAsync<Project>(projectId);
            }
        }

        public static async Task<Project> CreateOrUpdateProjectAsync(Project project)
        {
            using (var store = new MyCouchStore(GetDbClient(ProjectsDatabaseName)))
            {
                var setResponse = await store.SetAsync(project);
                return setResponse;
            }
        }
    }
}
