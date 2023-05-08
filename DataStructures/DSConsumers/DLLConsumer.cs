using DataStructures.Helpers;
using DataStructures.Logic.IServices;
using DataStructures.Logic.Services;
using Entities.Models;

namespace DataStructures.DSConsumers {
    public class DLLConsumer : IDLLConsumer {

        private readonly IDoublyLinkedList<int> _list;
        public DLLConsumer(IDoublyLinkedList<int> list) {
            _list = list;
        }

        public void ExecuteStack() {
            Console.WriteLine();
            Display.Info("---------------------- Doubly Linked List ----------------------\n");
            while (true) {
                DoublyLinkedList<int>.Menu();
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice) {

                    #region Insertion
                    //Append node at beginning
                    case 1:
                        Display.Info("Enter value of new Node: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        _list.Append(value);
                        Display.Success("-> Node Appended Successfully.\n");
                        Console.WriteLine();
                        break;

                    //Prepend a node at beginning
                    case 2:
                        Display.Info("Enter value of new Node: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        _list.Prepend(value);
                        Display.Success("-> Node Prepended Successfully.\n");
                        Console.WriteLine();
                        break;

                    //Insert at index
                    case 3:
                        Display.Info("Enter index for new Node: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Display.Info("Enter value of new Node: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        bool success = _list.Insert(index, value);
                        if (success) Display.Success(string.Format("Node inserted successfully at {0}", index));
                        Console.WriteLine("\n");
                        break;
                    #endregion

                    #region Deletion
                    //Remove first node
                    case 4:
                        int removedNode = _list.RemoveFirst();
                        if (removedNode != default) {
                            Display.Warning(string.Format("Removed {0} from the list!\n", removedNode));
                        } else Display.Error("List is empty!\n");
                        Console.WriteLine("\n");
                        break;

                    //Remove last node
                    case 5:
                        removedNode = _list.RemoveLast();
                        if (removedNode != default) {
                            Display.Warning(string.Format("Removed {0} from the list!\n", removedNode));
                        } else Display.Error("List is empty!\n");
                        Console.WriteLine("\n");
                        break;

                    //Remove a node value
                    case 6:
                        Display.Info("Enter Node to remove: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        removedNode = _list.Remove(value);
                        if (removedNode != default) {
                            Display.Warning(string.Format("Removed {0} from the list!\n", removedNode));
                        } else Display.Error("Node not found!\n");
                        Console.WriteLine("\n");
                        break;

                    //Remove middle node at a particular index
                    case 7:
                        Display.Info("Enter index for new Node: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        removedNode = _list.RemoveAt(index);
                        if (removedNode != default) {
                            Display.Warning(string.Format("Removed {0} from the list!\n", removedNode));
                        } else Display.Error("Index not valid!\n");
                        Console.WriteLine("\n");
                        break;
                    #endregion

                    #region Searching
                    //Find a node
                    case 8:
                        Display.Info("Enter Node value to find: ");
                        value = Convert.ToInt32(Console.ReadLine());

                        int searchedNode = _list.Find(value);

                        if (searchedNode != default) {
                            Display.Success(string.Format("Node {0} is present in the list!\n", searchedNode));
                        } else {
                            Display.Warning(string.Format("Node {0} doesn't exist in the list!\n", value));
                        }
                        Console.WriteLine("\n");
                        break;

                    //Get node at index
                    case 9:
                        Display.Info("Enter index: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        DLLNode<int> node = _list.Get(value);
                        if (node is not null) {
                            Display.Success(string.Format("Node {0} is found!\n", node.Value));
                        }
                        Console.WriteLine("\n");
                        break;

                    //Get first node
                    case 10:
                        if (_list.First is not null) {
                            Display.Success(string.Format("First node is: {0}\n", _list.First.Value));
                        } else Display.Warning("List is empty!\n");
                        Console.WriteLine();
                        break;

                    //Get last node
                    case 11:
                        if (_list.Last is not null) {
                            Display.Success(string.Format("Last node is: {0}\n", _list.Last.Value));
                        } else Display.Warning("List is empty!\n");
                        Console.WriteLine();
                        break;

                    //Check if list contains a node
                    case 12:
                        Display.Info("Enter Node value to check: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        if (_list.Contains(value)) {
                            Display.Success("Yes, List contains the value!\n");
                        } else Display.Error("No, List does not contain the value!\n");
                        Console.WriteLine();
                        break;
                    #endregion

                    #region Updation
                    //Update node
                    case 13:
                        Display.Info("Enter index to update: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        Display.Info("Enter new value: ");
                        value = Convert.ToInt32(Console.ReadLine());

                        bool result = _list.Set(index, value);
                        if (result) Display.Success(string.Format("Node at index {0} updated successfully\n", index));
                        else Display.Error(string.Format("Failed to update node at index {0}\n", index));
                        Console.WriteLine("\n");
                        break;

                    //Reverse node
                    case 14:
                        _list.TraverseReverse();
                        Console.WriteLine();
                        break;
                    #endregion

                    //Node Count of a list
                    case 15:
                        Display.Success(string.Format("Node Count is: {0}\n", _list.Count));
                        Console.WriteLine("\n");
                        break;

                    //Traverse nodes of a list
                    case 16:
                        _list.Traverse();
                        Console.WriteLine("\n");
                        break;

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

    public interface IDLLConsumer {
        void ExecuteStack();
    }
}
