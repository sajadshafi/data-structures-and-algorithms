using DataStructures.Helpers;
using DataStructures.Logic.IServices;
using Entities.Models;

namespace DataStructures.Logic.Services {
    public class DoublyLinkedList<T> : IDoublyLinkedList<T> {
        #region Private section
        private readonly EqualityComparer<T> comparer;
        private int _size = 0;
        #endregion

        #region Constructors
        public DoublyLinkedList() {
            comparer = EqualityComparer<T>.Default;
        }
        #endregion
        public int Count {
            get { return _size; }
        }

        public DLLNode<T> First { get; set; }
        public DLLNode<T> Last { get; set; }

        #region Insertion
        public void Append(T value) {
            DLLNode<T> node = new(value);
            if (Count == 0) {
                First = Last = node;
            } else {
                Last.Next = node;
                node.Previous = Last;
                Last = node;
            }
            _size++;
        }

        public void Prepend(T value) {
            DLLNode<T> node = new(value);
            if (Count == 0) {
                First = Last = node;
            } else {
                node.Next = First;
                First.Previous = node;
                First = node;
            }
            _size++;
        }

        public bool Insert(int index, T value) {
            if (index < 0 || index > Count) {
                Display.Error("Index is not valid!");
                return false;
            }
            if (index == 0) {
                Prepend(value);
                return true;
            } else if (index == Count) {
                Append(value);
                return true;
            }

            DLLNode<T> prev = Get(index - 1);
            DLLNode<T> newNode = new(value) {
                Previous = prev,
                Next = prev.Next
            };
            newNode.Next.Previous = prev.Next = newNode;
            _size++;
            return true;
        }
        #endregion

        #region Searching
        public bool Contains(T value) {
            return comparer.Equals(value, Find(value));
        }

        public T Find(T value) {
            if (Count <= 0 || value == null) return default;

            DLLNode<T> currentNode = First;
            while (currentNode is not null) {
                if (comparer.Equals(currentNode.Value, value))
                    return currentNode.Value;

                currentNode = currentNode.Next;
            }
            return default;
        }

        public DLLNode<T> Get(int index) {
            if (!IsValidIndex(index) || Count == 0) return default;

            DLLNode<T> currentNode = First;
            for (int i = 0; i < index; i++) {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }
        #endregion

        #region Deletion
        public T Remove(T value) {
            if(Count <=0) return default;
            if (comparer.Equals(value, First.Value)) return RemoveFirst();

            if(!Contains(value)) {
                return default;
            }

            DLLNode<T> temp = First;
            while(!comparer.Equals(value, temp.Value)) {
                temp = temp.Next;
            }

            temp.Previous.Next = temp.Next;
            if(temp.Next != null) 
                temp.Next.Previous = temp.Previous;

            temp.Next = temp.Previous = null;
            _size--;
            return temp.Value;
        }

        public T RemoveAt(int index) {
            if (!IsValidIndex(index)) return default;
            if (index == 0) return RemoveFirst();
            if (index == Count - 1) return RemoveLast();

            DLLNode<T> node = Get(index - 1);
            DLLNode<T> temp = node.Next;
            node.Next = temp.Next;
            temp.Next.Previous = node;

            temp.Next = temp.Previous = null;
            _size--;
            return temp.Value;
        }

        public T RemoveFirst() {
            if (First == null) return default;
            DLLNode<T> temp = First;
            if (Count == 1) {
                First = Last = null;
            } else {
                First = temp.Next;
                First.Previous = null;
            }
            _size--;
            temp.Next = temp.Previous = null;
            return temp.Value;
        }

        public T RemoveLast() {
            if (First == null) return default;
            DLLNode<T> temp = Last;
            if (Count == 1) {
                First = Last = null;
            } else {
                Last = temp.Previous;
                Last.Next = null;
            }
            temp.Next = temp.Previous = null;
            _size--;
            return temp.Value;
        }
        #endregion

        #region Updation
        public bool Set(int index, T newValue) {
            if (!IsValidIndex(index) || Count == 0) return false;
            Get(index).Value = newValue;
            return true;
        }
        #endregion

        public void TraverseReverse() {
            if (Count > 0) {
                DLLNode<T> temp = Last;
                Display.MainMenu("Doubly Linked List Reversed:  ");
                while (temp is not null) {
                    Display.Success(" " + temp.Value);
                    temp = temp.Previous;
                }
                Display.Success(string.Format("\t Total: {0}\n", Count));
                return;
            }
            Display.Error("Doubly Linked List is empty!\n");
        }

        public void Traverse() {
            if (Count > 0) {
                DLLNode<T> temp = First;
                Display.MainMenu("Doubly Linked List:  ");
                while (temp is not null) {
                    Display.Success(" " + temp.Value);
                    temp = temp.Next;
                }
                Display.Success(string.Format("\t Total: {0}\n", Count));
                return;
            }
            Display.Error("List is empty!\n");
        }

        private bool IsValidIndex(int index) {
            if (index < 0 || index >= _size) {
                Display.Error("Index is not valid!\n");
                return false;
            }
            return true;
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
            Display.Info("14. Reverse Traverse Linked List!.\n");

            Display.Info("15. Get Node Count!.\n");
            Display.Info("16. Traverse Linked List!.\n");
            Display.Info("0.  Back.\n");
            Display.MainMenu("Please Enter you choice: ");
        }
    }
}
