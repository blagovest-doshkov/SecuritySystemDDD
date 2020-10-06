namespace SecuritySystem.Application.ControlCenter.Commands.Common
{
    using Application.Common;
    using System;

    public abstract class AlarmEventCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int SystemId { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public string City { get;  set; } = default!;
        public string StreetInfo { get; set; } = default!;
        public double Latitude { get; set; } = default!;
        public double Longtitude { get; set; } = default!;
        public string ContactName { get;  set; } = default!;
        public string ContactPhoneNumber { get;  set; } = default!;
        //public DateTime EventDateTime { get;  set; } = default!;
        //public int AlarmEventState { get;  set; } = default!;
        //public int? AssignedGuardId { get;  set; } = default!;
    }
}
