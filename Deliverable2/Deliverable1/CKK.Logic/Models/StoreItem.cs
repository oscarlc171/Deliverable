using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class StoreItem
    {
        private Product product1;
        private int quantity;

        public StoreItem(Product product, int Quantity)
        {
            product1 = product;
            quantity = Quantity;
        }

        public Product GetProduct()
        {
            return product1;
        }

        public void SetProduct(Product product)
        {
            product1 = product;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int Quantity)
        {
            quantity = Quantity;
        }
    }
}
