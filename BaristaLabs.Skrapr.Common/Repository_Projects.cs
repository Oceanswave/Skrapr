namespace BaristaLabs.Skrapr.Common
{
    using System;
    using System.Linq;
    using BaristaLabs.Skrapr.Common.DomainModel;
    using MyCouch;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyCouch.Requests;

    public partial class Repository
    {
        public static async Task<IList<Project>> ListProjectsAsync(string userId)
        {
            using (var store = new MyCouchStore(GetDbClient()))
            {
                var query = new QueryViewRequest("projects", "byUserId").Configure(q => q
                    .Key(userId)
                    .Reduce(false));

                var existingCardResponse =
                    await store.Client.Views.QueryAsync<Project>(query);

                return existingCardResponse.Rows.Select(r => r.Value).ToList();
            }
        }

        public static async Task<bool> ProjectExistsAsync(string accountId, string projectId)
        {
            using (var store = new MyCouchStore(GetDbClient()))
            {
                var existingCardResponse =
                    await store.ExistsAsync(projectId);

                return existingCardResponse;
            }
        }

        public static async Task<Project> GetProjectAsync(string userId, string projectId)
        {
            using (var store = new MyCouchStore(GetDbClient()))
            {
                return await store.GetByIdAsync<Project>(projectId);
            }
        }

        public static async Task<Project> CreateOrUpdateProjectAsync(string userId, Project project)
        {
            if (String.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");

            if (project == null)
                throw new ArgumentNullException("project");

            project.UserId = userId;
            if (String.IsNullOrEmpty(project.Id))
            {
                project.CreatedOn = DateTime.UtcNow;
            }
            project.LastUpdated = DateTime.UtcNow;

            using (var store = new MyCouchStore(GetDbClient()))
            {
                var setResponse = await store.Client.Entities.PostAsync(project);
                return setResponse.Content;
            }
        }
    }
}
