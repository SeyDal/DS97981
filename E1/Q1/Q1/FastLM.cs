using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class FastLM
    {
        public readonly WordCount[] WordCounts;


        public FastLM(WordCount[] wordCounts)
        {
            this.WordCounts = wordCounts.OrderBy(wc => wc.Word).ToArray();
        }

        public ulong BinarySearch(string word , int start , int end )
        {
            int middle = (int)((end - start) / 2) + start;
            if (start == end)
            {
                if (string.Compare(WordCounts[middle].Word, word) == 0)
                    return WordCounts[middle].Count;
                else
                    return 0;
            }
            
            if (string.Compare(WordCounts[middle].Word,word )> 0)
            {
                return BinarySearch(word, start, middle);
            }
            else if (string.Compare(WordCounts[middle].Word, word) < 0)
            {
                return BinarySearch(word, middle+1,end);
            }
            else
            {
                return WordCounts[middle].Count;

            }
            
        
            
        }


        public bool GetCount(string word, out ulong count)
        {
            count = 0;
            count = BinarySearch(word, 0, WordCounts.Length - 1);

            return true;
        }
    }
}
