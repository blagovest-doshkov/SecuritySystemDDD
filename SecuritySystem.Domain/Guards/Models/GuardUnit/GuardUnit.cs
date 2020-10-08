namespace SecuritySystem.Domain.Guards.Models
{
    using Common.Models;
    using Common;
    using Guards.Exceptions;
    using static ModelConstants.GuardUnit;

    public class GuardUnit: Entity<int>, IAggregateRoot
    {
        internal GuardUnit(string userId, string name)
        {
            ValidateUserId(userId);
            ValidateName(name);

            this.UserId = userId;
            this.Name = name;
        }

        public string UserId { get; private set; }
        public string Name { get; private set; }

        private void ValidateName(string name)
        {
            Validator.StringLength<InvalidGuardUnitException>(name, MinNameLength, MaxNameLength, nameof(this.Name));
        }

        private void ValidateUserId(string userId)
        {
            Validator.StringNotEmpty<InvalidGuardUnitException>(userId, nameof(this.UserId));
        }
    }
}
