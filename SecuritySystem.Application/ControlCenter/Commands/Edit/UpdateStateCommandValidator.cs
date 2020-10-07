namespace SecuritySystem.Application.ControlCenter.Commands.Installation
{
    using FluentValidation;
    using SecuritySystem.Domain.Common.Models;
    using SecuritySystem.Domain.ControlCenter.Models;

    public class UpdateStateCommandValidator : AbstractValidator<UpdateStateCommand>
    {
        public UpdateStateCommandValidator()
        {
            this.RuleFor(r => r.Id)
                .GreaterThan(0);

            this.RuleFor(s => s.State)
                .Must(Enumeration.HasValue<AlarmEventState>)
                .WithMessage("'AlarmEventState' is not valid.");
        }
    }
}
