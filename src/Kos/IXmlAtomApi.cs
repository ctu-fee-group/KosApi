using System.Threading;
using System.Threading.Tasks;
using Kos.Atom;

namespace Kos
{
    public interface IXmlAtomApi
    {
        /// <summary>
        /// Load loadable entity that is obtained using another entity
        /// </summary>
        /// <param name="kosLoadable">Entity to be loaded</param>
        /// <param name="token"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T?> LoadEntityAsync<T>(AtomLoadableEntity<T>? kosLoadable,
            CancellationToken token = default)
            where T : class, new();
    }
}