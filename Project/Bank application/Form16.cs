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
    public partial class Form16 : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-3DTHG80;Initial Catalog=Bank;Integrated Security=True;";
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet.LOAN' table. You can move, or remove it, as needed.
            this.lOANTableAdapter.Fill(this.bankDataSet.LOAN);
            {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        string query = @"SELECT 
                                         LOAN_NUMBER,
                                         LOAN_AMOUNT,
                                         LOAN_TYPE
                                         FROM LOAN";
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }
    }
 }
