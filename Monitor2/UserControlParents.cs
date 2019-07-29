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

namespace Monitor2
{
    public partial class UserControlParents : UserControl
    {
        public UserControlParents()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            sqlDataSource1.Fill();
        }
        StudentDAO studentDao = new StudentDAO();

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridView1.CalcHitInfo(e.Location);
            if (info.InRowCell)
            {
                int row = info.RowHandle;
                GridColumn colum = info.Column;
                DataRow rowcolum = gridView1.GetDataRow(row);
                textEdit1.Text = gridView1.GetRowCellValue(row, "ID").ToString();
                textEdit2.Text = gridView1.GetRowCellValue(row, "Name").ToString();
                textEdit3.Text = gridView1.GetRowCellValue(row, "PhoneNumber").ToString();
                textEdit4.Text = gridView1.GetRowCellValue(row, "Email").ToString();
                textEdit5.Text = gridView1.GetRowCellValue(row, "Address").ToString();
                textEdit6.Text = gridView1.GetRowCellValue(row, "FirstName").ToString();
                textEdit7.Text = gridView1.GetRowCellValue(row, "LastName").ToString();
            }
        }

        //Button Them 
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (studentDao.exedata("INSERT INTO Parent (ID, Name, PhoneNumber, Email, Address) VALUES ('" + textEdit1.Text + "',N'" + textEdit2.Text + "','" + textEdit3.Text + "',N'" + textEdit4.Text + "',N'" + textEdit5.Text + "')") == true)
            {
                MessageBox.Show("Đã thêm dữ liệu");
            }
            else
            {
                MessageBox.Show("Không thể thêm dữ liệu");
            }
            sqlDataSource1.Fill();
        }

        //Button Sua
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (studentDao.exedata("UPDATE Parent SET Name = N'" + textEdit2.Text + "', PhoneNumber = '" + textEdit3.Text + "',Email = N'" + textEdit4.Text + "',Address ='" + textEdit5.Text + "'  WHERE ID = '" + textEdit1.Text + "' ") == true)
            {
                MessageBox.Show("Đã Sửa dữ liệu");
            }
            else
            {
                MessageBox.Show("Không thể Sửa dữ liệu");
            }
            sqlDataSource1.Fill();
        }

        //Button xoa
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (studentDao.exedata("delete from Parent where ID = '" + textEdit1.Text + "' ") == true)
            {
                MessageBox.Show("Đã Xóa dữ liệu");
            }
            else
            {
                MessageBox.Show("Không thể Xóa dữ liệu");
            }
            sqlDataSource1.Fill();
        }

        //Button Load
        private void simpleButton4_Click(object sender, EventArgs e)
        {

            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            sqlDataSource1.Fill();
        }
    }
}
