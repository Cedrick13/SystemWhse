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

namespace SystemWhse.Forms
{
    public partial class FormOpening: Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        public FormOpening()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormOpening_Load(object sender, EventArgs e)
        {
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
                    string query = "SELECT custcode,itemcode,uom,itemdesc,qty_item FROM Items";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a new column for the counter
                    dt.Columns.Add("RecNo", typeof(int));

                    // Loop through the rows and set the counter value
                    int counter = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        row["RecNo"] = counter++;
                    }
                    
                    dt.Columns["RecNo"].SetOrdinal(0);

                    dataGridView1.DataSource = dt;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Optionally, set specific column widths (if needed)
                    dataGridView1.Columns["RecNo"].Width = 80;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
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
    }
}
