namespace SecuritySystem.Application.ControlCenter.Commands.Common
{
    using FluentValidation;
    using Application.Common;
    using static Domain.ControlCenter.Models.ModelConstants.AlarmEvent;
    using static Domain.ControlCenter.Models.ModelConstants.Address;
    using static Domain.Common.Models.ModelConstants.Contact;
    using static Domain.Common.Models.ModelConstants.PhoneNumber;
    using static Domain.Common.Models.ModelConstants.GeoCoordinates;
    using SecuritySystem.Domain.Common.Models;
    using SecuritySystem.Domain.ControlCenter.Models;

    public class AlarmEventCommandValidator<TCommand> : AbstractValidator<AlarmEventCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public AlarmEventCommandValidator()
        {      
            this.RuleFor(s => s.SystemId)
                .GreaterThan(0);

            this.RuleFor(s => s.Notes)
                .MinimumLength(MinNotesLength)
                .MaximumLength(MaxNotesLength)
                .NotEmpty();

            this.RuleFor(c => c.ContactName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(s => s.ContactPhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();

            this.RuleFor(s => s.City)
                .MinimumLength(MinCityNameLength)
                .MaximumLength(MaxCityNameLength)
                .NotEmpty();

            this.RuleFor(c => c.StreetInfo)
                .MinimumLength(MinStreetNameLength)
                .MaximumLength(MaxStreetNameLength)
                .NotEmpty();

            this.RuleFor(s => s.Latitude)
                .GreaterThan(MinLatitude)
                .LessThan(MaxLatitude);

            this.RuleFor(s => s.Longtitude)
                .GreaterThan(MinLongtitude)
                .LessThan(MaxLongtitude);

            //this.RuleFor(s => s.EventDateTime)
            //    .NotEmpty();

            //this.RuleFor(c => c.AlarmEventState)
            //    .Must(Enumeration.HasValue<AlarmEventState>)
            //    .WithMessage("'AlarmEventState' is not valid.");

        }
    }
}
