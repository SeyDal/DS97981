using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class RabinKarp : Processor
    {
        public RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            List<long> occurrences = new List<long>();
            int prime_number = 151;
            int alcharacters_number = 256;
            int pattern_length = pattern.Length;
            int text_length = text.Length;
            int pat_hash = 0;
            int txt_hash = 0;
            int i, j;
            int h = 1;

           


            for (i = 0; i < pattern_length; i++)
            {
                pat_hash = (alcharacters_number * pat_hash + pattern[i]) % prime_number;
                txt_hash = (alcharacters_number * txt_hash + text[i]) % prime_number;
            }

            for (i = 0; i < pattern_length - 1; i++)
                h = (h * alcharacters_number) % prime_number;

            for (i = 0; i <= text_length - pattern_length; i++)
            {


                if (pat_hash == txt_hash)
                {
                    for (j = 0; j < pattern_length; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }

                    if (j == pattern_length)
                        occurrences.Add(i);
                }
                if (i < text_length - pattern_length)
                {
                    txt_hash = (alcharacters_number * (txt_hash - text[i] * h) + text[i + pattern_length]) % prime_number;
                    if (txt_hash < 0)
                        txt_hash = (txt_hash + prime_number);
                }
            }

            return occurrences.ToArray();
        }
       


        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            return null;
        }
    }
}
