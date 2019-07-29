using ServiceCore.Models;
using ServiceCore.Models.Subject;
using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor2
{
    public class CacheCore
    {
        public static string UserID { get; set; } = "13";
        public static List<SubjectRegisterModel> mSubjectRegisterModelList { get; set; }
        public static List<ClassModel> mClassList { get; set; }
        public static List<CareerModel> mCareerList { get; set; }
        public static List<SchoolYearModel> mSchoolYearList { get; set; }
        public static List<SubjectModel> mSubjectList { get; set; }
        public static List<TeacherModel> mTeacherList { get; set; }
        public static List<WeekModel> mWeekList { get; set; }
        public static List<RoomModel> mRoomList { get; set; }
    }
}
