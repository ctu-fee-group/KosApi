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
        public static IServiceCollection AddKosApiFactory(this IServiceCollection collection)
        {
            collection
                .AddOptions<KosApiOptions>();
            
            collection
                .TryAddSingleton<IKosAtomApiFactory, KosApiFactory>();

            return collection;
        }

        public static IServiceCollection AddScopedKosApi(this IServiceCollection collection, Func<IServiceProvider, string> getToken)
        {
            collection
                .AddKosApiFactory();

            collection
                .AddScoped<IKosAtomApi>(p => p.GetRequiredService<IKosAtomApiFactory>().CreateApi(getToken(p)))
                .AddScoped<IKosPeopleApi, KosPeopleApi>();

            return collection;
        }
        
        public static IServiceCollection AddKosCaching(this IServiceCollection collection)
        {

            collection
                .TryAddSingleton<KosCacheService>();

            collection
                .Replace(ServiceDescriptor.Singleton<IKosAtomApiFactory, CachingKosApiFactory>());

            return collection;
        }
    }
}