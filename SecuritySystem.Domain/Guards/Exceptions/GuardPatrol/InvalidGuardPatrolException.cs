namespace SecuritySystem.Domain.Guards.Exceptions
{
    using Common;

    public class InvalidGuardPatrolException : BaseDomainException
    {
        public InvalidGuardPatrolException()
        {
        }

        public InvalidGuardPatrolException(string error) => this.Error = error;
    }
}
