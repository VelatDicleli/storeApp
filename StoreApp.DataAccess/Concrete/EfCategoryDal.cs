using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.GenericRepo.Concrete;
using StoreApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Concrete
{
    public class EfCategoryDal : RepoBase<Category>, ICategoryDal
    {
        public EfCategoryDal(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
