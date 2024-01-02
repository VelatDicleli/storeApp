using StoreApp.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {   
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IOrderService _orderService;
        private IAuthService _authService;
        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService,IAuthService authService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            _orderService = orderService;
            _authService = authService;
        }
        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;
    }
}
