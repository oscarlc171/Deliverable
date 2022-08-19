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
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> Products { get; set; }
        public ShoppingCart(Customer cust)
        {
            Customer = cust;
            Products = new List<ShoppingCartItem>();
        }
        public int GetCustomerId()
        {
            return Customer.Id;
        }
        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }

            for (int i = 0; i < Products.Count; ++i)
            {
                if (Products[i].Product.Id == id)
                {
                    return Products[i];
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
                Products.Add(newItem);
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
            if (quantity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            var existingItem = GetProductById(id);
            if (existingItem != null)
            {
                if ((existingItem.Quantity - quantity) <= 0)
                {
                    Products.Remove(existingItem);
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
            for (int i = 0; i < Products.Count; ++i)
            {
                grandTotal += Products[i].Product.Price * Products[i].Quantity;
            }
            return grandTotal;
        }
        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }

    }
}
