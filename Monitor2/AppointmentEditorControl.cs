using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor2
{
    public class AppointmentEditorControl : ISchedulerInplaceEditorEx
    {
        CustomizeAppointMentEditorfrm editorFrm;
        Appointment appointment;
        SchedulerControl control;
        public event EventHandler CommitChanges;
        public event EventHandler RollbackChanges;

        public AppointmentEditorControl(SchedulerInplaceEditorEventArgs inplaceEditorArgs)
        {
            this.appointment = inplaceEditorArgs.ViewInfo.Appointment;
            this.control = inplaceEditorArgs.Control;
            CreateEditor(inplaceEditorArgs);
        }

        CustomizeAppointMentEditorfrm Editor { get { return editorFrm; } }
        Appointment Appointment { get { return appointment; } }
        SchedulerControl Control { get { return control; } }

        void CreateEditor(SchedulerInplaceEditorEventArgs inplaceEditorArgs)
        {
            this.editorFrm = new CustomizeAppointMentEditorfrm(inplaceEditorArgs);
        }

        public void Activate()
        {
            Editor.FillForm(control,appointment);
            Editor.Show(Control.FindForm());
        }

        public void ApplyChanges()
        {
            throw new NotImplementedException();
        }

        public void Deactivate()
        {
            Editor.Close();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
