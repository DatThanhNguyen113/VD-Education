using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ServiceCore.DataAccess;
using ServiceCore.Models;
using ServiceCore.Models.Base;
using ServiceCore.Models.Subject;
using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace Monitor2
{
    /// <summary>
    /// author: DatNguyen - 07/06/2019
    /// </summary>
    /// 
    public partial class NewCoursefrm : Form
    {
        #region global variable
        Dictionary<string, GroupControl> ControlManager = new Dictionary<string, GroupControl>();
        string SubjectCode = "";
        int SchoolYearID = 0;
        int ExpectedStudent;
        BackgroundWorker backgroundWorkerGenerateTimeTable;
        ProgressDialog dialog;
        string TeacherName;
        bool IsRunSuccess = true;
        Task dialogThread;
        int SubjectRegisterID = 0;
        #endregion

        ICallBackArg callBack;
        public NewCoursefrm(string subbjectCode,string teacherName,int subjectRegisterID,ICallBackArg callBackArg)
        {
            InitializeComponent();
            SubjectCode = subbjectCode;
            callBack = callBackArg;
            lbTeacher.Text = teacherName;
            SubjectRegisterID = subjectRegisterID;
            var mList = SubClass.GetInstance().GetBySubjectRegister(subjectRegisterID);
            gcClass.DataSource = mList;
            gvClass.BestFitColumns();
            CacheCore.mWeekList = WeekModel.GetInstance().GetAll();
            CacheCore.mRoomList = RoomModel.GetInstance().GetAll();
        }

        public NewCoursefrm(int subjectregisterid)
        {
            InitializeComponent();

        }

        public NewCoursefrm()
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewCoursefrm_Load(object sender, EventArgs e)
        {
            GetSubjectDetail(SubjectCode);
            LoadComboBoxData();
        }

        private void GetSubjectDetail(string code)
        {
            var item = CacheCore.mSubjectList.FirstOrDefault(x => x.Code == code);
            if(item != null)
            {
                lbSubjectCode.Text = item.Code;
                lbSubjectName.Text = item.Name;
               // lbYear.Text = CacheCore.mSchoolYearList.FirstOrDefault(x => x.ID == item.SchoolYearID).Name;
            }
        }

        private void LoadSubClassList()
        {
            var mList = CacheCore.mClassList;
            List<SubClass> mSubClass = new List<SubClass>();
            for(int i = 0; i < mList.Count; i++)
            {
                var model = mList[i];
                SubClass item = new SubClass();
                item.ID = model.ID;
                item.Code = model.Code;
                item.Name = model.Name;
                mSubClass.Add(item);
            }
            gcClass.DataSource = mSubClass;
            gvClass.BestFitColumns();
        }

        public void LoadComboBoxData()
        {
            foreach (var item in CacheCore.mWeekList)
            {
                ComboBoxItem cbxItem = new ComboBoxItem();
                cbxItem.Value = item.ID;
                cbxItem.Text = item.Name;
                SetUpComboBoxItem(cbxStartWeek,cbxItem);
                
                SetUpComboBoxItem(cbxEndWeek, cbxItem);
            }
            dpStartDate.EditValue = CacheCore.mWeekList[0].StartDate;
            dpEnđate.EditValue = CacheCore.mWeekList[0].EndDate;
        }

        public void SetUpComboBoxItem(ComboBoxEdit cbx, object cbxItem)
        {
            ComboBoxItemCollection collection1 = cbx.Properties.Items;
            collection1.BeginUpdate();
            try
            {
                collection1.Add(cbxItem);
            }
            finally
            {
                collection1.EndUpdate();
            }
            cbx.SelectedIndex = 0;
        }

        private void cbxStartWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mItem = (ComboBoxItem)cbxStartWeek.EditValue;
            var model = CacheCore.mWeekList.FirstOrDefault(x => x.ID == mItem.Value);
            if(model != null)
            {
                dpStartDate.EditValue = model.StartDate;
            }
        }

        private void cbxEndWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mItem = (ComboBoxItem)cbxEndWeek.EditValue;
            var model = CacheCore.mWeekList.FirstOrDefault(x => x.ID == mItem.Value);
            if (model != null)
            {
                dpEnđate.EditValue = model.EndDate;
            }
        }

        private GroupControl SumaryGroupControl(string name,string text,GroupControl roomControl, GroupControl sessionControl, GroupControl lessionControl)
        {
            GroupControl groupControl = new GroupControl();
            groupControl.Controls.Add(lessionControl);
            var flowControl = (FlowLayoutPanel)sessionControl.Controls[0];
            var checkedMorning = (CheckEdit)flowControl.Controls[0];
            var checkedAfterNoon = (CheckEdit)flowControl.Controls[1];
            var checkedListBox = (CheckedListBox)lessionControl.Controls[0];
            checkedMorning.CheckedChanged += (sender,e) => checkedMorning_CheckedChanged(sender,e, checkedListBox, checkedAfterNoon, name, roomControl, groupControl);
            checkedAfterNoon.CheckedChanged += (sender, e) => checkedAfterNoon_CheckedChanged(sender, e, checkedListBox, checkedMorning, name, roomControl, groupControl);
            groupControl.Controls.Add(sessionControl);
            groupControl.Controls.Add(roomControl);
            groupControl.Name = "groupControl" + name;
            groupControl.Size = new System.Drawing.Size(161, 209);
            groupControl.TabIndex = 0;
            groupControl.Text = text;

          
            return groupControl;
        }

        #region session checked change event
        private void checkedMorning_CheckedChanged(object sender, System.EventArgs e,CheckedListBox checkedListBox, CheckEdit checkTwo,string name,GroupControl roomControl,GroupControl groupControl)
        {
            CheckEdit edit = sender as CheckEdit;
            if(edit.Checked && checkTwo.Checked)
            {
                checkedListBox.Items.Clear();
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 1",
            "Tiết 2",
            "Tiết 3",
            "Tiết 4",
            "Tiết 5",
            "Tiết 6",
            "Tiết 7",
            "Tiết 8",
            "Tiết 9",
            "Tiết 10",
            "Tiết 11",
            "Tiết 12"});
            }
            else if(edit.Checked)
            {
                checkedListBox.Items.Clear();
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 1",
            "Tiết 2",
            "Tiết 3",
            "Tiết 4",
            "Tiết 5",
            "Tiết 6"});
            }
            else if (checkTwo.Checked)
            {
                checkedListBox.Items.Clear();
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 7",
            "Tiết 8",
            "Tiết 9",
            "Tiết 10",
            "Tiết 11",
            "Tiết 12"});
            }
            else
            {
                checkedListBox.Items.Clear();
            }
            ConflictSelector(edit, checkTwo, (ComboBoxEdit)roomControl.Controls[0], name, groupControl);
        }

        private void checkedAfterNoon_CheckedChanged(object sender, System.EventArgs e, CheckedListBox checkedListBox, CheckEdit checkTwo,string name, GroupControl roomControl,GroupControl groupControl)
        {
            CheckEdit edit = sender as CheckEdit;
            if (edit.Checked && checkTwo.Checked)
            {
                checkedListBox.Items.Clear();
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 1",
            "Tiết 2",
            "Tiết 3",
            "Tiết 4",
            "Tiết 5",
            "Tiết 6",
            "Tiết 7",
            "Tiết 8",
            "Tiết 9",
            "Tiết 10",
            "Tiết 11",
            "Tiết 12"});
            }
            else if (edit.Checked)
            {
                checkedListBox.Items.Clear();
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 7",
            "Tiết 8",
            "Tiết 9",
            "Tiết 10",
            "Tiết 11",
            "Tiết 12"});
               
            }
            else if (checkTwo.Checked)
            {
                checkedListBox.Items.Clear();
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 1",
            "Tiết 2",
            "Tiết 3",
            "Tiết 4",
            "Tiết 5",
            "Tiết 6"});
            }
            else
            {
                checkedListBox.Items.Clear();
            }
            ConflictSelector(checkTwo,edit, (ComboBoxEdit)roomControl.Controls[0], name, groupControl);
        }

        #endregion

        private GroupControl GetRoomControl()
        {
            GroupControl groupControl = new GroupControl();
            groupControl.Text = "Phòng";
            groupControl.Size = new System.Drawing.Size(157, 42);
            ComboBoxEdit cbxEdit = new ComboBoxEdit();
            foreach(var data in CacheCore.mRoomList)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Value = data.ID;
                comboBoxItem.Text = data.Code;
                SetUpComboBoxItem(cbxEdit, comboBoxItem);

            }
            cbxEdit.Dock = DockStyle.Fill;
            groupControl.Controls.Add(cbxEdit);
            groupControl.Dock = DockStyle.Top;
            return groupControl;
        }

        private GroupControl GetSessionControl()
        {
            GroupControl groupControl = new GroupControl();
            groupControl.Text = "Buổi học";
            groupControl.Size = new System.Drawing.Size(157, 45);

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;

            CheckEdit checkEditMorning = new CheckEdit();
            checkEditMorning.Size = new System.Drawing.Size(62, 19);
            checkEditMorning.Properties.Caption = "Sáng";

            CheckEdit checkEditAferNoon = new CheckEdit();
            checkEditAferNoon.Size = new System.Drawing.Size(62, 19);
            checkEditAferNoon.Properties.Caption = "Chiều";

            flow.Controls.Add(checkEditMorning);
            flow.Controls.Add(checkEditAferNoon);
            groupControl.Controls.Add(flow);
            groupControl.Dock = DockStyle.Top;
            return groupControl;
        }
    

        private GroupControl GetLessionControl()
        {
            GroupControl groupControl = new GroupControl();
            groupControl.Text = "Tiết học";
            groupControl.Size = new System.Drawing.Size(157, 100);
            groupControl.Dock = DockStyle.Fill;
            CheckedListBox checkedList = new CheckedListBox();
            checkedList.Dock = System.Windows.Forms.DockStyle.Fill;
            checkedList.FormattingEnabled = true;
            groupControl.Controls.Add(checkedList);
            return groupControl;
        }

        #region checkbox day
        private void ckMonday_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMonday.Checked)
            {
                var mControl = SumaryGroupControl("Monday","Thứ 2",GetRoomControl(),GetSessionControl(),GetLessionControl());
                if (!ControlManager.ContainsKey(mControl.Name))
                {
                    mControl.Text = "Thứ 2";
                    ControlManager.Add(mControl.Name, mControl);
                    flowLayoutPanel1.Controls.Add(mControl);
                }
            }
            else
            {
                if (ControlManager.ContainsKey("groupControlMonday"))
                {
                    flowLayoutPanel1.Controls.Remove(ControlManager["groupControlMonday"]);
                    ControlManager.Remove("groupControlMonday");
                }
            }
        }
       

        private void ckTuesday_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTuesday.Checked)
            {
                var mControl = SumaryGroupControl("Tuesday", "Thứ 3", GetRoomControl(), GetSessionControl(), GetLessionControl());
                if (!ControlManager.ContainsKey(mControl.Name))
                {
                    mControl.Text = "Thứ 3";
                    ControlManager.Add(mControl.Name, mControl);
                    flowLayoutPanel1.Controls.Add(mControl);
                }
            }
            else
            {
                if (ControlManager.ContainsKey("groupControlTuesday"))
                {
                    flowLayoutPanel1.Controls.Remove(ControlManager["groupControlTuesday"]);
                    ControlManager.Remove("groupControlTuesday");
                }

            }
        }

        private void ckWednesday_CheckedChanged(object sender, EventArgs e)
        {
            if (ckWednesday.Checked)
            {
                var mControl = SumaryGroupControl("Wednesday", "Thứ 4", GetRoomControl(), GetSessionControl(), GetLessionControl());
                if (!ControlManager.ContainsKey(mControl.Name))
                {
                    mControl.Text = "Thứ 4";
                    ControlManager.Add(mControl.Name, mControl);
                    flowLayoutPanel1.Controls.Add(mControl);
                }
            }
            else
            {
                if (ControlManager.ContainsKey("groupControlWednesday"))
                {
                    flowLayoutPanel1.Controls.Remove(ControlManager["groupControlWednesday"]);
                    ControlManager.Remove("groupControlWednesday");
                }

            }
        }

        private void ckThursday_CheckedChanged(object sender, EventArgs e)
        {
            if (ckThursday.Checked)
            {
                var mControl = SumaryGroupControl("Thursday", "Thứ 5", GetRoomControl(), GetSessionControl(), GetLessionControl());
                if (!ControlManager.ContainsKey(mControl.Name))
                {
                    mControl.Text = "Thứ 5";
                    ControlManager.Add(mControl.Name, mControl);
                    flowLayoutPanel1.Controls.Add(mControl);
                }
            }
            else
            {
                if (ControlManager.ContainsKey("groupControlThursday"))
                {
                    flowLayoutPanel1.Controls.Remove(ControlManager["groupControlThursday"]);
                    ControlManager.Remove("groupControlThursday");
                }

            }
        }

        private void ckFriday_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFriday.Checked)
            {
                var mControl = SumaryGroupControl("Friday", "Thứ 6", GetRoomControl(), GetSessionControl(), GetLessionControl());
                if (!ControlManager.ContainsKey(mControl.Name))
                {
                    mControl.Text = "Thứ 6";
                    ControlManager.Add(mControl.Name, mControl);
                    flowLayoutPanel1.Controls.Add(mControl);
                }
            }
            else
            {
                if (ControlManager.ContainsKey("groupControlFriday"))
                {
                    flowLayoutPanel1.Controls.Remove(ControlManager["groupControlFriday"]);
                    ControlManager.Remove("groupControlFriday");
                }
                   
            }
        }

        private void ckSaturday_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSaturday.Checked)
            {
                var mControl = SumaryGroupControl("Saturday", "Thứ 7", GetRoomControl(), GetSessionControl(), GetLessionControl());
                if (!ControlManager.ContainsKey(mControl.Name))
                {
                    mControl.Text = "Thứ 7";
                    ControlManager.Add(mControl.Name, mControl);
                    flowLayoutPanel1.Controls.Add(mControl);
                }
            }
            else
            {
                if (ControlManager.ContainsKey("groupControlSaturday"))
                {
                    flowLayoutPanel1.Controls.Remove(ControlManager["groupControlSaturday"]);
                    ControlManager.Remove("groupControlSaturday");
                }
                 
            }
        }

        private void ckSunday_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSunday.Checked)
            {
                var mControl = SumaryGroupControl("Sunday", "Chủ nhật", GetRoomControl(), GetSessionControl(), GetLessionControl());
                if (!ControlManager.ContainsKey(mControl.Name))
                {
                    mControl.Text = "Chủ nhật";
                    ControlManager.Add(mControl.Name, mControl);
                    flowLayoutPanel1.Controls.Add(mControl);
                }
            }
            else
            {
                if (ControlManager.ContainsKey("groupControlSunday"))
                {
                    flowLayoutPanel1.Controls.Remove(ControlManager["groupControlSunday"]);
                    ControlManager.Remove("groupControlSunday");
                }
            }
        }
        #endregion
        private void ConflictSelector(CheckEdit check1,CheckEdit check2,ComboBoxEdit cbxRoom,string day,GroupControl groupControl)
        {
            //if((check1.Checked || check2.Checked) && cbxRoom.SelectedIndex > -1)
            //{
            //    string sesson = "";
            //    if (check1.Checked)
            //    {
            //        sesson = "Sáng";
            //    }
            //    else
            //    {
            //        sesson = "Chiều";
            //    }
            //    var status = GetDateRangeConfict(day,sesson,cbxRoom.EditValue.ToString());
            //    if (!status)
            //    {
            //        groupControl.LookAndFeel.UseWindowsXPTheme = false;
            //        groupControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            //    }
            //    else
            //    {
            //        groupControl.LookAndFeel.UseWindowsXPTheme = true;
            //    }
            //}
        }

        private bool GetDateRangeConfict(string day,string session,string room)
        {
            var startDate = DateTime.Parse(dpStartDate.EditValue.ToString());
            var endDate = DateTime.Parse(dpEnđate.EditValue.ToString());
            var totalDate = (endDate - startDate).TotalDays;
            for(int i = 1; i < totalDate; i++)
            {
                var mDate = startDate.AddDays(i);
                var dow = mDate.DayOfWeek.ToString();
                if(dow.ToLower() == day.ToLower())
                {
                    var result = checkConflictSession(mDate, session, room);
                    if(result.ID < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private BaseResult checkConflictSession(DateTime date,string session,string room)
        {
            CCoreDao db = new CCoreDao();
            GenerateData Render = new GenerateData();
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    Date = date,
                    Sesson = session,
                    Room = room
                }, "2011", "", CacheCore.UserID);
                var ds = db.GetContextData(xml);
                var response = Render.ResponseObject<BaseResult>(ds.Tables[0]);
                return response;
            }
            catch
            {
                return null;
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                backgroundWorkerGenerateTimeTable = new BackgroundWorker();
                backgroundWorkerGenerateTimeTable.WorkerReportsProgress = true;
                backgroundWorkerGenerateTimeTable.ProgressChanged += backgroundWorkerGenerateTimeTable_ProgressChanged;
                backgroundWorkerGenerateTimeTable.DoWork += backgroundWorkerGenerateTimeTable_DoWork;
                backgroundWorkerGenerateTimeTable.RunWorkerCompleted += backgroundWorkerGenerateTimeTable_RunWorkerCompleted;
                if (backgroundWorkerGenerateTimeTable.IsBusy)
                {
                    backgroundWorkerGenerateTimeTable.CancelAsync();
                }
                else
                {
                    backgroundWorkerGenerateTimeTable.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Xin chọn các thông tin cần thiết");
                return;
            }
        }

        private bool validateForm()
        {
            bool isSuccess = false;
            for(int i = 0; i < gvClass.RowCount; i++)
            {
                int checkEdit =  Int32.Parse(gvClass.GetRowCellValue(i, "Status").ToString());
                if (checkEdit == 1)
                {
                    isSuccess =  true;
                }
            }
            if (isSuccess)
            {
                if (!ckMonday.Checked && !ckTuesday.Checked && !ckWednesday.Checked && !ckFriday.Checked && !ckThursday.Checked && !ckSaturday.Checked && !ckSunday.Checked)
                {
                    isSuccess = false;
                }
            }

            return isSuccess;
        }

        private double progressCount = 0;
        private int headNumber = 0;
        private double progressTotalPercent = 0;
        private double currentProgressPercent = 0;

        private void backgroundWorkerGenerateTimeTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dialogThread.Dispose();
            }
            catch { }

            callBack.TimeTable_Created(SubjectRegisterID, lbSubjectName.Text);

            if (IsRunSuccess)
            {
                progressBar1.Value = 100;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void backgroundWorkerGenerateTimeTable_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage < 100)
            {
                progressBar1.Value = e.ProgressPercentage;
            }
        }


        private void backgroundWorkerGenerateTimeTable_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SubjectDAO subjectDAO = new SubjectDAO();
                var mSubClassList = (List<SubClass>)gcClass.DataSource;
                headNumber = 100 / mSubClassList.Count;
                //foreach (var classItem in mSubClassList)
                //{
                //    if (classItem.Status == 1)
                //    {

                //    }
                //}
                //MasterTimeTableModel model = new MasterTimeTableModel();
                //model.SubjectRegisterID = SubjectRegisterID;
                //model.ClassID = classItem.ID;
                //model.FromDate = DateTime.Parse(dpStartDate.EditValue.ToString());
                //model.ToDate = DateTime.Parse(dpEnđate.EditValue.ToString());
                //var fromCbxItem = (ComboBoxItem)cbxStartWeek.SelectedItem;
                //var endCbxItem = (ComboBoxItem)cbxEndWeek.SelectedItem;
                //model.FromWeek = fromCbxItem.Value;
                //model.ToWeek = endCbxItem.Value;

                var model = SubjectRegisterModel.GetInstance();
                model.ID = SubjectRegisterID;
                model.StartLearnDate = DateTime.Parse(dpStartDate.EditValue.ToString());
                model.EndLearnDate = DateTime.Parse(dpEnđate.EditValue.ToString());
                var fromCbxItem = (ComboBoxItem)cbxStartWeek.SelectedItem;
                var endCbxItem = (ComboBoxItem)cbxEndWeek.SelectedItem;
                model.FromWeek = fromCbxItem.Value;
                model.ToWeek = endCbxItem.Value;
                model.UpdateTime();
                //BaseResponseModel<object> baseResponse = subjectDAO.AddMasterTimeTable(model);
                //if (baseResponse.Result > 0)
                //{
                //    CaculateTimeTableRow(baseResponse.Result, subjectDAO, DateTime.Parse(dpStartDate.EditValue.ToString()), DateTime.Parse(dpEnđate.EditValue.ToString()), out IsRunSuccess);
                //    if (!IsRunSuccess)
                //    {
                //        break;
                //    }
                //}
                CaculateTimeTableRow(SubjectRegisterID, subjectDAO, DateTime.Parse(dpStartDate.EditValue.ToString()), DateTime.Parse(dpEnđate.EditValue.ToString()), out IsRunSuccess);
                model.UpdateStatus(2);
                
            }
            catch
            {
                IsRunSuccess = false;
            }
        }

        private void CaculateTimeTableRow(int id, SubjectDAO dao, DateTime startdate, DateTime endDate, out bool IsRunnSuccess)
        {
            int totalDay = Int32.Parse((endDate - startdate).TotalDays.ToString());
            var currentDate = DateTime.Now;
            currentProgressPercent = totalDay / headNumber;
            for (int i = 0; i < totalDay; i++)
            {
                var mDate = startdate.AddDays(i + 1);
                GroupControl groupControl;
                if (GetSelectedDayofWeek(mDate.DayOfWeek.ToString(),out groupControl))
                {
                    TimeTableModel model = new TimeTableModel();
                    model.SubjectRegisterID = id;
                    model.CreatedDate = currentDate;
                    model.Date = mDate;
                    model.Day = ConvertDateOfWeek(mDate.DayOfWeek.ToString());
                    var roomName = "";
                    var isRoom = GetRoomString(groupControl, out roomName);
                    if (isRoom)
                    {
                        model.Room = roomName;
                    }
                    string morningSession = "", afternoonSession = "";
                    var isSession = GetSessionString(groupControl,out morningSession, out afternoonSession);
                    if (isSession)
                    {
                        if(morningSession.Length > 0)
                        {
                            model.Session = "Sáng";
                            model.LessonNumber = morningSession.Remove(morningSession.Length-1,1);
                            BaseResponseModel<object> baseResponse = dao.CreateTimeTable(CacheCore.UserID, model);
                            if (baseResponse.Result < 0)
                            {
                                IsRunnSuccess = false;
                                break;
                            }
                        }

                        if(afternoonSession.Length > 0)
                        {
                            model.Session = "Chiều";
                            model.LessonNumber = afternoonSession.Remove(afternoonSession.Length - 1, 1);
                            BaseResponseModel<object> baseResponse = dao.CreateTimeTable(CacheCore.UserID, model);
                            if (baseResponse.Result < 0)
                            {
                                IsRunSuccess = false;
                                break;
                            }
                        }
                    }
                    progressTotalPercent += currentProgressPercent;
                    backgroundWorkerGenerateTimeTable.ReportProgress(Int32.Parse(progressTotalPercent.ToString()), "Đang thực thi....");
                }
            }
            IsRunnSuccess = true;
        }


        private bool GetSelectedDayofWeek(string day, out GroupControl control)
        {
            foreach(var item in ControlManager)
            {
                if (item.Key.ToLower().Contains(day.ToLower()))
                {
                    control = item.Value;
                    return true;
                }
            }
            control = new GroupControl();
            return false;
        }

        private string ConvertDateOfWeek(string day)
        {
            if (day.Length > 0)
            {
                if (day == "Sunday")
                {
                    return "Chủ Nhật";
                }
                else if (day == "Monday")
                {
                    return "Thứ Hai";
                }
                else if (day == "Tuesday")
                {
                    return "Thứ Ba";
                }
                else if (day == "Wednesday")
                {
                    return "Thứ Tư";
                }
                else if (day == "Thursday")
                {
                    return "Thứ Năm";
                }
                else if (day == "Friday")
                {
                    return "Thứ Sáu";
                }
                else if (day == "Saturday")
                {
                    return "Thứ Bảy";
                }
            }
            return "";
        }

        private bool GetSessionString(GroupControl control, out string morningSession, out string afternoonSession)
        {
            try
            {
                var mGroup = control.Controls[0];
                var checkedLisst = (CheckedListBox)mGroup.Controls[0];
                List<int> lessionList = new List<int>();
                foreach (var itemChecked in checkedLisst.CheckedItems)
                {
                    var m = itemChecked.ToString().Split(' ');
                    lessionList.Add(Int32.Parse(m[m.Length - 1]));
                }
                string s = "", q = "";
                foreach(var data in lessionList)
                {
                    if(data <= 6)
                    {
                        s += data + ",";
                    }
                    else
                    {
                        q += data + ",";
                    }
                }
                morningSession = s;
                afternoonSession = q;
                return true;
            }
            catch
            {
                morningSession = "";
                afternoonSession = "";
                return false;
            }
        }

        private bool GetRoomString(GroupControl control,out string roomName)
        {
            try
            {
                var mGroup = control.Controls[2];
                var cbxEdit = (ComboBoxEdit)mGroup.Controls[0];
                roomName = cbxEdit.Text;
                return true;
            }
            catch
            {
                roomName = "";
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewCoursefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserControlSubjectRegister userControlSubjectRegister = UserControlSubjectRegister._instance;
            userControlSubjectRegister.ReloadCurrentItem();
        }

        //private bool GetLessionString(GroupControl control, out string lession)
        //{
        //    try
        //    {
        //        var mGroup = control.Controls[2];
        //        var checkedLisst = (CheckedListBoxControl)mGroup.Controls[0];
        //        string s = "";
        //        foreach (var itemChecked in checkedLisst.CheckedItems)
        //        {
        //            var m = itemChecked.ToString().Split(' ');
        //            s += m[m.Length - 1];
        //        }
        //        lession = s;
        //        return true;
        //    }
        //    catch
        //    {
        //        lession = "";
        //        return false;
        //    }
        //}


    }

    #region private
    public class SubClass
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private static SubClass _Instance;
        public static SubClass GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new SubClass();
            }
            return _Instance;
        }

        public List<SubClass> GetBySubjectRegister(int subjectregisterid)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    SubjectRegisterID = subjectregisterid
                }, "2012", "RELATE", "13");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<SubClass>(ds.Tables[0]).ToList();
                return resp;
            }
            catch
            {
                return new List<SubClass>();
            }
        }

        public SubClass()
        {
            this.Status = 1;
        }
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }

    public class ComboBoxItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
    #endregion
}
