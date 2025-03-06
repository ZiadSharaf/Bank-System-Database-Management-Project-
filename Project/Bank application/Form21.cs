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
    public partial class Form21 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form21()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string customerSSN = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(customerSSN))
            {
                MessageBox.Show("Please enter a customer SSN.");
                return;
            }

            if (!CustomerExists(customerSSN))
            {
                MessageBox.Show("Customer with SSN " + customerSSN + " does not exist.");
                return;
            }

            if (DeleteCustomer(customerSSN))
            {
                MessageBox.Show("Customer deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete customer.");
            }
        }
        private bool CustomerExists(string customerSSN)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM CUSTOMER WHERE CUSTOMER_SSN = @CustomerSSN";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                connection.Close();
            }
        }
        private bool DeleteCustomer(string customerSSN)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string accountCheckQuery = "SELECT COUNT(*) FROM ACCOUNT WHERE CUSTOMER_SSN = @CustomerSSN";
                using (SqlCommand checkCommand = new SqlCommand(accountCheckQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                    int accountCount = (int)checkCommand.ExecuteScalar();

                    if (accountCount > 0)
                    {
                        string deleteAccountsQuery = "DELETE FROM ACCOUNT WHERE CUSTOMER_SSN = @CustomerSSN";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteAccountsQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }

                string deleteCustomerQuery = "DELETE FROM CUSTOMER WHERE CUSTOMER_SSN = @CustomerSSN";
                using (SqlCommand command = new SqlCommand(deleteCustomerQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void Form21_Load(object sender, EventArgs e)
        {

        }
    }
}
