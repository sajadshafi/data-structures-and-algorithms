using DataStructures.Helpers;
using DataStructures.Logic.IServices;
using Entities.Models;

namespace DataStructures.Logic.Services {
    public class CustomLinkedList<T> : ICustomLinkedList<T> {
        public CustomNode<T> Head { get; set; }
        public void Append(CustomNode<T> node) {
            if (Head == null) {
                Head = node;
                return;
            }

            CustomNode<T> currentNode = Head;
            while (currentNode.Next != null) {
                currentNode = currentNode.Next;
            }
            currentNode.Next = node;
        }

        public void Prepend(CustomNode<T> node) {
            if (Head == null) {
                Head = node;
                return;
            }

            node.Next = Head;
            Head = node;
        }

        public void Insert(int loc, CustomNode<T> node) {
            CustomNode<T> currentNode = Head;
            int i = 1;
            while (i < loc - 1 && currentNode.Next != null) {
                currentNode = currentNode.Next;
                i += 1;
            }

            if (i < loc - 1) {
                Display.Error(string.Format("Failed to insert Node, location is larger than the size of the list\n"));
                return;
            }

            node.Next = currentNode.Next;
            currentNode.Next = node;
            Display.Success("-> Node Inserted Successfully.\n");
        }

        public T RemoveFirst() {
            if (Head is null) {
                Display.Error("List is empty!");
                return default;
            }

            CustomNode<T> firstNode = Head;
            Head = firstNode.Next;
            return firstNode.Value;
        }

        public T RemoveLast() {
            if (Head is null) {
                Display.Error("List is empty!");
                return default;
            }

            CustomNode<T> currentNode = Head;
            while (currentNode.Next.Next is not null) {
                currentNode = currentNode.Next;
            }
            T removedNode = currentNode.Next.Value;
            currentNode.Next = null;
            return removedNode;
        }

        public T Remove(CustomNode<T> node, Func<T, T, bool> Compare) {
            CustomNode<T> currentNode = Head;
            T removedNode;
            if (Compare(Head.Value, node.Value)) {
                removedNode = Head.Value;
                Head = Head.Next;
                return removedNode;
            }

            while (currentNode.Next != null) {
                if (Compare(currentNode.Next.Value, node.Value)) {
                    break;
                }

                currentNode = currentNode.Next;
            }

            if (currentNode.Next == null) return default;

            removedNode = currentNode.Next.Value;
            currentNode.Next = currentNode.Next.Next;
            return removedNode;
        }

        public T Remove(int loc) {
            T removedNode;
            if (loc == 1) {
                removedNode = Head.Value;
                Head = Head.Next;
                return removedNode;
            }

            int i = 1;
            CustomNode<T> currentNode = Head;

            while (currentNode.Next.Next is not null) {
                if (i == loc - 1) { break; }
                currentNode = currentNode.Next;
                i += 1;
            }

            if (loc > i + 1) {
                Display.Error("Location doesn't exist!");
                return default;
            }

            //if(i == loc - 1) {
            //    removedNode = currentNode.Next.Value;
            //    currentNode.Next = null;
            //    return removedNode;
            //}

            removedNode = currentNode.Next.Value;
            currentNode.Next = currentNode.Next.Next;
            return removedNode;

        }

        public CustomNode<T> Find(T value, Func<T, T, bool> Compare) {
            CustomNode<T> currentNode = Head;
            while (currentNode is not null) {
                if (Compare(currentNode.Value, value))
                    return currentNode;

                currentNode = currentNode.Next;
            }

            return default;
        }

        public bool Any() {
            return Head is not null;
        }

        public static void Menu() {
            Display.Info("1. Append a new Node.\n");
            Display.Info("2. Prepend a new Node.\n");
            Display.Info("3. Insert at a location.\n");
            Display.Info("4. Remove First Node.\n");
            Display.Info("5. Remove Last Node.\n");
            Display.Info("6. Remove a Node.\n");
            Display.Info("7. Remove Node from a location.\n");
            Display.Info("8. Find a Node.\n");
            Display.Info("9. Is Linked list empty.\n");
            Display.Info("10. Traverse Linked List!.\n");
            Display.Info("0. Back.\n");
            Display.Info("Please Enter you choice: ");
        }
    }


    public class CustomLinkedList_v2<T> : ICustomLinkedList_v2<T> {

        public CustomNode<T> First { get; set; }
        public CustomNode<T> Last { get; set; }

        #region private fields
        private readonly EqualityComparer<T> comparer;
        private int _size = 0;
        #endregion

        #region Constructors
        public CustomLinkedList_v2() {
            comparer = EqualityComparer<T>.Default;
        }
        #endregion

        public int Count {
            get {
                return _size;
            }
        }

        private bool IsValidIndex(int index) {
            if (index < 0 || index >= _size) {
                Display.Error("Index is out of list size!\n");
                return false;
            }
            return true;
        }

        #region Searching
        public CustomNode<T> Find(T value) {

            if (value == null) return null;

            CustomNode<T> currentNode = First;
            while (currentNode is not null) {
                if (comparer.Equals(currentNode.Value, value))
                    return currentNode;

                currentNode = currentNode.Next;
            }
            return null;
        }

        public CustomNode<T> Get(int index) {
            if (!IsValidIndex(index)) return null;
            if (Count <= 0) return null;

            CustomNode<T> temp = First;
            for (int i = 0; i < index; i++) {
                temp = temp.Next;
            }
            return temp;
        }

