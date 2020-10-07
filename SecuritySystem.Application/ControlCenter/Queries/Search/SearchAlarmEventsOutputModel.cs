namespace SecuritySystem.Application.ControlCenter.Queries.Search
{
    using SecuritySystem.Application.ControlCenter.Queries.Common;
    using SecuritySystem.Domain.ControlCenter.Models;
    using System.Collections.Generic;

    public class SearchAlarmEventsOutputModel : AlarmEventsOutputModel<AlarmEvent>
    {
        public SearchAlarmEventsOutputModel(
            IEnumerable<AlarmEvent> alarmEvents,
            int page,
            int totalPages
            ) : base(alarmEvents, page, totalPages) { }
    }
}
