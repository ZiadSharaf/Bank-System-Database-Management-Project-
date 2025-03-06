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
    public partial class Form20 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form20()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string employeeID = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(employeeID))
            {
                MessageBox.Show("Please enter an employee ID.");
                return;
            }

            if (!EmployeeExists(employeeID))
            {
                MessageBox.Show("Employee with ID " + employeeID + " does not exist.");
                return;
            }

            if (DeleteEmployee(employeeID))
            {
                MessageBox.Show("Employee deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete employee.");
            }
        }
        private bool EmployeeExists(string employeeID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM EMPLOYEE WHERE Employee_ID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                connection.Close();
            }
        }
        private bool DeleteEmployee(string employeeID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string customerCheckQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE EMPLOYEE_ID = @EmployeeID";
                using (SqlCommand checkCommand = new SqlCommand(customerCheckQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                    int customerCount = (int)checkCommand.ExecuteScalar();

                    if (customerCount > 0)
                    {
                        string deleteCustomersQuery = "DELETE FROM CUSTOMER WHERE EMPLOYEE_ID = @EmployeeID";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteCustomersQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }

                string deleteEmployeeQuery = "DELETE FROM EMPLOYEE WHERE Employee_ID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(deleteEmployeeQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }
    }

 }

