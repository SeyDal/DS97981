using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class TreeHeight : Processor
    {
        public TreeHeight(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            long root=0;
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < (int)nodeCount; i++ )
            {
                nodes.Add(new Node());
            }
            for (int i = 0; i < (int)nodeCount; i++)
            {
                if (tree[i] == -1)
                {
                    root = i;

                }
                else
                {
                    nodes[i].parent = tree[i];
                    nodes[(int)tree[i]].AddChild(i);

                }

            }

            Queue q = new Queue();
            int height = 0;
            q.Enqueue(nodes[(int)root]);
            while (q.Count > 0)
            {
                height++;
                int q_size = q.Count;
                for (int i=0; i<q_size; i++ )
                {
                    Node node = (Node)q.Dequeue();
                    for (int j = 0; j < node.children.Count();j++)
                    {
                        q.Enqueue(nodes[(int)node.children[j]]);
                    }
                }
               
            }
            return height;


        }
    }
    public class Node 
    {
        public long parent;
        public List<long> children = new List<long> ();
        public void AddChild (long child)
        {
            children.Add(child);
        }
    }
}
