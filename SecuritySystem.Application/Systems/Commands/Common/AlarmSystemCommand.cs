namespace SecuritySystem.Application.Systems.Commands.Common
{
    using Application.Common;

    public abstract class AlarmSystemCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int OwnerId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Notes { get; set; } = default!;

        public string ContactName { get; private set; } = default!;
        public string ContactPhoneNumber { get; private set; } = default!;

        public string Country { get; private set; } = default!;
        public string Province { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string Street { get; private set; } = default!;
        public double Latitude { get; private set; }
        public double Longtitude { get; private set; }

        //public string ControlUnitSerialNumber { get; private set; } = default!;
    }
}
