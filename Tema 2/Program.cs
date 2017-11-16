using System;

namespace Tema_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToString(-2, 2));
            Console.Write(Convert.ToString(2, 2).PadLeft(32, '0'));
        }
    }
}