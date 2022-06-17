using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    abstract public class Entity
    {
        public virtual string _name { get; set; }
        public virtual int _id { get; set; }
    }
}
