namespace SecuritySystem.Domain.Guards.Exceptions
{
    using Common;

    public class AssigningGuardPatrolException : BaseDomainException
    {
        public AssigningGuardPatrolException()
        {
        }

        public AssigningGuardPatrolException(string error) => this.Error = error;
    }
}
