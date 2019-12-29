using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    [Serializable]
    public class Node<T> : IEquatable<Node<T>>, IComparable<Node<T>>, IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {

        private delegate int SortHandler(T firstItem, T secondItem);
        private static SortHandler comparer;

        
        public T Value { get; set; }
        private Node<T> Parent { get; set; }
        private Node<T> LeftChild { get; set; }
        private Node<T> RightChild { get; set; }



        static Node()
        {
            comparer = (x, y) => { return x.CompareTo(y); };
        }

        public Node()
        {
            Value = default(T);
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }
        public Node(T value)
        {
            Value = value;
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }

        public Node(T value, IComparer<T> comparer) : this(value)
        {
            Node<T>.comparer = (x, y) => comparer.Compare(x, y);
        }


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

        public Node<T> Find(T value)
        {
            return Find(new Node<T>(value));
        }
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

        public void SortWith(IComparer<T> comparer)
        {
            Node<T>.comparer = (x, y) => comparer.Compare(x, y);
        }

        
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

        public bool Equals(Node<T> other)
        {
            return other != null &&
                   EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public int CompareTo(Node<T> other)
        {
            return comparer(Value, other.Value);
        }

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
