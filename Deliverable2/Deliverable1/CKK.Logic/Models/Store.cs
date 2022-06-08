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
        private List<StoreItem> _items = new List<StoreItem>();

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

            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].GetProduct().GetId() == prod.GetId())
                {
                    _items[i].SetQuantity(_items[i].GetQuantity() + quantity);
                }
                
                else if (_items[i] == null)
                {
                    _items[i] = new StoreItem(prod, quantity);
                }
            }

            return null;
        }    

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }

            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].GetProduct().GetId() == id)
                {
                    _items[i].SetQuantity(_items[i].GetQuantity() - quantity);

                    if (_items[i].GetQuantity() < 0)
                    {
                        _items[i].SetQuantity(0);
                    }

                }
            }

            return null;
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
