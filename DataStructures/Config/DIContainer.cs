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
                    services.AddTransient<ICustomStack, CustomStack>();

                    //Consumers
                    services.AddTransient<IStackConsumer, StackConsumer>();
                }).Build();
        }
    }
}
