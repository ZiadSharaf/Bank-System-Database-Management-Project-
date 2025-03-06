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
using System.Xml.Linq;

namespace Bank
{
    public partial class Form14 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ssn = textBox1.Text;
            string name = textBox2.Text;

            bool customerExists = CheckCustomerInDatabase(ssn, name);

            if (customerExists)
            {
                MessageBox.Show("Login successful!");
                Form15 form = new Form15();
                form.FormClosed += Form15_FormClosed;
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid SSN or Name. Please try again.");
            }
        }
        private void Form15_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private bool CheckCustomerInDatabase(string ssn, string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM CUSTOMER WHERE CUSTOMER_SSN = @SSN AND CUSTOMER_NAME = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Assuming CUSTOMER_SSN is varchar in the database
                    command.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = ssn;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}
