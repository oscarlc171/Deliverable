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
                var getProductById =
                    from product in Products
                    where product.Product.Id == id
                    select product;
            }
            return null;
        }
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
            }

            else
            {
                foreach (var product in Products)
                {
                    if (product.Product == prod)
                    {
                        product.Quantity += quantity;
                        return product;
                    }

                    else
                    {
                        var newProduct = new ShoppingCartItem(prod, quantity);
                        Products.Add(newProduct);
                        return newProduct;
                    }
                }
                return null;
            }
        }
        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            var existingItem = GetProductById(id);
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
                        return product;
                    }

                    else
                    {
                        product.Quantity -= quantity;
                        return product;
                    }
        
                }

                else
                {
                    throw new ProductDoesNotExistException();
                }
            }
            return null;
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
