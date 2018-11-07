using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class PrimitiveCalculator: Processor
    {
        public PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public long[] Solve(long n)
        {
            List<long[]> results_list = new List<long[]> { new long[] { 0 }, new long[] { 1 }, new long[] { 1, 2 }, new long[] { 1, 3 } };
            int number = (int)n;
            for (int i = 4; i <= (int)n; i++)
            {
                List<long[]> possible_results = new List<long[]>();

                if (i % 3 == 0)
                    possible_results.Add(results_list[i/3]);
                if (i % 2 == 0)
                    possible_results.Add(results_list[i/2]);
                possible_results.Add(results_list[i-1]);
                int min_length = possible_results[0].Length;
                int min_length_index = 0;
                for (int j = 1; j < possible_results.Count(); j++)
                {
                    if (possible_results[j].Length < min_length)
                        min_length_index = j;
                }
                List<long> result = new List<long>();
                result = possible_results[min_length_index].ToList();
                result.Add(i);
                results_list.Add(result.ToArray());
               

            }
            
           
                

               
                return results_list[number];


            
            
           
        }
    }
}
