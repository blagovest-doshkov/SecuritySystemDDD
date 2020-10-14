namespace SecuritySystem.Application.Systems.Commands.Common
{
    using FluentValidation;
    using Application.Common;
    using static Domain.Systems.Models.ModelConstants;
    using static Domain.Common.Models.ModelConstants;

    public class AlarmSystemCommandValidator<TCommand> : AbstractValidator<AlarmSystemCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public AlarmSystemCommandValidator()
        {
            this.RuleFor(s => s.OwnerId)
                .NotEmpty();

            this.RuleFor(s => s.Name)
                .MinimumLength(AlarmSystem.MinNameLength)
                .MaximumLength(AlarmSystem.MaxNameLength)
                .NotEmpty();

            this.RuleFor(s => s.Notes)
                .MinimumLength(AlarmSystem.MinNotesLength)
                .MaximumLength(AlarmSystem.MaxNotesLength)
                .NotEmpty();

            this.RuleFor(c => c.ContactName)
                .MinimumLength(Contact.MinNameLength)
                .MaximumLength(Contact.MaxNameLength)
                .NotEmpty();

            this.RuleFor(s => s.ContactPhoneNumber)
                .MinimumLength(PhoneNumber.MinPhoneNumberLength)
                .MaximumLength(PhoneNumber.MaxPhoneNumberLength)
                .Matches(PhoneNumber.PhoneNumberRegularExpression)
                .NotEmpty();

            this.RuleFor(s => s.Country)
                .MinimumLength(Address.MinCountryNameLength)
                .MaximumLength(Address.MaxCountryNameLength)
                .NotEmpty();

            this.RuleFor(s => s.City)
                .MinimumLength(Address.MinCityNameLength)
                .MaximumLength(Address.MaxCityNameLength)
                .NotEmpty();

            this.RuleFor(s => s.Street)
                .MinimumLength(Address.MinStreetNameLength)
                .MaximumLength(Address.MaxStreetNameLength)
                .NotEmpty();

            this.RuleFor(s => s.Latitude)
                .InclusiveBetween(GeoCoordinates.MinLatitude, GeoCoordinates.MaxLatitude);

            this.RuleFor(s => s.Longitude)
                .InclusiveBetween(GeoCoordinates.Minlongitude, GeoCoordinates.Maxlongitude);

        }
    }
}
