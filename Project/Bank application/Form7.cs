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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bank
{
    public partial class Form7 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form7()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string employeeID = textBox1.Text;
            string employeeName = textBox2.Text;
            string employeeAddress = textBox3.Text;
            string branchNumber = textBox4.Text;

            

            if (EmployeeIDExists(employeeID))
            {
                MessageBox.Show("Employee ID already exists. Please choose a different one.");
                return;
            }

            if (InsertEmployeeDetails(employeeID, employeeName, employeeAddress, branchNumber))
            {
                MessageBox.Show("Employee signed up successfully.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Failed to sign up the employee. Please try again.");
            }
        }
        private bool EmployeeIDExists(string employeeID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM EMPLOYEE WHERE EMPLOYEE_ID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool InsertEmployeeDetails(string employeeID, string employeeName, string employeeAddress, string branchNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO EMPLOYEE (EMPLOYEE_ID, EMPLOYEE_NAME, EMPLOYEE_ADDRESS, BRANCH_NUMBER) VALUES (@EmployeeID, @EmployeeName, @EmployeeAddress, @BranchNumber)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@EmployeeName", employeeName);
                    command.Parameters.AddWithValue("@EmployeeAddress", employeeAddress);
                    command.Parameters.AddWithValue("@BranchNumber", branchNumber);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                    connection.Close();
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
