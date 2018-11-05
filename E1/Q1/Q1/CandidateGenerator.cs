using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public static class CandidateGenerator
    {
        public static readonly char[] Alphabet =
            Enumerable.Range('a', 'z' - 'a' + 1)
                      .Select(c => (char)c)
                      .ToArray();

        public static string[] GetCandidates(string word)
        {
            List<string> candidates = new List<string>();
            for (int i = 0; i < word.Length + 1;i++) 
            {
                for (int j = 0; j<Alphabet.Length; j++)
                {
                    candidates.Add(Insert(word, i, Alphabet[j]));
                }
                
            }
            for (int i = 0; i < word.Length ; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    candidates.Add(Substitute(word,i,Alphabet[j]));
                }

            }

            for (int i = 0; i < word.Length; i++)
            {
                
                    candidates.Add(Delete(word,i));
             

            }

            return candidates.ToArray();
        }

        private static string Insert(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length+1];
            int index = 0;
            for (int i = 0; i< word.Length+1; i++)
            {
                if (i == pos)
                    newWord[i] = c;
                else
                {
                    newWord[i] = wordChars[index];
                    index++;
                }
            }
            return new string(newWord);
        }

        private static string Delete(string word, int pos)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length-1];
            int index = 0;
            for (int i=0;  i< word.Length -1;i++)
            {
                if (i == pos)
                    index++;
                newWord[i] = wordChars[index];
                index++;
            }
            return new string(newWord);
        }

        private static string Substitute(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length];
            newWord = wordChars;
            newWord[pos] = c;
            return new string(newWord);
        }

    }
}
