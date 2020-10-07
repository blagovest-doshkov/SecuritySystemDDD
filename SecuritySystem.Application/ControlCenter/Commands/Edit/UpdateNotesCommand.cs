namespace SecuritySystem.Application.ControlCenter.Commands.Installation
{
    using Application.Common;
    using MediatR;
    using Domain.ControlCenter.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateNotesCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Notes  { get; private set; } = default!;

        public class UpdateNotesCommandHandler : IRequestHandler<UpdateNotesCommand, Result>
        {
            private readonly IAlarmEventDomainRepository alarmEventDomainRepository;

            public UpdateNotesCommandHandler(
                IAlarmEventDomainRepository alarmEventDomainRepository)
            {
                this.alarmEventDomainRepository = alarmEventDomainRepository;
            }

            public async Task<Result> Handle(
                UpdateNotesCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmEvent = await this.alarmEventDomainRepository
                    .Find(request.Id, cancellationToken);

                alarmEvent.UpdateNotes(request.Notes);

                await this.alarmEventDomainRepository.Save(alarmEvent, cancellationToken);

                return Result.Success;
            }
        }
    }
}
