namespace SecuritySystem.Domain.ControlCenter.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Common.Models;
    using Models;

    public class AlarmEventByStateSpecification : Specification<AlarmEvent>
    {
        private readonly AlarmEventState State;
        private readonly bool include;

        public AlarmEventByStateSpecification(int? stateId)
        {
            this.State = default!;
            this.include = false;
            if (stateId != null && Enumeration.HasValue<AlarmEventState>((int)stateId))
            {
                this.include = true;
                this.State = Enumeration.FromValue<AlarmEventState>((int)stateId);
            }            
        }
        protected override bool Include
            => include;
        
        public override Expression<Func<AlarmEvent, bool>> ToExpression()
        {
            return alarmEvent => alarmEvent.State.Value == this.State.Value;
        }
    }
}
