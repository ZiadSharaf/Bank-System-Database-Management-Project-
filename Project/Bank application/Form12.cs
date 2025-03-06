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
    public partial class Form12 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string employeeId = textBox1.Text;
            string employeeName = textBox2.Text;
            string employeeAddress = textBox3.Text;
            string branchNumber = textBox4.Text;

            if (IsEmployeeIdValid(employeeId))
            {
                UpdateEmployeeDetails(employeeId, employeeName, employeeAddress, branchNumber);
            }
            else
            {
                MessageBox.Show("Invalid employee ID.");
            }
        }
        private bool IsEmployeeIdValid(string employeeId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM EMPLOYEE WHERE EMPLOYEE_ID = @EmployeeId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private void UpdateEmployeeDetails(string employeeId, string employeeName, string employeeAddress, string branchNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE EMPLOYEE SET EMPLOYEE_NAME = @EmployeeName, EMPLOYEE_ADDRESS = @EmployeeAddress, BRANCH_NUMBER = @BranchNumber WHERE EMPLOYEE_ID = @EmployeeId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@EmployeeName", employeeName);
                command.Parameters.AddWithValue("@EmployeeAddress", employeeAddress);
                command.Parameters.AddWithValue("@BranchNumber", branchNumber);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee details updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update employee details.");
                }
            }
        }

    }
}
