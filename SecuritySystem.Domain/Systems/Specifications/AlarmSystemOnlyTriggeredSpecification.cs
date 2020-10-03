namespace SecuritySystem.Domain.Systems.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models;

    public class AlarmSystemOnlyTriggeredSpecification : Specification<AlarmSystem>
    {
        private readonly bool isAlarmTriggered;

        public AlarmSystemOnlyTriggeredSpecification(bool isAlarmTriggered)
        {
            this.isAlarmTriggered = isAlarmTriggered;
        }

        public override Expression<Func<AlarmSystem, bool>> ToExpression()
        {
            if (this.isAlarmTriggered)
            {
                return AlarmSystem => AlarmSystem.AlarmTriggered;
            }

            return AlarmSystem => true;
        }
    }
}
