using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Functions;

namespace AG_tema_1_prim
{
    public static class Maximum
    {
        private static int _nCount;

        private static ExploreType _searchMode;

        public static int GetRandom(int min, int max)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(min, max);
        }

        private static char Not(this char c)
        {
            return c == '0' ? '1' : '0';
        }

        public static string ToBinary(this int number)
        {
            return Convert.ToString(number, 2).PadLeft(5, '0');
        }

        public static int ToInt(this string number)
        {
            return Convert.ToInt32(number, 2);
        }

        private static string GenerateNextN(this string number)
        {
            try
            {
                var newList = number.ToList();
                if (_nCount == 5)
                    _nCount = 0;
                newList[_nCount] = number[_nCount++].Not();
                return string.Join("", newList.ToArray());
            }
            catch
            {
                throw new InvalidOperationException("String does not match a 5 bit binary number");
            }
        }

        public static void SetMode(ExploreType mode)
        {
            _searchMode = mode;
        }

        private static string Explore(IFunction function, string number)
        {
            var max = number;
            var maximer = number;

            while (true)
            {
                for (var i = 0; i < 5; i++)
                {
                    var newNumber = number.GenerateNextN();
                    //Console.WriteLine(newNumber + " " + function.Calculate(new List<decimal> { number.ToInt() }) + " " + function.Calculate(new List<decimal> {newNumber.ToInt()}));
                    if (function.Calculate(new List<decimal> {max.ToInt()}) >=
                        function.Calculate(new List<decimal> {newNumber.ToInt()}))
                        continue;
                    max = newNumber;
                    if (_searchMode == ExploreType.Best) continue;
                    _nCount = 0;
                    break;
                }

                number = max;
                if (function.Calculate(new List<decimal> { max.ToInt() }) <=
                    function.Calculate(new List<decimal> { maximer.ToInt() }))
                    break;
                maximer = max;
            }

           // Console.WriteLine();

            return max;
        }

        public static void Write(this Dictionary<int, List<int>> list)
        {
            var orderedList = list.OrderBy(x => x.Key).Reverse();
            foreach (var pair in orderedList)
            {
                Console.Write(pair.Key + ": ");
                if (pair.Value.Count > 0) pair.Value.ForEach(value => Console.Write(value + " "));
                Console.WriteLine();
            }
        }

        public static async Task<Dictionary<int, List<int>>> GetMaximum(IFunction function)
        {
            var finalList = new Dictionary<int, List<int>>();
            for (var i = 0; i < 32; i++)
            {
                var startValue = i;
                await Task.Run(() =>
                {
                    var max = 0;
                    while (true)
                    {
                        var newMax = Explore(function, startValue.ToBinary()).ToInt();
                        if (max < newMax)
                            max = newMax;
                        else
                            break;
                    }
                    //Console.WriteLine(startValue + ": " + max);
                    var key = max;//(int) function.Calculate(new List<decimal> {max});
                    if (finalList.ContainsKey(key))
                        finalList[key].Add(startValue);
                    else
                        finalList.Add(key, new List<int> {startValue});
                });
            }
            //Console.WriteLine();
            return finalList;
        }
    }
}