using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree;
using Students;

namespace TreeTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void CreatingNodeWithStudentValue()
        {
            //arrange
            Student student = new Student()
            {
                FirstName = "Mark",
                LastName = "Twain",
                TestName = "Math",
                TestDate = Convert.ToDateTime("11/11/2019 1:11:11 PM"),
                Mark = 8
            };


            //action
            var node = new Node<Student>(student);

            //assert

            Assert.AreEqual(student, node.Value);
        }

        [TestMethod]
        public void CreatingNodeWithStringValue()
        {
            //arrange
            string str= "Unique";

            //action

            var node = new Node<string>(str);

            //assert

            Assert.AreEqual(str, node.Value);
        }

        [TestMethod]
        public void TreeBuilding()
        {
            //arrange
            Node<int> node1 = new Node<int>(4);
            Node<int> node2 = new Node<int>(32);
            Node<int> node3 = new Node<int>(20);

            //action

            node1.Add(node2);
            node1.Add(node3);

            //assert

            Assert.IsTrue(node1.LeftChild == null &&
                          node1.RightChild == node2&&
                          node1.RightChild.LeftChild==node3);
        }

        [TestMethod]
        public void DeletingNode()
        {
            //arrange
            Node<int> node1 = new Node<int>(4);
            Node<int> node2 = new Node<int>(32);
            Node<int> node3 = new Node<int>(20);
            node1.Add(node2);
            node1.Add(node3);

            //action
            node1.Delete(node2);

            //assert
            Assert.AreEqual(node1.RightChild, node3);
        }

        [TestMethod]
        public void BalanceTree()
        {
            //arrange
            Node<int> node = new Node<int>(11);
            BinaryTree<int> tree = new BinaryTree<int>(15);
            tree.Root.Add(new Node<int>(14));
            tree.Root.Add(new Node<int>(13));
            tree.Root.Add(new Node<int>(12));
            tree.Root.Add(new Node<int>(11));
            tree.Root.Add(new Node<int>(10));
            tree.Root.Add(new Node<int>(9));
            tree.Root.Add(new Node<int>(8));
            tree.Root.Add(new Node<int>(7));
            tree.Root.Add(new Node<int>(6));
            tree.Root.Add(new Node<int>(5));
            tree.Root.Add(new Node<int>(4));
            tree.Root.Add(new Node<int>(3));
            tree.Root.Add(new Node<int>(2));
            tree.Root.Add(new Node<int>(1));

            //action
            tree.Balance();

            //assert
            Assert.AreEqual(tree.Root.RightChild.LeftChild.RightChild,node);
        }
    }
}
