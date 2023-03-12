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
    public partial class student_btn : Form
    {
        function fn = new function();
        string query;
             
        public student_btn()
        {
            InitializeComponent();
        }

        hostelClass hc = new hostelClass();

        public void Clear()
        {
            txtBoxStudentID.Text = "";
            txtBoxRoomID.Text = "";
            txtBoxStudentName.Text = "";
            txtBoxUSN.Text = "";
            txtBoxPhone.Text = "";
            txtBoxEmail.Text = "";
            txtBoxRoomNo.Text = "";
            cmbMessFaci.Text = "";
        }

        private void lbl_roomNo_Click(object sender, EventArgs e)
        {

        }

        private void student_btn_Load(object sender, EventArgs e)
        {
            /*label1.Text = "Welcome, " + hostelClass.UserID.ToString();
            DataTable dt1 = hc.avail_room_select();
            dgvAvailableRooms.DataSource = dt1;
            DataTable dt2 = hc.student_select();
            dgvStudentList.DataSource = dt2;*/
            query = "select * from hostel where Booked='No'";
            DataSet ds = fn.getdata(query);
            dgvAvailableRooms.DataSource = ds.Tables[0];

            query = "select * from student";
            DataSet da = fn.getdata(query);
            dgvStudentList.DataSource = da.Tables[0];

            


        }

        private void dgvAvailableRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            query = "select * from student";
            DataSet ds = fn.getdata(query);
            dgvAvailableRooms.DataSource = ds.Tables[0];

        }

        private void dgvAvailableRooms_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtBoxRoomNo.Text = dgvAvailableRooms.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxRoomID.Text = dgvAvailableRooms.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxNumberBedsH.Text = dgvAvailableRooms.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void dgvStudentList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtBoxStudentName.Text = dgvStudentList.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxUSN.Text = dgvStudentList.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxPhone.Text = dgvStudentList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxEmail.Text = dgvStudentList.Rows[rowIndex].Cells[4].Value.ToString();
            txtBoxRoomNo.Text = dgvStudentList.Rows[rowIndex].Cells[5].Value.ToString();
            cmbMessFaci.Text = dgvStudentList.Rows[rowIndex].Cells[6].Value.ToString();
        }

            private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtBoxStudentName.Text != "") || (txtBoxUSN.Text != "") || (txtBoxEmail.Text != "") || (txtBoxPhone.Text != ""))
            {
                string query = "insert into student values ('" + txtBoxStudentName.Text + "','" + txtBoxUSN.Text + "','" + txtBoxPhone.Text + "','" + txtBoxEmail.Text + "','" + txtBoxRoomNo.Text + "','" + cmbMessFaci.Text + "') update hostel set Booked='Yes' where room_no='"+txtBoxRoomNo.Text+"'";
                fn.setdata(query, "Room is successfully Allocated.");
                Clear();

            }
            else
            {
                MessageBox.Show("Failed to add new room. Try Again !");
            }

        }

        private void txtBoxPrice_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBoxStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxRoomID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if ((txtBoxStudentName.Text != "") || (txtBoxUSN.Text != "") || (txtBoxEmail.Text != "") || (txtBoxPhone.Text != ""))
            
                {
                string query = "update  student  set student_name='" + txtBoxStudentName.Text + "',usn='" + txtBoxUSN.Text + "',phone='" + txtBoxPhone.Text + "',  email ='" + txtBoxEmail.Text + "',room_no='" + txtBoxRoomNo.Text + "',mess='" + cmbMessFaci.Text + "'";
                fn.setdata(query, "Room Updated successfully.");
                Clear();

            }
            else
            {
                MessageBox.Show("Failed to add new room. Try Again !");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            query = "Delete from student where email='" + txtBoxEmail.Text + "'update hostel set Booked='No' where room_no='"+txtBoxRoomNo.Text+"'";
            fn.setdata(query, "Student Deleted Sucessfully.");

        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtBoxSearch.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM hm_rooms WHERE room_no LIKE '%" + keyword + "%' AND availability = 'YES'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvAvailableRooms.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtBoxSearch.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT s.student_id, s.student_name, s.student_usn, s.student_phone, s.student_email, r.room_no FROM hm_student s, hm_rooms r WHERE student_name LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvStudentList.DataSource = dt;
        }

        private void dgvStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtBoxStudentName.Text = dgvStudentList.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxUSN.Text = dgvStudentList.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxPhone.Text = dgvStudentList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxEmail.Text = dgvStudentList.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxRoomNo.Text = dgvStudentList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbMessFaci.Text = dgvStudentList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            welcome wc = new welcome();
            wc.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxRoomNo_TextChanged(object sender, EventArgs e)
        {
            query = "select room_no from hostel where booked='No'";
            DataSet ds = fn.getdata(query);
            txtBoxRoomNo.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void dgvStudentList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStudentList_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void dgvStudentList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {/*
            int rowIndex = e.RowIndex;
            txtBoxStudentName.Text = dgvStudentList.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxUSN.Text = dgvStudentList.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxPhone.Text = dgvStudentList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxEmail.Text = dgvStudentList.Rows[rowIndex].Cells[4].Value.ToString();
            txtBoxRoomNo.Text = dgvStudentList.Rows[rowIndex].Cells[5].Value.ToString();
            cmbMessFaci.Text = dgvStudentList.Rows[rowIndex].Cells[6].Value.ToString();
        */}

        private void button1_Click(object sender, EventArgs e)
        {
            student_btn_Load(this, null);
        }
    }
}
