using StoreApp.Entities.Dtos;
using StoreApp.Entities.Models;
using StoreApp.Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Abstract
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts(bool trackChanges);
        Product GetProductById(int id, bool trackChanges);

        void Add(ProductDtoForInsertion productDto);
        void Update(ProductDtoForUpdate productDto);
        void RemoveProduct(int id);
        ProductDtoForUpdate GetProductForUpdate(int id, bool v);
        public IEnumerable<ProductDto> GetShowcaseProduct(bool trackChanges);
        IEnumerable<ProductDto> GetAllProductsWithDetails(ProductRequestParameters p);
    }
}
