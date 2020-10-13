namespace SecuritySystem.Application.Systems.Queries.Common
{
    using SecuritySystem.Application.Systems.Querries;
    using SecuritySystem.Domain.Common;
    using SecuritySystem.Domain.Systems.Models;
    using SecuritySystem.Domain.Systems.Specifications;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class AlarmSystemsQuery
    {
        private const int AlarmSystemsPerPage = 10;
        public int Page { get; set; } = 1;

        public bool? Armed { get; set; }
        public bool? Installed { get; set; }
        public string? OwnerId { get; set; }
        public bool? Triggered { get; set; }

        public abstract class AlarmSystemsQueryHandler
        {
            private readonly IAlarmSystemQueryRepository alarmSystemQueryRepository;

            protected AlarmSystemsQueryHandler(IAlarmSystemQueryRepository alarmSystemQueryRepository)
            {
                this.alarmSystemQueryRepository = alarmSystemQueryRepository;
            }

            protected Task<IEnumerable<AlarmSystem>> GetAlarmSystemListing(
                AlarmSystemsQuery request, 
                CancellationToken cancellationToken = default)
            {
                var alarmSystemSpecification = this.GetAlarmSystemSpecification(request);
                var skip = (request.Page - 1) * AlarmSystemsPerPage;
                return this.alarmSystemQueryRepository.GetAlarmSystemListings(alarmSystemSpecification, skip, take: AlarmSystemsPerPage, cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                AlarmSystemsQuery request,
                CancellationToken cancellationToken = default)
            {
                var alarmSystemSpecification = this.GetAlarmSystemSpecification(request);
                var totalAlarmSystems = await this.alarmSystemQueryRepository.Total(alarmSystemSpecification, cancellationToken);
                return (int)Math.Ceiling((double)totalAlarmSystems / AlarmSystemsPerPage);
            }

            private Specification<AlarmSystem> GetAlarmSystemSpecification(AlarmSystemsQuery request)
            {
                return new AlarmSystemByOwnerSpecification(request.OwnerId)
                    .And(new AlarmSystemByInstallationStatusSpecification(request.Installed))
                    .And(new AlarmSystemByArmStatusSpecification(request.Armed))
                    .And(new AlarmSystemOnlyTriggeredSpecification(request.Triggered));
            }
        }
    }
}
