using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Models
{
    public class NotifyModel
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("data")]
        public dynamic Data { get; set; }
        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
