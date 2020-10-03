namespace SecuritySystem.Domain.Systems.Exceptions
{
    using Common;

    public class InvalidAlarmSystemException : BaseDomainException
    {
        public InvalidAlarmSystemException()
        {
        }

        public InvalidAlarmSystemException(string error) => this.Error = error;
    }
}
