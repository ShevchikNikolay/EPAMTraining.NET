using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node<T> where T : IComparable<T>
    {
        T Value { get; set; }
        Node<T> Parent { get; set; }
        Node<T> LeftChild { get; set; }
        Node<T> RightChild { get; set; }





        public Node(T value)
        {
            Value = value;
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }





        public static bool operator >(Node<T> left, Node<T> right)
        {
            if (left.Value.CompareTo(right.Value) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Node<T> left, Node<T> right)
        {
            if (left.Value.CompareTo(right.Value) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
