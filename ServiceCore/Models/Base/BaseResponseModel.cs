using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Models.Base
{
    public class BaseResponseModel<T> where T : class
    {
        [JsonProperty("response_data")]
        public T ResponseData { get; set; }
        [JsonProperty("response_message")]
        public string ResponseMessage { get; set; }
        [JsonProperty("result")]
        public int Result { get; set; }
        [JsonProperty("status_code")]
        public HttpStatusCode StatusCode {
            get
            {
                if (this.Result == -1)
                {
                    return HttpStatusCode.NotFound;
                }
                else if (this.Result == -2)
                {
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.OK;
            }
            set
            {
                if(this.Result == -1)
                {
                    this.StatusCode = HttpStatusCode.NotFound;
                }
                else if (this.Result == -2)
                {
                    this.StatusCode = HttpStatusCode.BadRequest;
                }
                else if (this.Result > 0)
                {
                    this.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    this.StatusCode = value;
                }
            }
        }
    }
}
