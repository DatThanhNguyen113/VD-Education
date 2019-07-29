using ServiceCore.DataAccess;
using ServiceCore.Models;
using ServiceCore.Models.Base;
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
    public partial class Form1 : Form
    {
        private BaseResponseModel<object> baseResponseModel;
        AccountDAO dao = new AccountDAO();
        public int UserID;
        int iLoginFailed;
        const int cNumberLoginFailed = 3;
        public static Form1 _Instance;

        public Form1()
        {
            InitializeComponent();
            _Instance = this;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //baseResponseModel = new BaseResponseModel<object>();
            //SignInModel model = new SignInModel();

            //model.UserName = edtUsername.Text;
            //model.Password = edtPass.Text;
            //baseResponseModel = dao.ValidateSignIn(model);
            //if (baseResponseModel.Result > 0)
            //{
            //    MessageBox.Show(baseResponseModel.ResponseMessage);
            //    UserID = baseResponseModel.Result;
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show(baseResponseModel.ResponseMessage);
            //    if (iLoginFailed < cNumberLoginFailed)
            //    {
            //        iLoginFailed += 1;
            //        this.DialogResult = DialogResult.None;
            //    }
            //    else
            //    {
            //        this.DialogResult = DialogResult.Cancel;
            //    }

            //}
            if(edtUsername.Text.ToString().Length < 1 && edtPass.Text.ToString().Length < 1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            else
            {
                if(edtUsername.Text.ToLower() == "admin" && edtPass.Text.ToLower() == "viendongadmin")
                {
                    FormMain f2 = new FormMain();
                    f2.UserID = 13;
                    f2.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            UserID = 0;
            this.Close();
        }

        public void CloseApplication()
        {
            _Instance.Close();
        }
    }
}
