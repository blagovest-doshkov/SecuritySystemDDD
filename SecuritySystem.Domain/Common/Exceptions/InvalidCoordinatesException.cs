namespace SecuritySystem.Domain.Common.Exceptions
{
    public class InvalidCoordinatesException : BaseDomainException
    {
        public InvalidCoordinatesException()
        {
        }

        public InvalidCoordinatesException(string error) => this.Error = error;
    }
}
