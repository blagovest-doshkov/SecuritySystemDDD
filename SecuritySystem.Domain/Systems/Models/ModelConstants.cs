namespace SecuritySystem.Domain.Systems.Models
{
    public class ModelConstants
    {
        public class DeviceType
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
        }

        public class AlarmSystem
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
            public const int MinNotesLength = 0;
            public const int MaxNotesLength = 150;
        }

        public class Address
        {
            public const int MinCityNameLength = 2;
            public const int MaxCityNameLength = 200;
            public const int MinCountryNameLength = 2;
            public const int MaxCountryNameLength = 120;
            public const int MinStreetNameLength = 2;
            public const int MaxStreetNameLength = 200;
        }

        public class ErrorCode
        {
            public const int MinCodeLength = 2;
            public const int MaxCodeLength = 6;
            public const int MinDescriptionLength = 2;
            public const int MaxDescriptionLength = 300;
        }

        public class Zone
        {
            public const int MinNotesLength = 0;
            public const int MaxNotesLength = 150;
        }
    }
}
