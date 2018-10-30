using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Program

    {
       

        static void Main(string[] args) { }
        public static int BinarySearch(long[] a, long b, int start, int end)
        {
            if (end < start)
                return -1;
            int middle = (int)(start + ((end - start) / 2));
            if (a[middle] == b)
                return middle;
            else if (b < a[middle])
                return BinarySearch(a, b, start, middle - 1);
            else
                return BinarySearch(a, b, middle + 1, end);

        }

        public static long[] BinarySearch1(long[] a, long[] b)
        {
            long[] result_Array = new long[b.Length];

            for (int i = 0; i < b.Length; i++)
            {
                result_Array[i] = BinarySearch(a, b[i], 0, a.Length - 1);

            }


            return result_Array;
        }

        public static string ProcessBinarySearch1(string inStr) =>
            TestTools.Process(inStr, BinarySearch1);


        public static Tuple<List<long>, List<long>> MajorityElement(long[] a,int start , int end)
        {
            if (start==end-1)
            {
                List<long> majors = new List<long>();
                List<long> others = new List<long>();
                majors.Add(a[start]);
                return Tuple.Create(majors, others);

            }
               
              
            int middle = (int)(start + ((end - start) / 2));
            var left_half = MajorityElement(a, start, middle);
            var right_half = MajorityElement(a, middle, end);
            int counter = 0;
            for(int i = 0; i < right_half.Item2.Count(); i++)
            {
                if (right_half.Item2[i] == left_half.Item1[0])
                {
                    left_half.Item1.Add(left_half.Item1[0]);
                    counter += 1;
                }
            }
            for (int i = 0; i < counter; i++)
                right_half.Item2.Remove(left_half.Item1[0]);


            counter = 0;
            for (int i = 0; i < left_half.Item2.Count(); i++)
            {
                if (left_half.Item2[i] == right_half.Item1[0])
                {
                    right_half.Item1.Add(right_half.Item1[0]);
                    counter += 1;
                }
            }
            for (int i = 0; i < counter; i++)
                left_half.Item2.Remove(right_half.Item1[0]);

            List<long> majors1 = new List<long>();
            List<long> others1 = new List<long>();
            
            if (right_half.Item1[0] == left_half.Item1[0])
            {
                right_half.Item1.AddRange(left_half.Item1);
                right_half.Item2.AddRange(left_half.Item2);
                majors1 = right_half.Item1;
                others1 = right_half.Item2;


            }
            else if (left_half.Item1.Count() > right_half.Item1.Count())
            {
                left_half.Item2.AddRange(right_half.Item2);
                left_half.Item2.AddRange(right_half.Item1);
                majors1 = left_half.Item1;
                others1 = left_half.Item2;

            }
            else
            {
                right_half.Item2.AddRange(left_half.Item2);
                right_half.Item2.AddRange(left_half.Item1);
                majors1 = right_half.Item1;
                others1 = right_half.Item2;

            }
            var result = Tuple.Create(majors1, others1);


            return result;
        }
        
        public static long MajorityElement2(long n, long[] a)
        {
            var result_tuple=MajorityElement(a, 0, (int)n );
            if (result_tuple.Item1.Count() > n / 2.0)
                return 1;
            else
                return 0;
        }

        public static string ProcessMajorityElement2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)MajorityElement2);

        public static long[] ImprovingQuickSort(long[] a_tmp,int start,int end)
            
        {

            if (start >= end)
                return a_tmp;
            Random random = new Random();
            int random_number= random.Next(start, end);
            long tmp = 0;
            tmp = a_tmp[start];
            a_tmp[start] = a_tmp[random_number];
            a_tmp[random_number] = tmp;
            


            int first_index = start + 1;
            int second_index = start  ;
            long key = a_tmp[start];
            for (int i = start+1; i <= end; i++)
            {
                if (a_tmp[i] <= key)
                {
                    second_index++;
                    tmp = a_tmp[second_index];
                    a_tmp[second_index] = a_tmp[i];
                    a_tmp[i] = tmp;

                  
                    if (a_tmp[second_index]< key)
                    {

                        tmp = a_tmp[second_index];
                        a_tmp[second_index] = a_tmp[first_index];
                        a_tmp[first_index] = tmp;

                        first_index++;
                    }
                  
                }

            }
            tmp = a_tmp[start];
            a_tmp[start] = a_tmp[first_index - 1];
            a_tmp[first_index - 1] = tmp;

            a_tmp=ImprovingQuickSort(a_tmp, start, first_index - 1);
            a_tmp=ImprovingQuickSort(a_tmp, second_index + 1, end);
            return a_tmp;



            
        }

        public static long[] ImprovingQuickSort3(long n, long[] a)
        {
                      
            return ImprovingQuickSort(a,0,(int)n-1);
        }

        public static string ProcessImprovingQuickSort3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)ImprovingQuickSort3);


        public static Tuple<List<long>, List<long>>  MergeSort(List<long> a,int start , int end)
        {
            
            if (start==end)
            {
                List<long> item1 = new List<long>();
                List<long> item2 = new List<long>();
                item2.Add(a[start]);
                item1.Add(0);
                return Tuple.Create(item1,item2);

            }
            int middle = (int)((end-start+1)/2)+start;
            var left = MergeSort(a,start,middle-1);
            var right = MergeSort(a,middle,end);


            long counter = left.Item1[0] + right.Item1[0];
            List<long> counter_list = new List<long>();
            List<long> left_list1 = new List<long>();
            List<long> right_list1 = new List<long>();
            List<long> result_list = new List<long>();
            left_list1 = left.Item2;
            right_list1 = right.Item2;
            int left_counter = 0;
            int right_counter = 0;
            while (left_counter<left_list1.Count() && right_counter < right_list1.Count() )
            {
                if (left_list1[left_counter] > right_list1[right_counter])
                {
                    counter += right_list1.Count()-right_counter;
                    result_list.Add(left_list1[left_counter]);
                    left_counter++;
                }
                else
                {
                    result_list.Add(right_list1[right_counter]);
                    right_counter++;
                }

            }
            if (left_counter != left_list1.Count())
            {
                for (int i = left_counter; i < left_list1.Count(); i++)
                    result_list.Add(left_list1[i]);
            }
            if (right_counter != right_list1.Count())
            {
                for (int i = right_counter; i < right_list1.Count(); i++)
                    result_list.Add(right_list1[i]);
            }

            counter_list.Add(counter);
            return Tuple.Create(counter_list, result_list);

        }
        public static long NumberofInversions4(long n, long[] a)
        {

            return MergeSort(a.ToList(),0,(int)n-1).Item1[0];
        }

        public static string ProcessNumberofInversions4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)NumberofInversions4);

        public static Tuple<List<long>,List<long>> ImprovingQuickSort2(List<long> a_tmp, List<long> b_tmp, int start, int end)

        {

            if (start >= end)
                return Tuple.Create(a_tmp, b_tmp);
            Random random = new Random();
            int random_number = random.Next(start, end);
            long tmp = 0;
            tmp = a_tmp[start];
            a_tmp[start] = a_tmp[random_number];
            a_tmp[random_number] = tmp;


            tmp = b_tmp[start];
            b_tmp[start] = b_tmp[random_number];
            b_tmp[random_number] = tmp;





            int first_index = start + 1;
            int second_index = start;
            long key = a_tmp[start];
            for (int i = start + 1; i <= end; i++)
            {
                if (a_tmp[i] <= key)
                {
                    second_index++;
                    tmp = a_tmp[second_index];
                    a_tmp[second_index] = a_tmp[i];
                    a_tmp[i] = tmp;

                    tmp = b_tmp[second_index];
                    b_tmp[second_index] = b_tmp[i];
                    b_tmp[i] = tmp;


                    if (a_tmp[second_index] < key)
                    {

                        tmp = a_tmp[second_index];
                        a_tmp[second_index] = a_tmp[first_index];
                        a_tmp[first_index] = tmp;


                        tmp = b_tmp[second_index];
                        b_tmp[second_index] = b_tmp[first_index];
                        b_tmp[first_index] = tmp;

                        first_index++;
                    }

                }

            }
            tmp = a_tmp[start];
            a_tmp[start] = a_tmp[first_index - 1];
            a_tmp[first_index - 1] = tmp;

            tmp = b_tmp[start];
            b_tmp[start] = b_tmp[first_index - 1];
            b_tmp[first_index - 1] = tmp;

           var a = ImprovingQuickSort2(a_tmp,b_tmp ,start, first_index - 1);
            a_tmp = a.Item1;
            b_tmp = a.Item2;
            a = ImprovingQuickSort2(a_tmp, b_tmp, second_index + 1, end);
            a_tmp = a.Item1;
            b_tmp = a.Item2;
            return Tuple.Create(a_tmp, b_tmp);




        }


        public static Tuple<List<long>, List<long>> MergeSort2(List<long> a,List<long>b, int start, int end)
        {

            if (start == end)
            {
                List<long> item1 = new List<long>();
                List<long> item2 = new List<long>();
                item2.Add(a[start]);
                item1.Add(b[start]);
                return Tuple.Create(item1, item2);

            }
            int middle = (int)((end - start + 1) / 2) + start;
            var left = MergeSort2(a,b, start, middle - 1);
            var right = MergeSort2(a,b, middle, end);


            List<long> counter_list = new List<long>();
            List<long> left_list1 = new List<long>();
            List<long> right_list1 = new List<long>();
            List<long> result_list = new List<long>();
            left_list1 = left.Item2;
            right_list1 = right.Item2;

            List<long> left_list2 = new List<long>();
            List<long> right_list2 = new List<long>();
            left_list2 = left.Item1;
            right_list2 = right.Item1;
            int left_counter = 0;
            int right_counter = 0;
            while (left_counter < left_list1.Count() && right_counter < right_list1.Count())
            {
                if (left_list1[left_counter] > right_list1[right_counter])
                {
                    counter_list.Add(left_list2[left_counter]);
                    result_list.Add(left_list1[left_counter]);
                    left_counter++;
                }
                else
                {
                    result_list.Add(right_list1[right_counter]);
                    counter_list.Add(right_list2[right_counter]);
                    right_counter++;
                }

            }
            if (left_counter != left_list1.Count())
            {
                for (int i = left_counter; i < left_list1.Count(); i++)
                {
                    counter_list.Add(left_list2[i]);
                    result_list.Add(left_list1[i]);
                }
            }
            if (right_counter != right_list1.Count())
            {
                for (int i = right_counter; i < right_list1.Count(); i++)
                {
                    counter_list.Add(right_list2[i]);
                    result_list.Add(right_list1[i]);
                }
            }

            return Tuple.Create(counter_list, result_list);

        }

        public static long[] OrganizingLottery5(long[] points, long[] startSegments,
            long[] endSegment)
        {
            List<long> starts_tmp_list = new List<long>();
            List<long> ends_tmp_list = new List<long>();
            List<long> points_tmp_list = new List<long>();
            List<long> numbers_list = new List<long>();
            List<long> numbers_tmp_list = new List<long>();
            List<long> result_list = new List<long>();


            for (int i = 0; i < startSegments.Length; i++)
            {
                starts_tmp_list.Add(1);
                ends_tmp_list.Add(2);
            }
            Dictionary<long, long> points_dict = new Dictionary<long, long>();
            for (int i = 0; i < points.Length; i++)
            {
                if (!points_dict.ContainsKey(points[i]))
                    points_dict.Add(points[i], 0);
                points_tmp_list.Add(3);
            }
            numbers_list = startSegments.ToList();
            numbers_tmp_list = starts_tmp_list;
            numbers_list.AddRange(points.ToList());
            numbers_list.AddRange(endSegment.ToList());
            numbers_tmp_list.AddRange(points_tmp_list);
            numbers_tmp_list.AddRange(ends_tmp_list);

            var a = MergeSort2(numbers_list, numbers_tmp_list, 0, numbers_list.Count() - 1);
            numbers_list = a.Item2;
            numbers_tmp_list = a.Item1;

            long counter = 0;
            for (int i=0; i < numbers_list.Count(); i++)
            {   
                if (numbers_tmp_list[i] == 1)
                    counter--;
                else if (numbers_tmp_list[i] == 2)
                    counter++;
                else 
                {
                    if (points_dict[numbers_list[i]] == 0)
                        points_dict[numbers_list[i]] += counter;

                }
               
            }
            
            for (int i=0;i<points.Length;i++)
            {
                result_list.Add(points_dict[points[i]]);
            }
            




            return result_list.ToArray();
        }

        public static string ProcessOrganizingLottery5(string inStr) =>
            TestTools.Process(inStr,OrganizingLottery5);

        public static double FindDistance (double x1 ,double y1 , double x2, double y2)
        {
            return Math.Pow((Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)), 0.5);
        }
            


        public static double FindMinDistance(List<Tuple<long,long>> points,int start,int end)

            
        {
            int size = end - start +1;
            if (size < 4)
            {
                double result=FindDistance(points[0].Item1,points[0].Item2, points[1].Item1, points[1].Item2);
                for (int i =start ;  i <= end; i++ )
                {
                    for (int j=i+1; j<= end; j++)
                    {
                        result = Math.Min(result, FindDistance(points[i].Item1, points[i].Item2, points[j].Item1, points[j].Item2));
                    }
                }
                return result;
            }
            double min_distance;
            double left_min, right_min;
            int middle = (int)size / 2+start;
            left_min = FindMinDistance(points, start, middle);
            right_min = FindMinDistance(points, middle, end);
            min_distance = Math.Min(left_min, right_min);
            int limit;
            limit = Math.Min((int)min_distance, middle - start);
            limit = Math.Min(limit, end-middle);





            for (int i = middle - limit; i <= middle+ limit; i++)
            {
                for (int j = i + 1; j <= middle+limit; j++)
                {
                    min_distance = Math.Min(min_distance, FindDistance(points[i].Item1, points[i].Item2, points[j].Item1, points[j].Item2));
                }
            }


            return min_distance;
        }
        public static double ClosestPoints6(long n, long[] xPoints, long[] yPoints)
        {
            List<Tuple<long, long>> sorted_list = new List<Tuple<long, long>>();
            for (int i = 0; i < (int)n; i++)
                sorted_list.Add(Tuple.Create(xPoints[i], yPoints[i]));

            sorted_list.Sort((x, y) => y.Item1.CompareTo(x.Item1));
            sorted_list.Reverse();
            double answer = FindMinDistance(sorted_list, 0, (int)n - 1);

            return Math.Round((double)((int)(answer*100000)/10.0))/10000.0 ;
        }

        public static string ProcessClosestPoints6(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[], long[], double>)
               ClosestPoints6);

    }
}
