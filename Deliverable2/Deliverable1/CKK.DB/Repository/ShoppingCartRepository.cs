﻿using CKK.DB.Interfaces;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static Dapper.SqlMapper;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ShoppingCartRepository(IConnectionFactory Conn)
        {
            _connectionFactory = Conn;
        }

        public ShoppingCartItem AddToCart(int ShoppingCardId, int ProductId, int quantity)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                ProductRepository _productRepository = new ProductRepository(_connectionFactory);
                var item = _productRepository.GetById(ProductId);
                var ProductItems = GetProducts(ShoppingCardId).Find(x => x.ProductId == ProductId);

                var shopitem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCardId,
                    ProductId = ProductId,
                    Quantity = quantity
                };

                if (item.Quantity >= quantity)
                {
                    if (ProductItems != null)
                    {
                        //Product already in cart so update quantity
                        var test = Update(shopitem);
                    }
                    else
                    {
                        //New product for the cart so add it
                        var test = Add(shopitem);
                    }
                }
                return shopitem;
            }
        }

        public int ClearCart(int shoppingCartId)
        {
            var sql = "DELETE FROM ShoppingCartItems WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, shoppingCartId);
                return result;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            var sql = "SELECT * FROM ShoppingCartItems WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault(sql, new { Id = shoppingCartId });
                return result;
            }
        }

        public decimal GetTotal(int ShoppingCartId)
        {
            var sql = @"SELECT SUM(p.Price) 
                        FROM ShoppingCartItems sci 
                        JOIN Products p on sci.ProductId = p.Id 
                        WHERE sci.Id = @Id;";

            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault(sql, new {Id = ShoppingCartId});
                return result;
            }
        }

        public void Ordered(int shoppingCartId)
        {
            var sql = "DELETE FROM ShoppingCartItems WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, new {Id = shoppingCartId});
            }
        }

        public int Update(ShoppingCartItem entity)
        {
            var sql = "UPDATE ShoppingCartItems SET ShoppingCartId = @ShoppingCartId, ProductId = @ProductId, Quantity = @Quantity WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
           
        public int Add(ShoppingCartItem entity)
        {
            var sql = "INSERT INTO ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@)";
        }
    }
}
