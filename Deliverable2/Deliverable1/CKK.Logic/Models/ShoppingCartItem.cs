using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
	public class ShoppingCartItem
	{
		private Product product1;
		private int quantity;

		public ShoppingCartItem(Product product, int Quantity)
		{
			product1 = product;
			quantity = Quantity;
		}

		public Product GetProduct()
		{
			return product1;
		}

		public void SetProduct(Product product)
		{
			product = product1;
		}

		public int GetQuantity()
		{
			return quantity;
		}

		public void SetQuantity(int Quantity)
		{
			Quantity = quantity;
		}

		public decimal GetTotal()
        {
			return quantity * product1.GetPrice();
        }


	}
}
