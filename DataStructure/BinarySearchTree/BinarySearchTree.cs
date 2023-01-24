using System;
using System.Collections.Generic;

namespace DataStructure.BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public enum eTraversalType
        {
            IN_ORDER,
            PRE_ORDER,
            POST_ORDER
        }
        public class Node<T>
        {
            public T value;
            public Node<T> left;
            public Node<T> right;

            public Node(T value) => this.value = value;
        }

        public Node<T> _root { get; set; }
        private Comparer<T> _comparer;

        public BinarySearchTree() => _comparer = Comparer<T>.Default;

        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = CreateNode(value);
                return;
            }

            var root = _root;
            while (true)
            {
                int result = _comparer.Compare(root.value, value);
                if (result < 0)
                {
                    if (root.right == null)
                    {
                        root.right = CreateNode(value);
                        break;
                    }
                    
                    root = root.right;
                }
                else
                {
                    if (root.left == null)
                    {
                        root.left = CreateNode(value);
                        break;
                    }
                    
                    root = root.left;
                }
            }
        }
        
        private Node<T> CreateNode(T value) => new Node<T>(value);

        public void Print(eTraversalType traversalType)
        {
            switch (traversalType)
            {
                case eTraversalType.IN_ORDER:
                    PrintInOrderTravel(_root);
                    break;
                case eTraversalType.PRE_ORDER:
                    PrintPreOrderTravel(_root);
                    break;
                case eTraversalType.POST_ORDER:
                    PrintPostOrderTravel(_root);
                    break;
            }
            
        }

        private void PrintPreOrderTravel(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
         
            Console.WriteLine(node.value);
            PrintPreOrderTravel(node.left);
            PrintPreOrderTravel(node.right);
        }

        private void PrintPostOrderTravel(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
         
            PrintPreOrderTravel(node.left);
            PrintPreOrderTravel(node.right);
            Console.WriteLine(node.value);
        }
        
        private void PrintInOrderTravel(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
         
            PrintPreOrderTravel(node.left);
            Console.WriteLine(node.value);
            PrintPreOrderTravel(node.right);
        }
    }
}