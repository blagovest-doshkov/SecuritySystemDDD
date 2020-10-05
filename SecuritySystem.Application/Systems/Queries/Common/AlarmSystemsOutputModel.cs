namespace SecuritySystem.Application.Systems.Queries.Common
{
    using System.Collections.Generic;

    public abstract class AlarmSystemsOutputModel<TAlarmSystemOutputModel>
    {
        internal AlarmSystemsOutputModel(
            IEnumerable<TAlarmSystemOutputModel> alarmSystems,
            int page,
            int totalPages)
        {
            this.AlarmSystems = alarmSystems;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TAlarmSystemOutputModel> AlarmSystems { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
