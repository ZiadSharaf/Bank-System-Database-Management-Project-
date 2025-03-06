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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.FormClosed += Form3_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.FormClosed += Form4_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.FormClosed += Form5_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 form = new Form11();
            form.FormClosed += Form11_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form16 form = new Form16();
            form.FormClosed += Form16_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form16_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form19 form = new Form19();
            form.FormClosed += Form19_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form19_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form20 form = new Form20();
            form.FormClosed += Form19_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form20_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
