using StoreApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.GenericRepo.Absract
{
    public interface IRepoBase<T> where T : class, IEntity, new()
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges);

        void Add(T entity);
        void RemoveProduct(T entity);

        void Update(T entity);

    }

}
