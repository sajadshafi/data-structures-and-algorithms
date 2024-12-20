namespace DataStructures.Logic.IServices {
    public interface IBinarySearchTree<T> {
        public int Count { get; }
        bool Insert(T node, Func<T, T, bool> IsGreater);
        T Remove(T node, Func<T, T, bool> IsGreater);
        void PreOrderTraversal();
        void PostOrderTraversal();
        void InOrderTraversal();
        T GetRoot();
        T Find(T node, Func<T, T, bool> IsGreater);
    }
}
