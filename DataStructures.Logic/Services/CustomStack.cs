using DataStructures.Logic.IServices;
namespace DataStructures.Logic.Services {
    public class CustomStack : ICustomStack {
        public int Top { get; set; } = -1;
        public int MAX_SIZE { get; set; }
        public int[] CreateStack() {
            return new int[MAX_SIZE];
        }

        public bool Push(ref int[] stack, int element) {
            if (IsFull()) {
                Console.WriteLine("Stack OverFlow!.");
                return false;
            } else {
                Top += 1;
                stack[Top] = element;
                return true;
            }
        }

        public int Pop(ref int[] stack) {
            if (IsEmpty()) {
                Console.WriteLine("Stack UnderFlow!.");
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
            if (IsEmpty()) Console.WriteLine("Stack is Empty!.");
            else {
                Console.Write("=> Stack Elements are: ");
                for (int i = 0; i <= Top; i++) {
                    Console.Write(stack[i] + "  ");
                }
            }
            Console.WriteLine();
        }

        public static void Menu() {
            Console.WriteLine("1. Push Element To Stack.");
            Console.WriteLine("2. Pop Element from Stack.");
            Console.WriteLine("3. Traverse Stack!.");
            Console.WriteLine("0. Exit.");
            Console.Write("Please Enter you choice. ");
        }
    }
}
