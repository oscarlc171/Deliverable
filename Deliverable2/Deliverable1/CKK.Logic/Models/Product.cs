using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Product
    {
        private int ID;
        private string name;
        private decimal price;

   

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

        public decimal GetPrice()
        {
            return price;
        }

        public void SetPrice(decimal Price)
        {
            price = Price;
        }
    }
}
