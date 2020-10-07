namespace SecuritySystem.Application.ControlCenter.Queries.Common
{
    using System.Collections.Generic;

    public abstract class AlarmEventsOutputModel<TAlarmEventOutputModel>
    {
        internal AlarmEventsOutputModel(
            IEnumerable<TAlarmEventOutputModel> alarmEvents,
            int page,
            int totalPages)
        {
            this.AlarmEvents = alarmEvents;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TAlarmEventOutputModel> AlarmEvents { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
