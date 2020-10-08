namespace SecuritySystem.Domain.Guards.Exceptions
{
    using Common;
    public class InvalidGuardUnitException : BaseDomainException
    {
        public InvalidGuardUnitException()
        {
        }

        public InvalidGuardUnitException(string error) => this.Error = error;
    }
}
