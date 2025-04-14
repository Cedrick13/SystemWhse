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
    public partial class FormReceiving: Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable table;
        private MySqlConnection connection;
        private string connStr;

        public FormReceiving()
        {
            InitializeComponent();
        }

        private void FormReceiving_Load(object sender, EventArgs e)
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
                    string query = "SELECT id, rcvno, rcvdt, custcode, bl_awb, formno, status, remarks FROM rcvinghd";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a new "No" column at the first position
                    DataColumn noCol = new DataColumn("No", typeof(int));
                    dt.Columns.Add(noCol);
                    noCol.SetOrdinal(0); // Move to first column

                    dataGridView1.Columns.Clear(); // clear old columns
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["No"].DisplayIndex = 0;


                    // Set counter values
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["No"] = i + 1;
                    }

                    // Bind to DataGridView
                    dataGridView1.DataSource = dt;

                    // Make it responsive
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AutoResizeColumns();

                    // Optional: styling and behavior
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToOrderColumns = true;
                    dataGridView1.AllowUserToResizeColumns = true;
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
                try
                {
                    conn.Open();

                    // Query to load data from the database
                    string query = "SELECT * FROM rcvinghd";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Bind data to the DataGridView
                    dataGridView1.DataSource = table;

                    // Count total rows
                    string countQuery = "SELECT COUNT(*) FROM rcvinghd";
                    MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                    int totalRows = Convert.ToInt32(countCmd.ExecuteScalar());

                    // Show total in label
                    label7.Text = $"Total Records: {totalRows}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
