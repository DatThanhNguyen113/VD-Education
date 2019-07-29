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
    public class StudentModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static StudentModel _Instance;

        public static StudentModel GetInstace()
        {
            if(_Instance == null)
            {
                _Instance = new StudentModel();
            }
            return _Instance;
        }

        public List<StudentModel> GetStudentByClass(int classid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ClassID = classid
                }, "2010", "", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<StudentModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<StudentModel>();
            }
        }

        public List<StudentModel> GetStudentBySubjectRegister(int subjectregisterid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    SubjectRegisterID = subjectregisterid
                }, "2010", "BYSUBJECTREGISTER", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<StudentModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<StudentModel>();
            }
        }

        public List<StudentModel> GetStudentByRegisted(int subjectregisterid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    SubjectRegisterID = subjectregisterid
                }, "2010", "BYREGISTED", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<StudentModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<StudentModel>();
            }
        }


        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("birth_date")]
        public DateTime BirthDate { get; set; }
        [JsonProperty("gender_id")]
        public int Gender { get; set; }
        [JsonProperty("gender_name")]
        public string GenderName { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("training_system_id")]
        public int TrainingSystemID { get; set; }
        [JsonProperty("training_system_name")]
        public string TrainingSystemName { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("class_code")]
        public string ClassCode { get; set; }
        [JsonProperty("class_id")]
        public int ClassID { get; set; }
        [JsonProperty("class_name")]
        public string ClassName { get; set; }
        [JsonProperty("school_year_name")]
        public string SchoolYearName { get; set; }
        [JsonProperty("start_year")]
        public int StartYear { get; set; }
        [JsonProperty("end_year")]
        public int EndYear { get; set; }
        [JsonProperty("school_year_id")]
        public int SchoolYearID { get; set; }
        [JsonProperty("role_id")]
        public int RoleID { get; set; }

        [JsonProperty("id_card_number")]
        public string IDCardNumber { get; set; }

        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        [JsonProperty("specialize_name")]
        public string SpecializeName { get; set; }
    }
}
