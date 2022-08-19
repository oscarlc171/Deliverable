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
        public virtual string Name { get; set; }
        public virtual int Id
        {
            get
            {
                return Id;
            }
            set
            {
                if (Id < 0)
                {
                    throw new InvalidIdException();
                }
                else
                {
                    Id = value;
                }
            }
        }
    }
}
