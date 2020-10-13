namespace SecuritySystem.Domain.Systems.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models;

    public class AlarmSystemByOwnerSpecification : Specification<AlarmSystem>
    {
        private readonly string? ownerId;

        public AlarmSystemByOwnerSpecification(string? ownerId)
            => this.ownerId = ownerId;

        protected override bool Include => this.ownerId != null;

        public override Expression<Func<AlarmSystem, bool>> ToExpression()
            => dealer => dealer.OwnerId == this.ownerId;
    }
}
