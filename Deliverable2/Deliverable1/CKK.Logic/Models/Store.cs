using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models 
{
    public class Store : Entity, IStore
    {
        private List<StoreItem> _items = new List<StoreItem>();
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
            }

            var existingItem = FindStoreItemById(prod.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                return existingItem;
            }
            else
            {
                var newItem = new StoreItem(prod, quantity);
                _items.Add(newItem);
                return newItem;
            }
        }    
        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            bool foundItem = false;
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (var item in _items)
            {
                if (item.Product.Id == id)
                {
                    if ((item.Quantity - quantity) <= 0)
                    {
                        item.Quantity = 0;
                    }

                    else
                    {
                        item.Quantity -= quantity;
                    }

                    foundItem = true;
                    return item;
                }
            }

            if (foundItem == false)
            {
                throw new ProductDoesNotExistException();
            }
            return null;
            
        }
        public List<StoreItem> GetStoreItems()
        {
            return _items;
        }
        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }

            else
            {
                foreach (var item in _items)
                {
                    if (item.Product.Id == id)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public List<StoreItem> GetAllProductsByName(string name)
        {
            List<StoreItem> itemsMatch = new List<StoreItem>();
            foreach (var item in _items)
            {
                if (item.Product.Name.Contains(name))
                {
                    itemsMatch.Add(item);
                }
            }

            if (!itemsMatch.Any())
            {
                return null;
            }
            itemsMatch.Sort();
            return itemsMatch;
        }
    }
}

/* var getItemById =
                    from item in _items
                    where item.Product.Id == id
                    select item;
 */

/* 
 foreach (var item in _items)
            {
                if (item.Product.Id == prod.Id)
                {
                    item.Quantity += quantity;
                    return item;
                }

                else
                {
                    var newItem = new StoreItem(prod, quantity);
                    _items.Add(newItem);
                    return newItem;
                }
            }
            return null; 
 */