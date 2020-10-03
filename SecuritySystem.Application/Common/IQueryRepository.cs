namespace SecuritySystem.Application.Common
{
    using Domain.Common;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}