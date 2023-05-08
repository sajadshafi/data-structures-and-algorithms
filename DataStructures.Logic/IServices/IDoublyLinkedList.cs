using Entities.Models;

namespace DataStructures.Logic.IServices {
    public interface IDoublyLinkedList<T> {

        /// <summary>
        /// Number of Nodes present in a LinkedList
        /// </summary>
        int Count { get; }
        DLLNode<T> First { get; set; }
        DLLNode<T> Last { get; set; }

        /// <summary>
        /// Get node at index
        /// </summary>
        /// <param name="index">index of the node to be found</param>
        /// <returns></returns>
        DLLNode<T> Get(int index);

        /// <summary>
        /// set value of a particular node
        /// </summary>
        /// <param name="index">index of the node to be found</param>
        /// <param name="value">value to be inserted in DLL</param>
        /// <returns></returns>
        bool Set(int index, T value);

        bool Contains(T value);

        /// <summary>
        /// Add a node to the end of the Linked list
        /// </summary>
        /// <param name="value">Node that needs to be added</param>
        void Append(T value);

        /// <summary>
        /// Add a node to the beginning of the LinkedList
        /// </summary>
        /// <param name="value">Takes a node that needs to be inserted</param>
        void Prepend(T value);

        /// <summary>
        /// Insert a node in the middle of the LinkedList
        /// </summary>
        /// </summary>
        /// <param name="index">The index where the Node will be added</param>
        /// <param name="value">value of the Node that needs to be inserted</param>
        bool Insert(int index, T value);

        /// <summary>
        /// Remove the last Node of the LinkedList
        /// </summary>
        /// <returns>Node that has been removed from the Linked List</returns>
        T RemoveLast();

        /// <summary>
        /// Remove the first Node of the LinkedList
        /// </summary>
        /// <returns>Node that has been removed from the Linked List</returns>
        T RemoveFirst();


        /// <summary>
        /// Removes a particular node any where in the LinkedList
        /// </summary>
        /// <param name="value">Node to be removed</param>
        /// <param name="Compare">Takes a function with two arguements to be compared and returns true if two values are same other false</param>
        /// <returns>Node that has been removed from the Linked List</returns> 
        T Remove(T value);

        /// <summary>
        /// Remove Node at a particular Index
        /// </summary>
        /// <param name="index">Index where the node needs to be removed</param>
        /// <returns>Node that has been removed from the Linked List</returns>
        T RemoveAt(int index);

        /// <summary>
        /// find if a Node exists in the LinkedList or not
        /// </summary>
        /// <param name="value">Node that we have to find</param>
        /// <returns>True if node is present otherwise false</returns>
        T Find(T value);

        /// <summary>
        /// Reverse a linked list
        /// </summary>
        void TraverseReverse();

        /// <summary>
        /// Visit nodes of a linked list
        /// </summary>
        void Traverse();
    }
}
