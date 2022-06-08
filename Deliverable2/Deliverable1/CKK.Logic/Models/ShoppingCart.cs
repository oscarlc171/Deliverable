using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _customer;
        private List<ShoppingCartItem> _products;

        public ShoppingCart(Customer cust)
        {
            _customer = cust;
            _products = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id)
        {
            for (int i = 0; i < _products.Count; ++i)
            {
                if (_products[i].GetProduct().GetId() == id)
                {
                    return _products[i];
                }

            }

            return null;
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            var existingItem = GetProductById(prod.GetId());
            if (existingItem == null)
            {
                var newItem = new ShoppingCartItem(prod, quantity);
                _products.Add(newItem);
                return newItem;
            }

            else
            {
                existingItem.SetQuantity(existingItem.GetQuantity() + quantity);
                return existingItem;
            }

     
        }


        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            var existingItem = GetProductById(id);
            if (existingItem == null)
            {
                return null;
            }

            else
            {
                existingItem.SetQuantity(existingItem.GetQuantity() - quantity);
                if (existingItem.GetQuantity() <= 0)
                {
                    _products.Remove(existingItem);
                }
                return null;
            }



        }

        public decimal GetTotal()
        {
            decimal grandTotal = 0;

            for (int i = 0; i < _products.Count; ++i)
            {
                grandTotal += _products[i].GetProduct().GetPrice();
            }

            return grandTotal;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return _products;
        }

        

    }
}
