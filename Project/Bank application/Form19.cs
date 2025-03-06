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
    public partial class Form19 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                string query = @"select CUSTOMER_NAME,
                                 EMPLOYEE_NAME,
                                 LOAN_NUMBER,
                                 LOAN_AMOUNT,
                                 LOAN_TYPE 
                                 From 
                                 CUSTOMER,EMPLOYEE,LOAN 
                                 where LOAN.CUSTOMER_SSN = CUSTOMER.CUSTOMER_SSN and LOAN.EMPLOYEE_ID = EMPLOYEE.EMPLOYEE_ID ";

                using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        connection.Close();
                    }
                }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
