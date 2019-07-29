using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Monitor2
{
    public partial class FormMain : Form
    {
        public int UserID { get; internal set; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlStudent fnew = new UserControlStudent();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }
        

        private void navBarItem2_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlTeacher fnew = new UserControlTeacher();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlParents fnew = new UserControlParents();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlSubject fnew = new UserControlSubject();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlClass fnew = new UserControlClass();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlSubjectRegister fnew = new UserControlSubjectRegister();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

       

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlNotification fnew = new UserControlNotification();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlKhoa fnew = new UserControlKhoa();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

      

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = Form1._Instance;
            if(form1 != null)
            form1.Close();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlClassDetails fnew = new UserControlClassDetails();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlBan fnew = new UserControlBan();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlApprovalRegist fnew = new UserControlApprovalRegist();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }

        private void navBarItem11_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControl2.Controls.Clear();
            UserControlApprovalRegist fnew = new UserControlApprovalRegist();
            fnew.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl2.Controls.Add(fnew);
        }
    }
}
