using StoreApp.Business.Abstract;
using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreApp.Business.Concrete
{
    public class OrderManager:IOrderService
    {
        private readonly IRepoManager _manager;

        public OrderManager(IRepoManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders =>
        _manager != null && _manager.order != null
        ? _manager.order.Orders : Enumerable.Empty<Order>().AsQueryable();
        




        public int NumberOfInProcess => _manager.order.NumberOfInProcess;

        public void Complete(int id)
        {
            _manager.order.Complete(id);
            _manager.Save();
        }

        public Order? GetOneOrder(int id)
        {
            return _manager.order.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            if (_manager != null )
            {
                _manager.order.SaveOrder(order);
                
            }
            else
            {
               
                Console.WriteLine("Hata: _manager veya _manager.order null.");
            }
        }

    }
}
