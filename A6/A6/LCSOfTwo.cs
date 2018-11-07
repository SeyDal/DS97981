using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfTwo: Processor
    {
        public LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            List<List<int>> table = new List<List<int>>();
            for (int i = 0; i <= seq1.Length; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j <= seq2.Length; j++)
                {
                    row.Add(0);

                }
                table.Add(row);
               
            }

            for (int i = 1; i <= seq1.Length; i++)
            {

                for (int j = 1; j <= seq2.Length; j++)
                {
                    


                    if (seq1[i - 1]==(seq2[j - 1]))
                    {
                        table[i][j] = table[i - 1][j - 1] + 1;
                        
                    }
                    else
                    {
                        table[i][j] = Math.Max(table[i-1][j], table[i][j-1]);
                    }

                }

            }


            return table[seq1.Length][seq2.Length];
        }
           
    }
}
