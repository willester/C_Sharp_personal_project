using SARIVAN_WILLIAM_1065_Project.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SARIVAN_WILLIAM_1065_Project
{
    public partial class Form2 : Form
    {

        List<User> users;


        public Form2()
        {
            InitializeComponent();

            users = new List<User>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.Hide();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();

        }
    }
}
