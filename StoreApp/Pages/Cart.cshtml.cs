using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Business.Abstract;
using StoreApp.Entities.Models;
using StoreApp.Infrastructer.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _services; //IOC
        public Cart cart { get; set; } //IOC
        public string ReturnUrl { get; set; } = "/";


        public CartModel(IServiceManager _services,Cart cart)
        {
            this._services = _services;
            this.cart = cart;
        }

        public void OnGet(string returnUrl)
        {
            //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            ReturnUrl = returnUrl ?? "/";
            
        }

        
        public IActionResult OnPost(int productId , string returnUrl)
        {
            Product? product = _services
                .ProductService
                .GetProductById(productId, false);

            if(product != null)
            {
                //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", cart);
            }
            return RedirectToPage(new { returnUrl=returnUrl });
        }

        public IActionResult OnPostRemove(int id , string returnUrl)
        {
            //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.RemoveLine(cart.Lines.First(x => x.Product.ProductId == id).Product);
            //HttpContext.Session.SetJson<Cart>("cart", cart);
            return Page();
        }
    }
}
