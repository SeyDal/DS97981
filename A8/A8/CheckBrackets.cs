using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class CheckBrackets : Processor
    {
        public CheckBrackets(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            List<char> opening_brackets = new List<char>();
            List<int> opening_brackets_index = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '[' || str[i] == '{')
                {
                    opening_brackets.Add(str[i]);
                    opening_brackets_index.Add(i);
                }
                else
                {
                    if (str[i] == ')')
                    {
                        if (opening_brackets.Count() > 0)
                        {

                            if (opening_brackets[opening_brackets.Count() - 1] == '(')
                            {
                                opening_brackets.RemoveAt(opening_brackets.Count() - 1);
                                opening_brackets_index.RemoveAt(opening_brackets_index.Count() - 1);

                                continue;
                            }
                            return i + 1;
                        }
                        return i + 1;




                    }
                    else if (str[i] == ']')
                    {
                        if (opening_brackets.Count() > 0)
                        {
                            if (opening_brackets[opening_brackets.Count() - 1] == '[')
                            {
                                opening_brackets.RemoveAt(opening_brackets.Count() - 1);
                                opening_brackets_index.RemoveAt(opening_brackets_index.Count() - 1);

                                continue;

                            }
                            return i + 1;
                        }
                        return i + 1;


                    }
                    else if (str[i] == '}')
                    {
                        if (opening_brackets.Count() > 0)
                        {

                            if (opening_brackets[opening_brackets.Count() - 1] == '{')
                            {
                                opening_brackets.RemoveAt(opening_brackets.Count() - 1);
                                opening_brackets_index.RemoveAt(opening_brackets_index.Count() - 1);

                                continue;
                            }
                            return i + 1;
                        }
                        return i + 1;


                    }

                }
            }
            if (opening_brackets.Count() == 0)
                return -1;
            else
                return opening_brackets_index[0]+1;
        }
    }
}
