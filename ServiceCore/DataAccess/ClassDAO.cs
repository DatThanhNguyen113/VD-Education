using ServiceCore.Models;
using ServiceCore.Models.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace ServiceCore.DataAccess
{
    public class ClassDAO
    {
        //conn
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ToString());

        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private BaseResponseModel<object> baseResponseModel;

        public BaseResponseModel<object> GetAllClass(string UserId)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1003", "", UserId);
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<ClassModel>(ds);
                return baseResponseModel;

            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> GetAllCareer(string UserId)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1004", "", UserId);
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<CareerModel>(ds);
                return baseResponseModel;

            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        public BaseResponseModel<object> GetAllSchoolYear(string UserId = "")
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1005", "");
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<SchoolYearModel>(ds);
                return baseResponseModel;

            }
            catch (Exception ex)
            {
                baseResponseModel.ResponseMessage = ex.Message.ToString();
                baseResponseModel.Result = -2;
            }
            return baseResponseModel;
        }

        private void openconnect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void closeconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public Boolean exedata(string cmd)
        {
            openconnect();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            closeconnect();
            return check;
        }
        public void loadCBB(ComboBox cmd, String sql, String display, String value)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ToString());
            con.Open();
            DataSet dataSet;
            SqlDataAdapter adapter;
            SqlCommand sl = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(sl);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            cmd.DataSource = dataSet.Tables[0];
            cmd.DisplayMember = display;
            cmd.ValueMember = value;
            con.Close();
        }
        public void loadCBB2(ComboBox cmd, String sql, String display, String value)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ToString());
            con.Open();
            DataSet dataSet;
            SqlDataAdapter adapter;
            SqlCommand sl = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(sl);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            cmd.DataSource = dataSet.Tables[0];
            cmd.DisplayMember = display;
            cmd.ValueMember = value;
            con.Close();
        }

    }
}
