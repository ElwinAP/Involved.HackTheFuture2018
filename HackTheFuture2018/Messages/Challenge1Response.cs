using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HackTheFuture2018
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Challenge1Response
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Question Question { get; set; }
    }

    public class Question
    {
        public ICollection<InputValues> InputValues { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InputValues
    {
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
