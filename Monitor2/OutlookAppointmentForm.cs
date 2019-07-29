using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Internal;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Native;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.iCalendar;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.Printing;
using DevExpress.XtraScheduler.Printing.Native;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler.Commands;
using DevExpress.XtraScheduler.Services;
using ServiceCore.Models.Base;
using ServiceCore.DataAccess;
using ServiceCore.Models.User;
using System.Collections.Generic;

namespace Monitor2
{
    /// <summary>
    /// Summary description for AppointmentRibbonForm.
    /// </summary>
    public partial class OutlookAppointmentForm : DevExpress.XtraBars.Ribbon.RibbonForm, IDXManagerPopupMenu
    {
        #region Fields
        bool openRecurrenceForm;
        readonly ISchedulerStorage storage;
        readonly SchedulerControl control;
        Icon recurringIcon;
        Icon normalIcon;
        readonly AppointmentFormController controller;
        IDXMenuManager menuManager;
        bool supressCancelCore;
        #endregion
        public Appointment mAppointment;
        public string mSubject = "";
        public string mName = "";
        public int currentID = 0;
        public int currentMasterTimeTableID = 0;
        public SchedulerControl mControl;
        int GlobalStatus = 0;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public OutlookAppointmentForm()
        {
            InitializeComponent();
        }
        public OutlookAppointmentForm(DevExpress.XtraScheduler.SchedulerControl control, Appointment apt, string mSubject, string mName,int mastertimetableid, int status)
            : this(control, apt, false, mSubject, mName, mastertimetableid, status)
        {
          
        }
        public OutlookAppointmentForm(DevExpress.XtraScheduler.SchedulerControl control, Appointment apt, bool openRecurrenceForm,string sSubject, string sName, int mastertimetableid, int status)
        {
            this.mSubject = sSubject;
            this.mName = sName;
            this.currentMasterTimeTableID = mastertimetableid;
            this.mControl = control;
            GlobalStatus = status;
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(control.DataStorage, "control.DataStorage");
            Guard.ArgumentNotNull(apt, "apt");

            this.openRecurrenceForm = openRecurrenceForm;
            mAppointment = apt;
            this.controller = CreateController(control, apt);

           
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            SetupPredefinedConstraints();

            LoadIcons();

            this.control = control;
            this.storage = control.DataStorage;


            BindControllerToControls();

            LookAndFeel.ParentLookAndFeel = control.LookAndFeel;
            this.defaultBarAndDockingController.Controller.LookAndFeel.ParentLookAndFeel = LookAndFeel;

            this.supressCancelCore = false;

            SetupRoomData(cbxRoom);
        }
        #region Properties
        [Browsable(false)]
        public IDXMenuManager MenuManager { get { return menuManager; } private set { menuManager = value; } }
        protected internal AppointmentFormController Controller { get { return controller; } }
        protected internal SchedulerControl Control { get { return control; } }
        protected internal ISchedulerStorage Storage { get { return storage; } }
        protected internal bool IsNewAppointment { get { return controller != null ? controller.IsNewAppointment : true; } }
        protected internal Icon RecurringIcon { get { return recurringIcon; } }
        protected internal Icon NormalIcon { get { return normalIcon; } }
        protected internal bool OpenRecurrenceForm { get { return openRecurrenceForm; } }
        [DXDescription("DevExpress.XtraScheduler.UI.AppointmentRibbonForm,ReadOnly")]
        [DXCategory(CategoryName.Behavior)]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return Controller.ReadOnly; }
            set
            {
                if (Controller.ReadOnly == value)
                    return;
                Controller.ReadOnly = value;
            }
        }
        protected override FormShowMode ShowMode { get { return DevExpress.XtraEditors.FormShowMode.AfterInitialization; } }
        #endregion

        public virtual void LoadFormData(Appointment appointment)
        {
            edtSubjectName.Text = mSubject;
            edtTeacherName.Text = mName;
            SetupRoomData(cbxRoom);
            dateEdit1.EditValue = appointment.Start;
            if (mAppointment.Id != null && Int32.Parse(mAppointment.Id.ToString()) > 0)
            {
                currentID = Int32.Parse(mAppointment.Id.ToString());
                replaceSelectedItemCbx(cbxRoom, appointment.Subject);
                
                if (appointment.End.Hour <13  || (appointment.End.Hour == 13 && (appointment.End.Minute == 0) ))
                {
                    radioGroupSession.SelectedIndex = 0;
                    var lessonRage =Ultility.getLessonRage(appointment.Start, appointment.End,0);
                    repairListBoxItem(checkedListBoxLessonNumber, 0, lessonRage);
                }
                else
                {
                    var lessonRage = Ultility.getLessonRage(appointment.Start, appointment.End, 1);
                    radioGroupSession.SelectedIndex = 1;
                    repairListBoxItem(checkedListBoxLessonNumber, 1, lessonRage);
                }
            }
        }

        //private void getLesssonRange(DateTime mDate, DateTime sDate,int type)
        //{
        //    var startHour = mDate.Hour;
        //    var endHour = sDate.Hour;
        //    int startLesson = 0;
        //    if(type == 0)
        //    {
        //        switch (startHour)
        //        {
        //            case 7:
        //                {
        //                    if(mDate.Minute == 0)
        //                    {
        //                        startLesson = 1;
        //                    }
        //                    else
        //                    {
        //                        startLesson = 2;
        //                    }
        //                    break;
        //                }
        //            case 8:
        //                {
        //                    startLesson = 3;
        //                    break;
        //                }
        //            case 9:
        //                {
        //                    startLesson = 4;
        //                    break;
        //                }
        //            case 10:
        //                {
        //                    startLesson = 5;
        //                    break;
        //                }
        //            case 11:
        //                {
        //                    startLesson = 6;
        //                    break;
        //                }
        //        }
        //    }
        //    else
        //    {
        //        switch (startHour)
        //        {
        //            case 13:
        //                {
        //                    if (mDate.Minute == 0)
        //                    {
        //                        startLesson = 7;
        //                    }
        //                    else
        //                    {
        //                        startLesson = 8;
        //                    }
        //                    break;
        //                }
        //            case 14:
        //                {
        //                    startLesson = 9;
        //                    break;
        //                }
        //            case 15:
        //                {
        //                    startLesson = 10;
        //                    break;
        //                }
        //            case 16:
        //                {
        //                    startLesson = 11;
        //                    break;
        //                }
        //            case 17:
        //                {
        //                    startLesson = 12;
        //                    break;
        //                }
        //        }
        //    }
        //}

       

        private void SetupRoomData(ComboBoxEdit cbxEdit)
        {
            foreach (var data in CacheCore.mRoomList)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Value = data.ID;
                comboBoxItem.Text = data.Code;
                SetUpComboBoxItem(cbxEdit, comboBoxItem);

            }
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

        private void replaceSelectedItemCbx(ComboBoxEdit cbx, string key)
        {
            ComboBoxItemCollection collection1 = cbx.Properties.Items;
            foreach (var item in collection1)
            {
                var m = (ComboBoxItem)item;
                if (m.Text == key)
                {
                    cbx.SelectedItem = m;
                    break;
                }
            }
        }

        private void repairListBoxItem(CheckedListBox checkedListBox, int type,List<int> mArr = null)
        {
            checkedListBox.Items.Clear();
            if (type == 0)
            {
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 1",
            "Tiết 2",
            "Tiết 3",
            "Tiết 4",
            "Tiết 5",
            "Tiết 6"});
                timeEdit1.EditValue = new DateTime().AddHours(7);
                timeEdit2.EditValue = new DateTime().AddHours(12).AddMinutes(15);
            }
            else
            {
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 7",
            "Tiết 8",
            "Tiết 9",
            "Tiết 10",
            "Tiết 11",
            "Tiết 12"});
                timeEdit1.EditValue = new DateTime().AddHours(13);
                timeEdit2.EditValue = new DateTime().AddHours(18).AddMinutes(15);
            }

            if(mArr != null && mArr.Count > 0)
            {
                for(int i = 0; i < mArr.Count; i++)
                {
                    checkedListBox.SetItemChecked(mArr[i], true);

                }
            }
        }

        public virtual bool SaveFormData(Appointment appointment)
        {
            return true;
        }
        public virtual bool IsAppointmentChanged(Appointment appointment)
        {
            return false;
        }
        public virtual void SetMenuManager(DevExpress.Utils.Menu.IDXMenuManager menuManager)
        {
            MenuManagerUtils.SetMenuManager(Controls, menuManager);
            this.menuManager = menuManager;
        }

        protected internal virtual void SetupPredefinedConstraints()
        {
            this.tbProgress.Properties.Minimum = AppointmentProcessValues.Min;
            this.tbProgress.Properties.Maximum = AppointmentProcessValues.Max;
            this.tbProgress.Properties.SmallChange = AppointmentProcessValues.Step;
        }
        protected virtual void BindControllerToControls()
        {
            this.DataBindings.Add("Text", Controller, "Caption");
            BindControllerToIcon();
          
            BindProperties(this.barLabel, "EditValue", "Label");

            BindProperties(this.barStatus, "EditValue", "Status");

            BindBoolToVisibility(this.barReminder, "Visibility", "ReminderVisible");
            BindProperties(this.barReminder, "Editvalue", "ReminderTimeBeforeStart");

            BindProperties(this.tbProgress, "Value", "PercentComplete");
            BindProperties(this.lblPercentCompleteValue, "Text", "PercentComplete", ObjectToStringConverter);
            BindProperties(this.progressPanel, "Visible", "ShouldEditTaskProgress");
            BindProperties(this.btnDelete, "Enabled", "CanDeleteAppointment");

            BindBoolToVisibility(this.btnRecurrence, "Visibility", "ShouldShowRecurrenceButton");
            BindProperties(this.btnRecurrence, "Down", "IsRecurrentAppointment");


            BindToBoolPropertyAndInvert(this.ribbonControl1, "Enabled", "ReadOnly");

        
            BindBoolToVisibility(this.btnTimeZones, "Visibility", "TimeZonesEnabled");
            BindProperties(this.btnTimeZones, "Down", "TimeZoneVisible");
        }

        protected virtual void BindControllerToIcon()
        {
            Binding binding = new Binding("Icon", Controller, "AppointmentType");
            binding.Format += AppointmentTypeToIconConverter;
            DataBindings.Add(binding);
        }
        protected virtual void ObjectToStringConverter(object o, ConvertEventArgs e)
        {
            e.Value = e.Value.ToString();
        }
        protected virtual void AppointmentTypeToIconConverter(object o, ConvertEventArgs e)
        {
            AppointmentType type = (AppointmentType)e.Value;
            if (type == AppointmentType.Pattern)
                e.Value = RecurringIcon;
            else
                e.Value = NormalIcon;
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty)
        {
            BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, DataSourceUpdateMode updateMode)
        {
            target.DataBindings.Add(targetProperty, Controller, sourceProperty, true, updateMode);
            BindToIsReadOnly(target, updateMode);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, ConvertEventHandler objectToStringConverter)
        {
            Binding binding = new Binding(targetProperty, Controller, sourceProperty, true);
            binding.Format += objectToStringConverter;
            target.DataBindings.Add(binding);
        }
        protected virtual void BindToBoolPropertyAndInvert(Control target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolInvertBinding(targetProperty, Controller, sourceProperty));
            BindToIsReadOnly(target);
        }
        protected virtual void BindToIsReadOnly(Control control)
        {
            BindToIsReadOnly(control, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected virtual void BindToIsReadOnly(Control control, DataSourceUpdateMode updateMode)
        {
            if ((!(control is BaseEdit)) || control.DataBindings["ReadOnly"] != null)
                return;
            control.DataBindings.Add("ReadOnly", Controller, "ReadOnly", true, updateMode);
        }

        protected virtual void BindProperties(DevExpress.XtraBars.BarItem target, string targetProperty, string sourceProperty)
        {
            BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected virtual void BindProperties(DevExpress.XtraBars.BarItem target, string targetProperty, string sourceProperty, DataSourceUpdateMode updateMode)
        {
            target.DataBindings.Add(targetProperty, Controller, sourceProperty, true, updateMode);
        }
        protected virtual void BindProperties(DevExpress.XtraBars.BarItem target, string targetProperty, string sourceProperty, ConvertEventHandler objectToStringConverter)
        {
            Binding binding = new Binding(targetProperty, Controller, sourceProperty, true);
            binding.Format += objectToStringConverter;
            target.DataBindings.Add(binding);
        }
        protected virtual void BindToBoolPropertyAndInvert(DevExpress.XtraBars.BarItem target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolInvertBinding(targetProperty, Controller, sourceProperty));
        }
        protected virtual void BindBoolToVisibility(DevExpress.XtraBars.BarItem target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolToVisibilityBinding(targetProperty, Controller, sourceProperty, false));
        }
        protected virtual void BindBoolToVisibility(DevExpress.XtraBars.BarItem target, string targetProperty, string sourceProperty, bool invert)
        {
            target.DataBindings.Add(new BoolToVisibilityBinding(targetProperty, Controller, sourceProperty, invert));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Controller == null)
                return;
            SubscribeControlsEvents();
            LoadFormData(Controller.EditedAppointmentCopy);
        }
        protected virtual AppointmentFormController CreateController(SchedulerControl control, Appointment apt)
        {
            return new AppointmentFormController(control, apt);
        }
        protected internal virtual void LoadIcons()
        {
            Assembly asm = typeof(SchedulerControl).Assembly;
            this.recurringIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.RecurringAppointment, asm);
            this.normalIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.Appointment, asm);
        }
        protected internal virtual void SubscribeControlsEvents()
        {
          
        }

        protected internal virtual void UnsubscribeControlsEvents()
        {
          
        }

        protected internal virtual void OnEdtStartTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtStartDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }


        protected internal virtual void OnOkButton()
        {
            Save(true);
        }
        protected virtual void OnSaveButton()
        {
            Save(false);
        }
        private void Save(bool closeAfterSave)
        {
            if (!SaveFormData(Controller.EditedAppointmentCopy))
                return;
            if (!Controller.IsConflictResolved())
            {
                ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_Conflict), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_Conflict), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Controller.IsAppointmentChanged() || Controller.IsNewAppointment || IsAppointmentChanged(Controller.EditedAppointmentCopy))
                Controller.ApplyChanges();
            if (closeAfterSave)
            {
                this.supressCancelCore = true;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
      
        protected virtual void OnSaveAsButton()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "iCalendar files (*.ics)|*.ics";
            fileDialog.FilterIndex = 1;
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                using (Stream stream = fileDialog.OpenFile())
                    ExportAppointment(stream);
            }
            catch
            {
                ShowMessageBox("Error: could not export appointments", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ExportAppointment(Stream stream)
        {
            if (stream == null)
                return;

            AppointmentBaseCollection aptsToExport = new AppointmentBaseCollection();
            aptsToExport.Add(Controller.EditedAppointmentCopy);
            iCalendarExporter exporter = new iCalendarExporter(this.storage, aptsToExport);

            exporter.ProductIdentifier = "-//Developer Express Inc.";
            exporter.Export(stream);
        }
        protected internal virtual DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(this, text, caption, buttons, icon);
        }
        protected internal virtual void OnDeleteButton()
        {
            if (IsNewAppointment)
                return;

            Controller.DeleteAppointment();

            DialogResult = DialogResult.Abort;
            Close();
        }
        protected internal virtual void OnRecurrenceButton()
        {
            if (!Controller.ShouldShowRecurrenceButton)
                return;

            Appointment patternCopy = Controller.PrepareToRecurrenceEdit();

            DialogResult result;
            using (Form form = CreateAppointmentRecurrenceForm(patternCopy, Control.OptionsView.FirstDayOfWeek))
            {
                result = ShowRecurrenceForm(form);
            }

            if (result == DialogResult.Abort)
            {
                Controller.RemoveRecurrence();
            }
            else if (result == DialogResult.OK)
            {
                Controller.ApplyRecurrence(patternCopy);
            }

            this.btnRecurrence.Down = Controller.IsRecurrentAppointment;
        }
        protected virtual void OnCloseButton()
        {
            this.Close();
        }

        private bool CancelCore()
        {
            bool result = true;

            if (DialogResult != System.Windows.Forms.DialogResult.Abort && Controller != null && Controller.IsAppointmentChanged() && !this.supressCancelCore)
            {
                DialogResult dialogResult = ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_SaveBeforeClose), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_SaveBeforeClose), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                    result = false;
                else if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    Save(true);
            }

            return result;
        }

        protected virtual DialogResult ShowRecurrenceForm(Form form)
        {
            return FormTouchUIAdapter.ShowDialog(form, this);
        }
        protected internal virtual Form CreateAppointmentRecurrenceForm(Appointment patternCopy, FirstDayOfWeek firstDayOfWeek)
        {
            AppointmentRecurrenceForm form = new AppointmentRecurrenceForm(patternCopy, firstDayOfWeek, Controller);
            form.SetMenuManager(MenuManager);
            form.LookAndFeel.ParentLookAndFeel = LookAndFeel;
            form.ShowExceptionsRemoveMsgBox = controller.AreExceptionsPresent();
            return form;
        }
        internal void OnAppointmentFormActivated(object sender, EventArgs e)
        {
            if (openRecurrenceForm)
            {
                openRecurrenceForm = false;
                OnRecurrenceButton();
            }
        }
        protected internal virtual void OnCbReminderValidating(object sender, CancelEventArgs e)
        {
            TimeSpan span = (TimeSpan)barReminder.EditValue;
            e.Cancel = span.Ticks < 0 && span != TimeSpan.MinValue;
            if (!e.Cancel)
                this.barReminder.DataBindings["EditValue"].WriteValue();
        }

        protected internal virtual void OnNextButton()
        {
            if (CancelCore())
            {
                this.supressCancelCore = true;
                OpenNextAppointmentCommand command = new OpenNextAppointmentCommand(Control);
                command.Execute();
                this.Close();
            }
        }

        protected internal virtual void OnPreviousButton()
        {
            if (CancelCore())
            {
                this.supressCancelCore = true;
                OpenPrevAppointmentCommand command = new OpenPrevAppointmentCommand(Control);
                command.Execute();
                this.Close();
            }
        }

        protected internal virtual void OnTimeZonesButton()
        {
            Controller.TimeZoneVisible = !Controller.TimeZoneVisible;
        }

        protected virtual void OnApplicationButtonClick()
        {
            this.dvInfo.Document = Control.GetPrintPreviewDocument(new RibbonFormPreviewMemoPrintStyle(Controller.EditedAppointmentCopy));
            this.dvInfo.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToWholePage);
        }

        protected virtual void OnPrintButton()
        {
            this.dvInfo.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect);
        }

        private void btnSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnOkButton();
        }

        private void barButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDeleteButton();
        }

        private void barRecurrence_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnRecurrenceButton();
        }

        private void bvbSave_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            OnSaveButton();
        }

        private void bvbSaveAs_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            OnSaveAsButton();
        }

        private void bvbClose_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            OnCloseButton();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (validateForm())
            {
                SubjectDAO dao = new SubjectDAO();
                TimeTableModel model = new TimeTableModel();
                model.MasterTimeTable = currentMasterTimeTableID;
                model.ID = currentID;
                model.Date = DateTime.Parse(dateEdit1.EditValue.ToString());
                model.Day = Ultility.ConvertDateOfWeek(model.Date.DayOfWeek.ToString());
                model.LessonNumber = GetLessionNumber(checkedListBoxLessonNumber);
                model.Room = controller.Subject = cbxRoom.EditValue.ToString();
                if (radioGroupSession.SelectedIndex == 0)
                {
                    model.Session = "Sáng";
                }
                else
                {
                    model.Session = "Chiều";
                }

                BaseResponseModel<object> mResponse = dao.UpdateTimeTableRow(CacheCore.UserID, model);
                if (mResponse.Result > 0)
                {
                    #region set up controller
                    var mStartTime = GetStartTime(model.Date, model.LessonNumber);
                    var mEndTime = GetEndTime(model.Date, model.LessonNumber);
                    controller.AllDay = false;
                    controller.Start = mStartTime;
                    controller.DisplayStart = mStartTime;
                    controller.End = mEndTime;
                    controller.DisplayEnd = mEndTime;
                    controller.Label = new AppointmentLabel(edtSubjectName.Text);
                    controller.Location = edtTeacherName.Text;
                    if (mResponse.Result > 1)
                    {
                        controller.Description = mResponse.Result.ToString();
                    }
                    else
                    {
                        controller.Description = currentID.ToString();
                    }

                    #endregion

                        controller.ApplyChanges(); 

                    
                    if(GlobalStatus == 3)
                    {
                        UserControlSubjectRegister subjectRegister = new UserControlSubjectRegister();
                        string subject = $"[VDADMIN]: Thay đổi thời khóa biểu";
                        string body = $"Khóa cua GV.{mName} hiện tại đã có sự thay đổi thời khóa biểu. Hãy kiểm tra lại lịch học nhé!";
                        subjectRegister.SendNoticeToSubjectRegister(subject, body, 0, ".TimeTable", 2, currentMasterTimeTableID);
                    }
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    //NewTimeTablefrm newTimeTablefrm = new NewTimeTablefrm();
                    //newTimeTablefrm.NotifyTimetableChange(currentMasterTimeTableID,mSubject);
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
            }
            
            if (currentMasterTimeTableID > 0)
            {

                //if(mResponse.Result > 0)
                //{
                //    controller.DisplayStart = GetStartTime(model.Date, model.LessonNumber);
                //    controller.DisplayEnd = GetEndTime(model.Date, model.LessonNumber);
                //    controller.Subject = 
                //}
            }
            
            //OnSaveButton();
        }

        private bool validateForm()
        {
            if(edtSubjectName.Text.Length < 1 || edtTeacherName.Text.Length < 1 || cbxRoom.Text.Length < 1 || dateEdit1.Text.Length < 1 || checkedListBoxLessonNumber.CheckedItems.Count < 1)
            {
                return false;
            }
            return true;
        }

        private string GetLessionNumber(CheckedListBox checkedListBox)
        {
            string result = "";
            List<int> lessionList = new List<int>();
            foreach (var itemChecked in checkedListBox.CheckedItems)
            {
                var m = itemChecked.ToString().Split(' ');
                result += m[1] + ",";
            }
            return result.Remove(result.Length - 1, 1);
        }

       

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !CancelCore();
            base.OnClosing(e);
        }

        private void btnNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnNextButton();
        }

        private void btnPrevious_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnPreviousButton();
        }

        private void btnTimeZones_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnTimeZonesButton();
        }

        private void ribbonControl1_ApplicationButtonClick(object sender, EventArgs e)
        {
            OnApplicationButtonClick();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrintButton();
        }

        private void radioGroupSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            repairListBoxItem(checkedListBoxLessonNumber, radioGroupSession.SelectedIndex);
        }

        #region caculate time by lesson
        private DateTime GetStartTime(DateTime sDate, string lession)
        {
            var mDate = sDate;
            mDate = mDate.AddHours(-(mDate.Hour));
            mDate = mDate.AddMinutes(-(mDate.Minute));
            var mArr = lession.Split(',');
            var mTime = Int32.Parse(mArr[0]);
            switch (mTime)
            {
                case 1:
                    {
                        mDate = mDate.AddHours(7);
                        break;
                    }
                case 2:
                    {
                        mDate = mDate.AddHours(7).AddMinutes(50);
                        break;
                    }
                case 3:
                    {
                        mDate = mDate.AddHours(8).AddMinutes(45);
                        break;
                    }
                case 4:
                    {
                        mDate = mDate.AddHours(9).AddMinutes(45);
                        break;
                    }
                case 5:
                    {
                        mDate = mDate.AddHours(10).AddMinutes(35);
                        break;
                    }
                case 6:
                    {
                        mDate = mDate.AddHours(11).AddMinutes(25);
                        break;
                    }
                case 7:
                    {
                        mDate = mDate.AddHours(13).AddMinutes(0);
                        break;
                    }
                case 8:
                    {
                        mDate = mDate.AddHours(13).AddMinutes(50);
                        break;
                    }
                case 9:
                    {
                        mDate = mDate.AddHours(14).AddMinutes(45);
                        break;
                    }
                case 10:
                    {
                        mDate = mDate.AddHours(15).AddMinutes(45);
                        break;
                    }
                case 11:
                    {
                        mDate = mDate.AddHours(16).AddMinutes(35);
                        break;
                    }
                case 12:
                    {
                        mDate = mDate.AddHours(17).AddMinutes(45);
                        break;
                    }
            }
            return mDate;
        }

        private DateTime GetEndTime(DateTime sDate, string lession)
        {
            var mDate = sDate;
            mDate = mDate.AddHours(-(mDate.Hour));
            mDate = mDate.AddMinutes(-(mDate.Minute));
            var mArr = lession.Split(',');
            var mTime = Int32.Parse(mArr[mArr.Length-1]);
            switch (mTime)
            {
                case 1:
                    {
                        mDate = mDate.AddHours(7).AddMinutes(50);
                        break;
                    }
                case 2:
                    {
                        mDate = mDate.AddHours(8).AddMinutes(45);
                        break;
                    }
                case 3:
                    {
                        mDate = mDate.AddHours(9).AddMinutes(45);
                        break;
                    }
                case 4:
                    {
                        mDate = mDate.AddHours(10).AddMinutes(35);
                        break;
                    }
                case 5:
                    {
                        mDate = mDate.AddHours(11).AddMinutes(25);
                        break;
                    }
                case 6:
                    {
                        mDate = mDate.AddHours(12).AddMinutes(15);
                        break;
                    }

                case 7:
                    {
                        mDate = mDate.AddHours(13).AddMinutes(50);
                        break;
                    }
                case 8:
                    {
                        mDate = mDate.AddHours(14).AddMinutes(45);
                        break;
                    }
                case 9:
                    {
                        mDate = mDate.AddHours(15).AddMinutes(45);
                        break;
                    }
                case 10:
                    {
                        mDate = mDate.AddHours(16).AddMinutes(35);
                        break;
                    }
                case 11:
                    {
                        mDate = mDate.AddHours(17).AddMinutes(45);
                        break;
                    }
                case 12:
                    {
                        mDate = mDate.AddHours(18).AddMinutes(15);
                        break;
                    }
            }
            return mDate;
        }
        #endregion

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(GlobalStatus < 3)
            {
                MessageBox.Show("Buổi học này hiện chưa có điểm danh!");
            }
            else
            {
                MusterDetail muster = new MusterDetail(currentID);
                muster.ShowDialog();
            }

        }
    }
}