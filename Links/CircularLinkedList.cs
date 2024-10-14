using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Links
{
    internal class CircularLinkedList<T> where T : IComparable<T>
    {
        public class Node
        {
            public T val;
            public Node(T val)
            {
                this.val = val;
            }
            public Node Next;
        }
        public Node head;
        public Node tail;
        /// <summary>
        /// Appends the supplied element to the "end" of the link list, making it the new tail.
        /// </summary>
        /// <param name="val">The value of the node to add.</param>
        public void Add(T val)
        {
            if (head == null)
            {
                head = new Node(val);
                tail = head;
            }
            else
            {
                if (head.Next == null)
                {
                    tail = new Node(val);
                    head.Next = tail;
                    tail.Next = head;
                }
                else
                {
                    tail.Next = new Node(val);
                    tail.Next.Next = head;
                    tail = tail.Next;
                }
            }
        }
        /// <summary>
        /// Recursively finds the size of this linked list.
        /// </summary>
        /// <returns>the number of elemetns in this list</returns>
        public int Size()
        {
            return size_helper(head);
        }
        private int size_helper(Node node)
        {
            if(node == tail)
            {
                return 1;
            }
            else
            {
                return size_helper(node.Next) + 1; 
            }
        }
        /// <summary>
        /// Recursively searches the list to see if it contains the specified value.
        /// </summary>
        /// <param name="val">The value to be searched for</param>
        /// <returns>True if within the list, false otherwise.</returns>
        public bool Contains(T val)
        {
            return ContainsHelper(head, val);
        }
        private bool ContainsHelper(Node node,T val)
        {
            if (node.val.Equals(val)){
                return true;
            }
            if(node == tail)
            {
                return false;
            }
            return ContainsHelper(node.Next, val);
        }
        /// <summary>
        /// Returns a space separated list of values in this list as a string.
        /// </summary>
        /// <returns></returns>
        public String ToString()
        {
            return toStringHelper(head);
        }
        private String toStringHelper(Node node)
        {
            if(node == tail)
            {
                return node.val.ToString();
            }
            else
            {
                return node.val.ToString() + " " + toStringHelper(node.Next);
            }
        }
        /// <summary>
        /// Recursively sorts the list in place with a shell sort. 
        /// The sort changes the values at nodes, but not object references, 
        /// so the Nodes themselves will be in the same order.
        /// </summary>
        public void ShellSort()
        {
            int size = Size();
            shell_sort_helper(size / 2, size);
        }
        private void shell_sort_helper(int gap,int size)
        {
            Node fastNode = head;
            Node slowNode = head;
            for (int i = 0; i < gap; i++)
            {
                fastNode = fastNode.Next;
            }
            while(fastNode != head)
            {
                int compare = slowNode.val.CompareTo(fastNode.val);
                if(compare > 0)
                {
                    T temp = fastNode.val;
                    fastNode.val = slowNode.val;
                    slowNode.val = temp;
                }
                slowNode =slowNode.Next;
                fastNode =fastNode.Next;
            }
            if (gap == 1)
            {
                return;
            }
            shell_sort_helper((int)Math.Ceiling((double)gap / 2), size);
        }
    }
}
