using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;

namespace VDSoLienLac.Models.Base.Response
{
    public class BaseResponseModel<T>
    {
        [DataMember(Name = "response_data")]
        [JsonProperty("response_data")]
        public T ResponseData { get; set; }
        [DataMember(Name = "response_message")]
        [JsonProperty("response_message")]
        public string ResponseMessage { get; set; }
        [DataMember(Name = "status_code")]
        [JsonProperty("status_code")]
        public HttpStatusCode StatusCode { get; set; }
        [DataMember(Name = "is_success")]
        [JsonProperty("is_success")]
        public bool IsSuccess { get; set; }
        [DataMember(Name = "result")]
        [JsonProperty("result")]
        public int Result { get; set; }
    }
}