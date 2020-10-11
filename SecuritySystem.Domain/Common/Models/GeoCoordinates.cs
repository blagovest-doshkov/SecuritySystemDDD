namespace SecuritySystem.Domain.Common.Models
{
    using Common.Exceptions;
    using System;
    using static ModelConstants.GeoCoordinates;

    public class GeoCoordinates: ValueObject
    {
        internal GeoCoordinates(double latitude, double longitude)
        {
            ValidateCoordinates(latitude, longitude);

            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public double DistanceToInKm(GeoCoordinates anotherLocation)
        {
            return DistanceToIn(anotherLocation, EarthRadiusInKm);
        }

        public double DistanceToInMeters(GeoCoordinates anotherLocation)
        {
            return DistanceToIn(anotherLocation, EarthRadiusInMeters);
        }

        private double DistanceToIn(GeoCoordinates anotherLocation, double earthRadiusUnit)
        {
            double dlon = Radians(anotherLocation.Longitude - this.Longitude);
            double dlat = Radians(anotherLocation.Latitude - this.Latitude);

            var a =
              Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
              Math.Cos(Radians(this.Latitude)) * Math.Cos(Radians(anotherLocation.Latitude)) *
              Math.Sin(dlon / 2) * Math.Sin(dlon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = earthRadiusUnit * c;
            return d;
        }

        private double Radians(double x)
        {
            return x * Math.PI / 180;
        }

        //Validations
        private void ValidateCoordinates(double latitude, double longitude)
        {
            ValidateLatitude(latitude);
            ValidateLongitude(longitude);
        }

        private void ValidateLatitude(double latitude)
        {
            Validator.InRange<InvalidCoordinatesException>(latitude, -90, 90, nameof(this.Latitude));
        }

        private void ValidateLongitude(double longitude)
        {
            Validator.InRange<InvalidCoordinatesException>(longitude, -180, 180, nameof(this.Longitude));
        }

    }
}
