using System;
using TestCommon;
using System.Collections.Generic;
using System.Linq;

namespace A11
{
    public class IsItBST : Processor
    {
        public IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool is_bst;


        public List<long> in_order_func(List<Node> nodes_list)
        {
            Stack<Node> stack = new Stack<Node>();
            Node index = nodes_list[0];
            List<long> inorder_result = new List<long>();
            while (index != null || stack.Count != 0)
            {
                while (index != null)
                {
                    stack.Push(index);
                    index = index.left;

                }
                index = stack.Pop();
                if (inorder_result.Count != 0 && inorder_result[(inorder_result.Count-1)]==index.key)
                {
                    is_bst = false;
                    break;
                }
                inorder_result.Add(index.key);
                index = index.right;

            }
            return inorder_result;
        }

        public bool Solve(long[][] nodes)
        {
            is_bst = true;
            List<Node> nodes_list = new List<Node>();
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes_list.Add(new Node());
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes_list[i].key = nodes[i][0];
                if (nodes[i][1] != -1)
                    nodes_list[i].left = nodes_list[(int)nodes[i][1]];
                if (nodes[i][2] != -1)
                    nodes_list[i].right = nodes_list[(int)nodes[i][2]];
            }

            List<long> result = in_order_func(nodes_list);
            List<long> tmp_result = new List<long>();
            if (is_bst == false)
                return false;
            tmp_result = result.OrderBy (item => item).ToList();
            for (int i= 0; i<result.Count; i++)
            {
                if (result[i] != tmp_result[i])
                    is_bst = false;
            }
            if (is_bst == false)
                return false;
            else
                return true;
            
        }
    }
   

}

