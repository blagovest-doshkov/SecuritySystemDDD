namespace SecuritySystem.Domain.Common.Exceptions
{
    public class InvalidContactException : BaseDomainException
    {
        public InvalidContactException()
        {
        }

        public InvalidContactException(string error) => this.Error = error;
    }
}
