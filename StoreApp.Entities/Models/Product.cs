using StoreApp.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entities.Models
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        
        public string? ProductName { get; set; } = string.Empty;
       
        public decimal Price { get; set; }

        public String? ImageUrl { get; set; }

        public int? CategoryId { get; set; }

        public Category? category { get; set; }
        public bool ShowCase {  get; set; }
    }
}