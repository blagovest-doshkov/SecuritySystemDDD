namespace SecuritySystem.Domain.Systems.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models;

    public class AlarmSystemByOwnerSpecification : Specification<AlarmSystem>
    {
        private readonly int? ownerId;

        public AlarmSystemByOwnerSpecification(int? ownerId)
            => this.ownerId = ownerId;

        protected override bool Include => this.ownerId != null;

        public override Expression<Func<AlarmSystem, bool>> ToExpression()
            => dealer => dealer.OwnerId == this.ownerId;
    }
}
