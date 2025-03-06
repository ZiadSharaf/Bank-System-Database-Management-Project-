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
    public partial class Form13 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form13()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string customerSSN = textBox1.Text;
            string customerName = textBox2.Text;
            string customerAddress = textBox3.Text;

            if (IsCustomerSSNValid(customerSSN))
            {
                UpdateCustomerDetails(customerSSN, customerName, customerAddress);
            }
            else
            {
                MessageBox.Show("Invalid customer SSN.");
            }
        }
        private bool IsCustomerSSNValid(string customerSSN)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM CUSTOMER WHERE CUSTOMER_SSN = @CustomerSSN";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private void UpdateCustomerDetails(string customerSSN, string customerName, string customerAddress)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE CUSTOMER SET CUSTOMER_NAME = @CustomerName, CUSTOMER_ADDRESS = @CustomerAddress WHERE CUSTOMER_SSN = @CustomerSSN";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                command.Parameters.AddWithValue("@CustomerName", customerName);
                command.Parameters.AddWithValue("@CustomerAddress", customerAddress);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer details updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update customer details.");
                }
            }
        }
    }

}  
