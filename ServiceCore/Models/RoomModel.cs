using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.Models
{
    public class RoomModel
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static RoomModel _Instance;
        public static RoomModel GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new RoomModel();
            }
            return _Instance;
        }

        public List<RoomModel> GetAll()
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "2005", "");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<RoomModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<RoomModel>();
            }
        }

        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
    }
}
