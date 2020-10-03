namespace SecuritySystem.Domain.ControlCenter.Models
{
    using Common.Models;

    public class AlarmEventState : Enumeration
    {
        //public static readonly TaskState PendingPatrolAssignment = new TaskState(1, nameof(PendingPatrolAssignment));
        //public static readonly TaskState Disarmed = new TaskState(2, nameof(InProgress));
        //public static readonly TaskState PatrolArrived = new TaskState(2, nameof(PatrolArrived));
        public static readonly AlarmEventState InProgress = new AlarmEventState(1, nameof(InProgress));
        public static readonly AlarmEventState Handled = new AlarmEventState(2, nameof(Handled));

        private AlarmEventState(int value)
            : this(value, FromValue<AlarmEventState>(value).Name)
        {
        }

        private AlarmEventState(int value, string name)
            : base(value, name)
        {
        }
    }
}
