using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Customer
    {
        private int ID;
        private string name;
        private string address;

        public Customer(int id, string Name, string Address)
        {
            ID = id;
            name = Name;
            address = Address;
        }

        public int GetId()
        {
            return ID;
        }

        public void SetId(int id)
        {
            ID = id;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string Name)
        {
            name = Name;
        }

        public string GetAddress()
        {
            return address;
        }
        
        public void SetAddress(string Address)
        {
            address = Address;
        }
    }
}
