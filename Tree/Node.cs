using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node<T> : IEquatable<Node<T>>, IComparable<Node<T>> where T : IComparable<T>, IEquatable<T>
    {

        private delegate int SortHandler (T firstItem, T secondItem);
        private static SortHandler comparer;

        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }




        private Node(T value)
        {
            Value = value;
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }
        public Node(T value, IComparer<T> comparer)
        {
            Value = value;
            Parent = null;
            LeftChild = null;
            RightChild = null;
            Node<T>.comparer = (x, y) => comparer.Compare(x, y);
        }



        public void Add(T value)
        {
            Add(new Node<T>(value));
        }
        private void Add(Node<T> node)
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
                    if(LeftChild!= null)
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
            throw new NotImplementedException();
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

        public Node<T> GetAverage()
        {
            throw new NotImplementedException();
        }

        public void SortWith(IComparer<T> comparer)
        {
            Node<T>.comparer = (x, y) => comparer.Compare(x,y);
            Balance();
        }

        public void Balance()
        {
            throw new NotImplementedException();
        }

        public List<T> ByAscendingOrder()
        {
            var result = new List<T>();

            if (LeftChild != null)
            {
                result.AddRange(LeftChild.ByAscendingOrder());
            }
            result.Add(Value);
            if (RightChild != null)
            {
                result.AddRange(RightChild.ByAscendingOrder());
            }

            return result;
        }
        
        public List<T> ByDescendingOrder()
        {
            var result = new List<T>();

            if (RightChild != null)
            {
                result.AddRange(RightChild.ByAscendingOrder());
            }
            result.Add(Value);
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
    }
}
