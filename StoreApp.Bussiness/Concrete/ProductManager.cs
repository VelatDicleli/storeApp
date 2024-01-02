using AutoMapper;
using StoreApp.Business.Abstract;
using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.Entities.Dtos;
using StoreApp.Entities.Models;
using StoreApp.Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Concrete
{
    public class ProductManager : IProductService
    {   
        private IRepoManager repoManager;
        private IMapper _mapper;

        public ProductManager(IRepoManager repoManager, IMapper _mapper)
        {
            this.repoManager = repoManager;
            this._mapper = _mapper;
        }

        public void Add(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            
            repoManager.product.Add(product);
            repoManager.Save();
        }

        public IEnumerable<ProductDto> GetAllProducts(bool trackChanges)
        {
            var products = repoManager.product.GetAll(trackChanges);

            foreach (var product in products)
            {
                yield return _mapper.Map<ProductDto>(product);
            }
        }

        public IEnumerable<ProductDto> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            var products = repoManager.product.GetAllProductsWithDetails(p);
            
            foreach(var product in products)
            {
                yield return _mapper.Map<ProductDto>(product);
            }
        }

        public Product? GetProductById(int id, bool trackChanges)
        {
            return repoManager.product.GetOneProduct(id,trackChanges);
        }

        public ProductDtoForUpdate GetProductForUpdate(int id, bool v)
        {
            var product = GetProductById(id, v);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IEnumerable<ProductDto> GetShowcaseProduct(bool trackChanges)
        {
            var products = repoManager.product.GetShowcaseProduct(trackChanges);
            
            foreach (var product in products)
            {
                yield return _mapper.Map<ProductDto>(product);
            }
        }

        public void RemoveProduct(int id)
        {
            var model = repoManager.product.GetOneProduct(id, false);
            repoManager.product.Remove(model);
            repoManager.Save();
            
        }

        
        public void Update(ProductDtoForUpdate productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            repoManager.product.UpdateProduct(entity);
            repoManager.Save();
        }
    }
}
