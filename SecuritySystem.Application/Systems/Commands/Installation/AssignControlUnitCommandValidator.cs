namespace SecuritySystem.Application.Systems.Commands.Installation
{
    using FluentValidation;

    public class AssignControlUnitCommandValidator: AbstractValidator<AssignControlUnitCommand>
    {
        public AssignControlUnitCommandValidator()
        {
            this.RuleFor(a => a.ControlUnitSerialNumber)
                .NotEmpty();
        }
    }
}
