using System;
using Newtonsoft.Json;
namespace bl
    .Entity
{
    public class CLanguage
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameNative { get; set; }
        public string Description { get; set; }
        public string CultureCode { get; set; }
        public int? Status { get; set; }
        public int? ZOrder { get; set; }
      //  [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]public DateTime? CreatedDateTime { get; set; }
        public int? CreatedUserID { get; set; }
        //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]public DateTime? UpdatedDateTime { get; set; }
        public int? UpdatedUserID { get; set; }
        public int? CreatedSystemID { get; set; }
        public int? UpdatedSystemID { get; set; }
        public string DateFormatString { get; set; }
    }
}
