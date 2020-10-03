namespace SecuritySystem.Domain.Guards.Factories
{
    using Models;

    public class GuardPatroltFactory : IGuardPatrolFactory
    {
        public GuardPatrol Build()
        {
            return new GuardPatrol();
        }
    }

}
