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
    public partial class hostel_btn : Form
    {
        function fn = new function();
        string query;

        public hostel_btn()
        {
            InitializeComponent();
        }

        hostelClass hc = new hostelClass();

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void hostel_btn_Load(object sender, EventArgs e)
        {
            query = "select * from hostel";
            DataSet ds = fn.getdata(query);
            dgvRoomList.DataSource = ds.Tables[0];
            /* label1.Text = "Welcome, " + hostelClass.UserID.ToString();
             DataTable dt = hc.room_select();
             dgvRoomList.DataSource = dt;*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtBoxRoom_id.Text = "";
            txtBoxRoomNo.Text = "";
            cmbRoomType.Text = "";
            txtBoxNoBeds.Text = "";
            txtBoxPrice.Text = "";
            txtBoxDesc.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if ((txtBoxPrice.Text != "") || (txtBoxNoBeds.Text != "") || (txtBoxRoomNo.Text != "") || (hc.description != ""))
            {
                string query = "insert into hostel(room_no,room_type,no_of_beds,price,description) values ('" + txtBoxRoomNo.Text + "','" + cmbRoomType.Text + "','" + txtBoxNoBeds.Text + "','" + txtBoxPrice.Text + "','" + txtBoxDesc.Text + "')";
                fn.setdata(query, "Room is successfully added.");
                Clear();

            }
            else
            {
                MessageBox.Show("Failed to add new room. Try Again !");
            }
        }

        private void dgvRoomList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtBoxRoom_id.Text = dgvRoomList.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxRoomNo.Text = dgvRoomList.Rows[rowIndex].Cells[1].Value.ToString();
            cmbRoomType.Text = dgvRoomList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxNoBeds.Text = dgvRoomList.Rows[rowIndex].Cells[4].Value.ToString();
            txtBoxPrice.Text = dgvRoomList.Rows[rowIndex].Cells[5].Value.ToString();
            txtBoxDesc.Text = dgvRoomList.Rows[rowIndex].Cells[6].Value.ToString();
        }

        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if ((txtBoxPrice.Text != "") || (txtBoxNoBeds.Text != "") || (txtBoxRoomNo.Text != "") || (hc.description != ""))
            {
                string query = "update  hostel  set room_type='" + cmbRoomType.Text + "',no_of_beds='" + txtBoxNoBeds.Text + "',price='" + txtBoxPrice.Text + "',description='" + txtBoxDesc.Text + "' Where room_no ='" + txtBoxRoomNo.Text + "'";
                fn.setdata(query, "Room Updated successfully.");
                Clear();

            }
            else
            {
                MessageBox.Show("Failed to add new room. Try Again !");
            }
        }

    

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            query = "Delete from hostel where room_no='" + txtBoxRoomNo.Text + "'";
            fn.setdata(query,"Room Deleted Sucessfully.");
        }

        private void txtBoxRoomNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRoomType_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxNoBeds_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNoBeds_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDesc_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvRoomList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            //txtBoxRoom_id.Text = dgvRoomList.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxRoomNo.Text = dgvRoomList.Rows[rowIndex].Cells[0].Value.ToString();
            cmbRoomType.Text = dgvRoomList.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxNoBeds.Text = dgvRoomList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxPrice.Text = dgvRoomList.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxDesc.Text = dgvRoomList.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void lbl_roomNo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxRoom_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            welcome wc = new welcome();
            wc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            query = "select * from hostel where room_no like'" + txtBoxSearch.Text + "%'";
            DataSet ds = fn.getdata(query);
            dgvRoomList.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hostel_btn_Load(this, null);
        }
    }
}
