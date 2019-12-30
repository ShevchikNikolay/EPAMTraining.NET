using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    /// <summary>
    /// Describes binary tree;
    /// </summary>
    /// <typeparam name="T"> type of objects, that tree contains</typeparam>
    [Serializable]
    public class BinaryTree<T> where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Collection of nodes. Represents binary tree.
        /// </summary>
        public Node<T> Root { get; private set; }

        /// <summary>
        /// Count of nodes in collection.
        /// </summary>
        public int NodeCount { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinaryTree()
        {
            Root = new Node<T>();
            NodeCount = 0;
        }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="value">value of universal type T.</param>
        public BinaryTree(T value)
        {
            Root = new Node<T>(value);
            NodeCount = 1;
        }

        /// <summary>
        /// Constructor with two parameters.
        /// </summary>
        /// <param name="value">value of universal type T</param>
        /// <param name="comparer">IComparer object</param>
        public BinaryTree(T value, IComparer<T> comparer)
        {
            Root = new Node<T>(value, comparer);
            NodeCount = 1;
        }

        /// <summary>
        /// Incapsulate Node.Add for value.
        /// </summary>
        /// <param name="value">Value of universal type</param>
        public void Add(T value)
        {
            Root.Add(new Node<T>(value));
            NodeCount++;
        }

        /// <summary>
        /// Incapsulate Node.Find method.
        /// </summary>
        /// <param name="value">Value of universal type</param>
        /// <returns></returns>
        public Node<T> Find(T value)
        {
            return Root.Find(value);
        }

        /// <summary>
        /// Method to delete node from tree. Incapsulate Node.Delete
        /// </summary>
        /// <param name="value">Value of universal type</param>
        public void Delete(T value)
        {
            Root.Delete(new Node<T>(value));
            NodeCount--;
        }

        /// <summary>
        /// Method to return node with minimum value.
        /// </summary>
        /// <returns></returns>
        public Node<T> GetMinimumNode()
        {
            return Root.GetMinimum();
        }

        /// <summary>
        /// Method to return node with maximum value.
        /// </summary>
        /// <returns></returns>
        public Node<T> GetMaximumNode()
        {
            return Root.GetMaximum();
        }

        /// <summary>
        /// Bring the tree to balanced state.
        /// </summary>
        public void Balance()
        {
            List<Node<T>> nodesByAscendingOrder = Root.ByAscendingOrder();
            Root = null;
            MiddlePointAdding(0, nodesByAscendingOrder.Count - 1, nodesByAscendingOrder);

        }
        private void MiddlePointAdding(int leftIndex, int rightIndex, List<Node<T>> list)
        {
            if (leftIndex <= rightIndex)
            {
                var middlePoint = (int)Math.Ceiling((leftIndex + rightIndex) / 2.0);
                if (Root == null)
                {
                    Root = list[middlePoint];
                }
                else
                {
                    Root.Add(list[(int)middlePoint]);
                }
                MiddlePointAdding(leftIndex, middlePoint - 1, list);
                MiddlePointAdding(middlePoint + 1, rightIndex, list);
            }
        }
    }
}
