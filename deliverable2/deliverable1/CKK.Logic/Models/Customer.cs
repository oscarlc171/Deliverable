using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Customer : Entity
    {
        public string _address { get; set; }

        public Customer(int id, string name)
            : base(id, name)
        {
        }
    }

}
