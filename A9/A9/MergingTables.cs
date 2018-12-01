using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class MergingTables : Processor
    {
        public MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public int  FindParent (int table,List<int> table_parent)
        {
            if (table_parent[table] == table)
                return table;
            else
                return FindParent(table_parent[table], table_parent);

        }
        public long[] Solve(long[] tableSizes, long[] sourceTables, long[] targetTables)
        {
            List<int> table_parents = new List<int>();
            List<long> result = new List<long>();
            long max=0;
            for (int i = 0; i < tableSizes.Length; i++)
            {
                table_parents.Add(i);
                if (tableSizes[i] > max)
                    max = tableSizes[i];
            }
           
            

            for (int i=0; i < targetTables.Length; i++)
            {
                int source_parent = FindParent((int)sourceTables[i]-1, table_parents);
                int target_parent = FindParent((int)targetTables[i]-1, table_parents);
                if (source_parent != target_parent)
                {
                    tableSizes[target_parent] += tableSizes[source_parent];
                    tableSizes[source_parent] = 0;
                    table_parents[source_parent] = table_parents[target_parent];
                }
                
                if (tableSizes[target_parent] > max)
                    max = tableSizes[target_parent];
                result.Add(max);
            }
            return result.ToArray();
        }
    }
}