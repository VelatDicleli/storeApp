using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.Extension;
using StoreApp.DataAccess.GenericRepo.Concrete;
using StoreApp.Entities.Models;
using StoreApp.Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Concrete
{
    public class EfProductDal : RepoBase<Product>, IProductDal
    {
        public EfProductDal(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<Product> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
        }

        public void Create(Product product)
        {
             Add(product);
        }

        public void Remove(Product product)
        {
            RemoveProduct(product);

        }

        public void UpdateProduct(Product entity)
        {
             Update(entity);
        }

        public IQueryable<Product> GetShowcaseProduct(bool trackChanges)
        {
            return FindAll(trackChanges).Where(p=>p.ShowCase.Equals(true));
        }

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _repositoryContext
                .Products
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.searchTerm)
                .FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice);
        }
    }
}
