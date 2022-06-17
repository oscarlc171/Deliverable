using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    public class InventoryItem
    {
        public virtual int _quantity { get; set; }
        public virtual Product _product { get; set; }

        public InventoryItem(Product product, int quantity)
        {
            _quantity = quantity;
            _product = product;
        }
    }
}
