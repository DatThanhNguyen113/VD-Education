using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Models.User
{
    public class TimeTableModel
    {
        public dynamic ID { get; set; }
        public int SubjectRegisterID { get; set; }
        [JsonProperty(NullValueHandling =NullValueHandling.Ignore,PropertyName ="subject_id")]
        public int SubjectID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subject_name")]
        public string SubjectName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "date")]
        public DateTime Date { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "lesson_number")]
        public string LessonNumber { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "day")]
        public string Day { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "room")]
        public string Room { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "week_number")]
        public string WeekNumber { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status")]
        public int Status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "session")]
        public string Session { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "created_date")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "updated_date")]
        public DateTime UpdatedDate { get; set; }
        public int MasterTimeTable { get; set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "teacher_name")]
        public string TeacherName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "from_date")]
        public DateTime FromDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "to_date")]
        public DateTime ToDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "from_week")]
        public int FromWeek { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "to_week")]
        public int ToWeek { get; set; }

        public DateTime SetEndDate(DateTime mDate,string s)
        {
            var arr = s.Split(',');
            var mHour = Int32.Parse(arr[arr.Length - 1]);
            mDate = upgradeTime(mDate, mHour,1);
            return mDate;
        }

        public DateTime SetStartDate(DateTime mDate,string s)
        {
            var arr = s.Split(',');
            var mHour = Int32.Parse(arr[0]);
            mDate = upgradeTime(mDate,mHour,0);
            return  mDate;
        }

        protected DateTime upgradeTime(DateTime mTime,int lession, int type)
        {
            mTime = mTime.AddHours(-(mTime.Hour));
            if (lession <= 6)
            {
                mTime = mTime.AddHours(7);
                switch (lession)
                {
                    case 1:
                        {
                            mTime = mTime.AddMinutes(type * 50);
                            break;
                        }
                    case 2:
                        {
                            mTime = mTime.AddMinutes((1 + type) * 50);
                            break;
                        }
                    case 3:
                        {
                            mTime = mTime.AddMinutes((2 + type) * 50 + 5);
                            break;
                        }
                    case 4:
                        {
                            mTime = mTime.AddMinutes((3 + type) * 50 + 15);
                            break;
                        }
                    case 5:
                        {
                            mTime = mTime.AddMinutes((4 + type) * 50 + 15);
                            break;
                        }
                    case 6:
                        {
                            mTime = mTime.AddMinutes((5 + type) * 50 + 15);
                            break;
                        }
                }
            }
            else
            {
                mTime = mTime.AddHours(13);
                switch (lession)
                {

                    case 7:
                        {
                            mTime = mTime.AddMinutes(type * 50);
                            break;
                        }
                    case 8:
                        {
                            mTime = mTime.AddMinutes((1+type) * 50);
                            break;
                        }
                    case 9:
                        {
                            mTime = mTime.AddMinutes((2+type)*50+5);
                            break;
                        }
                    case 10:
                        {
                            mTime = mTime.AddMinutes((3+type)*50 + 15);
                            break;
                        }
                    case 11:
                        {
                            mTime = mTime.AddMinutes((4+type)*50 + 15);
                            break;
                        }
                    case 12:
                        {
                            mTime = mTime.AddMinutes((5+type)*50 + 15);
                            break;
                        }
                }
            }
            return mTime;
        }

    }
}
