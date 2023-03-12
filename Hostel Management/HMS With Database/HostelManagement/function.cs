using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace HostelManagement
{
    internal class function
    {
        protected SqlConnection getconnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL 5470 i5\\Desktop\\HMS\\db_hostel.mdf;Integrated Security=True;Connect Timeout=30";
            return conn;
        }

        public SqlDataReader getforcombo(string query)
        {
            SqlConnection conn = getconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd = new SqlCommand(query, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;

        }
        public void setdata(string query, string message)
        {
            SqlConnection con = getconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("'" + message + "'", "Success", MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public DataSet getdata(string query)        //Extract Data from database
        {
            SqlConnection con = getconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
    }
}