﻿namespace SecuritySystem.Domain.Guards.Models
{
    public class ModelConstants
    {
        public class TaskAssignmentRequest
        {
            public const int MinNotesLength = 2;
            public const int MaxNotesLength = 80;
        }

        public class GuardPatrol
        {
            public const double DefaultOfficeLatitude = 42.696189;
            public const double DefaultOfficelongitude = 23.413198;
        }

        public class Address
        {
            public const int MinCityNameLength = 2;
            public const int MaxCityNameLength = 200;
            public const int MinStreetNameLength = 2;
            public const int MaxStreetNameLength = 200;
        }

        public class GuardUnit
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 200;
        }
    }
}
