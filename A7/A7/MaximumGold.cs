using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximumGold : Processor
    {
        public MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            List<List<long>> result_table = new List<List<long>>();
            for (int j = 0 ; j <= goldBars.Length; j++)
            {
                List<long> row = new List<long>();
                for (int i = 0; i <= (int)W; i++ )
                {
                    row.Add(0);
                }
                result_table.Add(row);

            }

            for (int row = 1; row <= goldBars.Length; row++)
            {
                for (int weight = 1; weight <= (int)W; weight++)
                {
                    result_table[row][weight] = result_table[row - 1][weight]; 
                    if (goldBars[row-1] <= weight)
                    {
                        long value = result_table[row - 1][(int)(weight - goldBars[row - 1])]+goldBars[row-1];
                        if (value > result_table[row][weight])
                            result_table[row][weight] = value;
                    }
                }

            }


            return result_table [goldBars.Length][(int)W];
        }
    }
}
