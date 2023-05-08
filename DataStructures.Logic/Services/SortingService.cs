using DataStructures.Helpers;
using DataStructures.Logic.IServices;

namespace DataStructures.Logic.Services {
    
    public class SortingService : ISortingService {
        public int[] SelectionSort(int[] array, int length) {
            for (int i = 1; i < length; i++) {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key) {
                    array[j + 1] = array[j];
                    array[j] = key;
                    j -= 1;
                }
            }
            return array;
        }

        public void InsertionSort(int[] array) {
            Display.Warning("Not Implemented yet.\n");
        }
        public void MergeSort(int[] array) { 
            Display.Warning("Not Implemented yet.\n");
        }
        public void QuickSort(int[] array) { 
            Display.Warning("Not Implemented yet.\n");
        }

        public void SortMenu() {
            Display.Info("\n\n-------- Select Sorting algorithm. --------\n");
            Display.Info("1. Selection Sort.\n");
            Display.Info("2. Insertion Sort.\n");
            Display.Info("3. Merge Sort.\n");
            Display.Info("4. Quick Sort.\n");
            Display.Info("0. Back.\n");
            Display.Info("Please Enter you choice: ");
        }

        #region Private Section
        //private static void Swap(ref int x, ref int y) {
        //    int z = y;
        //    y = x;
        //    x = z;
        //}
        #endregion
    }

}
