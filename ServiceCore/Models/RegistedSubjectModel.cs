using ServiceCore.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.Models
{
    public class RegistedSubjectModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static RegistedSubjectModel _Instance;

        public static RegistedSubjectModel GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new RegistedSubjectModel();
            }
            return _Instance;
        }

        public List<RegistedSubjectModel> GetApproval()
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "3", "EMP-ALL", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<RegistedSubjectModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<RegistedSubjectModel>();
            }
        }

        public List<RegistedSubjectModel> GetLearnedInfo(int id)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ID = id
                }, "3", "LEARNEDINFO", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<RegistedSubjectModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<RegistedSubjectModel>();
            }
        }

        public bool UpdateStatus(int status)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>("UPDATE", new
                {
                    ID = ID,
                    Status = status
                }, "3", "UPDATE", "13");
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

        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string DepartmentName { get; set; }
        public string SpecializeName { get; set; }
        public DateTime StartLearnDay { get; set; }
        public string LessonNumber { get; set; }
        public int TotalLesson { get; set; }
    }
}
