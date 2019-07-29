using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.Models
{
    public class SchoolYearModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static SchoolYearModel _Instance;

        public static SchoolYearModel GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new SchoolYearModel();
            }
            return _Instance;
        }

        public List<SchoolYearModel> GetAll()
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1005", "", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<SchoolYearModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<SchoolYearModel>();
            }
        }
             
        public int ID { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int IsCurrentYear { get; set; }

        public override string ToString()
        {
            return this.ID + " - " + this.Name;
        }
    }
}
