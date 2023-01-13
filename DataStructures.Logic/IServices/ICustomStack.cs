namespace DataStructures.Logic.IServices {
    public interface ICustomStack {
        int MAX_SIZE { get; set; }
        int Top { get; set; }

        int[] CreateStack();
        bool IsEmpty();
        bool IsFull();
        int Pop(ref int[] stack);
        bool Push(ref int[] stack, int element);
        void Traverse(int[] stack);
    }
}
