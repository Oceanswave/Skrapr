namespace BaristaLabs.Skrapr.Common
{
    using System;
    using System.Collections.Generic;
    using BaristaLabs.Skrapr.Common.DomainModel;

    public partial class Repository
    {
        /// <summary>
        /// Returns a collection of skraprs associated with the specified project.
        /// </summary>
        public static IList<Skrapr> GetSkraprs(string projectId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a collection of targets associated with the specified skrapr.
        /// </summary>
        public static IList<Skrapr> GetTargets(string skraprId)
        {
            throw new NotImplementedException();
        }
    }
}
