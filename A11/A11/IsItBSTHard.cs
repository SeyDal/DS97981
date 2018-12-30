using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A11
{
    public class IsItBSTHard : Processor
    {
        public IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
        public long find_height (Node node , long height , Node root)
        {
            if (node == root)
                return height;
            else
            {
                return find_height(node.parent, height + 1, root);
            }
            
        }
        public List<long> in_order_func(List<Node> nodes_list)
        {
            Stack<Node> stack = new Stack<Node>();
            Node index = nodes_list[0];
            Node root = nodes_list[0];
            List<long> inorder_result = new List<long>();
            List<Node> result_nodes_list = new List<Node>();
            while (index != null || stack.Count != 0)
            {
                while (index != null)
                {
                    stack.Push(index);
                    index = index.left;

                }
                index = stack.Pop();
                if (inorder_result.Count != 0 && inorder_result[(inorder_result.Count - 1)] == index.key)
                {
                    if (find_height(index , 0 , root) <  find_height(result_nodes_list[result_nodes_list.Count - 1], 0, root))
                    {
                        is_bst = false;
                        break;
                    }
                }
                inorder_result.Add(index.key);
                result_nodes_list.Add(index);
                index = index.right;

            }
            return inorder_result;
        }
        public bool is_bst;
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
                {
                    nodes_list[i].left = nodes_list[(int)nodes[i][1]];
                    nodes_list[(int)nodes[i][1]].parent = nodes_list[i];
                }
                if (nodes[i][2] != -1)
                {
                    nodes_list[i].right = nodes_list[(int)nodes[i][2]];
                    nodes_list[(int)nodes[i][2]].parent = nodes_list[i];

                }
            }
            List<long> result = in_order_func(nodes_list);
            List<long> tmp_result = new List<long>();
            if (is_bst == false)
                return false;
            tmp_result = result.OrderBy(item => item).ToList();
            for (int i = 0; i < result.Count; i++)
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
