using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models 
{
    public class Store : Entity
    {
        private List<StoreItem> _items;

        public Store(int id, string name)
            : base(id, name)
        {
            _items = new List<StoreItem>();
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            var existingItem = FindStoreItemById(prod._id);
            if (existingItem != null)
            {
                existingItem.SetQuantity(existingItem.GetQuantity() + quantity);
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
                return null;
            }

            var existingItem = FindStoreItemById(id);
            if (existingItem != null)
            {
                if (existingItem.GetQuantity() - quantity <= 0)
                {
                    existingItem.SetQuantity(0);
                }

                else
                {
                    existingItem.SetQuantity(existingItem.GetQuantity() - quantity);
                }
                
                return existingItem;
            }

            else
            {
                return null;
            }
        }

        public List<StoreItem> GetStoreItems()
        {
            return _items;
        }

        public StoreItem FindStoreItemById(int id)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i]._product._id == id)
                {
                    return _items[i];
                }
            }
            return null;
        }
    }
}
