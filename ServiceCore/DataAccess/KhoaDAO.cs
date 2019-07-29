using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceCore.DataAccess
{
    public class KhoaDAO
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ToString());
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
