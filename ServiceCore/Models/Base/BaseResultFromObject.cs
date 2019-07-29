using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.Models.Base
{
    public class BaseResultFromObject
    {
        public static BaseResponseModel<object> GetBaseResponse<T>(DataSet ds) where T: class
        {
            BaseResponseModel<object> baseResponseModel = new BaseResponseModel<object>();
            CCoreDao db = new CCoreDao();
            GenerateData Render = new GenerateData();
            BaseResult result;
            if (ds.Tables.Count == 1)
            {
                result = Render.ResponseObject<BaseResult>(ds.Tables[0]);
            }
            else
            {
                result = Render.ResponseObject<BaseResult>(ds.Tables[1]);
            }
            if(result.ID > 0)
            {
                var resp = Render.ResponseMultiObject<T>(ds.Tables[0]).ToList();
                baseResponseModel.ResponseData = resp;
                baseResponseModel.ResponseMessage = result.Message;
                baseResponseModel.Result = result.ID;
            }
            else
            {
                baseResponseModel.ResponseData = null;
                baseResponseModel.ResponseMessage = result.Message;
                baseResponseModel.Result = result.ID;
            }
            return baseResponseModel;
        }
    }
}
