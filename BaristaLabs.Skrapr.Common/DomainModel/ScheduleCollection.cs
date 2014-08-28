namespace BaristaLabs.Skrapr.Common.DomainModel
{
    using System.Collections.ObjectModel;

    public class ScheduleCollection : KeyedCollection<string, Schedule>
    {
        protected override string GetKeyForItem(Schedule item)
        {
            return item.Name;
        }
    }
}
