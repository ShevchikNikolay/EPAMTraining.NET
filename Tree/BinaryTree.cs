using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    [Serializable]
    public class BinaryTree<T> where T : IComparable<T>, IEquatable<T>
    {
        public Node<T> Root { get; private set; }
        public int NodeCount { get; private set; }


        public BinaryTree(List<T> values, IComparer<T> comparer)
        {
            throw new NotImplementedException();
        }
        public BinaryTree(T value, IComparer<T> comparer)
        {
            Root = new Node<T>(value, comparer);
            NodeCount = 1;
        }

        public void Add(T value)
        {
            Root.Add(value);
            NodeCount++;
        }

        public Node<T> Find(T value)
        {
            return Find(value);
        }

        public Node<T> GetMinimumNode()
        {
            return Root.GetMinimum();
        }

        public Node<T> GetMaximumNode()
        {
            return Root.GetMaximum();
        }
    }
}
