namespace SecuritySystem.Domain.Guards.Models
{
    using Exceptions;
    using Common;
    using Common.Models;
    using static ModelConstants.GuardPatrol;

    public class GuardPatrol: Entity<int>, IAggregateRoot
    {
        internal GuardPatrol() 
        {
            this.GeoLocation = new GeoCoordinates(DefaultOfficeLatitude, DefaultOfficeLongtitude);
            this.IsAvailable = false;
        }

        public GeoCoordinates GeoLocation { get; private set; }
        public bool IsAvailable { get; private set; }

        public GuardPatrol UpdateLocation(GeoCoordinates location)
        {
            ValidateLocation(location);
            this.GeoLocation = location;
            return this;
        }

        public GuardPatrol SetAvailabilityTo(bool state)
        {
            this.IsAvailable = state;
            return this;
        }

        //Validations
        private void ValidateLocation(GeoCoordinates location)
        {
            Validator.IsNotNull<InvalidLocationGuardPatrolException>(location, nameof(this.GeoLocation));
        }
    }
}
