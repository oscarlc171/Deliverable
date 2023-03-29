using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    [Serializable]
    abstract public class Entity
    {
        public virtual string Name { get; set; }
        private int id;
        public virtual int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidIdException();
                }
                else
                {
                    id = value;
                }
            }
        }
    }
}
