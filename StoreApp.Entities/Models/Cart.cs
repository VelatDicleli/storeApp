using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();    
        }

        public virtual void AddItem(Product product,int quantity)
        {
            CartLine? line = Lines.Where(p=>p.Product.ProductId == product.ProductId).FirstOrDefault();

            if(line!=null)
            {
                line.Quantity += quantity;

            }
            else
            {
                Lines.Add(new CartLine()
                { Product=product,
                  Quantity=quantity}
                );
            }
        }

        public virtual void RemoveLine(Product product) => Lines.RemoveAll(p=>p.Product.ProductId==product.ProductId);

        public virtual decimal TotalValue()=>Lines.Sum(p=>p.Product.Price*p.Quantity);

        public virtual void Clear()=> Lines.Clear();
        
    }
}
