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
    public partial class contactpage : Form
    {
        public contactpage()
        {
            InitializeComponent();
        }

        private void contactpage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            homepage hmp = new homepage();
            hmp.Show();
            this.Hide();

        }
    }
}
