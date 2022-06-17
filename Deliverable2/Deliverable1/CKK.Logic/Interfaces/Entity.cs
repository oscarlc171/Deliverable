using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public class Entity
    {
        protected string _name { get; set; }
        protected int _id { get; set; }

        public Entity(string name, int id)
        {
            _name = name;
            _id = id;
        }
    }
}
