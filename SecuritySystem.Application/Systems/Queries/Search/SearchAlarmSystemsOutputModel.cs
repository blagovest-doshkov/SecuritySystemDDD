namespace SecuritySystem.Application.Systems.Queries.Search
{
    using SecuritySystem.Application.Systems.Queries.Common;
    using SecuritySystem.Domain.Systems.Models;
    using System.Collections.Generic;

    public class SearchAlarmSystemsOutputModel : AlarmSystemsOutputModel<AlarmSystem>
    {
        public SearchAlarmSystemsOutputModel(
            IEnumerable<AlarmSystem> alarmSystems,
            int page,
            int totalPages
            ) : base(alarmSystems, page, totalPages) { }
    }
}
