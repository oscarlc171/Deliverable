﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    class InventoryItemStockTooLowException : Exception
    {
        public InventoryItemStockTooLowException() : base("Item stock too low")
        {

        }

        public InventoryItemStockTooLowException(string message) : base(message)
        {

        }
    }
}
