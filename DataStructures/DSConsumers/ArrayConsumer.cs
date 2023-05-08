using DataStructures.Helpers;
using DataStructures.Logic.IServices;
using DataStructures.Logic.Services;

namespace DataStructures.DSConsumers {
    public interface IArrayConsumer {
        void ExecuteStack();
    }

    public class ArrayConsumer : IArrayConsumer {
        private readonly ICustomArray _customArray;
        private readonly ISortingService _sortingService;
        public ArrayConsumer(ICustomArray customArray, ISortingService sortingService) {
            _customArray = customArray;
            _sortingService = sortingService;
        }

        public void ExecuteStack() {
            Console.WriteLine();

            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Append(new Entities.Models.CustomNode<int> { Value=3 });

            Display.Info("---------------------- Array ----------------------\n");
            _customArray.MAX_SIZE = 10;
            int[] array = _customArray.CreateArray();
            while (true) {
                CustomArray.Menu();
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice) {
                    case 1:
                        Display.Success("Enter element to insert: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        bool result = _customArray.Insert(ref array, value);
                        if (result) {
                            Display.Success("-> Element inserted Successfully.\n");
                            Console.WriteLine();
                        } else {
                            Display.Error("-> Failed to Insert!.\n");
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Display.Warning("Enter Element to delete: ");
                        int element = Convert.ToInt32(Console.ReadLine());
                        bool response = _customArray.Delete(ref array, element);
                        if (!response) Display.Error("Failed to Delete!.\n");
                        else Display.Success(string.Format("-> Deleted Successfully!. -> {0}\n", element));
                        break;
                    case 3:
                        _customArray.TraverseArray(array);
                        break;
                    case 4:
                        _sortingService.SortMenu();
                        int sortOption = Convert.ToInt32(Console.ReadLine());

                            switch (sortOption) {
                                case 1:
                                    int[] sortedArray = _sortingService.SelectionSort(array, _customArray.Length);
                                    _customArray.TraverseArray(sortedArray);
                                    break;
                                case 2:
                                    _sortingService.InsertionSort(array);
                                    //_customArray.TraverseArray(sortedArray);
                                    break;
                                case 3:
                                    _sortingService.MergeSort(array);
                                    //_customArray.TraverseArray(sortedArray);
                                    break;
                                case 4:
                                    _sortingService.QuickSort(array);
                                    //_customArray.TraverseArray(sortedArray);
                                    break;
                                case 0:
                                    return;
                                default:
                                    Display.Error("! => Invalid Choice Try Again!..\n");
                                    break;
                            }
                        break;
                    case 0:
                        return;
                    default:
                        Display.Error("! => Invalid Choice Try Again!..\n");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
