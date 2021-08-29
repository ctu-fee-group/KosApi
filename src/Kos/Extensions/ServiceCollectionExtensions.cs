using System;
using Kos.Abstractions;
using Kos.Caching;
using Kos.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kos.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScopedKosApiFactory(this IServiceCollection collection)
        {
            collection
                .AddOptions<KosApiOptions>();
            
            collection
                .TryAddScoped<IKosAtomApiFactory, KosApiFactory>();

            return collection;
        }

        public static IServiceCollection AddScopedKosApi(this IServiceCollection collection, Func<IServiceProvider, string> getToken)
        {
            collection
                .AddScopedKosApiFactory();

            collection
                .AddScoped<IKosAtomApi>(p => p.GetRequiredService<IKosAtomApiFactory>().CreateApi(getToken(p)))
                .AddScoped<IKosPeopleApi, KosPeopleApi>();

            return collection;
        }
        
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