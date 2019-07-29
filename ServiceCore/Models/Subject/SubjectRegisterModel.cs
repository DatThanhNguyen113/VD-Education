using Newtonsoft.Json;
using ServiceCore.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.Models.Subject
{
    public class SubjectRegisterModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static SubjectRegisterModel _Instance;

        public static SubjectRegisterModel GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new SubjectRegisterModel();
            }
            return _Instance;
        }

        public bool UpdateTime()
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>("UPDATE", new
                {
                    SubjectRegisterID = ID,
                    StartLearnDate = StartLearnDate,
                    EndLearnDate = EndLearnDate,
                    FromWeek = FromWeek,
                    ToWeek = ToWeek
                }, "4", "UPDATE::ROW", "13");
                var ds = db.ExecuteAction(xml);
                var resp = Render.ResponseObject<BaseResult>(ds.Tables[0]);
                if (resp.ID > 0) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateStatus(int status)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    ID = ID,
                    Status = status
                }, "1008", "SUBJECT", "13");
                var ds = db.ExecuteAction(xml);
                var resp = Render.ResponseObject<BaseResult>(ds.Tables[0]);
                if (resp.ID > 0) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public List<SubjectRegisterModel> GetBySpecialize(int specializeid,int schoolyearid = 0)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    SpecializeID = specializeid,
                    SchoolYearID = schoolyearid
                }, "4", "EMP-SPECIALIZE", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<SubjectRegisterModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<SubjectRegisterModel>();
            }
        }

        public List<SubjectRegisterModel> GetByClass(int classid,int schoolyearid = 0)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ClassID = classid,
                    SchoolYearID = schoolyearid
                }, "4", "EMP-RELATE", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<SubjectRegisterModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<SubjectRegisterModel>();
            }
        }

        public List<SubjectRegisterModel> GetAll(int schoolyearid =0)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    SchoolYearID = schoolyearid
                }, "4", "EMP-ALL", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<SubjectRegisterModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<SubjectRegisterModel>();
            }
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "teacher_id")]
        public string TeacherID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "start_learn_date")]
        public DateTime StartLearnDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "end_learn_date")]
        public DateTime EndLearnDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subject_id")]
        public int SubjectID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expected_studen_number")]
        public int ExpectedStudentNumber { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "teacher_name")]
        public string TeacherName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "register_status")]
        public string RegisterStatus { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "total_credits")]
        public int TotalCredits { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "theory_credit")]
        public int TheoryCredit { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "practice_credit")]
        public int PracticeCredit { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "lession_number")]
        public int LessionNumber { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "final_evaluation_percent")]
        public int FinalEvaluationPercent { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "semi_final_evaluation_percent")]
        public int SemiFinalEvaluationPercent { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "diligence_percent")]
        public int DiligencePercent { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subject_registed_id")]
        public int SubjectRegistedID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status_id")]
        public int StatusID { get; set; }
        public int ID { get; set; }
        public string TeacherCode { get; set; }
        public int CurrentStudentNumber { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "school_year_id")]
        public int SchoolYearID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "school_year_name")]
        public int SchoolYearName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "master_timetable_id")]
        public int MasterTimeTableID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "master_timetable_status_id")]
        public int MasterTimeTableStatusID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "master_timetable_status_code")]
        public string MasterTimeTableStatusCode { get; set; }
        public string SubjectRegisterStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int FromWeek { get; set; }
        public int ToWeek { get; set; }


        public override string ToString()
        {
            return "Khóa học môn " + this.Name;
        }
    }

    
}
