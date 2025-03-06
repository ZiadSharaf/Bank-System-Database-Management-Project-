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
    public partial class Form15 : Form
    {
        public Form15()
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form13 form = new Form13();
            form.FormClosed += Form13_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form13_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }
    }
}
