using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Cache;
using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;
using Kos.Data;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Serialization.Xml;

namespace Kos
{
    /// <summary>
    /// Entity used to interact with kos API
    /// </summary>
    public class AuthorizedKosApi : IXmlAtomApi, IDisposable
    {
        private readonly ILogger _logger;
        private readonly RestClient _client;
        private readonly MemoryCache _cache;
        private readonly KosApiOptions _options;
        private KosApiPeople? _people;
        private KosApiTeachers? _teachers;
        private KosApiStudents? _students;

        internal AuthorizedKosApi(string accessToken, KosApiOptions options, ILogger logger)
        {
            _logger = logger;
            _client = new RestClient(options.BaseUrl ?? throw new InvalidOperationException("BaseUrl is null"))
            {
                Authenticator = new KosApiAuthenticator(accessToken),
                CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache)
            };

            _options = options;
            _cache = new MemoryCache(options.CacheOptions ?? new MemoryCacheOptions());

            _client.UseDotNetXmlSerializer();
        }

        /// <summary>
        /// Endpoint /people
        /// </summary>
        public KosApiPeople People => _people ??= new KosApiPeople(this, _logger);

        /// <summary>
        /// Endpoint /teachers
        /// </summary>
        public KosApiTeachers Teachers => _teachers ??= new KosApiTeachers(this, _logger);

        /// <summary>
        /// Endpoint /students
        /// </summary>
        public KosApiStudents Students => _students ??= new KosApiStudents(this, _logger);

        /// <summary>
        /// Load loadable entity that is obtained using another entity
        /// </summary>
        /// <param name="kosLoadable"></param>
        /// <param name="cachePolicy"></param>
        /// <param name="token"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T?> LoadEntityAsync<T>(AtomLoadableEntity<T>? kosLoadable,
            CachePolicy cachePolicy = CachePolicy.DownloadIfNotAvailable,
            CancellationToken token = default)
            where T : class, new()
        {
            if (kosLoadable is null || kosLoadable.Href is null)
            {
                _logger.LogWarning($"Cannot obtain href from {typeof(T).FullName} loadable");
                return default;
            }

            if (cachePolicy != CachePolicy.DownloadOnly &&
                _cache.TryGetValue(kosLoadable.Href, out T? cachedValue))
            {
                return cachedValue;
            }

            if (cachePolicy == CachePolicy.CacheOnly)
            {
                throw new CacheEntryNotFoundException($"Could not find entry with key {kosLoadable} in cache");
            }

            IRestRequest request =
                new RestRequest(kosLoadable.Href,
                    Method.GET);

            return await GetResponse<T>(kosLoadable.Href, request, token);
        }

        private async Task<T?> GetResponse<T>(string identifier, IRestRequest request, CancellationToken token)
            where T : class, new()
        {
            IRestResponse<AtomEntry<T?>>? response = await _client.ExecuteAsync<AtomEntry<T?>>(request, token);
            if (!response.IsSuccessful || response?.Data is null || response.Data.Content is null)
            {
                _logger.LogWarning(response?.ErrorException,
                    $"Could not obtain kos api information({identifier}): {response?.StatusCode} {response?.ErrorMessage} {response?.Content}");

                if (_options.ThrowOnError && response?.StatusCode != HttpStatusCode.NotFound)
                {
                    if (response?.ErrorException is not null)
                    {
                        throw response.ErrorException;
                    }
                
                    throw new InvalidOperationException(
                        $"Could not obtain response from the server {response?.StatusCode} {response?.ErrorMessage} {response?.Content}");
                }
            }

            return _cache.Set(identifier, response?.Data?.Content);
        }

        public void Dispose()
        {
            _cache.Dispose();
        }
    }
}