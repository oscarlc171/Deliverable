using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

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
            return _customer.Id;
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }

            for (int i = 0; i < _products.Count; ++i)
            {
                if (_products[i].product.Id == id)
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
                throw new InventoryItemStockTooLowException();
            }

            var existingItem = GetProductById(prod.Id);
            if (existingItem == null)
            {
                var newItem = new ShoppingCartItem(prod, quantity);
                _products.Add(newItem);
                return newItem;
            }

            else
            {
                existingItem.Quantity += quantity;
                return existingItem;
            }

     
        }


        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var existingItem = GetProductById(id);
            if (existingItem != null)
            {
                if ((existingItem.Quantity - quantity) <= 0)
                {
                    _products.Remove(existingItem);
                    existingItem.Quantity = 0;
                    return existingItem;
                }

                else
                {
                    existingItem.Quantity -= quantity;
                    return existingItem;
                }
            }

            else
            {
                throw new ProductDoesNotExistException();
            }



        }

        public decimal GetTotal()
        {
            decimal grandTotal = 0;

            for (int i = 0; i < _products.Count; ++i)
            {
                grandTotal += _products[i].Product.Price * _products[i].Quantity;
            }

            return grandTotal;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return _products;
        }

        

    }
}
