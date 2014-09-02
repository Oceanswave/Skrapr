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

                var projectsResponse =
                    await store.Client.Views.QueryAsync<Project>(query);

                return projectsResponse.Rows.Select(r => r.Value).ToList();
            }
        }

        public static async Task<Project> GetProjectAsync(string userId, string projectId)
        {
            using (var store = new MyCouchStore(GetDbClient()))
            {
                var result =  await store.GetByIdAsync<Project>(projectId);
                return result.UserId != userId
                    ? null
                    : result;
            }
        }

        public static async Task<bool> DeleteProjectAsync(string userId, string projectId)
        {
            using (var store = new MyCouchStore(GetDbClient()))
            {
                var project = await GetProjectAsync(userId, projectId);

                if (project == null)
                    return false;

                return await store.DeleteAsync(projectId);
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
