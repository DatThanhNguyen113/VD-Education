﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceCore.DataAccess;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using System.IO;
using ExcelDataReader;

namespace Monitor2
{
    public partial class UserControlClass : UserControl
    {
        public UserControlClass()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            sqlDataSource1.Fill();
        }
        ClassDAO classDAO = new ClassDAO();

        //button them
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (classDAO.exedata("INSERT INTO Class (Code, Name, SchoolYearID, DepartmentID) VALUES ('" + textEdit2.Text + "',N'" + textEdit3.Text + "','" + textEdit4.Text + "','" + textEdit5.Text + "')") == true)
            {
                MessageBox.Show("Đã thêm dữ liệu");
            }
            else
            {
                MessageBox.Show("Không thể thêm dữ liệu");
            }
            sqlDataSource1.Fill();
        }

        //button sua
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (classDAO.exedata("UPDATE Class SET Code = '" + textEdit2.Text + "', Name = N'" + textEdit3.Text + "',SchoolYearID ='" + textEdit4.Text + "' ,DepartmentID = '" + textEdit5.Text + "' WHERE ID = '" + textEdit1.Text + "' ") == true)
            {
                MessageBox.Show("Đã Sửa dữ liệu");
            }
            else
            {
                MessageBox.Show("Không thể Sửa dữ liệu");
            }
            sqlDataSource1.Fill();
        }

        //button xoa
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (classDAO.exedata("delete from Class where ID = '" + textEdit1.Text + "' ") == true)
            {
                MessageBox.Show("Đã Xóa dữ liệu");
            }
            else
            {
                MessageBox.Show("Không thể Xóa dữ liệu");
            }
            sqlDataSource1.Fill();
        }

        //button load
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            sqlDataSource1.Fill();
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridView1.CalcHitInfo(e.Location);
            if (info.InRowCell)
            {
                int row = info.RowHandle;
                GridColumn colum = info.Column;
                DataRow rowcolum = gridView1.GetDataRow(row);
                textEdit1.Text = gridView1.GetRowCellValue(row, "ID").ToString();
                textEdit2.Text = gridView1.GetRowCellValue(row, "Code").ToString();
                textEdit3.Text = gridView1.GetRowCellValue(row, "Name").ToString();
                textEdit4.Text = gridView1.GetRowCellValue(row, "SchoolYearID").ToString();
                textEdit5.Text = gridView1.GetRowCellValue(row, "DepartmentID").ToString();
                comboBox1.Text = gridView1.GetRowCellValue(row, "Ban").ToString();
                comboBox2.Text = gridView1.GetRowCellValue(row, "HocKy").ToString();

            }
        }

        private void UserControlClass_Load(object sender, EventArgs e)
        {
            String sql = "Select ID, Name from Department";
            String display = "Name";
            String value = "ID";
            this.classDAO.loadCBB(comboBox1, sql, display, value);
            comboBox1.Text = "";

            String sql2 = "Select ID, Name from SchoolYear";
            String display2 = "Name";
            String value2 = "ID";
            this.classDAO.loadCBB(comboBox2, sql2, display2, value2);
            comboBox2.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textEdit5.Text = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textEdit4.Text = comboBox2.SelectedValue.ToString();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
            dialog.DefaultExt = "xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.gridView1.ExportToXls(dialog.FileName);
                MessageBox.Show("Sucess");
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;       
              try
                {
                FileStream stream = new FileStream(dialog.FileName, FileMode.Open);
                IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet dataSet = excelDataReader.AsDataSet();
                DataClasses3DataContext conn = new DataClasses3DataContext();
                foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            Class add = new Class()
                            {
                                Code = Convert.ToString(dr[0]),
                                Name = Convert.ToString(dr[1]),
                                SchoolYearID = Convert.ToInt32(dr[2]),
                                DepartmentID = Convert.ToInt32(dr[3]),
                               
                            };
                            conn.Classes.InsertOnSubmit(add);
                        }
                    }
                    conn.SubmitChanges();
                    excelDataReader.Close();
                    stream.Close();
                    MessageBox.Show("Sucess");
                    sqlDataSource1.Fill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi File Hoặc File Đang Mở");
                }
            
        }
    }
}
