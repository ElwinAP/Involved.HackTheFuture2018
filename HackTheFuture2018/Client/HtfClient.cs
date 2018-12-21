using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HackTheFuture2018.Client
{
    public class HtfClient
    {
        private readonly HttpClient _client;
        private readonly string _base_url = "http://htf2018.azurewebsites.net/Challenges/";
        private readonly string _identification_token = "NjA0MzI4YTUtN2I5Ni00NmFjLWJjYjItNDE2Y2FlNGFiOTE1";
        private HttpContent _content;

        public HtfClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_identification_token);
        }

        public async Task GetChallenge()
        {
            var Uri = "http://htf2018.azurewebsites.net/Challenges";
            var res = await _client.GetAsync(Uri);
            var bla = "";
        }

        public async Task PostChallenge1()
        {
            var sum = 0;

            var res = await _client.GetAsync(_base_url + "593bc0a2e0dfdc53b239bc2a96ab0fd5");
            var stringRes = await res.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Challenge1Response>(stringRes);

            var values = response.Question.inputValues.ToList();
            foreach (var value in values)
            {
                sum =+ value.Data;
            }

            //make resbody

            await _client.PostAsync(_base_url + "593bc0a2e0dfdc53b239bc2a96ab0fd5", _content);
        }
    }
}

