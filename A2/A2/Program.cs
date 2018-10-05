using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        public static int NaiveMaxPairwiseProduct(List<int> numbers)
        {
            int product = 0;
            int n = numbers.Count();
            for (int i = 0; i < n; ++i)
            {
                for (int j = i+1; j < n; ++j)
                {
                    product = Math.Max(product, numbers[i] * numbers[j]);
                }
            }
            return product;
        }
        public static int FastMaxPairwiseProduct(List<int> numbers)
        {
            int index = 0;
            int n = numbers.Count();
            for (int i = 1; i < n ; ++i)
            {
                if (numbers[i] > numbers[index])
                {
                    index = i;
                }
            }
            int tmp = numbers[index];
            numbers[index] = numbers[n-1];
            numbers[n-1] = tmp;
            index = 0;
            for ( int i =1; i < (n-1); ++i)
            {
                if (numbers[i] > numbers[index])
                {
                    index = i;
                }
            }
            tmp = numbers[index];
            numbers[index] = numbers[n - 2];
            numbers[n - 2] = tmp;
            return numbers[n-2] * numbers[n - 1];
        }
        public static string Process(string input)
        {
            var inData = input.Split(new char[] { '\n', '\r', ' ' },
            StringSplitOptions.RemoveEmptyEntries)
            .Select(s => int.Parse(s))
            .ToList();
            return FastMaxPairwiseProduct(inData).ToString();
        }


        
        static void Main(string[] args)
        {

        }
    }
}
