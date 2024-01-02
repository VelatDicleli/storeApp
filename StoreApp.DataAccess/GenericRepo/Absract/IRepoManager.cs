using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.DataAccess.Abstract;

namespace StoreApp.DataAccess.GenericRepo.Absract
{
    public interface IRepoManager
    {
        IProductDal product { get; }

        ICategoryDal category { get; }

        IOrderDal order { get; }
        
        void Save();
    }
}
