namespace SecuritySystem.Application.Systems.Commands.Create
{
    using FluentValidation;
    using Common;

    public class CreateAlarmSystemCommandValidator : AbstractValidator<CreateAlarmSystemCommand>
    {
        public CreateAlarmSystemCommandValidator()
            => this.Include(new AlarmSystemCommandValidator<CreateAlarmSystemCommand>( ));
    }
}
