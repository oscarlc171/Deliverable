﻿using System;
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
            product = product1;
            Quantity = quantity;
        }

        public Product GetProduct()
        {
            return product1;
        }

        public void SetProduct(Product product)
        {
            product = product1;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int Quantity)
        {
            Quantity = quantity;
        }
    }
}
