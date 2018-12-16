using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class HashingWithChain : Processor
    {
        public HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);
        public long bucket_count;
        public List<List<string>> hash_map;



        public string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            bucket_count = bucketCount;
            hash_map = new List<List<string>>();
            for (int i = 0; i < (int)bucket_count; i++)
            {
                List<string> chain = new List<string> ();
                hash_map.Add(chain);
            }
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;
        

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            return hash;
        }
        public long HashFunc (string str , long bucket)
        {
            long hash = 0;
            for (int i = str.Length-1;  i > -1 ; i--)
            {
                hash = (hash * ChosenX + (int)(str[i])) % BigPrimeNumber;
            }
            

            return hash%bucket_count;
        }
        public void Add(string str)
        {
            long hash_func = HashFunc(str, bucket_count);
            if (!hash_map[(int)hash_func].Contains(str))
                {
                hash_map[(int)hash_func].Add(str);

                }
           

        }

        public string Find(string str)
        {
            long hash_func = HashFunc(str, bucket_count);
            string answer;
            if (hash_map[(int)hash_func].Contains(str))
                answer = "yes";
            else
                answer = "no";
            return answer;
        }

        public void Delete(string str)
        {
            long hash_func = HashFunc(str, bucket_count);
            if (hash_map[(int)hash_func].Contains(str))
                hash_map[(int)hash_func].Remove(str);

        }

        public string Check(int i)
        {
            string result="";
            for (int j = hash_map[i].Count()-1; j > -1 ; j--)
            {
                result += hash_map[i][j];
                if (j > 0)
                    result += " ";
            }
            if (result!="")
                return result;
            else
            {
                result = "-";
                return result;
            }
        }
    }
}
