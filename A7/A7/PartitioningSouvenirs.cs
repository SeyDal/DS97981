using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class PartitioningSouvenirs : Processor
    {
        public PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long find_partition(long[] souvenirs , long capacity1 , long capacity2 , long capacity3 , int index)
        {
            if (capacity1 == 0 && capacity2 == 0 && capacity3 == 0)
                return 1;

            if (index < 0)
                return 0;
           
            long result1 = 0, result2 = 0 , result3 = 0;
            if (capacity1 - souvenirs[index] >= 0)
                result1 = find_partition(souvenirs, capacity1 - souvenirs[index], capacity2, capacity3, index - 1);
            if (capacity2 - souvenirs[index] >= 0 && result1 == 0)
                result2 = find_partition(souvenirs, capacity1 , capacity2 - souvenirs[index], capacity3, index - 1);
            if (capacity3 - souvenirs[index] >= 0 && result1 == 0 && result2 == 0)
                result3 = find_partition(souvenirs, capacity1, capacity2, capacity3 - souvenirs[index], index - 1);
            if (result1 == 1 || result2 == 1 || result3 == 1) 
                return 1;
            return 0;
        }

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long sum_of_souvenirs = 0;
            if (souvenirsCount < 3)
                return 0;

            for (int i = 0; i < (int)souvenirsCount; i++)
                sum_of_souvenirs += souvenirs[i];
            if (sum_of_souvenirs % 3 != 0)
                return 0;
            else
            {
                long capacity = sum_of_souvenirs / 3;
                return find_partition(souvenirs, capacity, capacity, capacity, (int)souvenirsCount - 1);
            }
            
            
        }
    }
}
