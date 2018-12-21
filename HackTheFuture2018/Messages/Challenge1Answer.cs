using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HackTheFuture2018.Messages
{
    public class Challenge1Answer
    {
        public string challengeId { get; set; }
        public ICollection<Values> values { get; set; }
    }

    public class Values
    {
        public string name { get; set; }
        public string data { get; set; }
    }
}
