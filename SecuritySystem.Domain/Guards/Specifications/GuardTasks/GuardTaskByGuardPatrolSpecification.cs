namespace SecuritySystem.Domain.Guards.Specifications.GuardTasks
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models;

    public class GuardTaskByGuardPatrolSpecification : Specification<GuardTask>
    {
        private readonly int? GuardPatrolId;

        public GuardTaskByGuardPatrolSpecification(int? guardPatrolId)
        {
            this.GuardPatrolId = guardPatrolId;       
        }

        protected override bool Include
            => GuardPatrolId != null;


        public override Expression<Func<GuardTask, bool>> ToExpression()
        {
            return guardTask => guardTask.AssignedPatrol.Id == this.GuardPatrolId;
        }
    }
}
