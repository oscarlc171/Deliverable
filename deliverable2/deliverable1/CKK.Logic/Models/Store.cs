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
                var findStoreItem =
                  from item in _items
                  where item.Product.Id == id
                  select item;
            }
            return null;
        }
    }
}
