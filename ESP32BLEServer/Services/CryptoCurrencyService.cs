using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;

namespace ESP32BLEServer.Services
{
    class CryptoCurrencyService
    {
        private const string Endpoint = "https://min-api.cryptocompare.com/data/price?fsym={0}&tsyms={1}";

        public async Task<int> Get(string fsym, string tsym)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format(Endpoint, fsym, tsym));
            var start = response.IndexOf(":") + 1;
            var length = response.IndexOf("}") - start;
            var resultString = response.Substring(start, length).Trim();
            Debug.WriteLine(string.Format("CryptoCurrencyService: {0} - {1} => {2}", fsym, tsym, resultString));
            var result = double.Parse(resultString);
            return (int)result;
        }
    }
}
