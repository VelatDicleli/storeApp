using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Abstract
{
   public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
        IAuthService AuthService { get; }
    }
}
