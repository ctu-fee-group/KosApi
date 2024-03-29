﻿//
//  Program.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using Kos.Abstractions;
using Kos.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kos.Example
{
    /// <summary>
    /// The entry point class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point method.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            // Note: dependency injection is not needed, but it is easier with it
            var services = CreateServices();
            using var scope = services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            var peopleApi = scopedServices.GetRequiredService<IKosPeopleApi>();
            var loadableApi = scopedServices.GetRequiredService<IKosAtomApi>();

            // This could throw if there was error (except 404) and KosApiOptions.ThrowOnError was true (that is default)
            var person = await peopleApi.GetPersonAsync("username");
            if (person is not null)
            { // Person was obtained successfully
                Console.WriteLine($"Found person {person.FirstName} {person.LastName}");

                // Load associated teacher entity using generic loading mechanism
                var student = await loadableApi.LoadEntryAsync(person.Roles.Students.FirstOrDefault());
                var teacher = await loadableApi.LoadEntryAsync(person.Roles.Teacher);
            }
            else
            {
                Console.WriteLine("Could not find the specified person");
            }

            // Obtained from cache
            person = await peopleApi.GetPersonAsync("username");
        }

        private static IServiceProvider CreateServices()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            return new ServiceCollection()

                // Logging is needed in case of errors
                .AddLogging
                (
                    builder => builder
                        .AddConsole()
                )

                // Replaces IKosAtomApiFactory with caching counterpart that will get IMemoryCache
                .AddScoped<IMemoryCache, MemoryCache>() // Scoped so each scope will have its own memory cache
                .AddKosCaching(ServiceLifetime.Scoped)

                // Adds scoped api that will get the token by provided way
                .AddKosApi
                (
                    p =>
                        p.GetRequiredService<IOptions<AuthOptions>>().Value.AccessToken
                        ?? throw new InvalidOperationException("Token was not provided"),
                    lifetime: ServiceLifetime.Scoped
                )

                // Configure options needed for kos api
                .Configure<KosApiOptions>(config.GetSection("Kos"))

                // Add options with access token, used for example, not part of the library
                .Configure<AuthOptions>(config.GetSection("Auth"))
                .BuildServiceProvider();
        }
    }
}