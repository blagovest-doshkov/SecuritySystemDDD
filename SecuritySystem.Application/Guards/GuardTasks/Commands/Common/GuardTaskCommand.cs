namespace SecuritySystem.Application.Guards.GuardTasks.Common
{
    using Application.Common;
    using System;

    public abstract class GuardTaskCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int EventId { get; set; } = default!;
        public DateTime EventDateTime { get; set; } = default!;
        public int GuardTaskState { get; set; } = default!;
    }
}
