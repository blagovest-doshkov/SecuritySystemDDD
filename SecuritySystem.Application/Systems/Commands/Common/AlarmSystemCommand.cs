namespace SecuritySystem.Application.Systems.Commands.Common
{
    using Application.Common;

    public abstract class AlarmSystemCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string OwnerId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public string ContactName { get;  set; } = default!;
        public string ContactPhoneNumber { get;  set; } = default!;
        public string Country { get;  set; } = default!;
        public string Province { get;  set; } = default!;
        public string City { get;  set; } = default!;
        public string Street { get;  set; } = default!;
        public double Latitude { get;  set; }
        public double Longitude { get;  set; }

        //public string ControlUnitSerialNumber { get; private set; } = default!;
    }
}
