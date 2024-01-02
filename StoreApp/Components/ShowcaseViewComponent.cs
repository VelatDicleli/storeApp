using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;

namespace StoreApp.Components
{
    public class ShowcaseViewComponent:ViewComponent
    {
        private readonly IServiceManager serviceManager;

        public ShowcaseViewComponent(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var products = serviceManager.ProductService.GetShowcaseProduct(false);
            

            return View(products);
        }
    }
}
