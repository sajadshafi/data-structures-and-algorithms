
namespace DataStructures.Logic.IServices {
    public interface ISortingService {
        void InsertionSort(int[] array);
        void MergeSort(int[] array);
        void QuickSort(int[] array);
        int[] SelectionSort(int[] array, int length);
        void SortMenu();
    }
}
