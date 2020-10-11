namespace SecuritySystem.Infrastructure.Guards.Services
{
    using SecuritySystem.Domain.Common.Models;
    using SecuritySystem.Domain.Guards.Models;
    using SecuritySystem.Domain.Guards.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LocationGuardPatrolService : ILocationGuardPatrolService
    {
        public Task<GuardPatrol> FindNearestPatrol(GeoCoordinates targetLocation, IEnumerable<GuardPatrol> patrols)
        {
            GuardPatrol result = patrols.FirstOrDefault();
            double minDistanceInMeters = result.GeoLocation.DistanceToInMeters(targetLocation);
            foreach (var guardPatrol in patrols)
            {
                var currentDistanceToTargetInMeters = guardPatrol.GeoLocation.DistanceToInMeters(targetLocation);
                if(currentDistanceToTargetInMeters < minDistanceInMeters)
                {
                    result = guardPatrol;
                    minDistanceInMeters = currentDistanceToTargetInMeters;
                }
            }

            return Task.FromResult(result);
        }
    }
}
