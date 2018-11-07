using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class MoneyChange : Processor
    {
        private static readonly int[] COINS = new int[] { 1, 3, 4 };

        public MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            List<long> result_list = new List<long> { 0, 1, 2, 1, 1, 2 };
            int index = (int)n;
            if (n < 6)
                return result_list[index];
            else
            {
                for (int i = 6; i <= index; i++)
                {
                    long result1 = result_list[i - 1] + 1;
                    long result2 = result_list[i - 3] + 1;
                    long result3 = result_list[i - 4] + 1;
                    result1 = Math.Min(result1, result2);
                    result1 = Math.Min(result1, result3);
                    result_list.Add(result1);

                }

                return result_list[index];
                return 0;
            }
        }
    }
}
