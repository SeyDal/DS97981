using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Program
    
    {
        public static long Fibonacci(long n)
        {
            int length = (int)n;
            List<long> fibList = new List<long>(length);
            fibList.Add(1);
            fibList.Add(1);
            for (int i = 2; i < length; ++i)
                fibList.Add(fibList[i - 2] + fibList[i - 1]);

            if (length == 0)
                return 0;
            else
                return fibList[length - 1];

        }
        public static long Fibonacci_LastDigit(long n)
        {
            int length = (int)n;
            List<long> fibList = new List<long>();
            fibList.Add(1);
            fibList.Add(1);
            for (int i = 2; i < length; ++i)
                fibList.Add(((fibList[i - 2] + fibList[i - 1])-(fibList[i - 2]+ fibList[i - 1] )/10*10));

            if (length == 0)
                return 0;
            else
                return fibList[length-1];
        }
        public static long GCD (long a, long b)
        {
            long min, max;
            if (a >= b)
            {
                max = a;
                min = b;
            }
            else
            {
                max = b;
                min = a;
            }
            while (true)
            {
                if (min == 0)
                    break;
                long tmp = max % min;
                max = min;
                min = tmp;
                

            }
            return max;

        }

        public static long LCM (long a,long b)
        {
            if (a == 0 || b == 0)
                return 0;
            else 
                return a*b/GCD(a,b) ;
        }


        public static long Fibonacci_Mod(long n ,long m)
        {
            List<long> fibList = new List<long>();

            fibList.Add(0);
            fibList.Add(1);
            int i = 2;
            while (true)
            {
                long mod = (fibList[i - 2] + fibList[i - 1]) % m;
               

                if (mod == 1 && fibList[i-1]==0 )
                    break;
                else
                {
                    fibList.Add(mod);
                }
                i++;
              
            }

            int period = fibList.Count()-1;
            int result = (int)(n % period);
            return fibList[result];
        
        }
        

        public static long Fibonacci_Sum (long n)
        {
            
            long fib = Fibonacci_Mod(n + 2, 10);
            if (fib == 0)
                return 9;
            else
                return fib - 1;

        }


        public static long Fibonacci_Partial_Sum(long n,long m)
        {
            long min, max;
            if (n >= m)
            {
                max = n;
                min = m;
            }
            else
            {
                max = m;
                min = n;
            }


            return (Fibonacci_Sum(max)+10-Fibonacci_Sum(min-1))%10;
        }


        public static long Fibonacci_Sum_Squares(long n)
        {
            long n1 = Fibonacci_Mod(n-1,10);
            long n2 = Fibonacci_Mod((n),10);
            return ((n1 + n2) * n2)%10 ;
        }


    
            

        
        public static string Process(string inStr, Func<long, long> longProcessor)
        {
            long n = long.Parse(inStr);
            return longProcessor(n).ToString();
        }
        public static string Process(string inStr, Func<long, long, long> longProcessor)
        {
            var toks = inStr.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            long a = long.Parse(toks[0]);
            long b = long.Parse(toks[1]);
            return longProcessor(a, b).ToString();
        }
        public static string ProcessFibonacci(string inStr) =>
            Process(inStr, Fibonacci);
        public static string ProcessFibonacci_LastDigit(string inStr) =>
            Process(inStr, Fibonacci_LastDigit);
        public static string ProcessGCD(string inStr) =>
            Process(inStr, GCD);
        public static string ProcessLCM(string inStr) =>
            Process(inStr, LCM);
        public static string ProcessFibonacci_Mod(string inStr) =>
            Process(inStr, Fibonacci_Mod);
        public static string ProcessFibonacci_Sum(string inStr) =>
            Process(inStr, Fibonacci_Sum);
        public static string ProseccFibonacci_Partial_Sum(string inStr) =>
            Process(inStr, Fibonacci_Partial_Sum);
        public static string ProcessFibonacci_Sum_Squares(string inStr) =>
            Process(inStr, Fibonacci_Sum_Squares);
        static void Main(string[] args)
        {
        }
    }
}
