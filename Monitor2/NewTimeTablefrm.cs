using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using ServiceCore.DataAccess;
using ServiceCore.Models.Base;
using ServiceCore.Models.User;

namespace Monitor2
{
    public partial class NewTimeTablefrm : Form
    {
        private static NewTimeTablefrm _instance;
        private static object syncLock = new object();
        public static SchedulerControl schedulerControlInstance;
        private static SchedulerStorage schedulerStorageInstance;
        private XtraMessageBoxArgs boxArg = new XtraMessageBoxArgs();

        SubjectDAO dao = new SubjectDAO();
        int MasterTimeTableID;
        string SubjectName ="";
        string TeacherName = "";
        int globalStatus = 0;

        public NewTimeTablefrm() { }

        public NewTimeTablefrm(int id, int staus = 0)
        {
            InitializeComponent();
            MasterTimeTableID = id;
            globalStatus = staus;
            customAppointment();
        }

        private void customAppointment()
        {
            AppointmentMappingInfo mappings = this.schedulerStorage1.Appointments.Mappings;
            mappings.Start = "StartDate";
            mappings.End = "EndDate";
            mappings.Subject = "Room";
            mappings.AllDay = "AllDay";
            mappings.Description = "Description";
            mappings.Label = "SubjectName";
            mappings.Location = "TeacherName";
            mappings.RecurrenceInfo = "RecurrenceInfo";
            mappings.ReminderInfo = "ReminderInfo";
            mappings.ResourceId = "OwnerId";
            mappings.Status = "Status";
            mappings.Type = "EventType";
            mappings.AppointmentId = "ID";
            //mappings.ResourceId = "ID";
        }

        private void NewTimeTablefrm_Load(object sender, EventArgs e)
        {
            //schedulerControl1.DayView.TimeSlots.Add(new TimeSlot(TimeSpan.FromHours(2), "2 hours"));
            //schedulerControl1.DayView.TimeScale = TimeSpan.FromMinutes(30);
            TimeRulerRemark(schedulerControl1);
            schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            LoadSchedulerData();
        }

        private void TimeRulerRemark(SchedulerControl schedulerControl)
        {
            schedulerControl.DayView.TimeSlots.Clear();
            TimeSpan span = TimeSpan.FromMinutes(50);
            schedulerControl1.DayView.TimeSlots.Add(span, "50 Phút");
            schedulerControl1.DayView.TimeScale = span;
            schedulerControl1.DayView.VisibleTime =
                            new TimeOfDayInterval(new TimeSpan(7, 0, 0), new TimeSpan(18, 15, 0));
            schedulerControl1.DayView.VisibleTimeSnapMode = true;
        }

        private void LoadSchedulerData()
        {
            BaseResponseModel<object> baseResponse = dao.GetTimeTable(CacheCore.UserID, MasterTimeTableID);
            var mList = (List<TimeTableModel>)baseResponse.ResponseData;
            foreach (var item in mList)
            {
                SubjectName = item.SubjectName;
                TeacherName = item.TeacherName;
                item.StartDate = item.SetStartDate(item.Date, item.LessonNumber);
                item.EndDate = item.SetEndDate(item.Date, item.LessonNumber);

            }

            if(this.schedulerControl1 == null)
            {
                schedulerControlInstance.Start = mList[0].StartDate;
                schedulerStorageInstance.Appointments.DataSource = mList;
            }
            else
            {
                this.schedulerControl1.Start = mList[0].StartDate;
                this.schedulerStorage1.Appointments.DataSource = mList;
            }
        }

