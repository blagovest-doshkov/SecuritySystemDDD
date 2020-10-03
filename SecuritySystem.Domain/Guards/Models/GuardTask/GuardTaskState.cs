namespace SecuritySystem.Domain.Guards.Models
{
    using Common.Models;

    public class GuardTaskState: Enumeration
    {
        //public static readonly TaskState PendingPatrolAssignment = new TaskState(1, nameof(PendingPatrolAssignment));
        //public static readonly TaskState PatrolOnWay = new TaskState(2, nameof(InProgress));
        //public static readonly TaskState PatrolArrived = new TaskState(2, nameof(PatrolArrived));
        public static readonly GuardTaskState InProgress = new GuardTaskState(1, nameof(InProgress));
        public static readonly GuardTaskState Handled = new GuardTaskState(2, nameof(Handled));

        private GuardTaskState(int value)
            : this(value, FromValue<GuardTaskState>(value).Name)
        {
        }

        private GuardTaskState(int value, string name)
            : base(value, name)
        {
        }
    }
}
