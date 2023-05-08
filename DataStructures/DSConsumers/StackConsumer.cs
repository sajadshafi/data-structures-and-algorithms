

using DataStructures.Helpers;
using DataStructures.Logic.IServices;
using DataStructures.Logic.Services;

namespace DataStructures.DSConsumers {
    public class StackConsumer : IStackConsumer {
        private readonly ICustomStack _customStack;
        public StackConsumer(ICustomStack customStack) {
            _customStack = customStack;
        }

        public void ExecuteStack() {
            Console.WriteLine();
            Display.Info("---------------------- Stack Data Structure ----------------------\n");
            _customStack.MAX_SIZE = 5;
            int[] stack = _customStack.CreateStack();
            while (true) {
                CustomStack.Menu();
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice) {
                    case 1:
                        Display.Info("Enter element to push: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        bool result = _customStack.Push(ref stack, value);
                        if (result) {
                            Display.Success("-> Element Pushed Successfully.\n");
                            Console.WriteLine();
                        } else {
                            Display.Error("-> Failed to Push!.\n");
                            Console.WriteLine();   
                        }
                        break;
                    case 2:
                        int element = _customStack.Pop(ref stack);
                        if (element == -1) Display.Error("Failed to Pop!.\n");
                        else Display.Success(string.Format("-> Popped Successfully!. -> {0}\n", element));
                        Console.WriteLine();   
                        break;
                    case 3:
                        _customStack.Traverse(stack);
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
    
    public interface IStackConsumer {
        void ExecuteStack();
    }
}
