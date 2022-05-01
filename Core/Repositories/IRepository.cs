using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetByID(object id);
        IEnumerable<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        TEntity Insert(TEntity entity);
        List<TEntity> Insert(List<TEntity> entity);

        void Delete(object id);
        void Delete(TEntity entityToDelete);
        TEntity Update(TEntity entityToUpdate);

        List<TEntity> GetAll();

    }
}
