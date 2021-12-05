using System.Net.Http;
using System.Threading.Tasks;

namespace RatesAPI.Core.Interfaces
{
    public interface IRatesOperations
    {
        Task<LatestRatesResponse> GetLatestRatesAsync();

    }
}
