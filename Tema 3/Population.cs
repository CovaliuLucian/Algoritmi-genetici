using System;
using System.Collections.Generic;
using System.IO;
using Tema_3.Exceptions;

namespace Tema_3
{
    public class Population
    {
        public static int[,] Adjacency;
        public static int ValidColors, Vertices;
        public List<List<int>> ValueList;

        public Population()
        {
            ValueList = null;
            Read();
            ValidColors = Vertices - 1;
        }

        private static void Read()
        {
            var lines = File.ReadLines("input.txt");
            foreach (var line in lines)
            {
                if (line.StartsWith("c"))
                    continue;
                if (line.StartsWith("p edge"))
                {
                    var split = line.Split(' ');
                    Vertices = Convert.ToInt32(split[3]);
                    Adjacency = new int[Vertices+1, Vertices+1];
                }
                else if (line.StartsWith("e"))
                {
                    var split = line.Split(' ');
                    Adjacency[Convert.ToInt32(split[1]), Convert.ToInt32(split[2])] = 1;
                    Adjacency[Convert.ToInt32(split[2]), Convert.ToInt32(split[1])] = 1;
                }
                else
                {
                    throw new InvalidFormatException();
                }
            }
        }

        public void WriteAdjacency()
        {
            for (var i = 1; i <= Vertices; i++)
            {
                for (var j = 1; j <= Vertices; j++)
                    Console.Write(Adjacency[i, j] + " ");
                Console.WriteLine();
            }
        }

        public void WriteValueList()
        {
            foreach (var list in ValueList)
            {
                foreach (var i in list)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
    }
}