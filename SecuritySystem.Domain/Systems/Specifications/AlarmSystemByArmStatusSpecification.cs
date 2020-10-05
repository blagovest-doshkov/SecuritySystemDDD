namespace SecuritySystem.Domain.Systems.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models;

    public class AlarmSystemByArmStatusSpecification : Specification<AlarmSystem>
    {
        private readonly bool? isArmed;

        public AlarmSystemByArmStatusSpecification(bool? isArmed)
        {
            this.isArmed = isArmed;
        }
        protected override bool Include => this.isArmed != null;

        public override Expression<Func<AlarmSystem, bool>> ToExpression()
        {
            return alarmSystem => alarmSystem.IsArmed == this.isArmed;
        }
    }
}
