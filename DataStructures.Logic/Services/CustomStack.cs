using DataStructures.Helpers;
using DataStructures.Logic.IServices;
namespace DataStructures.Logic.Services {
    public class CustomStack : ICustomStack {
        public int Top { get; set; } = -1;

        public int MAX_SIZE { get; set; } = 0;
        public int[] CreateStack() {
            return new int[MAX_SIZE];
        }

        public bool Push(ref int[] stack, int element) {
            if (IsFull()) {
                Display.Error("Stack OverFlow!.\n");
                return false;
            } else {
                Top += 1;
                stack[Top] = element;
                return true;
            }
        }

        public int Pop(ref int[] stack) {
            if (IsEmpty()) {
                Display.Error("Stack UnderFlow!.");
                return -1;
            }
            int element = stack[Top];
            Top -= 1;
            return element;
        }

        public bool IsEmpty() {
            return Top == -1;
        }

        public bool IsFull() {
            return Top == MAX_SIZE - 1;
        }

        public void Traverse(int[] stack) {
            Console.WriteLine();
            if (IsEmpty()) Display.Error("Stack is Empty!.\n");
            else {
                Display.Success("=> Stack Elements are: ");
                for (int i = 0; i <= Top; i++) {
                    Display.Success(stack[i] + "  ");
                }
            }
            Console.WriteLine("\n");
        }

        public static void Menu() {
            Display.Info("1. Push Element To Stack.\n");
            Display.Info("2. Pop Element from Stack.\n");
            Display.Info("3. Traverse Stack!.\n");
            Display.Info("0. Exit.\n");
            Display.Info("Please Enter you choice: ");
        }
    }
}
