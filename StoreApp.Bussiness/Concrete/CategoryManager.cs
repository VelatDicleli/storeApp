using StoreApp.Business.Abstract;
using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {   
        private IRepoManager repoManager;
        public CategoryManager(IRepoManager repoManager)
        {
            this.repoManager = repoManager;
        }
        public IEnumerable<Category> GetCategories(bool trackChanges)
        {
            return repoManager.category.FindAll(trackChanges);
        }
    }
}
