using CKK.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic;
using CKK.Logic.Models;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System.Runtime.Serialization.Formatters.Binary;

namespace CKK.Persistance.Models
{
    internal class FileStore : IStore, ISavable, ILoadable
    {
        private List<StoreItem> Items;
        readonly string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
            Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
        private int IdCounter;


        private void CreatePath()
        {
            File.Create(FilePath);
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (Stream sw = new FileStream(FilePath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(sw))
                {
                    formatter.Serialize(sw, Items);
                    writer.Write(Items);
                    writer.Close();
                    sw.Close();
                }
                
                
            }
        }

        public void Load()
        {
            var reader = new BinaryFormatter();
             
            FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read);
            
            using(StreamReader sr = new StreamReader(FilePath))
            {
                List<StoreItem> items = new List<StoreItem>();

                items.Add((StoreItem)reader.Deserialize(fileStream));
                Items = items;
                sr.Close();
            }
            

        }

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
                Items.Add(newItem);
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

            foreach (var item in Items)
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
            return Items;
        }

        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }

            else
            {
                foreach (var item in Items)
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
            foreach (var item in Items)
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

        public List<StoreItem> GetProductsByQuantity()
        {
            bool sorted = false;
            int count = Items.Count;

            while (!sorted)
            {
                sorted = true;
                for (var i = 0; i < count; i++)
                {
                    try
                    {
                        if (Items[i].Quantity > Items[i + 1].Quantity)
                        {
                            int j = Items[i].Quantity;
                            Items[i].Quantity = Items[i + 1].Quantity;
                            Items[i + 1].Quantity = j;
                            sorted = false;
                        }
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            }
            return Items;
        }

        public List<StoreItem> GetProductsByPrice()
        {
            bool sorted = false;
            int count = Items.Count;

            while (!sorted)
            {
                sorted = true;
                for (var i = 0; i < count; i++)
                {
                    try
                    {
                        if (Items[i].Product.Price > Items[i + 1].Product.Price)
                        {
                            decimal j = Items[i].Product.Price;
                            Items[i].Product.Price = Items[i + 1].Product.Price;
                            Items[i + 1].Product.Price = j;
                            sorted = false;
                        }
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            }
            return Items;
        }
    }
}
