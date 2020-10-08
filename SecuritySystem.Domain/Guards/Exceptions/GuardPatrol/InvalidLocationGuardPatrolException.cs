namespace SecuritySystem.Domain.Guards.Exceptions
{
    using Common;

    public class InvalidLocationGuardPatrolException : BaseDomainException
    {
        public InvalidLocationGuardPatrolException()
        {
        }

        public InvalidLocationGuardPatrolException(string error) => this.Error = error;
    }
}
