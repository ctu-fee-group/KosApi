//
//  ServiceCollectionExtensions.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Kos.Abstractions;
using Kos.Caching;
using Kos.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kos.Extensions
{
    /// <summary>
    /// A class holding extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds kos api factory as a scoped service.
        /// </summary>
        /// <param name="collection">The collection to configure.</param>
        /// <returns>The passed collection.</returns>
        public static IServiceCollection AddScopedKosApiFactory(this IServiceCollection collection)
        {
            collection
                .AddOptions<KosApiOptions>();

            collection
                .TryAddScoped<IKosAtomApiFactory, KosApiFactory>();

            return collection;
        }

        /// <summary>
        /// Adds kos api as a scoped service.
        /// </summary>
        /// <param name="collection">The collection to configure.</param>
        /// <param name="getToken">The function that obtains the access token.</param>
        /// <returns>The passed collection.</returns>
        public static IServiceCollection AddScopedKosApi
            (this IServiceCollection collection, Func<IServiceProvider, string> getToken)
        {
            collection
                .AddScopedKosApiFactory();

            collection
                .AddScoped<IKosAtomApi>(p => p.GetRequiredService<IKosAtomApiFactory>().CreateApi(getToken(p)))
                .AddScoped<IKosPeopleApi, KosPeopleApi>();

            return collection;
        }

        /// <summary>
        /// Replaces kos api with a scoped caching service.
        /// </summary>
        /// <param name="collection">The collection to configure.</param>
        /// <returns>The passed collection.</returns>
        public static IServiceCollection AddScopedKosCaching(this IServiceCollection collection)
        {
            collection
                .TryAddScoped<KosCacheService>();

            collection
                .Replace(ServiceDescriptor.Scoped<IKosAtomApiFactory, CachingKosApiFactory>());

            return collection;
        }
    }
}