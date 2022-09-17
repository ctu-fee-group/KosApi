//
//  ServiceCollectionExtensions.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Kos.Abstractions;
using Kos.Caching;
using Kos.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Kos.Extensions
{
    /// <summary>
    /// A class holding extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds kos api as a scoped service.
        /// </summary>
        /// <param name="collection">The collection to configure.</param>
        /// <param name="getToken">The function that obtains the access token.</param>
        /// <param name="configureClient">The action used for configuring the http client.</param>
        /// <param name="lifetime">The lifetime of the service.</param>
        /// <returns>The passed collection.</returns>
        public static IServiceCollection AddKosApi
        (
            this IServiceCollection collection,
            Func<IServiceProvider, string> getToken,
            Action<IHttpClientBuilder>? configureClient = null,
            ServiceLifetime lifetime = ServiceLifetime.Singleton
        )
            => AddKosApi(collection, (p, ct) => Task.FromResult(getToken(p)), configureClient, lifetime);

        /// <summary>
        /// Adds kos api as a scoped service.
        /// </summary>
        /// <param name="collection">The collection to configure.</param>
        /// <param name="getToken">The function that obtains the access token.</param>
        /// <param name="configureClient">The action used for configuring the http client.</param>
        /// <param name="lifetime">The lifetime of the service.</param>
        /// <returns>The passed collection.</returns>
        public static IServiceCollection AddKosApi
        (
            this IServiceCollection collection,
            Func<IServiceProvider, CancellationToken, Task<string>> getToken,
            Action<IHttpClientBuilder>? configureClient = null,
            ServiceLifetime lifetime = ServiceLifetime.Singleton
        )
        {
            collection.TryAddSingleton<XmlSerializerFactory>();

            var clientBuilder = collection.AddHttpClient
            (
                "Kos",
                (services, client) =>
                {
                    var options = services.GetRequiredService<IOptions<KosApiOptions>>().Value;
                    if (options.BaseUrl is null)
                    {
                        throw new InvalidOperationException("The base url must be set.");
                    }

                    client.BaseAddress = new Uri(options.BaseUrl);
                }
            );
            configureClient?.Invoke(clientBuilder);

            collection
                .TryAdd
                    (ServiceDescriptor.Describe(typeof(TokenProvider), p => new TokenProvider(p, getToken), lifetime));

            collection
                .TryAdd(ServiceDescriptor.Describe(typeof(IKosAtomApi), typeof(KosAtomApi), lifetime));

            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosBranchesApi), typeof(KosBranchesApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosCoursesApi), typeof(KosCoursesApi), lifetime));
            collection.TryAdd
                (ServiceDescriptor.Describe(typeof(IKosCourseEventsApi), typeof(KosCoursesEventsApi), lifetime));
            collection.TryAdd
                (ServiceDescriptor.Describe(typeof(IKosCoursesGroupsApi), typeof(KosCoursesGroupsApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosDivisionsApi), typeof(KosDivisionsApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosDivisionsApi), typeof(KosDivisionsApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosExamsApi), typeof(KosExamsApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosParallelsApi), typeof(KosParallelsApi), lifetime));
            collection.TryAdd
                (ServiceDescriptor.Describe(typeof(IKosParametersApi), typeof(KosParametersApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosPathwaysApi), typeof(KosPathwaysApi), lifetime));
            collection
                .TryAdd(ServiceDescriptor.Describe(typeof(IKosPeopleApi), typeof(KosPeopleApi), lifetime));
            collection.TryAdd
                (ServiceDescriptor.Describe(typeof(IKosProgrammesApi), typeof(KosProgrammesApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosRoomsApi), typeof(KosRoomsApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosSemestersApi), typeof(KosSemestersApi), lifetime));
            collection.TryAdd
                (ServiceDescriptor.Describe(typeof(IKosStateExamsApi), typeof(KosStateExamsApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosStudentsApi), typeof(KosStudentsApi), lifetime));
            collection.TryAdd
                (ServiceDescriptor.Describe(typeof(IKosStudyPlansApi), typeof(KosStudyPlansApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosTeachersApi), typeof(KosTeachersApi), lifetime));
            collection.TryAdd(ServiceDescriptor.Describe(typeof(IKosThesesApi), typeof(KosThesesApi), lifetime));

            return collection;
        }

        /// <summary>
        /// Replaces kos api with a scoped caching service.
        /// </summary>
        /// <param name="collection">The collection to configure.</param>
        /// <param name="lifetime">The lifetime of the services.</param>
        /// <returns>The passed collection.</returns>
        public static IServiceCollection AddKosCaching
            (this IServiceCollection collection, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            collection
                .TryAdd(ServiceDescriptor.Describe(typeof(KosCacheService), typeof(KosCacheService), lifetime));

            collection
                .Replace(ServiceDescriptor.Describe(typeof(IKosAtomApi), typeof(CachingKosAtomApi), lifetime));

            return collection;
        }
    }
}