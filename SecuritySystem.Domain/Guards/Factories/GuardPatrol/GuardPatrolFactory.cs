namespace SecuritySystem.Domain.Guards.Factories
{
    using Models;

    public class GuardPatrolFactory : IGuardPatrolFactory
    {
        public GuardPatrol Build()
        {
            return new GuardPatrol();
        }
    }

}
