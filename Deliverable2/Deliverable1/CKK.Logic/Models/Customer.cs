using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Customer : Entity
    {
        public string _address;
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }
    }


}