        private void schedulerControl1_InplaceEditorShowing(object sender, InplaceEditorEventArgs e)
        {
          //  e.InplaceEditorEx = new AppointmentEditorControl(e.SchedulerInplaceEditorEventArgs);
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            Monitor2.OutlookAppointmentForm form = new Monitor2.OutlookAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm,SubjectName,TeacherName, MasterTimeTableID, globalStatus);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }
        }

        private void schedulerStorage1_AppointmentDependenciesInserted(object sender, PersistentObjectsEventArgs e)
        {
            Appointment apt = (Appointment)e.Objects;
            apt.Location = TeacherName;
            apt.LabelKey = SubjectName;
        }

        //private void schedulerStorage1_AppointmentDependenciesInserted(object sender, PersistentObjectsEventArgs e)
        //{
        //    Appointment apt = (Appointment)e.Objects;
        //    apt.Location = TeacherName;
        //    apt.LabelKey = SubjectName;
        //}

        public void RefeshScheduler()
        {
            LoadSchedulerData();
        }

        public static NewTimeTablefrm getInstance()
        {
            if(_instance == null)
            {
                lock(syncLock)
                {
                    _instance = new NewTimeTablefrm();
                    schedulerControlInstance = _instance.schedulerControl1;
                    schedulerStorageInstance = _instance.schedulerStorage1;
                } 
            }
            return _instance;
        }

        private void schedulerControl1_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {
            var sourceAppointment = e.SourceAppointment;
            var editedAppointment = e.EditedAppointment;
            if (sourceAppointment.Equals(editedAppointment))
            {
                e.Allow = false;
                return;
            }

            var mSource = schedulerControl1.SelectedAppointments.Where(x=>x.Id!=sourceAppointment.Id).ToList();
            if (ValidateConfictAppointment(e, sourceAppointment, editedAppointment))
            {
                var iModel = ((List<TimeTableModel>)schedulerStorage1.Appointments.DataSource).FirstOrDefault(x => x.ID == Int32.Parse(sourceAppointment.Id.ToString()));
                if(iModel.StartDate.Hour < 13 && iModel.EndDate.Hour >= 13)
                {
                    e.Allow = false;
                    boxArg.Caption = "Thông báo";
                    boxArg.Text = "Tiết học không thể kéo dài 2 buổi";
                    boxArg.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(boxArg).ToString();
                    return;
                }
                if(iModel != null)
                {
                    if(schedulerControl1.ActiveViewType == DevExpress.XtraScheduler.SchedulerViewType.Month)
                    {
                        iModel.Date = editedAppointment.Start.AddHours(-editedAppointment.Start.Hour).AddMinutes(-editedAppointment.Start.Minute);
                    }
                    else
                    {
                        iModel.Date = editedAppointment.Start.AddHours(-editedAppointment.Start.Hour).AddMinutes(-editedAppointment.Start.Minute);
                        List<int> mLesson;
                        if (iModel.EndDate.Hour < 13 || (iModel.EndDate.Hour == 13 && iModel.EndDate.Minute == 0))
                        {
                            mLesson = Ultility.getLessonRage(iModel.StartDate, iModel.EndDate, 0);
                        }
                        else
                        {
                            mLesson = Ultility.getLessonRage(iModel.StartDate, iModel.EndDate, 1);
                        }
                        string sLesson = "";
                        foreach(var item in mLesson)
                        {
                            var iCount = item + 1;
                            sLesson += iCount + ",";
                        }
                        sLesson = sLesson.Remove(sLesson.Length - 1, 1);
                        iModel.LessonNumber = sLesson;
                    }
                    BaseResponseModel<object> mResponse = dao.UpdateTimeTableRow(CacheCore.UserID, iModel);
                    if (mResponse.Result > 0)
                    {
                        //NotifyTimetableChange(MasterTimeTableID,SubjectName);
                        boxArg.Caption = "Thông báo";
                        boxArg.Text = "Thay đổi lịch học thành công";
                        boxArg.Buttons = new DialogResult[] { DialogResult.OK };

                        if(globalStatus == 3)
                        {
                            UserControlSubjectRegister subjectRegister = new UserControlSubjectRegister();
                            string subject = $"[VDADMIN]: Thay đổi thời khóa biểu";
                            string body = $"Khóa học môn {SubjectName} hiện tại đã có sự thay đổi thời khóa biểu. Hãy kiểm tra lại lịch học nhé!";
                            subjectRegister.SendNoticeToSubjectRegister(subject, body, 0, ".TimeTable", 2, MasterTimeTableID);
                        }
                    }
                    else
                    {
                        boxArg.Caption = "Thông báo";
                        boxArg.Text = "Xảy ra lỗi bất ngờ";
                        boxArg.Buttons = new DialogResult[] { DialogResult.OK };
                    }
                }
            }
            
            XtraMessageBox.Show(boxArg).ToString();
        }



        private bool ValidateConfictAppointment(AppointmentDragEventArgs e,Appointment sourceAppointment, Appointment editedAppointment)
        {
            for (int i = 0; i < schedulerControl1.SelectedAppointments.Count; i++)
            {
                var iAppointment = schedulerControl1.SelectedAppointments[i];
                if (iAppointment.Start.Date == editedAppointment.Start.Date)
                {
                    var hightSpan = iAppointment.Start.TimeOfDay;
                    var closeSpan = iAppointment.End.TimeOfDay;
                    var currentSpan = sourceAppointment.Start.TimeOfDay;
                    if (hightSpan >= currentSpan && closeSpan > currentSpan)
                    {
                        schedulerControl1.CancelUpdate();
                        editedAppointment = sourceAppointment;
                        e.Allow = false;
                        boxArg.Caption = "Thông báo";
                        boxArg.Text = "Xảy ra trùng lặp thời gian tại ngày đã chọn. Xin chọn một ngày khác";
                        boxArg.Buttons = new DialogResult[] { DialogResult.OK };
                        return false;
                    }
                }
            }
            return true;
        }

        //public void NotifyTimetableChange(int mastertimetableid,string subjectName)
        //{
        //    string subject = "[VDADMIN]: Thay đổi thời khóa biểu";
        //    string body = string.Format("Đã có sự thay đổi thời khóa biểu với môn {0}. Các bạn hãy xem lại lịch học nhé", subjectName);
        //    UserControlSubjectRegister subjectRegister = new UserControlSubjectRegister();
        //    var id = subjectRegister.SetNotifyMasterRow(subject, body, 0);
        //    if (id > 0)
        //    {
        //        var mList = subjectRegister.GetSutdentInSection(mastertimetableid);
        //        foreach (var item in mList)
        //        {
        //            var mResult = subjectRegister.SetNotifyDetailRow(id, item.ID,".SubjectRegister");
        //            subjectRegister.SendSectionNotice(subject, body, 1, item.ID, mResult,".TimeTable");

        //            if (mResult < 0)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}

        private void schedulerControl1_AllowAppointmentResize(object sender, AppointmentOperationEventArgs e)
        {
            e.Allow = false;
        }
    }
}
