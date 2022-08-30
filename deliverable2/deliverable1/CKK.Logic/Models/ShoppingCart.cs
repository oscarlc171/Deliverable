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

            else
            {
                foreach (var product in Products)
                {
                    if (product.Product.Id == id)
                    {
                        return product;
                    }
                }
            }
            return null;
        }
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity <= 0)
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
            bool foundItem = false;
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (var product in Products)
            {
                if (product.Product.Id == id)
                {
                    if ((product.Quantity - quantity) <= 0)
                    {
                        product.Quantity = 0;
                        Products.Remove(product);
                        foundItem = true;
                        return product;
                    }

                    else
                    {
                        product.Quantity -= quantity;
                        foundItem = true;
                        return product;
                    }
                }
            }

            if (foundItem == false)
            {
                throw new ProductDoesNotExistException();
            }

            return null;
        }
        public decimal GetTotal()
        {
            decimal grandTotal = 0;
            foreach (var product in Products)
            {
                grandTotal += product.Quantity * product.Product.Price;
            }
            return grandTotal;
        }
        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }

    }
}
