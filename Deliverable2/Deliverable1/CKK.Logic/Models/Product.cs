using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {
        public decimal _price { get; set; }

        public Product(decimal price, string name, int id)
            : base(name, id)
        {
            _price = price;
        }

    }
}
