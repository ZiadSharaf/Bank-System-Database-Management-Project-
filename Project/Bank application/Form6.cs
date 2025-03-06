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
    public partial class Form6 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string employeeID = textBox1.Text;
            string name = textBox2.Text;

            bool employeeExists = CheckEmployeeInDatabase(employeeID, name);

            if (employeeExists)
            {
                MessageBox.Show("Login successful!");
                Form8 form = new Form8();
                form.FormClosed += Form8_FormClosed;
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Employee ID or Name. Please try again.");
            }

        }
        private bool CheckEmployeeInDatabase(string employeeID, string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM EMPLOYEE WHERE EMPLOYEE_ID = @EmployeeID AND EMPLOYEE_NAME = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
