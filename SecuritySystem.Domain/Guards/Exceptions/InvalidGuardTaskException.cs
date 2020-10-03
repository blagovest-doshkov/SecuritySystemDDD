namespace SecuritySystem.Domain.Guards.Exceptions
{
    using Common;

    public class InvalidGuardTaskException : BaseDomainException
    {
        public InvalidGuardTaskException()
        {
        }

        public InvalidGuardTaskException(string error) => this.Error = error;

    }
}
