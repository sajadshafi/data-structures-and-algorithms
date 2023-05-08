namespace Entities.Models {
    public class CustomNode<T> {
        public T Value { get; set; }
        public CustomNode<T> Next { get; set; }

        public CustomNode() { }

        public CustomNode(T value) {
            Value = value;
        }
    }
}
