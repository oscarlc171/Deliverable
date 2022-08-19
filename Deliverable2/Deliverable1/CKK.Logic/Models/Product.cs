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
        public decimal Price
        {
            get
            {
                return Price;
            }

            set
            {
                if (Price < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                else
                {
                    Price = value;
                }
            }
        }
    }
}
