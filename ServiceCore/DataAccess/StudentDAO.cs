using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.DataAccess
{
    public class StudentDAO
    {
        //Student connect
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ToString());
        public void openconnect()
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
        public DataTable readdata(string cmd)
        {
            openconnect();
            DataTable da = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(da);
            }
            catch (Exception)
            {
                da = null;
            }
            closeconnect();
            return da;
        }
        public List<StudentModel> GetUserList()
        {
            List<StudentModel> list = new List<StudentModel>();
            StudentModel user;
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx)
				To in Bussiness object and then Pass it to Bussiness logic and then to
				DataAcess
				this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("load_Stu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user = new StudentModel();
                    user.ID = reader["ID"].ToString();
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.BirthDate = DateTime.Parse(reader["BirthDate"].ToString());
                    user.Gender = int.Parse(reader["Gender"].ToString());
                    user.ClassID = int.Parse(reader["ClassID"].ToString());
                    user.Country = reader["Country"].ToString();
                    user.Address = reader["Address"].ToString();
                    user.PhoneNumber = reader["Email"].ToString();
                    user.TrainingSystemID = int.Parse(reader["TrainingSystemID"].ToString());
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



    }
}
