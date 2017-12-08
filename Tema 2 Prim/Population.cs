using System;
using System.Collections.Generic;

namespace Tema_2_Prim
{
    public class Population
    {
        public List<List<string>> ValueList;

        public Population(List<List<string>> valueList)
        {
            ValueList = valueList;
        }

        public Population()
        {
            ValueList = null;
        }

        public void Write()
        {
            //Console.WriteLine(new DeJong1().Calculate(ValueList[0].ToDouble()));
            ValueList.ForEach(x =>
            {
                x.ForEach(b => Console.Write(b.ToDouble() + " "));
                //Console.Write(new DeJong1().Calculate(x.ToDouble()));
                Console.WriteLine();
            });
        }
    }
}