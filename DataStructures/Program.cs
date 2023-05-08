using DataStructures.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataStructures {
    public class Program {
        public static void Main() {
            
            //Configure Dependency Injection Container
            IHost host = DIContainer.ConfigureServices();
            //
            var svc = ActivatorUtilities.CreateInstance<Startup>(host.Services);
            svc.Run();
        }
    }
}
