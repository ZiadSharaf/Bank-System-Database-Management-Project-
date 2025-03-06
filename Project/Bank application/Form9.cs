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
    public partial class Form9 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form9()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string customerSSN = textBox1.Text;
            string employeeID = textBox5.Text;
            string customerName = textBox2.Text;
            string customerAddress = textBox3.Text;

            if (CustomerExists(customerSSN))
            {
                MessageBox.Show("Customer already exists. Please choose a different one.");
                return;
            }

            if (InsertCustomerDetails(customerSSN, employeeID, customerName, customerAddress))
            {
                MessageBox.Show("Customer signed up successfully.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Failed to sign up the customer. Please try again.");
            }
        }
        private bool CustomerExists(string customerSSN)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM CUSTOMER WHERE CUSTOMER_SSN = @CustomerSSN";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool InsertCustomerDetails(string customerSSN, string employeeID, string customerName, string customerAddress)
        {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO CUSTOMER (CUSTOMER_SSN, EMPLOYEE_ID, CUSTOMER_NAME, CUSTOMER_ADDRESS) VALUES (@CustomerSSN, @EmployeeID, @CustomerName, @CustomerAddress)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        command.Parameters.AddWithValue("@CustomerName", customerName);
                        command.Parameters.AddWithValue("@CustomerAddress", customerAddress);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            
             
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
