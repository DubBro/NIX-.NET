using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module5HW1.Config;
using Module5HW1.Services.Abstractions;
using Module5HW1.Services.Instances;

namespace Module5HW1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var provider = ConfigureDI(serviceCollection, configuration);
            var app = provider.GetService<App>();

            await app!.Start();
        }

        private static ServiceProvider ConfigureDI(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
            serviceCollection.AddHttpClient();
            serviceCollection.AddTransient<IHttpClientService, HttpClientService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IRegisterService, RegisterService>();
            serviceCollection.AddTransient<IResourceService, ResourceService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<App>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}