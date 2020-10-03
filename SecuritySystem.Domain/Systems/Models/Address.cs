namespace SecuritySystem.Domain.Systems.Models
{
    using Common;
    using Common.Models;
    using Exceptions;
    using static ModelConstants.Address;

    public class Address : Entity<int>
    {
        internal Address(
            string country,
            string province,
            string city,
            string street,
            GeoCoordinates coordinates)
        {
            Validate(country, city, street, coordinates);

            this.Country = country;
            this.Province = province;
            this.City = city;
            this.Street = street;
            this.Coordinates = coordinates;
        }

        public string Country { get; private set; }
        public string Province { get; private set; } = default!;
        public string City { get; private set; }
        public string Street { get; private set; }
        public GeoCoordinates Coordinates { get; private set; }

        //Methods
        public Address UpdateCountry(string country)
        {
            ValidateCountry(country);

            this.Country = country;
            return this;
        }

        public Address UpdateProvince(string province)
        {
            this.Province = province;
            return this;
        }

        public Address UpdateCity(string city)
        {
            ValidateCity(city);

            this.City = city;
            return this;
        }

        public Address UpdateStreet(string city)
        {
            ValidateCity(city);

            this.City = city;
            return this;
        }

        public Address UpdateCoordinates(GeoCoordinates coordinates)
        {
            this.Coordinates = coordinates;
            return this;
        }

        public Address UpdateCoordinates(double latitude, double longtitude)
        {
            return UpdateCoordinates(new GeoCoordinates(latitude, longtitude));
        }

        //VALIDATIONS
        private void Validate(
            string country,
            string city,
            string street,
            GeoCoordinates Coordinates)
        {
            ValidateCountry(country);
            ValidateCity(city);
            ValidateStreet(street);
            ValidateCoordinates(Coordinates);
        }

        private void ValidateCoordinates(GeoCoordinates coordinates)
        {
            Validator.IsNotNull<InvalidAddressException>(coordinates, nameof(this.Coordinates));
        }

        private void ValidateCountry(string Country)
        {
            Validator.StringNotEmpty<InvalidAddressException>(Country, nameof(this.Country));
            Validator.StringLength<InvalidAddressException>(Country, MinCountryNameLength, MaxCountryNameLength, nameof(this.Country));
        }

        private void ValidateCity(string City)
        {
            Validator.StringNotEmpty<InvalidAddressException>(City, nameof(this.City));
            Validator.StringLength<InvalidAddressException>(City, MinCityNameLength, MaxCityNameLength, nameof(this.City));
        }

        private void ValidateStreet(string Street)
        {
            Validator.StringNotEmpty<InvalidAddressException>(Street, nameof(this.Street));
            Validator.StringLength<InvalidAddressException>(Street, MinStreetNameLength, MaxStreetNameLength, nameof(this.Street));
        }
    }
}
