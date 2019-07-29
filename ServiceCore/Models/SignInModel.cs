using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCore;

namespace ServiceCore.Models
{
    public class SignInModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "user_name")]
        [Required(ErrorMessage = "Vui lòng cung cấp một tài khoản")]
        [StringLength(maximumLength: 16, MinimumLength = 5, ErrorMessage = "Tên tài khoản phải bao gồm 5 đến đến 16 kí tự...!")]
        public string UserName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "password")]
        [Required(ErrorMessage = "Vui lòng cung cấp một mật khẩu")]
        [StringLength(maximumLength: 16, MinimumLength = 5, ErrorMessage = "Mật khẩu phải bao gồm 5 đến đến 16 kí tự...!")]
        public string Password { get; set; }
        [JsonProperty("role_id")]
        public int RoleID { get; set; }

        [JsonProperty(NullValueHandling =NullValueHandling.Ignore,PropertyName ="role_code")]
        public string RoleCode { get; set; }
        [JsonProperty("role_name")]
        public string RoleName { get; set; }
        [JsonProperty("sign_in_session")]
        public string SignInSession { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore,PropertyName ="new_pass")]
        public string NewPass { get; set; }
    }
}
