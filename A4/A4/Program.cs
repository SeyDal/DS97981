using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A4
{
    public class Program
    {
        public static long ChangingMoney1(long money)
        {
            List<long> result_list = new List<long> { 0, 1, 2, 3, 4, 1, 2, 3, 4, 5, 1 };
            int index = (int)money;
            if (money < 11)
                return result_list[index];
            else
            {
                for (int i = 11; i <= index; i++)
                {
                    long result1 = result_list[i - 1] + 1;
                    long result2 = result_list[i - 5] + 1;
                    long result3 = result_list[i - 10] + 1;
                    result1 = Math.Min(result1, result2);
                    result1 = Math.Min(result1, result3);
                    result_list.Add(result1);

                }

                return result_list[index];

            }
        }

        public static long MaximizingLoot2(
            long capacity,long[] weight,long[] values)
            {
            List<double> value_per_weight = new List<double>();
            for (int i=0; i< weight.Count(); i++)
            {
                value_per_weight.Add((double)values[i] / weight[i]);
               
            }
            value_per_weight.Sort();
            Console.WriteLine(value_per_weight);
            long result_value = 0;
            long result_weight = 0;
            for (int i=value_per_weight.Count()-1; i >= 0; i--)
            {
                for (int j = 0; j < weight.Count(); j++)
                {
                    if(((double)values[j] / weight[j]) == value_per_weight[i])
                    {
                        if ((capacity - result_weight) <= weight[j] )
                        {
                            
                
                                result_value += (capacity - result_weight) * values[j] / weight[j];
                                result_weight = capacity;
                            
                            
                        }

                        else
                        {
                          
                                result_value += values[j];
                                result_weight += weight[j];
                                values[j] = -1;

                        }
                    }

                }
                if (capacity == result_weight)
                    break;
            }

            return result_value;


                
            }

        public static long MaximizingOnlineAdRevenue3 (long slotCount,long[] adRevenue,long[] avregeDailyClick)
        {
            Array.Sort(adRevenue);
            Array.Sort(avregeDailyClick);
            
            long result = 0;
            for(int i=0; i < (int)slotCount; i++)
            {
                result += adRevenue[i] * avregeDailyClick[i];
            }

            return result;
        }

        public static long CollectingSignatures4 (long tenantCount,long[] startTimes,long[] endTimes)
        {
            long temp = 0;

            for (int write = 0; write < tenantCount; write++)
            {
                for (int sort = 0; sort < tenantCount-1; sort++)
                {
                    if (endTimes[sort] > endTimes[sort + 1])
                    {
                        temp =startTimes[sort + 1];
                        startTimes[sort + 1] = startTimes[sort];
                        startTimes[sort] = temp;

                        temp = endTimes[sort + 1];
                        endTimes[sort + 1] = endTimes[sort];
                        endTimes[sort] = temp;

                    }
                }
            }
            long result = 0;
            List<int> removed_tenants = new List<int>();
            for (int i=0; i < tenantCount; i++)
            {
                if (!removed_tenants.Contains(i))
                {
                    for (int j = 0; j < tenantCount; j++)
                    {
                        if (((startTimes[j]<=startTimes[i] && startTimes[i] <=endTimes[j]) || (startTimes[i] <= startTimes[j] && startTimes[j] <= endTimes[i])) && !removed_tenants.Contains(j))
                            removed_tenants.Add(j);

                    }
                    result += 1;
                }
            }
            return result;
        }


        public static long[] MaximizeNumberOfPrizePlaces5(long n)
        {
            List<long> result_list = new List<long>() ;
            long sum = 0;
            if (n == 2)
            {
                result_list.Add(2);
                return result_list.ToArray();

            }
                
           for (int i = 0; i<(n-sum)/2; i++)
            {
                result_list.Add(i + 1);
                sum += (i + 1);
                
            }
            result_list.Add(n - sum);
            return result_list.ToArray();

        }


        public static string MaximizeSalary6 (long n , long[] numbers)
        {
            List<long> numbers_tmp = new List<long>();
            numbers_tmp = numbers.ToList();
            string result = "";

            for (int k=0; k < n; k++)
            {
                string max = numbers_tmp[0].ToString();
                for (int i = 0; i < numbers_tmp.Count(); i++)
                {
                    string a, b;
                    a = max + numbers_tmp[i].ToString();
                    b = numbers_tmp[i].ToString() + max;
                    if (int.Parse(b) >= int.Parse(a))
                        max = numbers_tmp[i].ToString();
                }
                result += max;
                numbers_tmp.Remove(int.Parse(max));


            }
           

            return result;
        }



        public static string ProcessMaximizeSalary6 (string inStr) =>
            TestTools.Process(inStr, MaximizeSalary6);
        public static string ProcessMaximizeNumberOfPrizePlaces5(string inStr) =>
            TestTools.Process(inStr,(Func < long, long[]>)MaximizeNumberOfPrizePlaces5);

        public static string ProcessCollectingSignatures4(string inStr) =>
            TestTools.Process(inStr,
                (Func<long, long[], long[], long>)CollectingSignatures4);
        public static string ProcessMaximizingOnlineAdRevenue3(string inStr) =>
            TestTools.Process(inStr,
                (Func<long, long[], long[], long>)MaximizingOnlineAdRevenue3);

        public static string ProcessMaximizingLoot2(string inStr) =>
            TestTools.Process(inStr, 
                (Func<long, long[], long[], long >) MaximizingLoot2);
        
        public static string ProcessChangingMoney1(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)ChangingMoney1);
        static void Main(string[] args)
        {
        }
    }
}
