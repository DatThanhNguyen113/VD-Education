using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Models.User
{
    public class ParentModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("role")]
        public int Role { get; set; }
        [JsonProperty("student_name")]
        public string StudentName { get; set; }
        [JsonProperty("class_name")]
        public string ClassName { get; set; }
    }
}
