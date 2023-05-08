namespace Entities.Models {
    public class DLLNode<T> {
        public DLLNode<T> Previous { get; set; }
        public T Value { get; set; }
        public DLLNode<T> Next { get; set; }

        public DLLNode(T value) {
            Value = value;
        }
    }
}
