namespace SecuritySystem.Domain.ControlCenter.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models;

    public class AlarmEventBySystemIdSpecification : Specification<AlarmEvent>
    {
        private readonly int? systemId;

        public AlarmEventBySystemIdSpecification(int? systemId)
            => this.systemId = systemId;

        protected override bool Include => this.systemId != null;

        public override Expression<Func<AlarmEvent, bool>> ToExpression()
            => alarmEvent => alarmEvent.SystemId == this.systemId;
    }
}
