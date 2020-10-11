namespace SecuritySystem.Application.Guards.GuardTasks.Queries.Common
{
    using SecuritySystem.Domain.Common;
    using SecuritySystem.Domain.Guards.Models;
    using SecuritySystem.Domain.Guards.Specifications.GuardTasks;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class GuardTaskQuery
    {
        private const int GuardTasksPerPage = 20;

        public int Page { get; set; }

        public int? GuardPatrolId { get; set; }

        public int? State { get; set; }

        public abstract class GuardTaskQueryHandler
        {
            private readonly IGuardTaskQueryRepository guardTaskQueryRepository;

            protected GuardTaskQueryHandler(IGuardTaskQueryRepository guardTaskQueryRepository)
            {
                this.guardTaskQueryRepository = guardTaskQueryRepository;
            }

            protected async Task<IEnumerable<GuardTask>> GetGuardTaskListings(
                GuardTaskQuery request,
                CancellationToken cancellationToken)
            {
                var specification = this.GetGuardTaskSpecification(request);
                var skip = (request.Page - 1) * GuardTasksPerPage;
                return await this.guardTaskQueryRepository.GetGuardTaskListings(
                    specification,
                    skip,
                    GuardTasksPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                GuardTaskQuery request,
                CancellationToken cancellationToken)
            {
                var specification = this.GetGuardTaskSpecification(request);

                return await this.guardTaskQueryRepository.Total(
                    specification,
                    cancellationToken);
            }

            private Specification<GuardTask> GetGuardTaskSpecification(GuardTaskQuery request)
            {
                return new GuardTaskByStateSpecification(request.State)
                    .And(new GuardTaskByGuardPatrolSpecification(request.GuardPatrolId));
            }
        }
    }
}
