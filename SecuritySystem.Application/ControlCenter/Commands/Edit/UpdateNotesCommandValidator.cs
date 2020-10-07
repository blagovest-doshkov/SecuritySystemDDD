namespace SecuritySystem.Application.ControlCenter.Commands.Installation
{
    using FluentValidation;
    using static Domain.ControlCenter.Models.ModelConstants.AlarmEvent;

    public class UpdateNotesCommandValidator : AbstractValidator<UpdateNotesCommand>
    {
        public UpdateNotesCommandValidator()
        {
            this.RuleFor(s => s.Notes)
                .MinimumLength(MinNotesLength)
                .MaximumLength(MaxNotesLength)
                .NotEmpty();
        }
    }
}
