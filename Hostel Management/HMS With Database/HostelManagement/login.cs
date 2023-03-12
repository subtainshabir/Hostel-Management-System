using HostelManagement.hmClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagement
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        hostelClass hc = new hostelClass();

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text =="" || textBoxPassword.Text == "")
            {
                MessageBox.Show("You need to fill all entries", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxUsername.Text=="Admin" && textBoxPassword.Text == "Admin")
            {
                welcome wc=new welcome();
                this.Hide();
                wc.Show();
                clear();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
            }
                    
        }

        public void clear ()
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
