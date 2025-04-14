using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SystemWhse.Forms
{
    public partial class FormPullout: Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable table;
        private MySqlConnection connection;
        private string connStr;
        public FormPullout()
        {
            InitializeComponent();
        }

        private void FormPullout_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadUserData();
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();

            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void LoadUserData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT custcode,itemcode,barcode,descript,uom,type,in_stock,qty_item FROM Items";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a new column for the counter
                    dt.Columns.Add("No", typeof(int));

                    // Loop through the rows and set the counter value
                    int counter = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        row["No"] = counter++;
                    }

                    dt.Columns["No"].SetOrdinal(0);

                    dataGridView1.DataSource = dt;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Optionally, set specific column widths (if needed)
                    dataGridView1.Columns["No"].Width = 80;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Load all data
                string query = "SELECT * FROM items";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                // Count total rows
                string countQuery = "SELECT COUNT(*) FROM items";
                MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                int totalRows = Convert.ToInt32(countCmd.ExecuteScalar());

                // Show total in label
                label7.Text = $"Total Record: {totalRows}";
            }
        }
    }
}
