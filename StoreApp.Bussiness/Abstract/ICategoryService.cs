using StoreApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(bool trackChanges);

    }
}
