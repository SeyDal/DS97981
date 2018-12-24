using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;
        long filter_size = 0;
        long hashfunc_size = 0;
        List<int> rnd_list;


        public Q3BloomFilter(int filterSize, int hashFnCount)
        {
            // زحمت بکشید پیاده سازی کنید

            Random rnd = new Random();
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];
            filter_size = filterSize;
            hashfunc_size = hashFnCount;
            List<int> rnd_list = new List<int>();
            for (int i = 0; i < hashFnCount; i++)
                rnd_list.Add(rnd.Next());
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                HashFunctions[i] = str => MyHashFunction(str, rnd_list[i]);
            }


        }

        public int MyHashFunction(string str, int num)
        {
           
            int result = 0;
            if (num == 0)
            {
                long BigPrimeNumber = 1000000007;
                long ChosenX = 456;
                long hash = 0;
                for (int i = str.Length - 1; i > -1; i--)
                {
                    hash = (hash * ChosenX + (int)(str[i])) % BigPrimeNumber;
                }
                result =(int) (hash % filter_size);
            }
            else if (num == 1)
            {
                long BigPrimeNumber = 1000000007;
                long ChosenX = 263;
                long hash = 0;
                for (int i = str.Length - 1; i > -1; i--)
                {
                    hash = (hash * ChosenX + (int)(str[i])) % BigPrimeNumber;
                }
                result = (int)(hash % filter_size);

            }
            else if (num == 2)
            {
                long BigPrimeNumber = 1000000007;
                long ChosenX = 1024;
                long hash = 0;
                for (int i = str.Length - 1; i > -1; i--)
                {
                    hash = (hash * ChosenX + (int)(str[i])) % BigPrimeNumber;
                }
                result = (int)(hash % filter_size);

            }
          
            return result;
        }

        public void Add(string str)
        {
            for (int i =0; i < hashfunc_size; i++)
            {
                Filter[MyHashFunction(str,i)] = true;
            }
        }

        public bool Test(string str)
        {
            bool result = true;
            for (int i = 0; i < hashfunc_size; i++)
            {
                 if (Filter[MyHashFunction(str, i)] != true)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}