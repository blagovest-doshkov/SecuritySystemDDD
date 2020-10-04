namespace SecuritySystem.Application.Guards.GuardTasks.Services
{
    using Domain.Common.Models;
    using Domain.Guards.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGuardPatrolLocationService
    {
        Task<GuardPatrol> DeterminateClosestGuardPatrol(IEnumerable<GuardPatrol> availablePatrols, GeoCoordinates targeLocation);
    }
}
