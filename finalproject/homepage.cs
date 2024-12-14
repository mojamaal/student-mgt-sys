using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject
{
    public partial class homepage : Form
    {
        public homepage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void homepage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            contactpage contact = new contactpage();
            contact.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aboutpage about = new aboutpage();
            about.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            registrationfrm reg = new registrationfrm();
            reg.Show();
            this.Hide();
        }
    }
}
