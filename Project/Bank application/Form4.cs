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
    public partial class Form4 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string branchNumber = textBox1.Text;
            string branchAddress = textBox2.Text;
            string bankCode = textBox3.Text;

            if (!BankCodeExists(bankCode))
            {
                MessageBox.Show("Bank code does not exist. Please enter a valid bank code.");
                return;
            }

            // Check if branch number already exists for the given bank code
            if (BranchNumberExists(bankCode, branchNumber))
            {
                MessageBox.Show("Branch number already exists for the given bank code. Please choose a different one.");
                return;
            }

            // Insert branch details into the database
            if (InsertBranchDetails(branchNumber, branchAddress, bankCode))
            {
                MessageBox.Show("Branch details added successfully.");
                // Clear the text boxes after successful insertion
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Failed to add branch details. Please try again.");
            }
        }
        private bool BankCodeExists(string bankCode)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                string query = "SELECT COUNT(*) FROM Bank WHERE BANK_CODE = @BankCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@BankCode", bankCode);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                    connection.Close();
                }

            }
        }
        private bool BranchNumberExists(string bankCode, string branchNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM BRANCH WHERE BRANCH_NUMBER = @BranchNumber AND BANK_CODE = @BankCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@BankCode", bankCode);
                    command.Parameters.AddWithValue("@BranchNumber", branchNumber);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                    connection.Close();
                }
            }
        }

        private bool InsertBranchDetails(string branchNumber, string branchAddress, string bankCode)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO BRANCH (BRANCH_NUMBER, BRANCH_ADDRESS, BANK_CODE) VALUES (@BranchNumber, @BranchAddress, @BankCode)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@BranchNumber", branchNumber);
                    command.Parameters.AddWithValue("@BranchAddress", branchAddress);
                    command.Parameters.AddWithValue("@BankCode", bankCode);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                    connection.Close();
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
