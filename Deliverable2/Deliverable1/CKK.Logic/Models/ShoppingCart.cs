using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        public Customer _customer { get; set; }
        public List<ShoppingCartItem> _products { get; set; }
        public ShoppingCart(Customer cust)
        {
            _customer = cust;
            _products = new List<ShoppingCartItem>();
        }
        public int GetCustomerId()
        {
            return _customer._id;
        }
        public ShoppingCartItem GetProductById(int id)
        {
            for (int i = 0; i < _products.Count; ++i)
            {
                if (_products[i]._product._id == id)
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
            var existingItem = GetProductById(prod._id);
            if (existingItem == null)
            {
                var newItem = new ShoppingCartItem(prod, quantity);
                _products.Add(newItem);
                return newItem;
            }
            else
            {
                existingItem._quantity += quantity;
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
            if (existingItem != null)
            {
                if ((existingItem._quantity - quantity) <= 0)
                {
                    _products.Remove(existingItem);
                    existingItem._quantity = 0;
                    return existingItem;
                }
                else
                {
                    existingItem._quantity -= quantity;
                    return existingItem;
                }
            }
            else
            {
                return null;
            }
        }
        public decimal GetTotal()
        {
            decimal grandTotal = 0;
            for (int i = 0; i < _products.Count; ++i)
            {
                grandTotal += _products[i]._product._price * _products[i]._quantity;
            }
            return grandTotal;
        }
        public List<ShoppingCartItem> GetProducts()
        {
            return _products;
        }

    }
}
