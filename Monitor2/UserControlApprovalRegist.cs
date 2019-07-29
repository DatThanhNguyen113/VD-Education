using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceCore.Models;
using DevExpress.XtraGrid.Views.Grid;
using ServiceCore.Models.Subject;

namespace Monitor2
{
    public partial class UserControlApprovalRegist : UserControl
    {
        RegistedSubjectModel globalItem = null;
        public UserControlApprovalRegist()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            var mList = RegistedSubjectModel.GetInstance().GetApproval();
            this.gridControl1.DataSource = mList;
            gridView1.BestFitColumns();
            globalItem = mList[0];
            DisplayData(mList[0]);
        }

        private void gridControl1_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {

        }

        private void DisplayData(RegistedSubjectModel currentItem)
        {
          
            tbxSubjectcode.Text = currentItem.Code;
            tbxSubjectName.Text = currentItem.Name;
            tbxStudentCode.Text = currentItem.StudentCode;
            tbxStudentName.Text = currentItem.Name;
            tbxClass.Text = currentItem.ClassName;
            tbxDepartment.Text = currentItem.DepartmentName;
            tbxSpecialize.Text = currentItem.SpecializeName;
            tbxStartDate.Text = currentItem.StartLearnDay.ToString("dd-MM-yyyy");

            var mList = RegistedSubjectModel.GetInstance().GetLearnedInfo(currentItem.ID);
            var learnedLesson = 0;
            var totalLesson = mList[0].TotalLesson;
            foreach (var item in mList)
            {
                var lessonArr = item.LessonNumber.Split(',');
                foreach (var arr in lessonArr)
                {
                    var iNum = 0;
                    if (Int32.TryParse(arr, out iNum))
                    {
                        learnedLesson += 1;
                    }
                }
            }
            TbxTotal.Text = totalLesson.ToString();
            tbxLearned.Text = learnedLesson.ToString();
            var learnedPercent = (learnedLesson * 100) / totalLesson;
            tbxLearnedPercent.Text = learnedPercent.ToString();
            tbxPercent.Text = (100 - learnedPercent).ToString();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if(globalItem != null)
            {
                if (globalItem.UpdateStatus(1))
                {
                    LoadGrid();
                    MessageBox.Show("Thành công!");
                    string subject = "[VDADMIN]: Yêu cầu đăng kí môn học";
                    string body = $"Môn học [{globalItem.Name}] mà bạn đăng kí đã được PHÊ DUYỆT. Hãy kiểm tra lại thời khóa biểu nhé!";
                    UserControlSubjectRegister userControlSubjectRegister = new UserControlSubjectRegister();
                    userControlSubjectRegister.SendNoticeToSubjectRegister(subject, body, 1, ".SubjectRegister", 3,0,0, globalItem.StudentCode);
                }
                else
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thực thi!");
                }
            }
            else
            {
                MessageBox.Show("Xin chọn dòng dữ liệu!");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (globalItem != null)
            {
                if (globalItem.UpdateStatus(-2))
                {
                    LoadGrid();
                    MessageBox.Show("Thành công!");
                    string subject = "[VDADMIN]: Yêu cầu đăng kí môn học";
                    string body = $"Môn học [{globalItem.Name}] mà bạn đăng kí đã bị TỪ CHỐI \n . Vui lòng liên hệ nhà trường để biết thêm thông tin chi tiết. \n Bạn sẽ không thể tìm lại các môn này để đăng kí ";
                    UserControlSubjectRegister userControlSubjectRegister = new UserControlSubjectRegister();
                    userControlSubjectRegister.SendNoticeToSubjectRegister(subject, body, 0, ".", 3, 0, 0, globalItem.StudentCode);
                }
                else
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thực thi!");
                }
            }
            else
            {
                MessageBox.Show("Xin chọn dòng dữ liệu!");
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = (sender as GridView).GetFocusedRow();
            if (row != null)
            {
                var currentItem = row as RegistedSubjectModel;
                globalItem = currentItem;
                DisplayData(currentItem);
            }
        }
    }
}
