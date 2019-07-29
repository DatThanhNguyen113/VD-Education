using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraEditors.Controls;
using static System.Windows.Forms.CheckedListBox;

namespace Monitor2
{
    public partial class CustomizeAppointMentEditorfrm : DevExpress.XtraEditors.XtraForm
    {
        Appointment appointment;
        SchedulerControl control;


        public CustomizeAppointMentEditorfrm(SchedulerInplaceEditorEventArgs inplaceEditorArgs)
        {
            InitializeComponent();
            this.control = inplaceEditorArgs.Control;
            if (inplaceEditorArgs.UseFullCellEditor)
            {
                this.Bounds = control.RectangleToScreen(inplaceEditorArgs.Bounds);
                DevExpress.Skins.Skin currentSkin = DevExpress.Skins.SchedulerSkins.GetSkin(control.LookAndFeel);
                DevExpress.Skins.SkinElement element = currentSkin[DevExpress.Skins.SchedulerSkins.SkinAllDayAreaSelected];
                this.BackColor = element.Color.BackColor;
                this.ForeColor = Color.White;
            }
            else
            {
                this.Bounds = AdjustEditorBounds(inplaceEditorArgs.Bounds);
                this.BackColor = inplaceEditorArgs.BackColor;
            }
        }

        private void CustomizeAppointMentEditorfrm_Load(object sender, EventArgs e)
        {

        }

        private void DisplayRool()
        {
            NewCoursefrm frm = new NewCoursefrm();
            
            foreach (var data in CacheCore.mRoomList)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Value = data.ID;
                comboBoxItem.Text = data.Code;
                frm.SetUpComboBoxItem(cbxRoom, comboBoxItem);
            }
        }

        public void FillForm(SchedulerControl control, Appointment appointment)
        {
            this.appointment = appointment;
            if(Int32.Parse(appointment.Id.ToString()) > 0)
            {
                btnOK.Text = "Thay đổi";
                replaceSelectedItemCbx(cbxRoom,appointment.Subject);
                dateEdit1.EditValue = appointment.Start;
                SetupRoomData(cbxRoom);
                if (appointment.End.Hour <= 13)
                {
                    radioGroupSession.SelectedIndex = 0;
                    repairListBoxItem(checkedListBoxLessonNumber,0);
                }
                else
                {
                    radioGroupSession.SelectedIndex = 1;
                    repairListBoxItem(checkedListBoxLessonNumber, 1);
                }
            }
            else
            {
                btnOK.Text = "Thêm mới";
            }

            //SchedulerDataStorage storage = control.DataStorage as SchedulerDataStorage;
            //this.appointmentLabelEdit1.Storage = storage;
            //this.appointmentLabelEdit1.AppointmentLabel = storage.Appointments.Labels.GetById(appointment.LabelKey);
            //this.edtSubject.Text = appointment.Subject;
            //this.edtDescription.Text = appointment.Description;
        }

        private void repairListBoxItem(CheckedListBox checkedListBox,int type)
        {
            checkedListBox.Items.Clear();
            if(type == 0)
            {
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
                checkedListBox.Items.AddRange(new object[] {
            "Tiết 7",
            "Tiết 8",
            "Tiết 9",
            "Tiết 10",
            "Tiết 11",
            "Tiết 12"});
            }
            
            for(int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetSelected(i,true);
            }
        }

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

        private void replaceSelectedItemCbx(ComboBoxEdit cbx,string key)
        {
            ComboBoxItemCollection collection1 = cbx.Properties.Items;
            foreach(var item in collection1)
            {
                var m = (ComboBoxItem)item;
                if(m.Text == key)
                {
                    cbx.SelectedItem = m;
                    break;
                }
            }
        }



        private Rectangle AdjustEditorBounds(Rectangle editorBounds)
        {
            Rectangle screenControlBounds = control.Parent.RectangleToScreen(control.Bounds);
            editorBounds.Offset(0, -3);
            Rectangle screenEditorBounds = control.RectangleToScreen(editorBounds);

            Size preferredSize = GetPreferredSize(editorBounds.Size);
            int height = Math.Max(preferredSize.Height, editorBounds.Height);
            int width = preferredSize.Width;

            Rectangle rect = screenEditorBounds;
            rect.Offset(6, 0);

            int maxBottom = Math.Min(screenControlBounds.Bottom, rect.Top + height);
            int top = maxBottom - height;

            Rectangle result = new Rectangle(rect.Left, top, width, height);
            if (screenControlBounds.Right < rect.Right)
            {
                int horzOffset = control.ActiveView is DayView ? 12 : 8;
                result = new Rectangle(screenEditorBounds.Left - width - horzOffset, top, width, height);
            }
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void CaculateLessonNumber()
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}