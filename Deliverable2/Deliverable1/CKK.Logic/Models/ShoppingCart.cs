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
        private ShoppingCartItem _product1;
        private ShoppingCartItem _product2;
        private ShoppingCartItem _product3;

        public ShoppingCart(Customer cust)
        {
            _customer = cust;
        }

        public ShoppingCart()
        {
        }

        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (id == _product1.GetProduct().GetId())
            {
                return _product1;
            }

            else if (id == _product2.GetProduct().GetId())
            {
                return _product2;
            }

            else if (id == _product3.GetProduct().GetId())
            {
                return _product3;
            }

            else
            {
                return null;
            }
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity < 0)
            {
                return null;
            }

            if (_product1 == null)
            {
                _product1.SetProduct(prod);
                _product1.SetQuantity(quantity);
                return _product1;
            }

            else if (_product2 == null)
            {
                _product2.SetProduct(prod);
                _product2.SetQuantity(quantity);
                return _product2;
            }

            else if (_product3 == null)
            {
                _product3.SetProduct(prod);
                _product3.SetQuantity(quantity);
                return _product3;
            }

            else
            {
                return null;
            }

        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if (quantity < 0)
            {
                return null;
            }

            if (_product1 != null)
            {
                _product1 = null;
                return _product1;
            }

            else if (_product2 != null)
            {
                _product2 = null;
                return _product2;
            }

            else if (_product3 != null)
            {
                _product3 = null;
                return _product3;
            }

            else
            {
                return null;
            }
        }

        public decimal GetTotal()
        {
            return _product1.GetTotal() + _product2.GetTotal() + _product3.GetTotal();
        }

        public ShoppingCartItem GetProduct(int prodNum)
        {
            if (prodNum == 1)
            {
                return _product1;
            }

            else if (prodNum == 2)
            {
                return _product2;
            }

            else if (prodNum == 3)
            {
                return _product3;
            }

            else
            {
                return null;
            }
        }

        

    }
}
