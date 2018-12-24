using System;
using System.Collections;
using System.Collections.Generic;

namespace E2
{

    public class Q1LinkedList
    {
        public class Node
        {
            public Node(int key) { this.Key = key;  }
            public int Key;
            public Node Next = null;
            public Node Prev = null;
            public override string ToString() => ToString(4);

            public string ToString(int maxDepth)
            {
                return maxDepth == 1 || Next == null ?
                    $"{Key.ToString()}" + (Next != null ? "..." : string.Empty) :
                    $"{Key.ToString()} {Next.ToString(maxDepth - 1)}";
            }
        }

        private Node Head = null;
        private Node Tail = null;
        private Node tmp_tail;

        public void Insert(int key)
        {
            if (Head == null)
            {
                Head = Tail = new Node(key);
            }
            else
            {
                var newNode = new Node(key);
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
                tmp_tail = Tail;
            }
        }

        public override string ToString() => Head.ToString();

        public void Reverse()
        {
            
           
            if (Tail.Next == Head)
            {
                Tail.Next.Next = null;
                Tail.Next.Prev = Tail;
                Tail = Tail.Next;
                Head = tmp_tail;
                
            }
            else
            {
               if (Tail.Next == null)
                {
                    Tail.Next = Tail.Prev;
                    Tail.Prev = null;
                    Reverse();
                }
               else
                {
                    Tail.Next.Next = Tail.Next.Prev;
                    Tail.Next.Prev = Tail;
                    Tail = Tail.Next;
                    Reverse();
                }
                
            }
        }

        public void DeepReverse()
        {
            Tail.Next = Tail.Prev;
            Tail.Prev = null;
            while (Tail != Head)
            {
                Tail.Next.Next = Tail.Next.Prev;
                Tail.Next.Prev = Tail;
                Tail = Tail.Next;
            }
            Head = tmp_tail;
        }

        public IEnumerable<int> GetForwardEnumerator()
        {
            var it = this.Head;
            while (it != null)
            {
                yield return it.Key;
                it = it.Next;
            }
        }

        public IEnumerable<int> GetReverseEnumerator()
        {
            var it = this.Tail;
            while (it != null)
            {
                yield return it.Key;
                it = it.Prev;
            }
        }
    }
}