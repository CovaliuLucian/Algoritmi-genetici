using System;

namespace Tema_2.Exceptions
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