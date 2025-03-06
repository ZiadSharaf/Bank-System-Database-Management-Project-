using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form18 form = new Form18();
            form.FormClosed += Form18_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form18_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.FormClosed += Form2_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.FormClosed += Form6_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form14 form = new Form14();
            form.FormClosed += Form14_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form14_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
