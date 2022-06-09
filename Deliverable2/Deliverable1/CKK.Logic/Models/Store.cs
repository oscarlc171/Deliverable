using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int _id;
        private string _name;
        private List<StoreItem> _items;

        public Store()
        {
            _items = new List<StoreItem>();
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            var existingItem = FindStoreItemById(prod.GetId());
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
                if (_items[i].GetProduct().GetId() == id)
                {
                    return _items[i];
                }
            }
            return null;
        }
    }
}
