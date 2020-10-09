namespace SecuritySystem.Application.Guards.GuardPatrols.Queries.Common
{
    using SecuritySystem.Domain.Common;
    using SecuritySystem.Domain.Guards.Models;
    using SecuritySystem.Domain.Guards.Specifications;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class GuardPatrolsQuery
    {
        private const int GuardPatrolsPerPage = 20;

        public int Page { get; set; }

        public bool OnlyAvailable { get; set; }

        public abstract class GuardPatrolsQueryHandler
        {
            private readonly IGuardPatrolQueryRepository guardPatrolQueryRepository;

            protected GuardPatrolsQueryHandler(IGuardPatrolQueryRepository guardPatrolQueryRepository)
            {
                this.guardPatrolQueryRepository = guardPatrolQueryRepository;
            }

            protected async Task<IEnumerable<GuardPatrol>> GetGuardPatrolListings(
                GuardPatrolsQuery request,
                CancellationToken cancellationToken)
            {
                var specification = this.GetGuardPatrolSpecification(request);
                var skip = (request.Page - 1) * GuardPatrolsPerPage;
                return await this.guardPatrolQueryRepository.GetGuardPatrolListings(
                    specification,
                    skip,
                    GuardPatrolsPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                GuardPatrolsQuery request,
                CancellationToken cancellationToken)
            {
                var specification = this.GetGuardPatrolSpecification(request);
              
                return await this.guardPatrolQueryRepository.Total(
                    specification,
                    cancellationToken);
            }

            private Specification<GuardPatrol> GetGuardPatrolSpecification(GuardPatrolsQuery request)
            {
                return new GuardPatrolOnlyAvailableSpecification(request.OnlyAvailable);
            }
        }
    }
}
