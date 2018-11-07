using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfThree: Processor
    {
        public LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            List<List<List<int>>> table = new List<List<List<int>>>();
            for (int i = 0; i <= seq1.Length; i++)
            {
                List<List<int>> row1 = new List<List<int>>();
                for (int j = 0 ; j <= seq2.Length; j++)
                {
                    List<int> row2 = new List<int>();
                    for (int k=0 ; k<= seq3.Length; k++)
                    {
                        row2.Add(0);
                    }

                    row1.Add(row2);
                }
                table.Add(row1);

            }

            for (int i = 1; i <= seq1.Length; i++)
            {

                for (int j = 1; j <= seq2.Length; j++)
                {


                    for (int k = 1 ; k <= seq3.Length; k++)
                    {
                        if (seq1[i - 1] == seq2[j - 1]  && seq2[j - 1] == seq3 [k-1])
                        {
                            table[i][j][k] = table[i - 1][j - 1][k-1] + 1;

                        }
                        else
                        {
                            table[i][j][k] = Math.Max(table[i - 1][j][k], table[i][j - 1][k]);
                            table[i][j][k] = Math.Max(table[i][j][k], table[i][j][k-1]);
                        }
                    }

                }

            }


            return table[seq1.Length][seq2.Length][seq3.Length];
        }
    
    }
}
