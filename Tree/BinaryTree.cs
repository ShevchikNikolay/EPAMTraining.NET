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
            Root.Add(new Node<T>(value));
            NodeCount++;
        }

        public Node<T> Find(T value)
        {
            return Find(value);
        }

        public void Delete(T value)
        {
            Root.Delete(new Node<T>(value));
            NodeCount--;
        }

        public Node<T> GetMinimumNode()
        {
            return Root.GetMinimum();
        }

        public Node<T> GetMaximumNode()
        {
            return Root.GetMaximum();
        }
        public void Balance()
        {
            List<Node<T>> nodesByAscendingOrder = Root.ByAscendingOrder();
            Root = null;
            MiddlePointAdding(0, nodesByAscendingOrder.Count - 1, nodesByAscendingOrder);

        }
        private void MiddlePointAdding(int leftIndex, int rightIndex, List<Node<T>> list)
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
