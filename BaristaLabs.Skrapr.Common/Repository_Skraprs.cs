namespace BaristaLabs.Skrapr.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BaristaLabs.Skrapr.Common.DomainModel;
    using MyCouch;
    using MyCouch.Requests;

    public partial class Repository
    {
        /// <summary>
        /// Returns a collection of skraprs associated with the specified project.
        /// </summary>
        public static async Task<IList<Skrapr>> ListSkraprsAsync(string projectId)
        {
            using (var store = new MyCouchStore(GetDbClient()))
            {
                var query = new QueryViewRequest("skraprs", "byProjectId").Configure(q => q
                    .Key(projectId)
                    .Reduce(false));

                var skraprsResponse =
                    await store.Client.Views.QueryAsync<Skrapr>(query);

                return skraprsResponse.Rows.Select(r => r.Value).ToList();
            }
        }

        public static async Task<bool> SkraprExistsAsync(string projectId, string skraprId)
        {
            using (var store = new MyCouchStore(GetDbClient()))
            {
                var projectExistsResponse =
                    await store.ExistsAsync(skraprId);

                return projectExistsResponse;
            }
        }

        public static async Task<Skrapr> GetSkraprAsync(string projectId, string skraprId)
        {
            using (var store = new MyCouchStore(GetDbClient()))
            {
                var query = new QueryViewRequest("skraprs", "byProjectId").Configure(q => q
                    .Key(projectId)
                    .Reduce(false));

                return await store.GetByIdAsync<Skrapr>(skraprId);
            }
        }

        public static async Task<Skrapr> CreateOrUpdateSkraprAsync(string userId, string projectId, Skrapr skrapr)
        {
            if (String.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");

            if (String.IsNullOrWhiteSpace(projectId))
                throw new ArgumentNullException("projectId");

            if (skrapr == null)
                throw new ArgumentNullException("skrapr");

            var project = await Repository.GetProjectAsync(userId, projectId);
            if (project == null)
                throw new InvalidOperationException("A project with the specified id does not exist for the user.");

            skrapr.ProjectId = projectId;
            if (String.IsNullOrEmpty(skrapr.Id))
            {
                skrapr.CreatedOn = DateTime.UtcNow;
            }
            skrapr.LastUpdated = DateTime.UtcNow;

            using (var store = new MyCouchStore(GetDbClient()))
            {
                var setResponse = await store.Client.Entities.PostAsync(skrapr);
                return setResponse.Content;
            }
        }
    }
}
