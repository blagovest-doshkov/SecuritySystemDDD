namespace SecuritySystem.Domain.ControlCenter.Models
{
    using Common;
    using Common.Models;
    using Exceptions;
    using static ModelConstants.Address;

    public class Address : ValueObject
    {
        internal Address(
            string city, 
            string streetInfo,
            GeoCoordinates coordinates)
        {
            Validate(city, streetInfo);

            this.City = city;
            this.StreetInfo = streetInfo;
            this.Coordinates = coordinates;
        }

        //EF workaround for migrations
        internal Address(
            string city,
            string streetInfo)
        {
            this.City = city;
            this.StreetInfo = streetInfo;
            this.Coordinates = default!;
        }

        public string City { get; private set; }
        public string StreetInfo { get; private set; }
        public GeoCoordinates Coordinates { get; private set; }

        //Validations
        private void Validate(string city, string streetInfo)
        {
            ValidateCity(city);
            ValidateStreetInfo(streetInfo);
        }

        private void ValidateCity(string city)
        {
            Validator.StringLength<InvalidAddressException>(city, MinCityNameLength, MaxCityNameLength, nameof(this.City));
        }

        private void ValidateStreetInfo(string street)
        {
            Validator.StringLength<InvalidAddressException>(street, MinStreetNameLength, MaxStreetNameLength, nameof(this.StreetInfo));
        }
    }
}
