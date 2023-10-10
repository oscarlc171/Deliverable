using System;
using CKK.Logic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CKK.DB.Interfaces
{
    interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetByName(string name);
    }
}
