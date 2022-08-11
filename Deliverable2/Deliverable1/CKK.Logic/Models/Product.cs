using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {
        private decimal _price;

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
