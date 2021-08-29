using System.Threading;
using System.Threading.Tasks;
using Kos.Data;

namespace Kos.Abstractions
{
    public interface IKosPeopleApi
    {
        public Task<KosPerson?> GetPersonAsync(string username, CancellationToken token = default);
    }
}