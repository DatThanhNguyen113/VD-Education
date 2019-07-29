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
    public class MusterModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static MusterModel _Instance;
        public static MusterModel GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new MusterModel();
            }
            return _Instance;
        }

        public List<MusterModel> GetByTimeTableID(int timetableid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    TimeTableID = timetableid
                }, "2003", "EMP", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<MusterModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<MusterModel>();
            }
        }


        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("subject_name")]
        public string SubjectName { get; set; }
        [JsonProperty("student_name")]
        public string StudentName { get; set; }
        [JsonProperty("student_id")]
        public string StudentID { get; set; }
        [JsonProperty("join_status")]
        public int JoinStatus { get; set; }
        [JsonProperty("timetable_id")]
        public int TimeTableID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
