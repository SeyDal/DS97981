using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class PacketProcessing : Processor
    {
        public PacketProcessing(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);
        public Tuple<int,List<long>> buffer(long bufferSize,
            long arrivalTimes,
            long processingTimes, List<long> finish_time)
        {
           
            while (finish_time.Count() > 0 && finish_time[0] <= arrivalTimes)
            {
                finish_time.RemoveAt(0);
            }
            if (finish_time.Count() < bufferSize)
            {
                if (finish_time.Count() == 0)
                {
                    finish_time.Add(arrivalTimes + processingTimes);
                    return Tuple.Create( (int)arrivalTimes,finish_time);
                }
                else
                {
                    long start_time = arrivalTimes;
                    if (finish_time[finish_time.Count() - 1] > start_time)
                        start_time = finish_time[finish_time.Count() - 1];
                    else if (finish_time[finish_time.Count() - 1] == start_time)
                        start_time = finish_time[-1] + 1;
                    finish_time.Add(start_time + processingTimes);
                    return Tuple.Create((int)start_time, finish_time);

                }

            }
            else
                return Tuple.Create(-1, finish_time);
        }
        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            List<long> result = new List<long>();
            List<long> finish_time = new List<long>();
         

            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                var response = buffer(bufferSize, arrivalTimes[i], processingTimes[i], finish_time);
                finish_time = response.Item2;
                result.Add(response.Item1);
                
            }
            return result.ToArray();
        }
    }
}
