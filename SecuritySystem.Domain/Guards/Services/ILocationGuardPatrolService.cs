namespace SecuritySystem.Domain.Guards.Services
{
    using Common.Models;
    using Models;
    using System.Collections.Generic;

    public interface ILocationGuardPatrolService
    {
        GuardPatrol FindClosestPatrol(GeoCoordinates targeLocation, IEnumerable<GuardPatrol> patrols);
    }
}
