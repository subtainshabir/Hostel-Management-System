using HostelManagement.hmClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagement
{
    public partial class mess_btn : Form
    {
        function fn = new function();
        string query;
        public mess_btn()
        {
            InitializeComponent();
        }

        hostelClass hc = new hostelClass();


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            welcome wc = new welcome();
            wc.Show();
        }

        private void txtBoxRoomNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mess_btn_Load(object sender, EventArgs e)
        {
            /*//label1.Text = "Welcome, " + hostelClass.UserID.ToString();
            DataTable dt1 = hc.mess_select();
            dgvMessList.DataSource = dt1;
            DataTable dt2 = hc.Stu_Mess();
            dgvStuMessList.DataSource = dt2;*/
            query = "select * from mess ";
            DataSet ds = fn.getdata(query);
            dgvMessList.DataSource = ds.Tables[0];

            query = "select * from student where mess='YES' ";
            DataSet da = fn.getdata(query);
            dgvStuMessList.DataSource = da.Tables[0];
        }

        public void Clear()
        {
            txtBoxItemName.Text = "";
            txtBoxTotalPrice.Text = "";
            txtBoxQuantity.Text = "";
            comboBox1.Text = "";
            txtBoxYear.Text = "";            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtBoxItemName.Text != "") || (txtBoxQuantity.Text != "") || (txtBoxTotalPrice.Text != "") || (txtBoxYear.Text != ""))
            {
                string query = "insert into mess values ('" + txtBoxItemName.Text + "','" + txtBoxQuantity.Text + "','" + txtBoxTotalPrice.Text + "','" + comboBox1.Text + "','" + txtBoxYear.Text + "')";
                fn.setdata(query, "Mess is successfully Updated.");
                Clear();

            }
            else
            {
                MessageBox.Show("Failed to update mess. Try Again !");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
           /* try {
                string keyword = txtBoxSearch.Text;
                SqlConnection conn = new SqlConnection(myconnstr);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM hm_mess WHERE month LIKE '%" + keyword + "%' OR year LIKE '%" + keyword + "%'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvMessList.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "select * from mess where month_name like'" + txtBoxSearch.Text + "%'";
            DataSet ds = fn.getdata(query);
            dgvMessList.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mess_btn_Load(this, null);
        }
    }
}
