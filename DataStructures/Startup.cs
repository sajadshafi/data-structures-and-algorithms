using DataStructures.DSConsumers;
using DataStructures.Helpers;

namespace DataStructures {
    public class Startup : IStartup {
        private readonly IStackConsumer _stackConsumer;
        private readonly IArrayConsumer _arrayConsumer;
        private readonly ILinkedListConsumer _listConsumer;
        private readonly IDLLConsumer _dllConsumer;
        public Startup(
                IStackConsumer stackConsumer,
                IArrayConsumer arrayConsumer,
                ILinkedListConsumer listConsumer,
                IDLLConsumer dllConsumer
            ) {
            _stackConsumer = stackConsumer;
            _arrayConsumer = arrayConsumer;
            _listConsumer = listConsumer;
            _dllConsumer = dllConsumer;
        }
        public void Run() {
            while (true) {
                ShowDSMenu();
                int choice;
                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice) {
                        case 1:
                            _arrayConsumer.ExecuteStack();
                            break;
                        case 2:
                            _stackConsumer.ExecuteStack();
                            break;
                        case 3:
                            Display.Warning(string.Format("Queue is not Implemented yet...\n"));
                            break;
                        case 4:
                            _listConsumer.ExecuteStack_v2();
                            break;
                        case 5:
                            _dllConsumer.ExecuteStack();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Display.Error(string.Format("Invalid Input Please try again!...\n"));
                            break;
                    }
                } catch (Exception ex) {
                    Display.Error(string.Format("An Error Occured: {0}\n", ex.Message));
                }
            }
        }

        public void ShowDSMenu() {
            Display.MainMenu(string.Format("********** Welcome To Data Structures **********\n"));
            Display.MainMenu(string.Format("1. Arrays\n"));
            Display.MainMenu(string.Format("2. Stack\n"));
            Display.MainMenu(string.Format("3. Queue\n"));
            Display.MainMenu(string.Format("4. Linked List\n"));
            Display.MainMenu(string.Format("5. Doubly Linked List\n"));
            Display.MainMenu(string.Format("0. Exit App\n"));
            Display.MainMenu(string.Format("=>  Select option: "));
        }
    }
    public interface IStartup {
        void Run();
        void ShowDSMenu();
    }
}
