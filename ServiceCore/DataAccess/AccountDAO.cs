
using ServiceCore.Hash;
using ServiceCore.Models;
using ServiceCore.Models.Base;
using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.DataAccess
{
    public class AccountDAO
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private BaseResponseModel<object> baseResponseModel;

        public BaseResponseModel<object> ValidateSignIn(SignInModel model)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                var mPass = "";
                if (IsMD5(model.Password))
                {
                    mPass = model.Password;
                }
                else
                {
                    mPass = MD5Hashing.Encrypt(model.Password);
                }
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    UserName = model.UserName,
                    Password = mPass
                }, "1", "");
                var ds = db.GetContextData(xml);
                var result = Render.ResponseObject<BaseResult>(ds.Tables[1]);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<SignInModel>(ds);
                baseResponseModel.ResponseMessage = result.Description;
                return baseResponseModel;

            }
            catch(Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> GetUserInfo(string userid,int roleid,string context="")
        {
            try
            {
                switch (roleid)
                {
                    case 1: context = "TEA-SELF";
                        break;
                    case 2: context = "STU-SELF";
                        break;
                    case 3: context = "EMP-SELF";
                        break;
                    case 4:
                        context = "PAR-SELF";
                        break;
                    default:
                        break;
                }
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ID = userid
                }, "2", context, userid);
                var ds = db.GetContextData(xml);
                if(roleid == 1)
                {
                    baseResponseModel = BaseResultFromObject.GetBaseResponse<TeacherModel>(ds);
                }
                else if(roleid == 2)
                {
                    baseResponseModel = BaseResultFromObject.GetBaseResponse<StudentModel>(ds);
                }
                else if (roleid == 4)
                {
                    baseResponseModel = BaseResultFromObject.GetBaseResponse<ParentModel>(ds);
                }

                return baseResponseModel;
            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> UpdateUserInfo(string userid,object item)
        {
            try
            {
                var model = (StudentModel)Convert.ChangeType(item, typeof(StudentModel)); ;
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>("UPDATE", new
                {
                    RoleID = model.RoleID
                    ,
                    FirstName = model.FirstName
                    ,LastName = model.LastName
                    ,Email = model.Email
                    ,BirthDate = model.BirthDate
                    ,Gender = model.Gender
                    ,Country = model.Country
                    ,Address = model.Address
                    ,PhoneNumber = model.PhoneNumber
                    ,IDCardNumber = model.IDCardNumber
                }, "2", "", userid);
                var ds = db.ExecuteAction(xml);

                baseResponseModel = BaseResultFromObject.GetBaseResponse<object>(ds);

                return baseResponseModel;
            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> ChangeUserInfo(string userid,string oldpass,string newpass)
        {
            string xml = Render.GenerateXmlFromObject<object>("UPDATE", new
            {
                OldPassword = MD5Hashing.Encrypt(oldpass),
                NewPassword = MD5Hashing.Encrypt(newpass)
            }, "2008", "", userid);
            var ds = db.ExecuteAction(xml);
            baseResponseModel = BaseResultFromObject.GetBaseResponse<object>(ds);
            return baseResponseModel;
        }

        #region checking
        public static bool IsMD5(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return false;
            }

            return Regex.IsMatch(input, "^[0-9a-fA-F]{32}$", RegexOptions.Compiled);
        }
        #endregion
    }
}
