using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.Models
{
    public class WeekModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static WeekModel _Instance;

        public static WeekModel GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new WeekModel();
            }
            return _Instance;
        }

        public List<WeekModel> GetAll()
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "2004", "");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<WeekModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<WeekModel>();
            }
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
    }
}
