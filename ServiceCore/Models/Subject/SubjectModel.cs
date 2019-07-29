using ServiceCore.DataAccess;
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
    public class SubjectModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static SubjectModel _Instance;

        public static SubjectModel GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new SubjectModel();
            }
            return _Instance;
        }

        public List<SubjectModel> GetSubjectList()
        {
            SubjectDAO subject = new SubjectDAO();
            var result = subject.GetAllSubject("13");
            var resp = (List<SubjectModel>)result.ResponseData;
            return resp;
        }

        public List<SubjectModel> GetSubjectBySpecialize(int classid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ClassID = classid
                }, "1006", "BYSPECIALIZE", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<SubjectModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<SubjectModel>();
            }
        }

        public List<SubjectModel> GetNotLearnList(int classid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ClassID = classid
                }, "1006", "NOTLEARN", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<SubjectModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<SubjectModel>();
            }
        }

        public bool CheckExistLowPioritySubject(int classid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ClassID = classid
                }, "2014", "", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseObject<BaseResult>(ds.Tables[0]);
                if (resp.ID < 1)
                    return false;
                else return true;
            }
            catch
            {
                return false;
            }
        }

        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ClassID { get; set; }
        public int SchoolYearID { get; set; }
        public string Description { get; set; }
        public int TotalCredits { get; set; }
        public int PracticeCredit { get; set; }
        public int TheoryCredit { get; set; }
        public int LessionNumber { get; set; }
        public int FinalEvaluationPercent { get; set; }
        public int SemiFinalEvaluationPercent { get; set; }
        public int DiligencePercent { get; set; }
        public int SubjectTypeID { get; set; }
        public int SpecializeID { get; set; }
        public int Piority { get; set; }

        public override string ToString()
        {
            return this.Code + " - " + this.Name;
        }
    }
}
