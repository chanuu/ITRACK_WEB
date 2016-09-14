using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ITRACK.EntityFramework.Repositories
{
    public abstract class ITRACKRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ITRACKDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ITRACKRepositoryBase(IDbContextProvider<ITRACKDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ITRACKRepositoryBase<TEntity> : ITRACKRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ITRACKRepositoryBase(IDbContextProvider<ITRACKDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
