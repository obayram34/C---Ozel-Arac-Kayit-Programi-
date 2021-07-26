using OtoTakip.DataAccess.Abstract;
using OtoTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {


        public void AddToAracListesis(TEntity entitiy)
        {
            using (TContext context= new TContext())
            {
                var addedEntity = context.Entry(entitiy);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
             
        }

        public void DeleteAracListesis(TEntity entitiy)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entitiy);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList(); 
            }
        }

        public TEntity GetOneAracListesis(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void UpdateAracListesis(TEntity entitiy)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entitiy);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
