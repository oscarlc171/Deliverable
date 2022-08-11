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
        private string _name;
        private int _id;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Id
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
            }
        }

    }
}
