namespace SecuritySystem.Domain.Guards.Specifications.GuardTasks
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Common.Models;
    using Models;

    public class GuardTaskByStateSpecification : Specification<GuardTask>
    {
        private readonly GuardTaskState State;
        private readonly bool include;

        public GuardTaskByStateSpecification(int? stateId)
        {
            this.State = default!;
            this.include = false;
            if (stateId != null && Enumeration.HasValue<GuardTaskState>((int)stateId))
            {
                this.include = true;
                this.State = Enumeration.FromValue<GuardTaskState>((int)stateId);
            }            
        }
        protected override bool Include
            => include;
        
        public override Expression<Func<GuardTask, bool>> ToExpression()
        {
            return guardTask => guardTask.State == this.State;
        }
    }
}
