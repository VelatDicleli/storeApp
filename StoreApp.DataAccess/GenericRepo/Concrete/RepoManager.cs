using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.GenericRepo.Absract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.GenericRepo.Concrete
{
    public class RepoManager : IRepoManager
    {

        private RepositoryContext repositoryContext;
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;
        private readonly IOrderDal _orderDal;

        public RepoManager(IProductDal _productDal,RepositoryContext repositoryContext, ICategoryDal categoryDal,IOrderDal orderDal)
        {
            this._productDal = _productDal;
            this.repositoryContext = repositoryContext;
            _categoryDal = categoryDal;
            _orderDal = orderDal;   
        }

        public IProductDal product => _productDal;

        public ICategoryDal category => _categoryDal;

        public IOrderDal order => _orderDal;

        public void Save()
        {
           repositoryContext.SaveChanges();
        }
    }
}
