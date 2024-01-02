using StoreApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entities.Models
{
    public class Category :IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
