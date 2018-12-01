using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class ParallelProcessing : Processor
    {
        public ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<int> threads = new List<int>();
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();
            List<long> threads_start_time = new List<long>();
            List<long> threads_end_time = new List<long>();

          
            for (int i=0; i <( jobDuration.Length); i++)
            {
                
                result.Add(Tuple.Create((long)0, (long)0));
                if (i < threadCount)
                {
                    threads.Add(i);
                    threads_start_time.Add(0);
                    threads_end_time.Add(jobDuration[i]);
                    result[i] = Tuple.Create((long)i, (long)0);


                }
                else
                {
                    long min = threads_end_time[0];
                    int min_index = 0;
                    for (int j = 1; j < threadCount; j++)
                    {
                        if (threads_end_time[j] < min)
                        {
                            min = threads_end_time[j];
                            min_index = j;
                        }
                    }
                   

                    if (i < jobDuration.Length)
                    {
                        threads[min_index] = i;
                        threads_start_time[min_index] = threads_end_time[min_index];
                        threads_end_time[min_index] += jobDuration[i];
                    }
                    result[threads[min_index]] = Tuple.Create((long)min_index, threads_start_time[min_index]);
                }


            }

            return result.ToArray();

        }
    }
}
