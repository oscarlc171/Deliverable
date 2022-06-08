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
        private List<ShoppingCartItem> _products = new List<ShoppingCartItem>();

        public ShoppingCart(Customer cust)
        {
            _customer = cust;
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

            for (int i = 0; i < _products.Count; ++i)
            {
                if (_products[i].GetProduct().GetId() == prod.GetId())
                {
                    _products[i].SetQuantity(_products[i].GetQuantity() + quantity);
                }

                else if (_products[i] == null)
                {
                    _products[i] = new ShoppingCartItem(prod, quantity);
                }
            }

            return null;
        }


        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            for (int i = 0; i < _products.Count; ++i)
            {
                if (_products[i].GetProduct().GetId() == prod.GetId())
                {
                 _products[i].SetQuantity(_products[i].GetQuantity() - quantity);

                    if (_products[i].GetQuantity() < 0 || _products[i].GetQuantity() == 0)
                    {
                        _products.RemoveAt(i);
                    }

                }
            }
            return null;
            

       
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
