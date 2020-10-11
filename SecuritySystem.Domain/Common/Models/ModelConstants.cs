namespace SecuritySystem.Domain.Common.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }
        public class GeoCoordinates
        {
            public const int MinLatitude = -90;
            public const int MaxLatitude = 90;
            public const int Minlongitude = -180;
            public const int Maxlongitude = 180;
            public const double EarthRadiusInKm = 6378.16;
            public const double EarthRadiusInMeters = 6378160;
        }
        public class PhoneNumber
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }
        public class Contact
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
        }
    }
}
