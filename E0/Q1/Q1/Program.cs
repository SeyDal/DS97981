using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Program
    {
        private static Dictionary<int, char[]> D =
            new Dictionary<int, char[]>
            {
                [0] = new char[] { '+' },
                [1] = new char[] { '_', ',', '@' },
                [2] = new char[] { 'A', 'B', 'C' },
                [3] = new char[] { 'D', 'E', 'F' },
                [4] = new char[] { 'G', 'H', 'I' },
                [5] = new char[] { 'J', 'K', 'L' },
                [6] = new char[] { 'M', 'N', 'O' },
                [7] = new char[] { 'P', 'Q', 'R', 'S' },
                [8] = new char[] { 'T', 'U', 'V' },
                [9] = new char[] { 'W', 'X', 'Y', 'Z' },
            };

        public static List<string> AddNewNumber(List<string> list,int number)
        {
            List<string> tmp_list = new List<string>();
            for (int j = 0; j < D[number].Length; j++)
            {
                for (int k = 0; k < list.Count(); k++)
                {
                    tmp_list.Add(list[k]+ D[number][j].ToString());
                }
            }
            return tmp_list;
        }

        public static string[] GetNames(int[] phone)
        {
            List<String> result_list = new List<string>();
            for (int i = 0; i < D[phone[0]].Length; i++)
                result_list.Add(D[phone[0]][i].ToString());
            
            int phone_number_size = phone.Length;
            for (int i=1;i<phone_number_size;i++)
            {
                result_list = AddNewNumber(result_list, phone[i]);
            }
            // write your code here
            return result_list.ToArray();
        }

        static void Main(string[] args)
        {
            int[] phoneNumber = new int[] {0, 9, 1, 2, 2, 2, 4, 2, 5, 2, 5 };

            // چاپ یک رشته حرفی برای شماره تلفن
            for (int i=0; i< phoneNumber.Length; i++)
                Console.Write(D[phoneNumber[i]][0]);
            Console.WriteLine();
        }


    }
}
