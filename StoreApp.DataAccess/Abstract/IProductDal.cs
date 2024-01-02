using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.Entities.Models;
using StoreApp.Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Abstract
{
    public interface IProductDal : IRepoBase<Product>
    {
        IQueryable<Product> GetAll(bool trackChanges);
        IQueryable<Product> GetShowcaseProduct(bool trackChanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);

        Product? GetOneProduct(int id, bool trackChanges);

        void Create(Product product);
        void Remove(Product product);
        void UpdateProduct(Product entity);
    }
}
