

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
            Console.WriteLine("---------------------- Stack Data Structure ----------------------");
            _customStack.MAX_SIZE = 5;
            int[] stack = _customStack.CreateStack();
            while (true) {
                CustomStack.Menu();
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice) {
                    case 1:
                        Console.Write("Enter element to push: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        bool result = _customStack.Push(ref stack, value);
                        if (result) {
                            Console.WriteLine("-> Element Pushed Successfully.");
                            Console.WriteLine();
                        } else {
                            Console.WriteLine("-> Failed to Push!.");
                            Console.WriteLine();   
                        }
                        break;
                    case 2:
                        int element = _customStack.Pop(ref stack);
                        if (element == -1) Console.WriteLine("Failed to Pop!.");
                        else Console.WriteLine("-> Popped Successfully!. -> {0}", element);
                        Console.WriteLine();   
                        break;
                    case 3:
                        _customStack.Traverse(stack);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("! => Invalid Choice Try Again!..");
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
