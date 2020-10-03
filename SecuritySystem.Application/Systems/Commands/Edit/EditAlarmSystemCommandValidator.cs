namespace SecuritySystem.Application.Systems.Commands.Edit
{
    using FluentValidation;
    using SecuritySystem.Application.Systems.Commands.Common;

    public class EditAlarmSystemCommandValidator : AbstractValidator<EditAlarmSystemCommand>
    {
        EditAlarmSystemCommandValidator()
        {
            this.Include(new AlarmSystemCommandValidator<EditAlarmSystemCommand>());
        }
    }
}
