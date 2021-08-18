using System;
using System.Globalization;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using Kos.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kos.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Note: dependency injection is not needed, but it is easier with it
            IServiceProvider services = CreateServices();
            
            KosApi api = services.GetRequiredService<KosApi>();
            string? accessToken = services
                .GetRequiredService<IOptions<AuthOptions>>()
                .Value.AccessToken;

            if (accessToken == null)
            {
                throw new InvalidOperationException("AccessToken must be set in config");
            }

            // Retrieve authorized kos api that will remember access token
            AuthorizedKosApi authorizedKosApi = api.GetAuthorizedApi(accessToken);

            // This could throw if there was error (except 404) and KosApiOptions.ThrowOnError was true (that is default)
            KosPerson? person = await authorizedKosApi.People.GetPersonAsync("username");
            if (person is not null) // Person was obtained successfully
            {
                Console.WriteLine($"Found person {person.FirstName} {person.LastName}");
                
                // Load associated teacher entity using generic loading mechanism
                KosTeacher? teacher = await authorizedKosApi.LoadEntityAsync(person.Roles.Teacher);
            }
            else
            {
                Console.WriteLine("Could not find the specified person");
            }
            
            // Obtained from cache
            person = await authorizedKosApi.People.GetPersonAsync("username");
        }

        static IServiceProvider CreateServices()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            
            return new ServiceCollection()
                // Logging is needed in case of errors
                .AddLogging(builder => builder
                    .AddConsole())
                
                // Better to add as scoped, but this example does not support scopes
                .AddSingleton<KosApi>()
                
                // Add options needed for kos api
                .Configure<KosApiOptions>(config.GetSection("Kos"))
                
                // Add options with access token, used for example, not part of the library
                .Configure<AuthOptions>(config.GetSection("Auth"))
                .BuildServiceProvider();
        }
    }
}