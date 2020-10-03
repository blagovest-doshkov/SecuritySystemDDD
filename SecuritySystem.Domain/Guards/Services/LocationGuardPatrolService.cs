namespace SecuritySystem.Domain.Guards.Services
{
    using Common.Models;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class LocationGuardPatrolService
    {
        GuardPatrol FindClosestPatrol(GeoCoordinates targeLocation, IEnumerable<GuardPatrol> patrols)
        {
            var minDistance = patrols.Min(gp => gp.GeoLocation.DistanceToInMeters(targeLocation));
            return patrols.FirstOrDefault(gp => gp.GeoLocation.DistanceToInMeters(targeLocation) == minDistance);

        }
    }
}
