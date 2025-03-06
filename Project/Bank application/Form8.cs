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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.FormClosed += Form1_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 form = new Form10();
            form.FormClosed += Form10_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form10_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void button2_Click(object sender, EventArgs e)
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

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form21 form = new Form21();
            form.FormClosed += Form21_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form21_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
