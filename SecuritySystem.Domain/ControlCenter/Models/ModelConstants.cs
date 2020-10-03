namespace SecuritySystem.Domain.ControlCenter.Models
{
    public class ModelConstants
    {
        public class Address
        {
            public const int MinCityNameLength = 2;
            public const int MaxCityNameLength = 200;
            public const int MinStreetNameLength = 2;
            public const int MaxStreetNameLength = 200;
        }

        public class AlarmEvent
        {
            public const int MinNotesLength = 2;
            public const int MaxNotesLength = 100;
        }
    }
}
