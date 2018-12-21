using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HackTheFuture2018
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Challenge1Response
    {
        public Question Question { get; set; }
    }

    public class Question
    {
        public ICollection<InputValue> inputValues { get; set; }
    }

    public class InputValue
    {
        public string Name { get; set; }
        public int Data { get; set; }
    }
}
