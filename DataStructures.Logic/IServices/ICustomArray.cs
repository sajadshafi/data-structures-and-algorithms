
namespace DataStructures.Logic.IServices {
    public interface ICustomArray {
        int Length { get; set; }
        int MAX_SIZE { get; set; }

        int[] CreateArray();
        bool Insert(ref int[] array, int element);
        bool Delete(ref int[] array, int element);


        /// <summary>
        /// Display elements of an array
        /// </summary>
        /// <param name="array">the array that needs to be traversed</param>
        void TraverseArray(int[] array);
    }
}
