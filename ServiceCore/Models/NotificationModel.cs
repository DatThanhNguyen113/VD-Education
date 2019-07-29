using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.Models
{
    public class NotificationModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();

        private static NotificationModel _Instance;

        public static NotificationModel GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new NotificationModel();
            }
            return _Instance;
        }

        public NotificationModel GetDetail(int id,string userid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ID = id
                }, "2009", "DETAIL", userid);
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseObject<NotificationModel>(ds.Tables[0]);
                return resp;
            }
            catch
            {
                return new NotificationModel();
            }
        }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("receiver_name")]
        public string ReceiverName { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
