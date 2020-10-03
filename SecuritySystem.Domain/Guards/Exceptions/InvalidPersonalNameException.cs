namespace SecuritySystem.Domain.Guards.Exceptions
{
    using Common;

    public class InvalidPersonalNameException : BaseDomainException
    {
        public InvalidPersonalNameException()
        {
        }

        public InvalidPersonalNameException(string error) => this.Error = error;
    }
}
