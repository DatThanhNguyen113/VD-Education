using ServiceCore.DataAccess;
using ServiceCore.Models;
using ServiceCore.Models.Base;
using ServiceCore.Models.Subject;
using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Monitor2
{
    static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            //Form1 fLogin = new Form1();
            //fLogin.ShowDialog();
            //if (fLogin.UserID > 0)
            //{
            //    FormMain f2 = new FormMain();
            //    f2.UserID = fLogin.UserID;
            //    Application.Run(f2);
            //}
            if (DetectWifiAvailable())
            {
                loadStatisList();
                FormMain f2 = new FormMain();
                f2.UserID = 13;
                //Form1 frm1 = new Form1();
                Application.Run(f2);
            }
            else
            {
                MessageBox.Show("Xin kiểm tra lại kết nối internet của bạn!");
            }

        }

        static bool DetectWifiAvailable()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

         static void loadStatisList()
        {
            SubjectDAO subjectDAO = new SubjectDAO();
            ClassDAO classDAO = new ClassDAO();
            TeacherDAO teacherDAO = new TeacherDAO();
            if (CacheCore.mWeekList == null || CacheCore.mWeekList.Count < 1)
            {
                UtilityDAO dao = new UtilityDAO();
                var mResp = dao.GetWeek();
                CacheCore.mWeekList = (List<WeekModel>)mResp.ResponseData;
            }
            if (CacheCore.mRoomList == null || CacheCore.mRoomList.Count < 1)
            {
                UtilityDAO dao = new UtilityDAO();
                var mResp = dao.GetRoom();
                CacheCore.mRoomList = (List<RoomModel>)mResp.ResponseData;
            }
            if (CacheCore.mSubjectRegisterModelList == null || CacheCore.mSubjectRegisterModelList.Count < 1)
            {
                SubjectDAO dao = new SubjectDAO();
                BaseResponseModel<object> baseResponse = dao.GetSubjectRegister(CacheCore.UserID, "EMPL");
                CacheCore.mSubjectRegisterModelList = new List<SubjectRegisterModel>();
                CacheCore.mSubjectRegisterModelList = (List<SubjectRegisterModel>)baseResponse.ResponseData;
            }

            if (CacheCore.mClassList == null || CacheCore.mClassList.Count < 1)
            {
                BaseResponseModel<object> baseResponse = classDAO.GetAllClass(CacheCore.UserID);
                CacheCore.mClassList = (List<ClassModel>)baseResponse.ResponseData;
            }

            if (CacheCore.mCareerList == null || CacheCore.mCareerList.Count < 1)
            {
                BaseResponseModel<object> baseResponse = classDAO.GetAllCareer(CacheCore.UserID);
                CacheCore.mCareerList = (List<CareerModel>)baseResponse.ResponseData;
            }

            if (CacheCore.mSchoolYearList == null || CacheCore.mSchoolYearList.Count < 1)
            {
                BaseResponseModel<object> baseResponse = classDAO.GetAllSchoolYear(CacheCore.UserID);
                CacheCore.mSchoolYearList = (List<SchoolYearModel>)baseResponse.ResponseData;
            }

            if (CacheCore.mSubjectList == null || CacheCore.mSubjectList.Count < 1)
            {
                BaseResponseModel<object> baseResponse = subjectDAO.GetAllSubject(CacheCore.UserID);
                CacheCore.mSubjectList = (List<SubjectModel>)baseResponse.ResponseData;
            }

            if (CacheCore.mTeacherList == null || CacheCore.mTeacherList.Count < 1)
            {
                BaseResponseModel<object> baseResponse = teacherDAO.GetAllTeacher(CacheCore.UserID);
                CacheCore.mTeacherList = (List<TeacherModel>)baseResponse.ResponseData;
            }
        }
    }
}
