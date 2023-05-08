using DataStructures.Logic.IServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataStructures.Logic.Services;
using DataStructures.DSConsumers;

namespace DataStructures.Config {
    public class DIContainer {
        public static IHost ConfigureServices() {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) => {
                    services.AddSingleton<IStartup, Startup>();

                    //Data Structures
                    services.AddTransient<ICustomStack, CustomStack>();
                    services.AddTransient<ICustomArray, CustomArray>();
                    services.AddSingleton(typeof(ICustomLinkedList<>), typeof(CustomLinkedList<>));
                    services.AddSingleton(typeof(ICustomLinkedList_v2<>), typeof(CustomLinkedList_v2<>));
                    services.AddScoped(typeof(IDoublyLinkedList<>), typeof(DoublyLinkedList<>));
                    services.AddTransient<ISortingService, SortingService>();
                    //Consumers
                    services.AddTransient<IStackConsumer, StackConsumer>();
                    services.AddTransient<IArrayConsumer, ArrayConsumer>();
                    services.AddSingleton<ILinkedListConsumer, LinkedListConsumer>();
                    services.AddScoped<IDLLConsumer, DLLConsumer>();
                }).Build();
        }
    }
}
