using DataStructures.Helpers;
using DataStructures.Logic.IServices;
using DataStructures.Logic.Services;
using Entities.Models;

namespace DataStructures.DSConsumers {
    public class LinkedListConsumer : ILinkedListConsumer {
        private readonly ICustomLinkedList<int> _list;
        private readonly ICustomLinkedList_v2<int> _listv2;
        public LinkedListConsumer(ICustomLinkedList<int> list, ICustomLinkedList_v2<int> listv2) {
            _list = list;
            _listv2 = listv2;
        }
        public void ExecuteStack() {
            Console.WriteLine();
            Display.Info("---------------------- Linked List Version 1.0 ----------------------\n");
            static bool isEqual(int x, int y) => x == y;
            while (true) {
                CustomLinkedList<int>.Menu();
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice) {

                    //Append a node at end
                    case 1:
                        Display.Info("Enter value of new Node: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        _list.Append(new CustomNode<int>() { Value = value });
                        Display.Success("-> Node Appended Successfully.\n");
                        Console.WriteLine();
                        break;

                    //Prepend a node at beginning
                    case 2:
                        Display.Info("Enter value of new Node: ");
                        _list.Prepend(new CustomNode<int>() { Value = Convert.ToInt32(Console.ReadLine()) });
                        Display.Success("-> Node Prepended Successfully.\n");
                        Console.WriteLine();
                        break;

                    //Insert in middle of list
                    case 3:
                        Display.Info("Enter location for new Node: ");
                        int location = Convert.ToInt32(Console.ReadLine());
                        Display.Info("Enter value of new Node: ");
                        int val = Convert.ToInt32(Console.ReadLine());
                        _list.Insert(location, new CustomNode<int>() { Value = val });
                        Console.WriteLine("\n");
                        break;

                    //Remove first node
                    case 4:
                        int removedNode = _list.RemoveFirst();
                        if (removedNode != default) {
                            Display.Warning(string.Format("Removed {0} from the list!", removedNode));
                        }
                        Console.WriteLine("\n");
                        break;

                    //Remove last node
                    case 5:
                        removedNode = _list.RemoveLast();
                        if (removedNode != default) {
                            Display.Warning(string.Format("Removed {0} from the list!", removedNode));
                        }
                        Console.WriteLine("\n");
                        break;

                    //Remove a node value
                    case 6:
                        if (_list.Head is null) {
                            Display.Error("List is empty\n");
                        } else {
                            Display.Info("Enter Node to remove: ");
                            int nodeValue = Convert.ToInt32(Console.ReadLine());
                            removedNode = _list.Remove(new CustomNode<int> { Value = nodeValue }, isEqual);
                            if (removedNode != default) {
                                Display.Warning(string.Format("Removed {0} from the list!", removedNode));
                            }
                        }
                        Console.WriteLine("\n");
                        break;

                    //Remove middle node at a particular location
                    case 7:
                        if (_list.Head is null) {
                            Display.Error("List is empty\n");
                        } else {
                            Display.Info("Enter location for new Node: ");
                            location = Convert.ToInt32(Console.ReadLine());
                            removedNode = _list.Remove(location);
                            if (removedNode != default) {
                                Display.Warning(string.Format("Removed {0} from the list!", removedNode));
                            }
                        }
                        Console.WriteLine("\n");
                        break;

                    //Find a node
                    case 8:
                        Display.Info("Enter Node value to find: ");
                        value = Convert.ToInt32(Console.ReadLine());

                        CustomNode<int> searchedNode = _list.Find(value, isEqual);

                        if (searchedNode != default) {
                            Display.Success(string.Format("Node {0} is present in the list!", searchedNode.Value));
                        } else {
                            Display.Warning(string.Format("Node {0} doesn't exist in the list!", value));
                        }
                        Console.WriteLine("\n");
                        break;

                    //Is there any node present in the list
                    case 9:
                        Display.Warning(string.Format("{0}\n", _list.Any() ? "No" : "Yes"));
                        Console.WriteLine();
                        break;

                    //Traverse nodes of a list
                    case 10:
                        CustomNode<int> currentNode = _list.Head;
                        Display.MainMenu("Linked List: ");
                        while (currentNode != null) {
                            Display.Success("  " + currentNode.Value);
                            currentNode = currentNode.Next;
                        }
                        Console.WriteLine("\n");
                        break;

                    //Back to previous menu
                    case 0:
                        _list.Head = null;
                        return;

                    default:
                        Display.Error("! => Invalid Choice Try Again!..\n");
                        Console.WriteLine();
                        break;
                }
            }
        }

