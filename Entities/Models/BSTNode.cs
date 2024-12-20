namespace Entities.Models {
    public class BSTNode<T> {
        public BSTNode<T> Left { get; set; }
        public T Value { get; set; }
        public BSTNode<T> Right { get; set; }
        public BSTNode(T node) {
            Left = Right = null;
            Value = node;
        }
    }
}
