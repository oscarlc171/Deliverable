﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class ProductDoesNotExistException : Exception 
    {
        public ProductDoesNotExistException() : base("Product does not exist")
        {

        }

        public ProductDoesNotExistException(string message) : base(message)
        {

        }
    }
}
