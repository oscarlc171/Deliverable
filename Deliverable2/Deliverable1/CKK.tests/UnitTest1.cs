using System;
using Xunit;
using CKK.Logic.Models;

namespace CKK.tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddProductTest()
        {
            try
            {
                ShoppingCart item1 = new ShoppingCart();
                var expected = 3;
                Product expectedProduct = new Product();
                item1.AddProduct(expectedProduct, expected);

                Assert.NotNull(item1);

            } catch
            {
                Console.WriteLine("Error");
            }
        }

        [Fact]
        public void RemoveProductTest()
        {
            try
            {
                ShoppingCart item1 = new ShoppingCart();
                var expected = 3;
                Product expectedProduct = new Product();
                item1.AddProduct(expectedProduct, expected);
                item1.RemoveProduct(expectedProduct, expected);

                Assert.Null(item1);

            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        [Fact]
        public void GetTotalTest()
        {
            try
            {
                ShoppingCart ShoppingCart = new ShoppingCart();
                int quantity1 = 4;
                int quantity2 = 5;
                Product product1 = new Product();
                Product product2 = new Product();
                product1.SetPrice(20);
                product2.SetPrice(30);
                var expected = 4 * 20 + 5 * 30;
                ShoppingCart.AddProduct(product1, quantity1);
                ShoppingCart.AddProduct(product2, quantity2);

                var actual = ShoppingCart.GetTotal();

                Assert.Equal(expected, actual);

                

            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
