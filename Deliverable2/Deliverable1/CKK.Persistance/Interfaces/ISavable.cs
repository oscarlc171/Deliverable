﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CKK.Persistance.Interfaces
{
    internal interface ISavable
    {
        public void Save();
        
    }
}
