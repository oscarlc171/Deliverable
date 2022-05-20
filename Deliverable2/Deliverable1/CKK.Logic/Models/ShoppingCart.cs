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
            if (quantity < 1)
            {
                return null;
            }

            if (_product1 == null)
            {
                ShoppingCartItem _product1 = new ShoppingCartItem(prod, quantity);
                return _product1;
            }

            else if (_product2 == null)
            {
                ShoppingCartItem _product2 = new ShoppingCartItem(prod, quantity);
                return _product2;
            }

            else if (_product3 == null)
            {
                ShoppingCartItem _product3 = new ShoppingCartItem(prod, quantity);
                return _product3;
            }

            if (_product1 != null && _product1.GetProduct().GetId() == prod.GetId())
            {
                _product1.SetQuantity(_product1.GetQuantity() + quantity);
                return _product1;
            }

            if (_product2 != null && _product2.GetProduct().GetId() == prod.GetId())
            {
                _product2.SetQuantity(_product2.GetQuantity() + quantity);
                return _product2;
            }

            if (_product3 != null && _product3.GetProduct().GetId() == prod.GetId())
            {
                _product3.SetQuantity(_product3.GetQuantity() + quantity);
                return _product3;
            }

            return null;

        }
        
        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            if (_product1 != null && _product1.GetProduct().GetId() == prod.GetId())
            {
                _product1.SetQuantity(_product1.GetQuantity() - quantity);
                return _product1;
            }

            if (_product2 != null && _product2.GetProduct().GetId() == prod.GetId())
            {
                _product2.SetQuantity(_product2.GetQuantity() - quantity);
                return _product2;
            }

            if (_product2 != null && _product2.GetProduct().GetId() == prod.GetId())
            {
                _product3.SetQuantity(_product3.GetQuantity() - quantity);
                return _product3;
            }

            else
            {
                return null;
            }
        }

        public decimal GetTotal()
        {
            decimal grandTotal = 0;

            if (_product1 != null)
            {
                grandTotal += _product1.GetTotal();
            }

            if (_product2 != null)
            {
                grandTotal += _product2.GetTotal();
            }
            if (_product3 != null)
            {
                grandTotal += _product3.GetTotal();
            }

            return grandTotal;
        }

        public ShoppingCartItem GetProduct(int prodNum)
        {
            if (prodNum == 1)
            {
                return _product1;
            }

            if (prodNum == 2)
            {
                return _product2;
            }

            if (prodNum == 3)
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
