using Bcore.Utility;
using Newtonsoft.Json;
using ServiceCore.DataAccess;
using ServiceCore.Models;
using ServiceCore.Models.Base;
using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using VDSoLienLac.Filters;

namespace VDSoLienLac.Controllers
{
    [RoutePrefix("api/accountservice")]
    public class AccountServiceController : ApiController
    {
        AccountDAO dao = new AccountDAO();
        [HttpPost]
        [Route("signin")]
        public IHttpActionResult SignIn(SignInModel model)
        {
            //var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            //jsonResolver.IgnoreProperty(typeof(SignInModel), "password");
            //jsonResolver.IgnoreProperty(typeof(SignInModel), "role_code");
            //jsonResolver.IgnoreProperty(typeof(SignInModel), "new_pass");
            //var serializerSettings = new JsonSerializerSettings();
            //serializerSettings.ContractResolver = jsonResolver;
            //var json = JsonConvert.SerializeObject(model, serializerSettings);

            //JsonSerializerSettings config = new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
            //this.json = JsonConvert.SerializeObject(model, Formatting.Indented, config);

            BaseResponseModel<object> baseResponseModel = dao.ValidateSignIn(model);
            var i = (List<SignInModel>)baseResponseModel.ResponseData;
            if (baseResponseModel.Result > 0 && i.Count > 0)
            {
                var token = JwtManager.GenerateToken(i[0].UserName, i[0].ID);
                i[0].SignInSession = token;
            }
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("userinfo")]
        [JwtAuthentication]
        public IHttpActionResult GetStudentInfo(SignInModel model)
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = dao.GetUserInfo(userid, model.RoleID);
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("userupdate")]
        [JwtAuthentication]
        public IHttpActionResult UpdateStudentInfo(StudentModel model)
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = dao.UpdateUserInfo(userid, model);
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("changepassword")]
        [JwtAuthentication]
        public IHttpActionResult ChangePassword(SignInModel model)
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = dao.ChangeUserInfo(userid, model.Password, model.NewPass);
            return Ok(baseResponseModel);
        }
    }
}
