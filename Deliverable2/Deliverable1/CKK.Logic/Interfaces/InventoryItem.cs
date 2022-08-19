using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    abstract public class InventoryItem
    {
        private int _quantity;
        private Product _product;

        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                if (value < 0)
                {
                    throw new InventoryItemStockTooLowException();
                }

                else
                {
                    _quantity = value;
                }
            }
        }

        public Product Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
            }
        }

    }
}
