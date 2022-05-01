using Core.DB;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
namespace Core.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        ShopContext context;
        DbSet<TEntity> dbSet;

        public Repository(ShopContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Filter(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public List<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        //https://stackoverflow.com/questions/50987635/the-instance-of-entity-type-item-cannot-be-tracked-because-another-instance-wi
        public virtual TEntity Update(TEntity entityToUpdate)
        {
            var entry = dbSet.First(s => s.Id == entityToUpdate.Id);
            context.Entry(entry).CurrentValues.SetValues(entityToUpdate);
            context.SaveChanges();
            return entityToUpdate;
        }

        public List<TEntity> Insert(List<TEntity> entity)
        {
            dbSet.AddRange(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
