using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class BinaryTreeTraversals : Processor
    {
        public BinaryTreeTraversals(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[] pre_order_func (List<Node> nodes_list)
        {
            Stack<Node> stack = new Stack<Node>();
            Node index = nodes_list[0];
            List<long> preorder_result = new List<long>();
            while (index != null || stack.Count != 0)
            {
                while (index != null)
                {
                    stack.Push(index);
                    preorder_result.Add(index.key);
                    index = index.left;


                }
                index = stack.Pop();
                index = index.right;

            }
            return preorder_result.ToArray();
        }
        public long[] post_order_func (List<Node> nodes_list)
        {
            Stack<Node> stack = new Stack<Node>();
            Node index = nodes_list[0];
            List<long> postorder_result = new List<long>();
            stack.Push(index);

            while ( stack.Count != 0)
            {
                index = stack.Pop();
                postorder_result.Add(index.key);
                if (index.left != null)
                    stack.Push(index.left);
                if (index.right != null)
                    stack.Push(index.right);
                

            }
            postorder_result.Reverse();
            return postorder_result.ToArray();
        }

        public long[] in_order_func(List<Node> nodes_list)
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
                inorder_result.Add(index.key);
                index=index.right;

            }
            return inorder_result.ToArray();
        }
        public long[][] Solve(long[][] nodes)
        {

            List<Node> nodes_list = new List<Node>();
            for (int i= 0; i<nodes.Length; i++)
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

            long[][] result = new long[][] { in_order_func(nodes_list), pre_order_func(nodes_list), post_order_func(nodes_list) };

            return result;
        }
    }
    public class Node
    {
        public Node left =null ;
        public Node right =null;
        public Node parent = null;
        public long key;
    


    }
}
