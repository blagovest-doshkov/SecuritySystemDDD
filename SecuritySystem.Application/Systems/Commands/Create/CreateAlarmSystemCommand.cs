namespace SecuritySystem.Application.Systems.Commands.Create
{
    using Common;
    using MediatR;
    using Domain.Systems.Repositories;
    using Domain.Systems.Factories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateAlarmSystemCommand : AlarmSystemCommand<CreateAlarmSystemCommand>, IRequest<CreateAlarmSystemOutputModel>
    {
        public class CreateCarAdCommandHandler : IRequestHandler<CreateAlarmSystemCommand, CreateAlarmSystemOutputModel>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;
            private readonly IAlarmSystemFactory alarmSystemFactory;

            public CreateCarAdCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository,
                IAlarmSystemFactory alarmSystemFactory)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
                this.alarmSystemFactory = alarmSystemFactory;
            }

            public async Task<CreateAlarmSystemOutputModel> Handle(
                CreateAlarmSystemCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmSystem = this.alarmSystemFactory
                    .WithUserId(request.OwnerId)
                    .WithName(request.Name)
                    .WithNotes(request.Notes)
                    .WithAddress(
                        request.Country,
                        request.Province,
                        request.City,
                        request.Street,
                        request.Latitude,
                        request.Longitude)
                    .WithContact(
                        request.ContactName,
                        request.ContactPhoneNumber)
                    .Build();


                await this.alarmSystemDomainRepository.Save(alarmSystem, cancellationToken);

                return new CreateAlarmSystemOutputModel(alarmSystem.Id);
            }
        }
    }
}
