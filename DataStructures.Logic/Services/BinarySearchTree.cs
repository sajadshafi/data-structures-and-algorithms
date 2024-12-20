using DataStructures.Helpers;
using DataStructures.Logic.IServices;
using Entities.Models;
using System.Xml.Linq;

namespace DataStructures.Logic.Services {
    public class BinarySearchTree<T> : IBinarySearchTree<T> {

        #region Private section
        private readonly EqualityComparer<T> _comparer;
        private BSTNode<T> _root;
        private int _size = 0;
        #endregion

        #region Constructors
        public BinarySearchTree() {
            _comparer = EqualityComparer<T>.Default;
            _root = null;
        }
        #endregion

        public int Count { get { return _size; } }

        public bool Insert(T node, Func<T, T, bool> IsGreater) {
            BSTNode<T> newNode = new(node);
            if (_root == null) {
                _root = newNode;
                _size++;
                return true;
            }
            BSTNode<T> temp = _root;
            BSTNode<T> prev = temp;
            while(temp != null) {
                if (_comparer.Equals(temp.Value, node)) return false;
                prev = temp;
                if (IsGreater(node, temp.Value)) temp = temp.Right;
                else if(IsGreater(temp.Value, node)) temp = temp.Left;
            }

            if (IsGreater(node, prev.Value)) prev.Right = newNode;
            else if (IsGreater(prev.Value, node)) prev.Left = newNode;

            _size++;
            return true;
        }
        
        public T Remove(T node, Func<T, T, bool> IsGreater) {
            if (_root == null) return default;
            BSTNode<T> temp;
            if(_root.Left is null && _root.Right is null) {
                temp = _root;
                _root = null;
                _size--;
                return temp.Value;
            }
            else {
                BSTNode<T> current = _root;
                BSTNode<T> prev = current;
                while (current != null && !_comparer.Equals(current.Value, node)) {
                    prev = current;
                    if (IsGreater(node, current.Value)) current = current.Right;
                    else if (IsGreater(current.Value, node)) current = current.Left;
                }

                if (current == null) return default;

                prev.Right = current.Right;

                temp = current.Right;
                while (temp.Left != null) {
                    temp = temp.Left;
                }
                temp.Left = current.Left;

                current.Right = current.Left = null;

                _size--;
                return current.Value;
            }
        }

        public void PreOrderTraversal() {
            if (_root == null) {
                Display.Error("Tree is empty.\n");
                return;
            }
            Display.MainMenu("Tree nodes are:  ");
            PreOrderTraverse(_root);
        }

        public void InOrderTraversal() {
            if (_root == null) {
                Display.Error("Tree is empty.\n");
                return;
            }
            Display.MainMenu("Tree nodes are:  ");
            InOrderTraverse(_root);
        }

        public void PostOrderTraversal() {
            if (_root == null) {
                Display.Error("Tree is empty.\n");
                return;
            }
            Display.MainMenu("Tree nodes are:  ");
            PostOrderTraverse(_root);
        }

        public T GetRoot() {
            if (_root == null) return default;
            return _root.Value;
        }
        public T Find(T node, Func<T, T, bool> IsGreater) {
            BSTNode<T> temp = _root;
            while(temp != null && !_comparer.Equals(temp.Value, node)) {
                if (IsGreater(node, temp.Value)) temp = temp.Right;
                else if (IsGreater(temp.Value, node)) temp = temp.Left;
            }

            if(temp == null) return default;
            return temp.Value;
        }

        #region private section
        private void PreOrderTraverse(BSTNode<T> root) {
            if(root == null) return;

            Display.Success($"{root.Value}  ");
            PreOrderTraverse(root.Left);
            PreOrderTraverse(root.Right);
        }

        private void InOrderTraverse(BSTNode<T> root) {
            if (root == null) return;

            InOrderTraverse(root.Left);
            Display.Success($"{root.Value}  ");
            InOrderTraverse(root.Right);
        }

        private void PostOrderTraverse(BSTNode<T> root) {
            if (root == null) return;

            PostOrderTraverse(root.Left);
            PostOrderTraverse(root.Right);
            Display.Success($"{root.Value}  ");
        }
        #endregion

        public static void Menu() {
            //Insertion
            Display.Info("1.  Insert a node.\n");
            Display.Info("2.  Remove a Node.\n");

            //searching
            Display.Info("3.  Find a Node.\n");
            Display.Info("4.  Get root node.\n");

            Display.Info("5.  Get Node Count.\n");
            Display.Info("6.  Pre Order Traversal.\n");
            Display.Info("7.  In Order Traversal.\n");
            Display.Info("8.  Post Order Traversal.\n");
            Display.Info("0.  Back.\n");
            Display.MainMenu("Please Enter you choice: ");
        }
    }
}
