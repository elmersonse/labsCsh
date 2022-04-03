using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void task1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Enabled = true;
            f.Show();
        }

        private void exitb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void task2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Enabled = true;
            f.Show();
        }
    }
}