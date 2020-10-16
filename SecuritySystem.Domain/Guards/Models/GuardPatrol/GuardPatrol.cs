namespace SecuritySystem.Domain.Guards.Models
{
    using Exceptions;
    using Common;
    using Common.Models;
    using static ModelConstants.GuardPatrol;
    using System.Collections.Generic;
    using System.Linq;

    public class GuardPatrol: Entity<int>, IAggregateRoot
    {
        private const int MaxAssignedGuardUnits = 2;
        private readonly HashSet<GuardUnit> guardUnits;

        internal GuardPatrol() 
        {
            this.GeoLocation = new GeoCoordinates(DefaultOfficeLatitude, DefaultOfficelongitude);
            this.IsAvailable = false;

            this.guardUnits = new HashSet<GuardUnit>();
        }

        public GeoCoordinates GeoLocation { get; private set; }
        public bool IsAvailable { get; private set; }

        public bool TaskAccepted { get; private set; }

        public IReadOnlyCollection<GuardUnit> GuardUnits => this.guardUnits.ToList().AsReadOnly();

        public void AssignGuardUnit(GuardUnit guardUnit)
        {
            if (this.guardUnits.Count >= 2)
                throw new InvalidGuardUnitException($"Cannot be assigned more than {MaxAssignedGuardUnits}");

            this.guardUnits.Add(guardUnit);
        }

        public GuardPatrol UpdateLocation(GeoCoordinates location)
        {
            ValidateLocation(location);
            this.GeoLocation = location;
            return this;
        }

        public GuardPatrol UpdateLocation(double latitude, double longitude)
        {
            this.GeoLocation = new GeoCoordinates(latitude, longitude);
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
