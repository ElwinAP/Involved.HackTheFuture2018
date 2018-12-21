using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HackTheFuture2018.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HackTheFuture2018.Client
{
    public class HtfClient
    {
        private readonly HttpClient _client;
        private readonly string _base_url = "http://htf2018.azurewebsites.net/Challenges/";
        private readonly string _identification_token = "NjA0MzI4YTUtN2I5Ni00NmFjLWJjYjItNDE2Y2FlNGFiOTE1";
        private readonly JsonSerializerSettings _serializerSettings;
        private HttpContent _content;

        public HtfClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("htf-identification", _identification_token);
        }

        public async Task GetChallenge()
        {
            var Uri = "http://htf2018.azurewebsites.net/Challenges";
            var res = await _client.GetAsync(Uri);
        }

        public async Task PostChallenge2()
        {
            var sum = 0;

            var res = await _client.GetAsync(_base_url + "593bc0a2e0dfdc53b239bc2a96ab0fd5");
            var stringRes = await res.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Challenge1Response>(stringRes);
            var id = response.Id;

            var values = response.Question.InputValues.ToList();
            foreach (var value in values)
            {
                var data = Convert.ToInt32(value.Data);
                sum += data;
            }

            var answerValues = new List<Values>()
            {
                new Values {data = sum.ToString(), name = "sum"}
 
            };
            var answer = new Challenge1Answer()
            {
                challengeId = id,
                values = answerValues
            };

            Thread.Sleep(1000);
            var body = CreateJsonBody(answer);            
            var postRes = await _client.PostAsync(_base_url + "593bc0a2e0dfdc53b239bc2a96ab0fd5", body);
        }

        public async Task PostChallenge4()
        {
            var res = await _client.GetAsync(_base_url + "7a34919d6dd4c2d9c3f05c6957946b82");
            var stringRes = await res.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Challenge1Response>(stringRes);
            var id = response.Id;

            var start = Convert.ToInt32(response.Question.InputValues.Single(i => i.Name == "start").Data);
            var end = Convert.ToInt32(response.Question.InputValues.Single(i => i.Name == "end").Data);

            var answerValues = new List<Values>();

            for (var x = start; x < end; x++)
            {
                var isPrime = true;
                for (var y = 2; y <= Math.Sqrt(x); y++)
                {
                    if (x % y == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    var value = new Values()
                    {
                        data = x.ToString(),
                        name = "prime"
                    };
                    answerValues.Add(value);
                }
            }

            var answer = new Challenge1Answer()
            {
                challengeId = id,
                values = answerValues
            };

            Thread.Sleep(1000);
            var body = CreateJsonBody(answer);
            var postRes = await _client.PostAsync(_base_url + "7a34919d6dd4c2d9c3f05c6957946b82", body);

            var jsonbla = await body.ReadAsStringAsync();
            var responsebla = JsonConvert.DeserializeObject<Challenge1Answer>(jsonbla);
            var resbla = await postRes.Content.ReadAsStringAsync();
            var bla = "";
        }

        private StringContent CreateJsonBody<T>(T message)
        {
            var serialized = JsonConvert.SerializeObject(message);
            return new StringContent(serialized, Encoding.UTF8, "application/json");
        }
    }
}

