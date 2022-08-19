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
        private List<StoreItem> _items;
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity < 1)
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
            if (quantity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            var existingItem = FindStoreItemById(id);
            if (existingItem != null)
            {
                if (existingItem.Quantity - quantity <= 0)
                {
                    existingItem.Quantity = 0;
                }
                else
                {
                    existingItem.Quantity -= quantity;
                }
                
                return existingItem;
            }
            else
            {
                throw new ProductDoesNotExistException();
            }
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

            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].product.Id == id)
                {
                    return _items[i];
                }
            }
            return null;
        }
    }
}
