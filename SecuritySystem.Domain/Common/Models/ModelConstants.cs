namespace SecuritySystem.Domain.Common.Models
{
    public class ModelConstants
    {
        public class GeoCoordinates
        {
            public const int MinLatitude = -90;
            public const int MaxLatitude = 90;
            public const int MinLongtitude = -180;
            public const int MaxLongtitude = 180;
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