        public bool Contains(T value) {
            return Find(value) != null;
        }
        #endregion

        #region Insertion
        public void Append(CustomNode<T> node) {
            if (Count <= 0) {
                First = node;
                Last = node;
            } else {
                Last.Next = node;
                Last = node;
            }
            _size++;
        }

        public void Prepend(CustomNode<T> node) {
            if (Count <= 0) {
                First = node;
                Last = node;
            } else {
                node.Next = First;
                First = node;
            }
            _size++;
        }

        public bool Insert(int index, CustomNode<T> node) {
            if (index == Count) {
                Append(node);
                return true;
            }
            if (index == 0) {
                Prepend(node);
                return true;
            }

            if (!IsValidIndex(index)) return false;

            if (Count == 0) {
                First = Last = node;
            }

            CustomNode<T> temp = Get(index - 1);
            node.Next = temp.Next;
            temp.Next = node;
            _size++;
            return true;
        }
        #endregion

        #region Deletion
        public CustomNode<T> RemoveFirst() {
            if (Count <= 0) {
                return null;
            }

            CustomNode<T> firstNode = First;
            First = firstNode.Next;
            _size--;
            return firstNode;
        }

        public CustomNode<T> RemoveLast() {
            if (Count == 0) {
                return null;
            }

            CustomNode<T> currentNode = First;
            CustomNode<T> preNode = First;
            while (currentNode.Next != null) {
                preNode = currentNode;
                currentNode = currentNode.Next;
            }

            Last = preNode;
            Last.Next = null;
            _size--;

            if (_size == 0) {
                First = Last = null;
            }
            return currentNode;
        }

        public CustomNode<T> Remove(CustomNode<T> node) {
            if (Count == 0) return null;
            if (comparer.Equals(First.Value, node.Value)) return RemoveFirst();
            if (comparer.Equals(Last.Value, node.Value)) return RemoveLast();

            CustomNode<T> temp = First;
            CustomNode<T> prev = temp;
            while (temp is not null) {
                prev = temp;
                temp = temp.Next;
                if (comparer.Equals(temp.Value, node.Value)) break;
            }
            if (temp is not null) prev.Next = temp.Next;
            return temp;
        }

        public CustomNode<T> RemoveAt(int index) {
            if (Count == 0 || !IsValidIndex(index)) return null;
            if (index == 0) return RemoveFirst();
            if (index == Count - 1) return RemoveLast();

            CustomNode<T> temp = Get(index - 1);
            CustomNode<T> removedNode = temp.Next;
            temp.Next = removedNode.Next;
            removedNode.Next = null;
            _size--;
            return removedNode;
        }
        #endregion

        #region Updation
        public bool Set(int index, T newValue) {
            if (!IsValidIndex(index)) return false;
            if (Count <= 0) return false;

            CustomNode<T> temp = Get(index);

            temp.Value = newValue;
            return true;
        }

        /// <summary>
        /// if(length > 1) {
        ///     Node temp = head;
        ///     head = tail;
        ///     tail = temp;
        ///	    Node after = temp.next;
        ///     Node before = null;
        ///	    for(int i = 0; i<length; i++) {
        ///	        after = temp.next;
        ///	        temp.next = before;
        ///	        before = temp;
        ///	        temp = after;
        ///     }
        ///}
        /// </summary>
        public void Reverse() {
            if (Count > 1) {

                CustomNode<T> prevNode = null;
                CustomNode<T> currentNode = First;
                CustomNode<T> nextNode = currentNode.Next;

                (Last, First) = (First, Last);

                //method 1
                //while (currentNode is not null) {
                //    currentNode.Next = prevNode;
                //    prevNode = currentNode;
                //    currentNode = nextNode;
                //    nextNode = currentNode?.Next;
                //}

                //method 2
                for(int i = 0; i < Count; i++) {
                    nextNode = currentNode.Next;
                    currentNode.Next = prevNode;
                    prevNode = currentNode;
                    currentNode = nextNode;

                }
            }
        }
        #endregion

        public void Traverse() {
            if (Count > 0) {
                CustomNode<T> temp = First;
                Display.MainMenu("Linked List:  ");
                while (temp is not null) {
                    Display.Success(" " + temp.Value);
                    temp = temp.Next;
                }
                Display.Success(string.Format("\t Total: {0}\n", Count));
                return;
            }
            Display.Error("List is empty!\n");
        }


        public static void Menu() {
            //Insertion
            Display.Info("1.  Append a new Node.\n");
            Display.Info("2.  Prepend a new Node.\n");
            Display.Info("3.  Insert at index.\n");

            //Deletion
            Display.Info("4.  Remove First Node.\n");
            Display.Info("5.  Remove Last Node.\n");
            Display.Info("6.  Remove a Node.\n");
            Display.Info("7.  Remove Node at index.\n");

            //searching
            Display.Info("8.  Find a Node.\n");
            Display.Info("9.  Get a node at index.\n");
            Display.Info("10. Get First node.\n");
            Display.Info("11. Get Last node.\n");
            Display.Info("12. Check if node exists in Linkedlist.\n");

            //updation
            Display.Info("13. Update a node.\n");
            Display.Info("14. Reverse List.\n");

            Display.Info("15. Get Node Count!.\n");
            Display.Info("16. Traverse Linked List!.\n");
            Display.Info("0.  Back.\n");
            Display.MainMenu("Please Enter you choice: ");
        }
    }
}


