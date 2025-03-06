using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.FormClosed += Form7_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 form = new Form9();
            form.FormClosed += Form9_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
