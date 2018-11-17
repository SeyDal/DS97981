using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximizingArithmeticExpression : Processor
    {
        public MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Operation (long num1 , long  num2 , char op)
        {
            
            if (op .Equals ('+'))
                return num1 + num2;
            else if (op .Equals( '-'))
                return num1 - num2;
            else 
                return num1 * num2;
        }
             
        public long Solve(string expression)
        {
            List<List<long>> min_table = new List<List<long>>();
            List<List<long>> max_table = new List<List<long>>();
            int numbers = (expression.Length + 1) / 2;
            for (int  i = 0; i <= numbers; i ++  )
            {
                List<long> row2 = new List<long>();
                List<long> row = new List<long>();
                for (int j = 0; j <= numbers; j++)
                {
                    row2.Add(0);
                    row.Add(0);
                }
                min_table.Add(row2);
                max_table.Add(row);
                if (i>0 )
                {
                    min_table[i][i] =int.Parse( expression[i * 2 - 2].ToString());
                    max_table[i][i] = int.Parse( expression[i * 2 - 2].ToString());


                }
            }


            for (int i = 1; i <= numbers-1; i++)
            {
                for (int j = 1; j <= numbers-i; j++)
                {
                    int index = i + j;
                    long min =1000000000;
                    long max = -1000000000;
                    long value1, value2, value3, value4;


                    for (int k = j;  k <= index-1 ; k++ )
                    {
                        value1 = Operation ( max_table[j][k] , max_table[k + 1][index] , expression[k * 2 - 1]);
                        value2 = Operation ( max_table[j][k] , min_table[k + 1][index] , expression[k * 2 - 1]);
                        value3 = Operation ( min_table[j][k] , min_table[k + 1][index] , expression[k * 2 - 1]);
                        value4 = Operation ( min_table[j][k] , max_table[k + 1][index] , expression[k * 2 - 1]);
                        min = Math.Min(min, Math.Min(Math.Min(value1,value2), Math.Min(value3,value4)));
                        max = Math.Max(max, Math.Max(Math.Max(value1, value2), Math.Max(value3, value4)));
                    }
                    min_table[j][index] = min;
                    max_table[j][index] = max;


                }
            }
            
            return max_table [1][numbers];
        }
    }
}
