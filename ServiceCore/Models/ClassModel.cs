using ServiceCore.DataAccess;
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
    public class ClassModel
    {

        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static ClassModel _Instance;

        public ClassModel()
        {

        }

        public static ClassModel GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new ClassModel();
            }
            return _Instance;
        }

        public List<ClassModel> GetClassList()
        {
            ClassDAO classDAO = new ClassDAO();
            var result = classDAO.GetAllClass("13");
            var resp = (List<ClassModel>)result.ResponseData;
            return resp;
        }

        public List<ClassModel> GetClassBySpecialize(int subjectregisterid,int specializeID)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    SubjectRegisterID = subjectregisterid,
                    SpecializeID = specializeID
                }, "1003", "BYREGISTERID", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<ClassModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<ClassModel>();
            }
        }

        public bool AddToSubjectRegister(int subjectregister)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    SubjectRegisterID = subjectregister,
                    ClassID = ID
                }, "2006", "ADDMORE", "13");
                var ds = db.ExecuteAction(xml);
                var resp = Render.ResponseObject<BaseResult>(ds.Tables[0]);
                if (resp.ID > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SchoolYearID { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int SpecializeID { get; set; }
        public string SpecializeName { get; set; }


        public override string ToString()
        {
            return this.Code + " - " + this.Name;
        }
    }
}