        public void ExecuteStack_v2() {
            Console.WriteLine();
            Display.Info("---------------------- Linked List Version 2.0 ----------------------\n");
            while (true) {
                CustomLinkedList_v2<int>.Menu();
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice) {

                    #region Insertion
                    //Append node at beginning
                    case 1:
                        Display.Info("Enter value of new Node: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        _listv2.Append(new CustomNode<int>(value));
                        Display.Success("-> Node Appended Successfully.\n");
                        Console.WriteLine();
                        break;

                    //Prepend a node at beginning
                    case 2:
                        Display.Info("Enter value of new Node: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        _listv2.Prepend(new CustomNode<int>(value));
                        Display.Success("-> Node Prepended Successfully.\n");
                        Console.WriteLine();
                        break;

                    //Insert at index
                    case 3:
                        Display.Info("Enter index for new Node: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Display.Info("Enter value of new Node: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        bool success = _listv2.Insert(index, new CustomNode<int>(value));
                        if(success) Display.Success(string.Format("Node inserted successfully at {0}", index));
                        Console.WriteLine("\n");
                        break;
                    #endregion

                    #region Deletion
                    //Remove first node
                    case 4:
                        CustomNode<int> removedNode = _listv2.RemoveFirst();
                        if (removedNode is not null) {
                            Display.Warning(string.Format("Removed {0} from the list!\n", removedNode.Value));
                        } else Display.Error("List is empty!\n");
                        Console.WriteLine("\n");
                        break;

                    //Remove last node
                    case 5:
                        removedNode = _listv2.RemoveLast();
                        if (removedNode is not null) {
                            Display.Warning(string.Format("Removed {0} from the list!\n", removedNode.Value));
                        } else Display.Error("List is empty!\n");
                        Console.WriteLine("\n");
                        break;

                    //Remove a node value
                    case 6:
                        Display.Info("Enter Node to remove: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        removedNode = _listv2.Remove(new CustomNode<int>(value));
                        if (removedNode is not null) {
                            Display.Warning(string.Format("Removed {0} from the list!\n", removedNode.Value));
                        } else Display.Error("Node not found!\n");
                        Console.WriteLine("\n");
                        break;

                    //Remove middle node at a particular index
                    case 7:
                        Display.Info("Enter index for new Node: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        removedNode = _listv2.RemoveAt(index);
                        if (removedNode is not null) {
                            Display.Warning(string.Format("Removed {0} from the list!\n", removedNode.Value));
                        } else Display.Error("Index not valid!\n");
                        Console.WriteLine("\n");
                        break;
                    #endregion

                    #region Searching
                    //Find a node
                    case 8:
                        Display.Info("Enter Node value to find: ");
                        value = Convert.ToInt32(Console.ReadLine());

                        CustomNode<int> searchedNode = _listv2.Find(value);

                        if (searchedNode != default) {
                            Display.Success(string.Format("Node {0} is present in the list!\n", searchedNode.Value));
                        } else {
                            Display.Warning(string.Format("Node {0} doesn't exist in the list!\n", value));
                        }
                        Console.WriteLine("\n");
                        break;

                    //Get node at index
                    case 9:
                        Display.Info("Enter index: ");
                        value = Convert.ToInt32(Console.ReadLine());

                        searchedNode = _listv2.Get(value);

                        if (searchedNode is not null) {
                            Display.Success(string.Format("Node {0} is found!\n", searchedNode.Value));
                        }
                        Console.WriteLine("\n");
                        break;

                    //Get first node
                    case 10:
                        if (_listv2.First is not null) {
                            Display.Success(string.Format("First node is: {0}\n", _listv2.First.Value));
                        } else Display.Warning("List is empty!\n");
                        break;
                    
                    //Get last node
                    case 11:
                        if (_listv2.Last is not null) {
                            Display.Success(string.Format("Last node is: {0}\n", _listv2.Last.Value));
                        } else Display.Warning("List is empty!\n");
                        Console.WriteLine();
                        break;

                    //Check if list contains a node
                    case 12:
                        Display.Info("Enter Node value to check: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        if (_listv2.Contains(value)) {
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
                        bool result = _listv2.Set(index, value);
                        if (result) Display.Success(string.Format("Node at index {0} updated successfully\n", index));
                        else Display.Error(string.Format("Failed to update node at index {0}\n", index));
                        Console.WriteLine("\n");
                        break;

                    //Reverse node
                    case 14:
                        _listv2.Reverse();
                        Display.Success(string.Format("List reversed successfully!\n\n"));
                        break;
                    #endregion

                    //Node Count of a list
                    case 15:
                        Display.Success(string.Format("Node Count is: {0}\n", _listv2.Count));
                        Console.WriteLine("\n");
                        break;

                    //Traverse nodes of a list
                    case 16:
                        _listv2.Traverse();
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

    public interface ILinkedListConsumer {
        void ExecuteStack();

        void ExecuteStack_v2();
    }
}
