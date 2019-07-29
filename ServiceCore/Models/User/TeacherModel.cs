using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.Models.User
{
    public class TeacherModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static TeacherModel _Instance;

        public static TeacherModel GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new TeacherModel();
            }
            return _Instance;
        }

        public List<TeacherModel> GetTeacherbySpecialize(int classid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ClassID = classid
                }, "1007", "BYSPECIALIZE", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<TeacherModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<TeacherModel>();
            }
        }

        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("birth_date")]
        public DateTime BirthDate { get; set; }
        [JsonProperty("work_unit")]
        public string WorkUnit { get; set; }
        [JsonProperty("graduating")]
        public string Graduating { get; set; }
        [JsonProperty("diploma")]
        public string Diploma { get; set; }
        [JsonProperty("bank_account_number")]
        public string BankAccountNumber { get; set; }
        [JsonProperty("bank_id")]
        public int BankID { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("role")]
        public int Role { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
