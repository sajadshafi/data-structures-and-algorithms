using DataStructures.Helpers;
using DataStructures.Logic.IServices;
using DataStructures.Logic.Services;

namespace DataStructures.DSConsumers {
    internal class BSTConsumer : IBSTConsumer {
        private readonly IBinarySearchTree<int> _tree;

        public BSTConsumer(IBinarySearchTree<int> tree) {
            _tree = tree;
        }

        public void ExecuteStack() {
            Console.WriteLine();
            Display.Info("---------------------- Doubly Linked List ----------------------\n");
            static bool IsGreater(int x, int y) => x > y;
            while (true) {
                BinarySearchTree<int>.Menu();
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice) {

                    #region Insertion
                    //Insert
                    case 1:
                        Display.Info("Enter value of new Node: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        bool success = _tree.Insert(value, IsGreater);
                        if (success) Display.Success(string.Format("Node inserted successfully!\n\n"));
                        break;
                    #endregion

                    #region Deletion
                    //Remove
                    case 2:
                        Display.Info("Enter value of node to be removed: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        int removedNode = _tree.Remove(value, IsGreater);
                        if (removedNode != default) {
                            Display.Warning(string.Format($"Removed {removedNode} from the tree!\n\n"));
                        } else Display.Error("Tree is empty, Or the node doesn't exist!\n\n");
                        break;
                    #endregion

                    #region Searching
                    //Find a node
                    case 3:
                        Display.Info("Enter value to be found: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        int foundItem = _tree.Find(value, IsGreater);
                        if (foundItem != default) {
                            Display.Success(string.Format($"Item {foundItem} found in tree.\n"));
                        } else Display.Error("Node not found.\n");
                        Console.WriteLine("\n");
                        break;

                    //Get tree node
                    case 4:
                        int rootNode = _tree.GetRoot();
                        if (rootNode != default) {
                            Display.Success(string.Format($"Root node is: {rootNode}.\n"));
                        } else Display.Warning("Tree is empty!\n");
                        Console.WriteLine();
                        break;
                    #endregion

                    //Node count
                    case 5:
                        Display.Success(string.Format($"Node Count is: {_tree.Count}\n"));
                        Console.WriteLine("\n");
                        break;

                    #region Traversal
                    //Pre-OrderTraversal
                    case 6:
                        _tree.PreOrderTraversal();
                        Console.WriteLine("\n\n");
                        break;

                    //In-Order Traversal
                    case 7:
                        _tree.InOrderTraversal();
                        Console.WriteLine("\n\n");
                        break;

                    //Post-Order Traversal
                    case 8:
                        _tree.PostOrderTraversal();
                        Console.WriteLine("\n\n");
                        break;
                    #endregion

                    //Back to previous menu
                    case 0:
                        return;

                    default:
                        Display.Error("! => Invalid Choice Try Again!..\n");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }

    public interface IBSTConsumer {
        void ExecuteStack();
    }
}
