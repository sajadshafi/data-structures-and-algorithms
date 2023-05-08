using Entities.Models;
using System;

namespace DataStructures.Logic.IServices {
    public interface ICustomLinkedList<T> {
        public CustomNode<T> Head { get; set; }

        /// <summary>
        /// Add a node to the end of the Linked list
        /// </summary>
        /// <param name="node">Node that needs to be added</param>
        void Append(CustomNode<T> node);

        /// <summary>
        /// Add a node to the beginning of the LinkedList
        /// </summary>
        /// <param name="node">Takes a node that needs to be inserted</param>
        void Prepend(CustomNode<T> node);

        /// <summary>
        /// Insert a node in the middle of the LinkedList
        /// </summary>
        /// </summary>
        /// <param name="index">The index where the Node will be added</param>
        /// <param name="node">The Node that needs to be inserted</param>
        void Insert(int loc, CustomNode<T> node);

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
        /// <param name="node">Node to be removed</param>
        /// <param name="Compare">Takes a function with two arguements to be compared and returns true if two values are same other false</param>
        /// <returns>Node that has been removed from the Linked List</returns> 
        T Remove(CustomNode<T> node, Func<T, T, bool> Compare);

        /// <summary>
        /// Remove Node at a particular Index
        /// </summary>
        /// <param name="index">Index where the node needs to be removed</param>
        /// <returns>Node that has been removed from the Linked List</returns>
        T Remove(int loc);

        /// <summary>
        /// find if a Node exists in the LinkedList or not
        /// </summary>
        /// <param name="node">Node that we have to find</param>
        /// <returns>True if node is present otherwise false</returns>
        CustomNode<T> Find(T value, Func<T, T, bool> Compare);

        /// <summary>
        /// Check if there is any Node in the LinkedList
        /// </summary>
        /// <returns>true or false based on the presence of any Node in the Linked List</returns>
        bool Any();
    }


    public interface ICustomLinkedList_v2<T> {

        /// <summary>
        /// Number of Nodes present in a LinkedList
        /// </summary>
        int Count { get; }
        CustomNode<T> First { get; set; }
        CustomNode<T> Last { get; set; }

        /// <summary>
        /// Get node at index
        /// </summary>
        /// <param name="index">index of the node to be found</param>
        /// <returns></returns>
        CustomNode<T> Get(int index);

        /// <summary>
        /// set value of a particular node
        /// </summary>
        /// <param name="index">index of the node to be found</param>
        /// <returns></returns>
        bool Set(int index, T newValue);

        bool Contains(T value);

        /// <summary>
        /// Add a node to the end of the Linked list
        /// </summary>
        /// <param name="node">Node that needs to be added</param>
        void Append(CustomNode<T> node);

        /// <summary>
        /// Add a node to the beginning of the LinkedList
        /// </summary>
        /// <param name="node">Takes a node that needs to be inserted</param>
        void Prepend(CustomNode<T> node);

        /// <summary>
        /// Insert a node in the middle of the LinkedList
        /// </summary>
        /// </summary>
        /// <param name="index">The index where the Node will be added</param>
        /// <param name="node">The Node that needs to be inserted</param>
        bool Insert(int index, CustomNode<T> node);

        /// <summary>
        /// Remove the last Node of the LinkedList
        /// </summary>
        /// <returns>Node that has been removed from the Linked List</returns>
        CustomNode<T> RemoveLast();

        /// <summary>
        /// Remove the first Node of the LinkedList
        /// </summary>
        /// <returns>Node that has been removed from the Linked List</returns>
        CustomNode<T> RemoveFirst();


        /// <summary>
        /// Removes a particular node any where in the LinkedList
        /// </summary>
        /// <param name="node">Node to be removed</param>
        /// <param name="Compare">Takes a function with two arguements to be compared and returns true if two values are same other false</param>
        /// <returns>Node that has been removed from the Linked List</returns> 
        CustomNode<T> Remove(CustomNode<T> node);

        /// <summary>
        /// Remove Node at a particular Index
        /// </summary>
        /// <param name="index">Index where the node needs to be removed</param>
        /// <returns>Node that has been removed from the Linked List</returns>
        CustomNode<T> RemoveAt(int index);

        /// <summary>
        /// find if a Node exists in the LinkedList or not
        /// </summary>
        /// <param name="node">Node that we have to find</param>
        /// <returns>True if node is present otherwise false</returns>
        CustomNode<T> Find(T value);

        /// <summary>
        /// Reverse a linked list
        /// </summary>
        void Reverse();

        /// <summary>
        /// Visit nodes of a linked list
        /// </summary>
        void Traverse();
    }
}
