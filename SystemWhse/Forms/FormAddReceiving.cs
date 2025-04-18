﻿using System;
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
    public partial class FormAddReceiving : Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable table;
        private MySqlConnection connection;
        private string connStr;
        Dictionary<string, string> customerMap = new Dictionary<string, string>();

        public FormAddReceiving()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void FormAddReceiving_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; // Exit without doing anything
            }

            // Proceed with cancel action
            this.Close(); // Close the form (if applicable)
        }

        private void LoadComboBoxData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT custcode, name FROM customer";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string code = reader.GetString("custcode");
                        string name = reader.GetString("name");

                        comboBox4.Items.Add(code); // still show code in comboBox
                        customerMap[code] = name;  // map code to name
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCode = comboBox4.SelectedItem.ToString();

            if (customerMap.ContainsKey(selectedCode))
            {
                textBox3.Text = customerMap[selectedCode]; // Display the customer name
            }
        }
    }
}

