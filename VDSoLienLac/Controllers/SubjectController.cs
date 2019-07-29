using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceCore.DataAccess;
using ServiceCore.Models;
using ServiceCore.Models.Base;
using ServiceCore.Models.Subject;
using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using VD.Datalayer.DataObject;
using VD.Utility;
using VDSoLienLac.Filters;
using VDSoLienLac.Models.Base;

namespace VDSoLienLac.Controllers
{
    [RoutePrefix("api/subject")]
    public class SubjectController : ApiController
    {
        SubjectDAO dao = new SubjectDAO();
        [HttpPost]
        [Route("getsubjectregister")]
        [JwtAuthentication]
        public IHttpActionResult GetSubjectRegister()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = dao.GetSubjectRegister(userid, "STU-SELF");
            var mList = (List<SubjectRegisterModel>)baseResponseModel.ResponseData;
            baseResponseModel.ResponseData = mList.Select(x => new { master_timetable_id =  x.MasterTimeTableID,subject_id =  x.SubjectID,code =  x.Code,name =  x.Name,teacher_name =  x.TeacherName, total_credits =  x.TotalCredits, practice_credit =  x.PracticeCredit, theory_credit = x.TheoryCredit, lession_number =  x.LessionNumber, semi_final_evaluation_percent =  x.SemiFinalEvaluationPercent, final_evaluation_percent =  x.FinalEvaluationPercent, diligence_percent = x.DiligencePercent, status = x.StatusID });
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("registsubject")]
        [JwtAuthentication]
        public IHttpActionResult RegistSubject(SubjectRegisterModel model)
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = dao.RegistSubject(model, userid);
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("getregistedsubject")]
        [JwtAuthentication]
        public IHttpActionResult GetRegistedSubject()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = dao.GetRegistedSubject(userid);
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("gettimetablebystudent")]
        [JwtAuthentication]
        public IHttpActionResult GetTimeTable()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = new BaseResponseModel<object>();
            try
            {
                CCoreDao db = new CCoreDao();
                GenerateData Render = new GenerateData();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1009", "", userid);
                var ds = db.GetContextData(xml);
                var mResp = Render.ResponseMultiObject<TimeTableModel>(ds.Tables[0]).ToList().Select(x => new {
                    subject_id= x.SubjectID,
                    subject_name =x.SubjectName,
                    teacher_name = x.TeacherName,
                    date = x.Date,
                    day = x.Day,
                    room = x.Room,
                    session = x.Session,
                    lesson_number = x.LessonNumber,
                    from_date = x.FromDate,
                    from_week = x.FromWeek,
                    to_date = x.ToDate,
                    to_week = x.ToWeek });
                var result = Render.ResponseObject<BaseResult>(ds.Tables[1]);
                if(result.ID > 0)
                {
                    baseResponseModel.ResponseData = mResp;
                    baseResponseModel.Result = 1;
                    baseResponseModel.ResponseMessage = result.Description;
                }
                else
                {
                    baseResponseModel.ResponseData = null;
                    baseResponseModel.ResponseMessage = result.Message;
                    baseResponseModel.Result = result.ID;
                }
            }
            catch(Exception ex)
            {
                baseResponseModel.ResponseData = null;
                baseResponseModel.ResponseMessage = ex.Message;
                baseResponseModel.Result = -2;
            }
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("gettimetablebyteacher")]
        [JwtAuthentication]
        public IHttpActionResult GetTimeTablebyTeacher()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = new BaseResponseModel<object>();
            try
            {
                CCoreDao db = new CCoreDao();
                GenerateData Render = new GenerateData();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1009", "TEA", userid);
                var ds = db.GetContextData(xml);
                var mResp = Render.ResponseMultiObject<TimeTableModel>(ds.Tables[0]).ToList().Select(x => new {
                    subject_id = x.SubjectID,
                    subject_name = x.SubjectName,
                    date = x.Date,
                    day = x.Day,
                    room = x.Room,
                    session = x.Session,
                    lesson_number = x.LessonNumber,
                    from_date = x.FromDate,
                    from_week = x.FromWeek,
                    to_date = x.ToDate,
                    to_week = x.ToWeek
                });
                var result = Render.ResponseObject<BaseResult>(ds.Tables[1]);
                if (result.ID > 0)
                {
                    baseResponseModel.ResponseData = mResp;
                    baseResponseModel.Result = 1;
                    baseResponseModel.ResponseMessage = result.Description;
                }
                else
                {
                    baseResponseModel.ResponseData = null;
                    baseResponseModel.ResponseMessage = result.Message;
                    baseResponseModel.Result = result.ID;
                }
            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseData = null;
                baseResponseModel.ResponseMessage = ex.Message;
                baseResponseModel.Result = -2;
            }
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("getMuster")]
        [JwtAuthentication]
        public IHttpActionResult GetMuster(MusterModel model)
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            var context = new HttpContextWrapper(HttpContext.Current);
            BaseResponseModel<object> baseResponseModel = null;
            var isDemoTime = Int32.Parse(ConfigurationManager.AppSettings["DemoTime"]?.ToString());
            if(isDemoTime == 1)
            {
                var currentDatetime = new DateTime(2019,07,13,8,30,0);
                baseResponseModel = dao.GetMuster(userid, currentDatetime);
            }
            else
            {
                HttpRequestBase request = context.Request;
                var currentRequestTime = Task.Run(async () => await GetCurrentTime(request)).GetAwaiter().GetResult();
                baseResponseModel = dao.GetMuster(userid, DateTime.Parse(currentRequestTime));
            }
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("setMusterTitle")]
        [JwtAuthentication]
        public IHttpActionResult SetMusterTitle(MusterModel model)
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = dao.UpdateMuster(userid, model.TimeTableID, 0, model.Title);
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("updateMusterStudent")]
        [JwtAuthentication]
        public IHttpActionResult MusterStudent(MusterModel model)
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = dao.UpdateMuster(userid, model.TimeTableID, 1, "", model.ID, model.StudentID);
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("getschoolyear")]
        public IHttpActionResult GetSchoolYear()
        {
            ClassDAO mClass = new ClassDAO();
            BaseResponseModel<object> baseResponseModel = mClass.GetAllSchoolYear();
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("getNotice")]
        [JwtAuthentication]
        public IHttpActionResult GetNotification()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = new BaseResponseModel<object>();
            try
            {
                CCoreDao db = new CCoreDao();
                GenerateData Render = new GenerateData();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "2009", "BYUSER", userid);
                var ds = db.GetContextData(xml);
                var mResp = Render.ResponseMultiObject<NotificationModel>(ds.Tables[0]).ToList();
                var result = Render.ResponseObject<BaseResult>(ds.Tables[1]);
                if (result.ID > 0)
                {
                    baseResponseModel.ResponseData = mResp;
                    baseResponseModel.Result = 1;
                    baseResponseModel.ResponseMessage = result.Description;
                }
                else
                {
                    baseResponseModel.ResponseData = null;
                    baseResponseModel.ResponseMessage = result.Message;
                    baseResponseModel.Result = result.ID;
                }
            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseData = null;
                baseResponseModel.ResponseMessage = ex.Message;
                baseResponseModel.Result = -2;
            }
            return Ok(baseResponseModel);
        }

        [HttpPost]
        [Route("getnoticedetail")]
        [JwtAuthentication]
        public IHttpActionResult GetNoticeDetail(int id)
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            string userid = identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString();
            BaseResponseModel<object> baseResponseModel = new BaseResponseModel<object>();
            try
            {
                baseResponseModel.ResponseData = NotificationModel.GetInstance().GetDetail(id, userid);
                baseResponseModel.Result = 1;
                baseResponseModel.ResponseMessage = "OK";
            }
            catch(Exception ex)
            {
                baseResponseModel.ResponseData = null;
                baseResponseModel.ResponseMessage = ex.Message;
                baseResponseModel.Result = -2;
            }
            return Ok(baseResponseModel);
        }

        #region utility

        private async Task<string> GetCurrentTime(HttpRequestBase requestBase)
        {
            var secret = ConfigurationManager.AppSettings["IpDataKey"].ToString();

            var xIP = GetIPAddress(requestBase);
            if (xIP.Length < 1 || xIP == "::1")
            {
                xIP = "2405:4800:5287:13b3:896b:721a:49b5:35f4";
            }
            string requestQuery = string.Format("https://api.ipdata.co/{0}?api-key={1}", xIP, secret);
            HttpClient client = new HttpClient();
            var resp = await client.GetAsync(requestQuery);
            var data = await resp.Content.ReadAsStringAsync();
            var Jobj = JObject.Parse(data);
            var currentTime = Jobj["time_zone"]["current_time"];
            return currentTime.ToString();
        }

        private string GetClientIp(HttpRequestMessage request = null)
        {
            request = request ?? Request;

            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)this.Request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return "";
            }
        }

        public static string GetIPAddress(HttpRequestBase request)
        {

            //string IP_Address = "";
            //try
            //{
            //    IP_Address = aRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //    if (string.IsNullOrEmpty(IP_Address))
            //    {
            //        IP_Address = aRequest.ServerVariables["REMOTE_ADDR"];
            //    }
            //}
            //catch (Exception exIP)
            //{
            //    log4net.Debug(exIP.Message);
            //}
            //return IP_Address;

            try
            {

                if (request.Headers["CF-CONNECTING-IP"] != null)
                    return request.Headers["CF-CONNECTING-IP"];

                var ipAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ipAddress))
                {
                    var addresses = ipAddress.Split(',');
                    if (addresses.Length != 0)
                        return addresses[0];
                }

                return request.UserHostAddress;
            }
            catch (Exception exIP)
            {
            }
            return "";

        }
    }
    #endregion
}

#region private model
public class CustomSubjectRegister
{
    [JsonProperty("teacher_name")]
    public string TeacherName { get; set; }
    [JsonProperty("subject_name")]
    public string SubjectName { get; set; }
    [JsonProperty("schoolyear_name")]
    public string SchoolYearName { get; set; }
    [JsonProperty("master_timetable_id")]
    public int MasterTimeTableID { get; set; }
    [JsonProperty("from_week")]
    public int FromWeek { get; set; }
    [JsonProperty("to_week")]
    public int ToWeek { get; set; }
    [JsonProperty("from_date")]
    public DateTime FromDate { get; set; }
    [JsonProperty("to_date")]
    public int ToDate { get; set; }
    [JsonProperty("timetable_detail")]
    public object TimeTableDetail { get; set; }
}
#endregion
