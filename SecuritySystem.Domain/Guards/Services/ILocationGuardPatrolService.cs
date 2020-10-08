namespace SecuritySystem.Domain.Guards.Services
{
    using Common.Models;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationGuardPatrolService
    {
        Task<GuardPatrol> FindNearestPatrol(GeoCoordinates targetLocation, IEnumerable<GuardPatrol> patrols);
    }
}
