using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
	public class ShoppingCartItem : InventoryItem
	{
		public ShoppingCartItem(Product product, int quantity)
			: base(product, quantity)
		{
		}

		public Product GetProduct()
		{
			return _product;
		}

		public void SetProduct(Product product)
		{
			_product = product;
		}

		public int GetQuantity()
		{
			return _quantity;
		}

		public void SetQuantity(int quantity)
		{
			_quantity = quantity;
		}

		public decimal GetTotal()
        {
			return _quantity * _product.GetPrice();
        }


	}
}
