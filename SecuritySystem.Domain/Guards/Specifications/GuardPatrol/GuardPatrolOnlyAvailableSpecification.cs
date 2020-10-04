namespace SecuritySystem.Domain.Guards.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models;

    public class GuardPatrolOnlyAvailableSpecification : Specification<GuardPatrol>
    {
        private readonly bool onlyAvailable;

        public GuardPatrolOnlyAvailableSpecification(bool onlyAvailable)
        {
            this.onlyAvailable = onlyAvailable;
        }

        public override Expression<Func<GuardPatrol, bool>> ToExpression()
        {
            if (this.onlyAvailable)
            {
                return GuardPatrol => GuardPatrol.IsAvailable;
            }

            return GuardPatrol => true;
        }
    }
}
