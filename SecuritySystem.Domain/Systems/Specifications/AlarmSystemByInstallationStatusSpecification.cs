namespace SecuritySystem.Domain.Systems.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models;

    public class AlarmSystemByInstallationStatusSpecification : Specification<AlarmSystem>
    {
        private readonly bool isInstalled;

        public AlarmSystemByInstallationStatusSpecification(bool isInstalled)
        {
            this.isInstalled = isInstalled;
        }

        public override Expression<Func<AlarmSystem, bool>> ToExpression()
        {
            return alarmSystem => alarmSystem.IsInstalled == this.isInstalled;
        }
    }
}
