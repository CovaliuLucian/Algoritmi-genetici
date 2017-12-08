using System;

namespace Tema_2_Prim.Exceptions
{
    public class InvalidArgsException : Exception
    {
        public InvalidArgsException(string message):base(message)
        {

        }

        public InvalidArgsException()
        {

        }
    }
}