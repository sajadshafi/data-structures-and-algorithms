using DataStructures.Helpers;
using DataStructures.Logic.IServices;

namespace DataStructures.Logic.Services {
    

    public class CustomArray : ICustomArray {
        public int MAX_SIZE { get; set; } = 0;
        public int Length { get; set; } = 0;
        public int[] CreateArray() {
            return new int[MAX_SIZE];
        }

        public void TraverseArray(int[] array) {
            if(Length == 0) {
                Display.Error("Array is Empty!\n");
                return;
            }

            Display.Success(string.Format("Array Elements are:  "));
            for (int i = 0; i < Length; i++) {
                Display.Success(string.Format(array[i] + "  "));
            }
            Console.WriteLine("\n");
        }

        public bool Insert(ref int[] array, int element) {
            if (Length == MAX_SIZE) {
                Display.Error("No empty space!\n");
                return false;
            }
            array[Length] = element;
            Length++;
            return true;
        }

        public bool Delete(ref int[] array, int element) {
            int position = FindElement(array, element);
            if(position == -1) {
                return false;
            } else {
                for(int i = position; i < Length; i++) {
                    array[i] = array[i+1];
                }
                Length -= 1;
                return true;
            }
        }

        public static void Menu() {
            Display.Info(string.Format("1. Insert Element To Array.\n"));
            Display.Info(string.Format("2. Delete Element from Array.\n"));
            Display.Info(string.Format("3. Traverse Array!.\n"));
            Display.Info(string.Format("4. Sort Array.\n"));
            Display.Info(string.Format("0. Go Back.\n"));
            Display.Info("Please Enter you choice: ");
        }

        private int FindElement(int[] array, int element) {
            int exist = -1;
            for(int i = 0; i < Length; i++) {
                if (array[i] == element) return i;
            }
            return exist;
        }
    }
}
