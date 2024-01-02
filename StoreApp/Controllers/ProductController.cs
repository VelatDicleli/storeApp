using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using StoreApp.Entities.Models;
using StoreApp.DataAccess.GenericRepo.Concrete;
using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.Business.Abstract;
using StoreApp.Entities.Dtos;
using StoreApp.Entities.RequestParameters;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private IServiceManager _serviceManager;


        public ProductController(IServiceManager _serviceManager)
        {
            this._serviceManager = _serviceManager;
        }

       public IActionResult Index(ProductRequestParameters p)
        {
            
            var products = _serviceManager.ProductService.GetAllProductsWithDetails(p);


            return View(products);
        }
    
        public IActionResult Detail(int id)
        {

            var model = _serviceManager.ProductService.GetProductById(id,false);
            return View(model);
        }

       


    }
}
