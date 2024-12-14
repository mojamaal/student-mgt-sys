using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace finalproject
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //loginbtn
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=""C:\Users\User\Desktop\C# Final Project (Jamaal)\C#\finalproject\db.mdf"";Integrated Security=True;Connect Timeout=30 ");
           {
    string username = textBox1.Text;
    string pass  = textBox2.Text;

    if (username == "Admin" && pass == "Skills@123")
    {
        registrationfrm reg = new registrationfrm();
        reg.Show();
        this.Hide();
    }
    else
    {
        MessageBox.Show("Invalid Login Credentials, please check Username and Password and try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}





        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
