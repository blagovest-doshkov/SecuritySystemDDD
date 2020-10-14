namespace SecuritySystem.Application.Systems.Commands.Edit
{
    using Common;
    using Application.Common;
    using Domain.Systems.Repositories;
    using MediatR;
    using System.Threading.Tasks;
    using System.Threading;

    public class EditAlarmSystemCommand: AlarmSystemCommand<EditAlarmSystemCommand>, IRequest<Result>
    {
        public class EditAlarmSystemCommandHandler : IRequestHandler<EditAlarmSystemCommand, Result>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;

            public EditAlarmSystemCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
            }

            public async Task<Result> Handle(EditAlarmSystemCommand request, CancellationToken cancellationToken)
            {
                var alarmSystem = await this.alarmSystemDomainRepository
                   .Find(request.Id, cancellationToken);

                alarmSystem
                    .UpdateName(request.Name)
                    .UpdateNotes(request.Notes)
                    .UpdateAddress(
                        request.Country,
                        request.Province,
                        request.City,
                        request.Street,
                        request.Latitude,
                        request.Longitude)
                    .UpdateContactsInfo(
                        request.ContactName,
                        request.ContactPhoneNumber);
                //STATUS UPDATE? NEW DOMAIN?


                await this.alarmSystemDomainRepository.Save(alarmSystem, cancellationToken);

                return Result.Success;
            }
        }
    }
}

