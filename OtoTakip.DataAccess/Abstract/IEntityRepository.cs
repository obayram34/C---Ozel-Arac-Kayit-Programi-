using OtoTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.DataAccess.Abstract
{
   public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T GetOneAracListesis(Expression<Func<T, bool>> filter);

        void AddToAracListesis(T entitiy);

        void UpdateAracListesis(T entitiy);

        void DeleteAracListesis(T entitiy);
    }
}
