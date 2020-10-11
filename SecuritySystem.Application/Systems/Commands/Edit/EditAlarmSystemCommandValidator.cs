namespace SecuritySystem.Application.Systems.Commands.Edit
{
    using FluentValidation;
    using SecuritySystem.Application.Systems.Commands.Common;

    public class EditAlarmSystemCommandValidator : AbstractValidator<EditAlarmSystemCommand>
    {
        public EditAlarmSystemCommandValidator()
        {
            this.Include(new AlarmSystemCommandValidator<EditAlarmSystemCommand>());
        }
    }
}
