﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public class Entity
    {
        public virtual string _name { get; set; }
        public virtual int _id { get; set; }

        public Entity(int id, string name)
        {
            _name = name;
            _id = id;
        }
    }
}
