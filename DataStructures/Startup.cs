using DataStructures.DSConsumers;

namespace DataStructures {
    public class Startup : IStartup {
        private readonly IStackConsumer _stackConsumer;
        public Startup(IStackConsumer stackconsumer) {
            _stackConsumer = stackconsumer;
        }
        public void Run() {
            while (true) {
                ShowDSMenu();
                int choice;
                try {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice) {
                        case 1:
                            _stackConsumer.ExecuteStack();
                            break;
                        case 2:
                            Console.WriteLine("Queue is not Implemented yet...");
                            break;
                        case 3:
                            Console.WriteLine("Linked List is not Implemented yet...");
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Input Please try again!...");
                            break;
                    }
                } catch (Exception ex) {
                    Console.WriteLine("An Error Occured: {0}", ex.Message);
                }
            }
        }

        public void ShowDSMenu() {
            Console.WriteLine("********************************* Welcome To Data Structures *********************************");
            Console.WriteLine("1. Stack");
            Console.WriteLine("2. Queue");
            Console.WriteLine("3. Linked List");
            Console.WriteLine("0. Exit DS APP");
            Console.Write("=>  Select option: ");
        }
    }
    public interface IStartup {
        void Run();
        void ShowDSMenu();
    }
}
