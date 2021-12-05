using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatesAPI.Core
{
    public class LatestRatesRequest
    {
        public string AccessKey { get; set; }
        public string Base { get; set; }
        public List<string> Symbols { get; set; }
    }
}
