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
    public partial class registrationfrm : Form
    {
        public registrationfrm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Desktop\C# Final Project (Jamaal)\C#\finalproject\db.mdf;Integrated Security=True;Connect Timeout=30");

        private void registrationfrm_Load(object sender, EventArgs e)
        {
        //form

            con.Open();
            string query = "select * from student";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader row = cmd.ExecuteReader();
            comboBox1.Items.Add("new register");
            while (row.Read())
            {
                comboBox1.Items.Add(row[0].ToString());
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // register button
            string regno = comboBox1.Text;
            string firstname = textBox1.Text;
            string lastname = textBox2.Text;
            DateTime dob = dateTimePicker1.Value;
            string gender;
            if (radioButton1.Checked)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }
            string address = richTextBox1.Text;
            string email = textBox3.Text;
            string mobilephone = textBox4.Text;
            string homephone = textBox5.Text;
            string parentname = textBox6.Text;
            string nic = textBox7.Text;
            string contactno = textBox8.Text;
            String query = "insert into student values ( '" + regno + "', '" + firstname + "', '" + lastname + "', '" + dob + "', '" + gender + "', '" + address + "', '" + email + "','" + mobilephone + "', '" + homephone + "', '" + parentname + "', '" + nic + "','" + contactno + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("recorded successfully", "registered student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }


          

        private void button2_Click(object sender, EventArgs e)
        {
            //update button
            string regno = comboBox1.Text;
            if (regno != "new register")
            {
                String firstname = textBox1.Text;
                String lastname = textBox2.Text;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "mm/dd/yyyy";
                string gender;
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";

                }
                string address = richTextBox1.Text;
                string email = textBox3.Text;
                string mobilephone = textBox4.Text;
                string homephone = textBox5.Text;
                string parentname = textBox6.Text;
                string nic = textBox7.Text;
                string contactno = textBox8.Text;
                string query = "update student set firstname ='" + firstname + "',  lastname = '" + lastname + "', dateofbirth = '" + dateTimePicker1.Value + "',  gender = '" + gender + "', address ='" + address + "', email = '" + email + "', mobilephone = '" + mobilephone + "', homephone ='" + homephone + "',parentname ='" + parentname + "', nic ='" + nic + "', contactno ='" + contactno + "', regno ='" + regno + "'";

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully!", "Updated ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "mm/dd/yyyy";
            DateTime today = DateTime.Today;
            dateTimePicker1.Text = today.ToString();


            radioButton1.Checked = false;
            radioButton2.Checked = false;

            richTextBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //combo box

            string regno = comboBox1.Text;
            if (regno != "new register") 
            {
                con.Open();
                string query = "select from student where regno = '" + regno + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader row = cmd.ExecuteReader();
                while (row.Read())
                {
                    textBox1.Text = row[1].ToString();
                    textBox2.Text = row[2].ToString();
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "mm/dd/yyyy";
                    dateTimePicker1.Text = row[3].ToString();
                    if (row[4].ToString() == "Male")
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;

                    }

                    richTextBox1.Text = row[5].ToString();
                    textBox3.Text = row[6].ToString();
                    textBox4.Text = row[7].ToString();
                    textBox5.Text = row[8].ToString();
                    textBox6.Text = row[9].ToString();
                    textBox7.Text = row[10].ToString();
                    textBox8.Text = row[11].ToString();

                }
                con.Close();
                button1.Enabled = false;
                button2.Enabled = true;
                button4.Enabled = true;
                
            }
            else

            {
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "mm/dd/yyyy";
                DateTime today = DateTime.Today;
                dateTimePicker1.Text =today.ToString();


                radioButton1.Checked = true;
                radioButton2.Checked = false;


                richTextBox1.Text = "";
                textBox3.Text = "";
                 textBox4.Text = "";
                 textBox5.Text = "";
                 textBox6.Text = "";
                 textBox7.Text = "";
                 textBox8.Text = "";
                button1.Enabled = true;
                button2.Enabled = false;
                button4.Enabled = false;
                }










        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (result == DialogResult.Yes)
         {
                     String regno = comboBox1.Text;
                     string query = "Delete from student where regno = '"+regno+"'";
                     con.Open();
                     SqlCommand cmd = new SqlCommand (query,con);
                     cmd.ExecuteNonQuery();
                     con.Close();
                     MessageBox.Show("record deleted successfully", "deleted student",MessageBoxButtons.OK,MessageBoxIcon.Information );
 
                 }
                 else if(result==DialogResult.Yes)
                 {
                     this.Close();
                 }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 loginform = new Form1();
            loginform.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            homepage hmp = new homepage();
            hmp.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
            
        
    }
}
