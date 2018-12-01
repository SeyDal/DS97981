using TestCommon;
using System;
using System.Collections.Generic;

namespace A9
{
    public class ConvertIntoHeap : Processor
    {
        public ConvertIntoHeap(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public  Tuple<long[] , List<Tuple<long, long>>> min_heap (long[] array,List<Tuple<long,long>> swaps, long node) 
        {
            int array_size = array.Length;
            int left_child = (int)node * 2 + 1;
            int right_child = (int)node * 2 + 2;
            long min = node ;
            if (left_child < array_size && array[min] > array[left_child])
                min = left_child;
            if (right_child < array_size && array[min] > array[right_child])
                min = right_child;
            if (min != node )
            {
                swaps.Add(Tuple.Create(node, min));
                long tmp = array[min];
                array[min] = array[node];
                array[node] = tmp;
                min_heap(array, swaps, min);

            }
            return Tuple .Create (array , swaps);
        }

        public Tuple<long, long>[] Solve(
            long[] array)
        {
       
            int array_size = array.Length;
            List<Tuple<long, long>> swaps_list = new List<Tuple<long, long>>();


            for (int i = (int)(array_size/2);i>-1;i--)
            {
                Tuple<long[], List<Tuple<long, long>>> output_tuple = min_heap(array, swaps_list, i);
                swaps_list = output_tuple.Item2;
                array = output_tuple.Item1;
            }
            return swaps_list.ToArray();
        }
    }

}