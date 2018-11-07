using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class EditDistance: Processor
    {
        public EditDistance(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            List<List<int>> table = new List<List<int>>();
            for (int i= 0; i<= str2 .Length; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j <= str1.Length; j++)
                {
                    row.Add(j);

                }
                table.Add(row);
                table[i][0] = i;
            }

            for (int i = 1; i <= str1.Length; i++)
            {
                
                for (int j = 1; j <= str2.Length; j++)
                {
                    int insert=table[j-1][i]+1;
                    int delete=table[j][i-1]+1;
                    int sub=table[j-1][i-1]+1;
                    int match=table[j-1][i-1];


                    if (str1[i-1].Equals(str2[j-1]))
                    {
                        table[j][i] = Math.Min(insert, delete);
                        table[j][i] = Math.Min(table[j][i], match);
                    }
                    else
                    {
                        table[j][i] = Math.Min(insert, delete);
                        table[j][i] = Math.Min(table[j][i], sub);
                    }

                }
                
            }


            return table[str2.Length][str1.Length];
        }

    }
}
