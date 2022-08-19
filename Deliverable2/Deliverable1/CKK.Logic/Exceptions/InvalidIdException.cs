using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    class InvalidIdException : Exception
    {
        public InvalidIdException() : base("Invalid Id number")
        {

        }

        public InvalidIdException(string message) : base(message)
        {

        }
    }


}
