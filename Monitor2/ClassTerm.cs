using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceCore.DataAccess;
using ServiceCore.Models.Subject;
using VD.Utility;
using VD.Datalayer.DataObject;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;

namespace Monitor2
{
    public partial class ClassTerm : Form
    {
        CCoreDao dao = new CCoreDao();
        private GenerateData Render = new GenerateData();
        ClassDAO classDAO = new ClassDAO();
        public List<SubjectModel> aa;
        public ClassTerm()
        {
            InitializeComponent();
            String sql2 = "Select Name, ID from Class";
            String display2 = "Name";           
            String value2 = "ID";
            classDAO.loadCBB2(comboBox1, sql2, display2, value2);
            comboBox1.Text = "";
            textEdit1.Text = "";

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";

            var items = new[] {
                new { Text = "Môn Cơ Sở", Value = "0" },
                new { Text = "Môn Cơ Bản", Value = "1" },
                new { Text = "Môn Nâng Cao", Value = "2" },

            };

            comboBox2.DataSource = items;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textEdit1.Text = comboBox1.SelectedValue.ToString();
            
           
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                checkEdit2.Enabled = false;
                checkEdit3.Enabled = false;
                if (textEdit1.Text != "")
                {
                    try
                    {
                        int idd = Int32.Parse(textEdit1.Text);
                        aa = GetClassSubjectAll(idd.ToString(), "");
                        gridControl1.DataSource = aa;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("vui lòng chọn lớp");
                    checkEdit1.Checked = false;
                }
            }
            else
            {
                checkEdit2.Enabled = true;
                checkEdit3.Enabled = true;
            }

        }
        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked)
            {
                checkEdit1.Enabled = false;
                checkEdit3.Enabled = false;
                if (textEdit1.Text != "")
                {
                    try
                    {
                        int idd = Int32.Parse(textEdit1.Text);
                        aa = GetClassSubjectAll(idd.ToString(), "NOTLEARN");
                        gridControl1.DataSource = aa;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("vui lòng chọn lớp");
                    checkEdit2.Checked = false;
                }
            }
            else
            {
                checkEdit1.Enabled = true;
                checkEdit3.Enabled = true;
            }
        }
        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit3.Checked)
            {
                checkEdit1.Enabled = false;
                checkEdit2.Enabled = false;
                if (textEdit1.Text != "")
                {
                    try
                    {
                        int idd = Int32.Parse(textEdit1.Text);
                        aa = GetClassSubjectAll(idd.ToString(), "BYSPECIALIZE");
                        gridControl1.DataSource = aa;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else {
                    MessageBox.Show("vui lòng chọn lớp");
                    checkEdit3.Checked = false;
                }
            }
            else
            {
                checkEdit2.Enabled = true;
                checkEdit1.Enabled = true;
            }
        }

        public List<SubjectModel> GetClassSubjectAll(String Classid, String status)
        {
            string xml = Render.GenerateXmlFromObject<object>(null, new
            {
                ClassID = Classid
            }, "1006", status, "13");
            var ds = dao.GetContextData(xml);
            var resp = Render.ResponseMultiObject<SubjectModel>(ds.Tables[0]).ToList();
            return resp;
        }

        private void ClassTerm_Load(object sender, EventArgs e)
        {
           
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridView1.CalcHitInfo(e.Location);
            if (info.InRowCell)
            {
                int row = info.RowHandle;
                GridColumn colum = info.Column;
                DataRow rowcolum = gridView1.GetDataRow(row);
                textEdit3.Text = gridView1.GetRowCellValue(row, "ID").ToString();
                textEdit6.Text = gridView1.GetRowCellValue(row, "Code").ToString();
                textEdit7.Text = gridView1.GetRowCellValue(row, "Name").ToString();
                //textEdit5.Text = gridView1.GetRowCellValue(row, "Description").ToString();
                //textEdit1.Text = gridView1.GetRowCellValue(row, "ClassID").ToString();
                textEdit2.Text = gridView1.GetRowCellValue(row, "Piority").ToString();
                String pio = gridView1.GetRowCellValue(row, "Piority").ToString();
                if (pio == "0")
                {
                    comboBox2.Text = "Môn Cơ Sở";
                }
                if (pio == "1")
                {
                    comboBox2.Text = "Môn Cơ Bản";
                }
                if (pio == "2")
                {
                    comboBox2.Text = "Môn Nâng Cao";
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text != "" && textEdit6.Text != "" && textEdit3.Text != "" && comboBox2.Text != "")
            {
                if (classDAO.exedata("INSERT INTO DepartmentSubjects (ClassID, SubjectID, Description, Piority) VALUES ('" + textEdit1.Text + "','" + textEdit3.Text + "',N'" + textEdit5.Text + "','" + textEdit2.Text + "')") == true)
                {
                    MessageBox.Show("Đã thêm dữ liệu");              
                }
                else
                {
                    MessageBox.Show("Không thể thêm dữ liệu");
                }
            }
            else {
                MessageBox.Show("Vui lòng nhấn chọn môn học muốn thêm");
            }
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textEdit2.Text = comboBox2.SelectedValue.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
