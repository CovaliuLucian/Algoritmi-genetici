using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Tema_3.Exceptions;

namespace Tema_3
{
    public static class Heuristic
    {
        public static int[,] Adjacency;
        public static int Vertices;

        private static void Shuffle<T>(this IList<T> list)
        {
            var provider = new RNGCryptoServiceProvider();
            var n = list.Count;
            while (n > 1)
            {
                var box = new byte[1];
                do provider.GetBytes(box); while (!(box[0] < n * (byte.MaxValue / n)));
                var k = (box[0] % n);
                n--;
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
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
                    Adjacency[Convert.ToInt32(split[1]) - 1, Convert.ToInt32(split[2]) - 1] = 1;
                    Adjacency[Convert.ToInt32(split[2]) - 1, Convert.ToInt32(split[1]) - 1] = 1;
                }
                else
                {
                    throw new InvalidFormatException();
                }
            }
        }

        public static int GetNumberOfNeighbors(this int i)
        {
            var nr = 0;
            for (var j = 0; j < Vertices; j++)
                if (Adjacency[i, j] == 1)
                    nr++;
            return nr;
        }

        public static int GetNumberOfAdjColors(this int i, List<int> colors)
        {
            var found = new List<int>();
            var nr = 0;
            for (var j = 0; j < Vertices; j++)
                if (Adjacency[i, j] == 1 && colors[j] != -1 && !found.Contains(colors[j]))
                {
                    nr++;
                    found.Add(colors[j]);
                }
            return nr;
        }

        public static List<int> Greedy()
        {
            Read();
            var colors = Enumerable.Repeat(-1,Vertices).ToList();
            for (var i = 0; i < Vertices; i++)
            {
                var usedColors = Enumerable.Repeat(0, Vertices).ToList();
                for (var j = 0; j < Vertices; j++)
                {
                    if (Adjacency[i, j] == 1 && colors[j] != -1)
                        usedColors[colors[j]]++;
                }
                for (var i1 = 0; i1 < usedColors.Count; i1++)
                {
                    if (usedColors[i1] != 0) continue;
                    colors[i] = i1;
                    break;
                }
            }

            return colors;
        }

        public static List<int> GreedyLdo()
        {
            Read();

            var all = Enumerable.Range(0, Vertices).OrderByDescending(i => i.GetNumberOfNeighbors()).ToList();

            var colors = Enumerable.Repeat(-1, Vertices).ToList();
            while(all.Count != 0)
            {
                var i = all.First();
                var usedColors = Enumerable.Repeat(0, Vertices).ToList();
                for (var j = 0; j < Vertices; j++)
                {
                    if (Adjacency[i, j] == 1 && colors[j] != -1)
                        usedColors[colors[j]]++;
                }
                for (var i1 = 0; i1 < usedColors.Count; i1++)
                {
                    if (usedColors[i1] != 0) continue;
                    colors[i] = i1;
                    break;
                }
                all.RemoveAt(0);
            }

            return colors;
        }

        public static List<int> GreedySdo()
        {
            Read();

            var all = Enumerable.Range(0, Vertices).ToList();

            var colors = Enumerable.Repeat(-1, Vertices).ToList();
            while (all.Count != 0)
            {
                all = Enumerable.Range(0, Vertices).OrderByDescending(v => v.GetNumberOfAdjColors(colors)).ToList();
                var i = all.First();
                var usedColors = Enumerable.Repeat(0, Vertices).ToList();
                for (var j = 0; j < Vertices; j++)
                {
                    if (Adjacency[i, j] == 1 && colors[j] != -1)
                        usedColors[colors[j]]++;
                }
                for (var i1 = 0; i1 < usedColors.Count; i1++)
                {
                    if (usedColors[i1] != 0) continue;
                    colors[i] = i1;
                    break;
                }
                all.RemoveAt(0);
            }

            return colors;
        }

        private static List<int> GreedyRandom()
        {
            Read();

            var all = Enumerable.Range(0, Vertices).ToList();
            all.Shuffle();

            var colors = Enumerable.Repeat(-1, Vertices).ToList();
            while (all.Count != 0)
            {
                var i = all.First();
                var usedColors = Enumerable.Repeat(0, Vertices).ToList();
                for (var j = 0; j < Vertices; j++)
                {
                    if (Adjacency[i, j] == 1 && colors[j] != -1)
                        usedColors[colors[j]]++;
                }
                for (var i1 = 0; i1 < usedColors.Count; i1++)
                {
                    if (usedColors[i1] != 0) continue;
                    colors[i] = i1;
                    break;
                }
                all.RemoveAt(0);
            }

            return colors;
        }

        public static List<int> GreedyRandom(int iterations)
        {
            var best = GreedyRandom();
            for (var i = 0; i < iterations - 1; i++)
            {
                var current = GreedyRandom();
                if (current.UsedColors() < best.UsedColors() && current.Conflicts() <= best.Conflicts())
                    best = current;
            }
            return best;
        }
    }
}