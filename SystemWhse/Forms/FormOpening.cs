using MySql.Data.MySqlClient;
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
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Diagnostics;
using System.Windows.Controls;

namespace SystemWhse.Forms
{
    public partial class FormOpening: Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable table;
        private MySqlConnection connection;
        private string connStr;

        public FormOpening()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormOpening_Load(object sender, EventArgs e)
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
                    string query = "SELECT id, openingno, opendt, custcode, whse, status, remarks FROM openinghd";

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
                    string query = "SELECT * FROM openinghd";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Bind data to the DataGridView
                    dataGridView1.DataSource = table;

                    // Count total rows
                    string countQuery = "SELECT COUNT(*) FROM openinghd";
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

        private void btnprev_Click(object sender, EventArgs e)
        {
          
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
           
        }

        private void navigate_records(int inc)
        {
            throw new NotImplementedException();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
           
        }

        private void select_navigation(string v)
        {
            throw new NotImplementedException();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Search query that filters data based on user input
                    string query = @"
            SELECT id, openingno, opendt, custcode, 
                   whse, status, remarks
            FROM openinghd 
            WHERE CONCAT(
                IFNULL(id, ''), 
                IFNULL(openingno, ''), 
                IFNULL(opendt, ''), 
                IFNULL(custcode, ''), 
                IFNULL(CAST(whse AS CHAR), ''), 
                IFNULL(CAST(status AS CHAR), ''), 
                IFNULL(remarks, '')
            ) LIKE @search";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Add a new column for the counter
                        dt.Columns.Add("No", typeof(int));

                        // Loop through the rows and set the counter value
                        int counter = 1;
                        foreach (DataRow row in dt.Rows)
                        {
                            row["No"] = counter++;
                        }

                        dt.Columns["No"].SetOrdinal(0);

                        // Display filtered data in DataGridView
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        // Display total records for search results
                        label7.Text = $"Total Records: {dt.Rows.Count}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search error: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddOpening form2 = new FormAddOpening();

            // Disable Form1 while Form2 is open
            this.Enabled = false;

            // Show Form2 as modal
            form2.ShowDialog();

            // Re-enable Form1 after Form2 closes
            this.Enabled = true;

            // Bring Form1 back to front
            this.BringToFront();
        }
    }
}
