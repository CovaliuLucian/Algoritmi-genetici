using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;
using Tema_3.Exceptions;

namespace Tema_3
{
    public class Population
    {
        public static int[,] Adjacency;
        public static int ValidColors, Vertices;
        public static int Size;
        public List<List<int>> ValueList;

        private static bool _firstInit = true;

        public Population(int s)
        {
            if (_firstInit)
            {
                Size = s;
                Read();
                ValidColors = Vertices - 1;
            }
            _firstInit = false;
        }

        public Population()
        {
            ValueList = null;
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
                    Vertices = Convert.ToInt32(split[2]);
                    Adjacency = new int[Vertices, Vertices];
                }
                else if (line.StartsWith("e"))
                {
                    var split = line.Split(' ');
                    Adjacency[Convert.ToInt32(split[1])-1, Convert.ToInt32(split[2])-1] = 1;
                    Adjacency[Convert.ToInt32(split[2])-1, Convert.ToInt32(split[1])-1] = 1;
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
                    Console.Write(i + " ");
                Console.Write("with: " +list.Fitness());
                Console.WriteLine();
            }
        }

        public List<List<int>> GetTopHalf()
        {
            return ValueList.OrderBy(list => list.Fitness()).Take(ValueList.Count / 2).ToList();
        }

        public List<List<int>> GetBottomHalf()
        {
            return ValueList.OrderByDescending(list => list.Fitness()).Take(ValueList.Count / 2).ToList();
        }

        public int GetMinimumFitness()
        {
            return ValueList.Min(list => list.Fitness());
        }

        public List<int> GetBest()
        {
            return ValueList.MinBy(list => list.Fitness());
        }

        public List<int> GetBestColored()
        {
            var noConflicts = ValueList.Where(list => list.Conflicts() == 0);
            var enumerable = noConflicts as IList<List<int>> ?? noConflicts.ToList();
            return !enumerable.Any() ? null : enumerable.MinBy(list => list.UsedColors());
        }
    }
}