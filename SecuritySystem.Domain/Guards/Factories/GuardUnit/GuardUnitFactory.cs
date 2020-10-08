namespace SecuritySystem.Domain.Guards.Factories
{
    using Models;
    using Exceptions;

    public class GuardUnitFactory : IGuardUnitFactory
    {
        private string UserId = default!;
        private string Name = default!;

        private bool UserIdSet = false;
        private bool NameSet = false;

        public IGuardUnitFactory WithUserId(string userId)
        {
            this.UserIdSet = true;
            this.UserId = userId;
            return this;
        }

        public IGuardUnitFactory WithName(string name)
        {
            this.NameSet = true;
            this.Name = name;
            return this;
        }

        public GuardUnit Build()
        {
            if (!UserIdSet || !NameSet)
            {
                throw new InvalidGuardUnitException("UserId and Name must have a value.");
            }

            return new GuardUnit(UserId, Name);
        }
    }

}
