﻿using MySql.Data.MySqlClient;
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
                    string query = "SELECT custcode,itemcode,descript,uom,opening_qty,qty_item,active FROM Items";

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
                try
                {
                    conn.Open();

                    // Query to load data from the database
                    string query = "SELECT * FROM items";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Bind data to the DataGridView
                    dataGridView1.DataSource = table;

                    // Count total rows
                    string countQuery = "SELECT COUNT(*) FROM items";
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
            SELECT custcode, itemcode, descript, uom, 
                   opening_qty, qty_item, active 
            FROM items 
            WHERE CONCAT(
                IFNULL(custcode, ''), 
                IFNULL(itemcode, ''), 
                IFNULL(descript, ''), 
                IFNULL(uom, ''), 
                IFNULL(CAST(opening_qty AS CHAR), ''), 
                IFNULL(CAST(qty_item AS CHAR), ''), 
                IFNULL(active, '')
            ) LIKE @search";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Display filtered data in DataGridView
                        dataGridView1.DataSource = dt;

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
    }
}
