using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.GenericRepo.Concrete
{
    public class RepoBase<T> : IRepoBase<T> where T : class, IEntity, new()
    {
        readonly protected RepositoryContext _repositoryContext;
        public RepoBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

        }

        public void Add(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
                 ? _repositoryContext.Set<T>()
                 : _repositoryContext.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
        {
            return trackChanges
                ? _repositoryContext.Set<T>().Where(condition).SingleOrDefault() 
                : _repositoryContext.Set<T>().Where(condition).AsNoTracking().SingleOrDefault();
        }

      

        public void RemoveProduct(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
        }
    }
}
