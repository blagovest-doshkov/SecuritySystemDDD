namespace SecuritySystem.Domain.ControlCenter.Exceptions
{
    using Common;

    public class InvalidAlarmEventException : BaseDomainException
    {
        public InvalidAlarmEventException()
        {
        }

        public InvalidAlarmEventException(string error) => this.Error = error;
    }
}
