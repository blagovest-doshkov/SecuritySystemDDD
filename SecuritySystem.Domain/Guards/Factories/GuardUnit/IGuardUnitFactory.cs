namespace SecuritySystem.Domain.Guards.Factories
{
    using Common;
    using Models;

    public interface IGuardUnitFactory : IFactory<GuardUnit>
    {
        IGuardUnitFactory WithUserId(string userId);
        IGuardUnitFactory WithName(string name);
    }

}
