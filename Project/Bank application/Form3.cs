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
    public partial class Form3 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bankName = textBox1.Text;
            string bankCode = textBox2.Text;
            string bankAddress = textBox3.Text;

            if (BankCodeExists(bankCode))
            {
                MessageBox.Show("Bank code already exists. Please choose a different one.");
                return;
            }
            if (InsertBankDetails(bankName, bankCode, bankAddress))
            {
                MessageBox.Show("Bank details added successfully.");
                label2.Text="";
                label3.Text = "";
                label4.Text = "";
            }
            else
            {
                MessageBox.Show("Failed to add Bank. Please try again.");
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
        private bool InsertBankDetails(string bankName, string bankCode, string bankAddress)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Bank (BANK_NAME, BANK_CODE, BANK_ADDRESS) VALUES (@BankName, @BankCode, @BankAddress)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@BankCode", bankCode);
                    command.Parameters.AddWithValue("@BankName", bankName);
                    command.Parameters.AddWithValue("@BankAddress", bankAddress);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                    connection.Close();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
