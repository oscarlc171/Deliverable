using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    abstract public class Entity
    {
        public virtual string _name { get; set; }
        public virtual int _id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id < 0)
                {
                    throw new InvalidIdException();
                }
                else
                {
                    _id = value;
                }
            }
        }
    }
}
