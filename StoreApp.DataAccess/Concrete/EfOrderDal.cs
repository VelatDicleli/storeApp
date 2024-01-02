using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.GenericRepo.Concrete;
using StoreApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Concrete
{
    public class EfOrderDal : RepoBase<Order>, IOrderDal
    {
        public EfOrderDal(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        
        public IQueryable<Order> Orders => _repositoryContext.Orders.Include(o => o.Lines)
            .ThenInclude(cl => cl.Product)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId);

        public int NumberOfInProcess =>
          _repositoryContext.Orders.Count(o => o.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = FindByCondition(o => o.OrderId.Equals(id), true);
            if (order is null)
                throw new Exception("Order could not found!");
            order.Shipped = true;
        }

        public Order? GetOneOrder(int id)
        {
            return FindByCondition(o => o.OrderId.Equals(id), false);
        }

        public void SaveOrder(Order order)
        {
            try
            {
                _repositoryContext.AttachRange(order.Lines.Select(l => l.Product));

                if (order.OrderId == 0)
                {
                    _repositoryContext.Orders.Add(order);
                }
                
                _repositoryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
                if (ex is DbUpdateException dbUpdateException)
                {
                    
                    Console.WriteLine("Veritabanı hatası: " + dbUpdateException.InnerException?.Message);
                }
            }
        }


    }
}
