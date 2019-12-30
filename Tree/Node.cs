using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{/// <summary>
/// Describes node of tree.
/// </summary>
/// <typeparam name="T">Universal type</typeparam>
    [Serializable]
    public class Node<T> : IEquatable<Node<T>>, IComparable<Node<T>>, IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {

        private delegate int SortHandler(T firstItem, T secondItem);
        private static SortHandler comparer;

        /// <summary>
        /// Value of universal type.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Reference to parent node.
        /// </summary>
        public Node<T> Parent { get; set; }

        /// <summary>
        /// Reference to left child node.
        /// </summary>
        public Node<T> LeftChild { get; set; }

        /// <summary>
        /// Reference to right child node.
        /// </summary>
        public Node<T> RightChild { get; set; }



        static Node()
        {
            comparer = (x, y) => { return x.CompareTo(y); };
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Node()
        {
            Value = default(T);
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }

        /// <summary>
        /// Initialize new instance of node with universal type value.
        /// </summary>
        /// <param name="value">universal type value</param>
        public Node(T value)
        {
            Value = value;
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }

        /// <summary>
        /// Initialize new instance of node with universal type value and IComparer object
        /// </summary>
        /// <param name="value">universal type value</param>
        /// <param name="comparer">IComparer object</param>
        public Node(T value, IComparer<T> comparer) : this(value)
        {
            Node<T>.comparer = (x, y) => comparer.Compare(x, y);
        }

        /// <summary>
        /// Method to add a node to the tree
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node<T> node)
        {
            if (this > node)
            {
                if (LeftChild != null)
                {
                    LeftChild.Add(node);
                }
                else
                {
                    LeftChild = node;
                    LeftChild.Parent = this;
                }
            }
            else
            {
                if (RightChild != null)
                {
                    RightChild.Add(node);
                }
                else
                {
                    RightChild = node;
                    RightChild.Parent = this;
                }
            }
        }

        /// <summary>
        /// method to find node by value.
        /// </summary>
        /// <param name="value">universal type value</param>
        /// <returns></returns>
        public Node<T> Find(T value)
        {
            return Find(new Node<T>(value));
        }

        /// <summary>
        /// Method to find the node in the tree.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public Node<T> Find(Node<T> node)
        {
            switch (CompareTo(node))
            {
                case var r when r < 0:
                    if (RightChild != null)
                    {
                        return RightChild.Find(node);
                    }
                    else
                    {
                        return null;
                    }

                case var r when r == 0:
                    if (Value.Equals(node.Value))
                    {
                        return this;
                    }
                    else
                    {
                        return RightChild.Find(node);
                    }

                case var r when r > 0:
                    if (LeftChild != null)
                    {
                        return LeftChild.Find(node);
                    }
                    else
                    {
                        return null;
                    }
            }
            return null;
        }

        /// <summary>
        /// Method to delete node from tree.
        /// </summary>
        /// <param name="node">The node.</param>
        public void Delete(Node<T> node)
        {
            var nodeToDelete = Find(node);
            var parent = nodeToDelete.Parent;
            var leftBranch = nodeToDelete.LeftChild;
            var rightBranch = nodeToDelete.RightChild;
            if (parent.LeftChild == nodeToDelete)
            {
                parent.LeftChild = null;
            }
            else
            {
                parent.RightChild = null;
            }
            if (leftBranch != null)
            {
                parent.Add(leftBranch);
            }
            if (rightBranch != null)
            {
                parent.Add(rightBranch);
            }
        }

        /// <summary>
        /// Method to find node with minimum value.
        /// </summary>
        /// <returns></returns>
        public Node<T> GetMinimum()
        {
            if (LeftChild != null)
            {
                return LeftChild.GetMinimum();
            }
            else
            {
                return this;
            }
        }

        /// <summary>
        /// Method to find node with maximum value.
        /// </summary>
        /// <returns></returns>
        public Node<T> GetMaximum()
        {
            if (RightChild != null)
            {
                return RightChild.GetMaximum();
            }
            else
            {
                return this;
            }
        }

        /// <summary>
        /// Method to set comparer to sort value objects.
        /// </summary>
        /// <param name="comparer"></param>
        public void SortWith(IComparer<T> comparer)
        {
            Node<T>.comparer = (x, y) => comparer.Compare(x, y);
        }

        /// <summary>
        /// Method to get list of nodes of the tree sorted by ascending order.
        /// </summary>
        /// <returns></returns>
        public List<Node<T>> ByAscendingOrder()
        {
            var result = new List<Node<T>>();

            if (LeftChild != null)
            {
                result.AddRange(LeftChild.ByAscendingOrder());
            }
            result.Add(this);
            if (RightChild != null)
            {
                result.AddRange(RightChild.ByAscendingOrder());
            }

            return result;
        }

        /// <summary>
        /// Method to get list of nodes of the tree sorted by descending order. 
        /// </summary>
        /// <returns></returns>
        public List<Node<T>> ByDescendingOrder()
        {
            var result = new List<Node<T>>();

            if (RightChild != null)
            {
                result.AddRange(RightChild.ByAscendingOrder());
            }
            result.Add(this);
            if (LeftChild != null)
            {
                result.AddRange(LeftChild.ByAscendingOrder());
            }

            return result;
        }


        /// <summary>
        /// Override operator "less than".
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns></returns>
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

        /// <summary>
        /// Override operator "greater than".
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns></returns>
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

        /// <summary>
        /// Override method Object.Equals()
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Node<T> item && Value.CompareTo(item.Value) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Implementation of IEquatable interface
        /// </summary>
        /// <param name="other">Node to compare</param>
        /// <returns></returns>
        public bool Equals(Node<T> other)
        {
            return other != null &&
                   EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        /// <summary>
        /// Override Object.GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);
        }

        /// <summary>
        /// Implementation of IComparable interface.
        /// </summary>
        /// <param name="other"> Node to compare</param>
        /// <returns></returns>
        public int CompareTo(Node<T> other)
        {
            return comparer(Value, other.Value);
        }

        /// <summary>
        /// Implementation of IEnumerable interface
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new NodeEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class NodeEnumerator : IEnumerator<T>
        {
            private readonly Node<T> node;
            private Node<T> currentNode;
            private Stack<Node<T>> stack;

            public NodeEnumerator(Node<T> node)
            {
                this.node = node;
                this.node.GetMinimum().Add(new Node<T>());
                stack = new Stack<Node<T>>();
            }

            public T Current
            {
                get
                {
                    if (currentNode.Value == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return currentNode.Value;
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (currentNode.RightChild != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.RightChild.GetMinimum();
                    return true;
                }
                else
                {
                    while (currentNode.Parent == stack.Peek())
                    {
                        currentNode = stack.Pop();
                        
                    }
                    if (currentNode.Parent == null)
                    {
                        return false;
                    }
                    currentNode = currentNode.Parent;
                    return true;
                }
            }

            public void Reset()
            {
                currentNode = node.GetMinimum().LeftChild;
            }
        }
    }
}
