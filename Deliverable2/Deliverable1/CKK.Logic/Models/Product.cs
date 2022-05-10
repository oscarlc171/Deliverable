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

        public Product(int Id, string Name, decimal Price)
            {
            ID = Id;
            name = Name;
            price = Price;
            }

        public int GetId()
        {
            return ID;
        }

        public void SetId(int id)
        {
            id = ID;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string Name)
        {
            Name = name;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public void SetPrice(decimal Price)
        {
            Price = price;
        }
    }
}
