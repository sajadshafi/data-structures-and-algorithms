namespace DataStructures.Logic.IServices {
    public interface ICustomStack {

        //MAX_SIZE is the maximum size of a stack
        int MAX_SIZE { get; set; }
        int Top { get; set; }

        int[] CreateStack();

        /// <summary>
        /// checks if stack is empty or not
        /// </summary>
        /// <returns>true or false based on if the stack is empty or not</returns>
        bool IsEmpty();

        /// <summary>
        /// checks if stack is full or not
        /// </summary>
        /// <returns>true or false based on if the stack is full or not</returns>
        bool IsFull();

        /// <summary>
        /// Pops an element from the stack
        /// </summary>
        /// <param name="stack">the stack data structure with a ref keyword which is used for call by reference that means.
        /// It will change the original value rather that a copy of stack</param>
        /// <returns>return the element that was popped</returns>
        int Pop(ref int[] stack);

        /// <summary>
        /// Pushes an element into the stack
        /// </summary>
        /// <param name="stack">the stack data structure with a ref keyword which is used for call by reference that means.
        /// It will change the original value rather that a copy of stack</param>
        /// <param name="element">Element to be pushed</param>
        /// <returns>return true or false  based on if the element was pushed successfully or not</returns>
        bool Push(ref int[] stack, int element);

        /// <summary>
        /// Traverse (Display) the elements of a stack
        /// </summary>
        void Traverse(int[] stack);
    }
}
