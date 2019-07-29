using ServiceCore.Models;
using ServiceCore.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.DataAccess
{
    public class UtilityDAO
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private BaseResponseModel<object> baseResponseModel;

        public BaseResponseModel<object> GetWeek()
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "2004", "");
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<WeekModel>(ds);
                return baseResponseModel;

            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> GetRoom()
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "2005", "");
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<RoomModel>(ds);
                return baseResponseModel;

            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }
    }
}
