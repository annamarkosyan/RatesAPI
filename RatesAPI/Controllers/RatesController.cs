using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RatesAPI.Core;
using RatesAPI.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatesController : ControllerBase
    {
        private readonly ILogger<RatesController> _logger;
        private readonly IRatesOperations _ratesOperations;
        public RatesController(ILogger<RatesController> logger, IRatesOperations ratesOperations)
        {
            _logger = logger;
            _ratesOperations = ratesOperations;
        }
        [HttpGet]
        public async Task<LatestRatesResponse> GetLatestRates()
        {
            return await _ratesOperations.GetLatestRatesAsync();
        }


    }
}
