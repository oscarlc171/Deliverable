using CKK.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic;
using CKK.Logic.Models;

namespace CKK.Persistance.Models
{
    internal class FileStore : ISavable, ILoadable
    {
        List<StoreItem> Items;
        readonly string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
            Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
        int IdCounter;

        private void CreatePath()
        {
            File.Create(FilePath);
        }
    }
}
