using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class FormDashboard: Form
    {
        
public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            int count = 0;
            string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM items";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        count = Convert.ToInt32(result);
                        label9.Text = count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM rcvinghd";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        count = Convert.ToInt32(result);
                        label5.Text = count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM openinghd";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        count = Convert.ToInt32(result);
                        label4.Text = count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM pullouthd";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        count = Convert.ToInt32(result);
                        label7.Text = count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
