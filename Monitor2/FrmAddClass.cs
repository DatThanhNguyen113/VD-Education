using ServiceCore.Models;
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
    public partial class FrmAddClass : Form
    {
        private int specializeID = 0;
        private int subjectRegisterID = 0;
        public FrmAddClass(int spec,int register)
        {
            InitializeComponent();
            this.specializeID = spec;
            this.subjectRegisterID = register;
        }

        private void FrmAddClass_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxControl1.Items.Clear();
            List<ClassModel> classList = null;
            if(radioGroup1.SelectedIndex == 0)
            {
                classList = ClassModel.GetInstance().GetClassBySpecialize(subjectRegisterID, specializeID);
                
            }
            else
            {
                classList = ClassModel.GetInstance().GetClassList();
            }
            checkedListBoxControl1.Items.AddRange(classList.ToArray());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var isItem = false;
            for (int i=0;i< checkedListBoxControl1.CheckedItems.Count; i++)
            {
                var model = checkedListBoxControl1.CheckedItems[i] as ClassModel;
                if(model != null)
                {
                    isItem = true;
                    if (!model.AddToSubjectRegister(subjectRegisterID))
                    {
                        MessageBox.Show("Xảy ra lỗi trong quá trình thực thi");
                        return;
                    }
                }

            }

            if (!isItem)
            {
                MessageBox.Show("Xin chọn ít nhất 1 giá trị");
            }
            else
            {
                MessageBox.Show("Thành công!");
                this.Close();
            }
        }
    }
}
