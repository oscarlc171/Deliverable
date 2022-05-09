using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    class Store
    {
        private int ID;
        private string name;
        private Product product1;
        private Product product2;
        private Product product3;

        public int GetId()
        {
            return ID;
        }

        public void SetId(int Id)
        {
            Id = ID;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string Name)
        {
            Name = name;
        }

        

    }

}
