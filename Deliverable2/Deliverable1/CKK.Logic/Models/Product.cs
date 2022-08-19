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
        public decimal _price
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

                else
                {
                    _price = value;
                }
            }
        }
    }
}
