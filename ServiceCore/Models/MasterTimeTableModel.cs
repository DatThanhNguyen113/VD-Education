using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Models
{
    public class MasterTimeTableModel
    {
        public int ID { get; set; }
        public int SubjectRegisterID { get; set; }
        public int ClassID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FromWeek { get; set; }
        public int ToWeek { get; set; }
        public string TeacherID { get; set; }
        public int SubjectID { get; set; }
        public int SchoolYearID { get; set; }
        public int ExpectedNumber { get; set; }
    }
}
