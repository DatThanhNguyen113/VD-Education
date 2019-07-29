using ServiceCore.Models.Base;
using ServiceCore.Models.User;
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
    public class TeacherDAO
    {

        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private BaseResponseModel<object> baseResponseModel;

        //teacher connect
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ToString());
        public List<TeacherModel> GetTeacherList()
        {
            List<TeacherModel> list = new List<TeacherModel>();
            TeacherModel user;
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx)
				To in Bussiness object and then Pass it to Bussiness logic and then to
				DataAcess
				this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("load_Tea", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user = new TeacherModel();
                    user.ID = reader["ID"].ToString();
                    user.Name = reader["LastName"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.BirthDate = DateTime.Parse(reader["BirthDate"].ToString());
                    user.WorkUnit = reader["WorkUnit"].ToString();
                    user.Graduating = reader["Graduating"].ToString();
                    user.Diploma = reader["Diploma"].ToString();
                    user.BankAccountNumber = reader["BankAccountNumber"].ToString();
                    user.BankID = int.Parse(reader["BankID"].ToString());
                    user.Description = reader["Description"].ToString();
                    list.Add(user);
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                list = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return list;
        }

        public BaseResponseModel<object> GetAllTeacher(string UserId)
        {
            try
            {
                baseResponseModel = new BaseResponseModel<object>();
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "1007", "", UserId);
                var ds = db.GetContextData(xml);
                baseResponseModel = BaseResultFromObject.GetBaseResponse<TeacherModel>(ds);
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
    }
}
