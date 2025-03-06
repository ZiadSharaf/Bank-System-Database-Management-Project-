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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12();
            form.FormClosed += Form12_FormClosed;
            form.Show();
            this.Hide();
        }
        private void Form12_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
