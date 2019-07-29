using ServiceCore.Models;
using ServiceCore.Models.Base;
using ServiceCore.Models.Subject;
using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.DataAccess
{
    public class SubjectDAO
    {


        //connect
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ToString());
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private BaseResponseModel<object> baseResponseModel;

        public BaseResponseModel<object> CreateSubjectRegister(SubjectRegisterModel model)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    TeacherID = model.TeacherID,
                    SubjectID = model.SubjectID,
                    ExpectedStudenNumber = model.ExpectedStudentNumber,
                    SchoolYearID = model.SchoolYearID
                }, "4", "");
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

        public BaseResponseModel<object> GetSubjectRegister(string UserId,string mContext,int classid = 0)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ClassID = classid
                }, "4", mContext, UserId);
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<SubjectRegisterModel>(ds);
                return baseResponseModel;

            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> RegistSubject(SubjectRegisterModel model,string UserId)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    MasterTimeTableID = model.MasterTimeTableID
                }, "3", "", UserId);
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

        public BaseResponseModel<object> GetRegistedSubject(string UserId)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "3", "SELF", UserId);
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<SubjectRegisterModel>(ds);
                baseResponseModel.ResponseData = ((List<SubjectRegisterModel>)baseResponseModel.ResponseData).Select(x => new { x.TeacherName, x.Code, x.Name, x.TotalCredits, x.PracticeCredit, x.TheoryCredit, x.LessionNumber, x.FinalEvaluationPercent, x.DiligencePercent });
                return baseResponseModel;

            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> RevokeRegistedSubject(SubjectRegisterModel model, string UserId)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>("UPDATE", new
                {
                    RegistedSubjectID = model.SubjectRegistedID
                }, "3", "DELETE", UserId);
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

        public BaseResponseModel<object> GetAllSubject(string UserId)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1006", "", UserId);
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<SubjectModel>(ds);
                return baseResponseModel;

            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> UpdateSubjectRegisterStatus(string UserId,int subjectregisterid, int status,string context)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    ID = subjectregisterid,
                    Status = status
                }, "1008", context, UserId);
                var ds = db.ExecuteAction(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<SubjectRegisterModel>(ds);
                return baseResponseModel;
            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> CreateTimeTable(string UserId,TimeTableModel model)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    SubjectRegisterID = model.SubjectRegisterID,
                    Date = model.Date,
                    LessonNumber = model.LessonNumber,
                    Day = model.Day,
                    Room = model.Room,
                    WeekNumber = model.WeekNumber,
                    CreateDate = model.CreatedDate,
                    Session = model.Session
                }, "1009", "INSERT", UserId);
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

        public BaseResponseModel<object> GetTimeTable(string UserId, int SubjectRegisterID)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    SubjectRegisterID = SubjectRegisterID
                }, "1009", "EMP", UserId);
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<TimeTableModel>(ds);
                return baseResponseModel;
            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> GetTimeTableByUser(string UserId)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1009", "", UserId);
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<TimeTableModel>(ds);
                return baseResponseModel;
            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> UpdateTimeTableRow(string UserId, TimeTableModel model)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    ID = model.ID,
                    Date = model.Date,
                    Day = model.Day,
                    LessonNumber = model.LessonNumber,
                    Room = model.Room,
                    Session = model.Session,
                    MasterTimeTable = model.MasterTimeTable
                }, "1009", "UPDATE::ROW", UserId);
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

        public BaseResponseModel<object> GetMuster(string UserId, DateTime currentdate, int Source = 0, int TimeTableID = 0)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = "";
                if(Source == 0)
                {
                    string session = "";
                    if(currentdate.Hour < 12)
                    {
                        session = "Sáng".ToLower();
                    }
                    else
                    {
                        session = "Chiều".ToLower();
                    }
                    xml = Render.GenerateXmlFromObject<object>(null, new
                    {
                        TimeTableID = TimeTableID,
                        Session = session,
                        CurrentDate = currentdate.ToString("yyyy-MM-dd")
                    }, "2003", "TEA", UserId);
                }
                else
                {
                    xml = Render.GenerateXmlFromObject<object>(null, new
                    {
                        TimeTableID = TimeTableID
                    }, "2003", "EMP", UserId);
                }
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<MusterModel>(ds);
                return baseResponseModel;
            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> UpdateMuster(string UserId,int TimeTableID,int type,string title="",int MusterID=0,string studentid = "")
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = "";
                if (type == 0)
                {
                    xml = Render.GenerateXmlFromObject<object>("UPDATE", new
                    {
                        TimeTableID = TimeTableID,
                        Title = title
                    }, "2003", "UPDATE::TITLE", UserId);
                }
                else
                {
                    xml = Render.GenerateXmlFromObject<object>("UPDATE", new
                    {
                        MusterID = MusterID,
                        TimeTableID = TimeTableID,
                        StudentID = studentid
                    }, "2003", "UPDATE::MUSTER", UserId);
                }
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

        public BaseResponseModel<object> AddMasterTimeTable( MasterTimeTableModel model)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    TeacherID = model.TeacherID,
                    SubjectRegisterID = model.SubjectRegisterID,
                    ClassID = model.ClassID,
                    SubjectID = model.SubjectID,
                    SchoolYearID = model.SchoolYearID,
                    ExpextedNumber = model.ExpectedNumber
                }, "2006", "", "13");
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


        private void openconnect()
        {
            //close
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void closeconnect()
        {
            //close
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public Boolean exedata(string cmd)
        {
            //sql
            openconnect();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            closeconnect();
            return check;
        }
        public void loadCBB(ComboBox cmd, String sql, String display, String value)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ToString());
            con.Open();
            DataSet dataSet;
            SqlDataAdapter adapter;
            SqlCommand sl = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(sl);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            cmd.DataSource = dataSet.Tables[0];
            cmd.DisplayMember = display;
            cmd.ValueMember = value;
            con.Close();
        }

    }
}
