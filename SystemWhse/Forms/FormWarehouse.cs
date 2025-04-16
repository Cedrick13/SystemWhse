using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static SystemWhse.Forms.FormAddOpening;

namespace SystemWhse.Forms
{
    public partial class FormWarehouse: Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable table;
        private MySqlConnection connection;
        private string connStr;
        Dictionary<string, string> customerMap = new Dictionary<string, string>();
        public FormWarehouse()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            /*timer1.Start();
              label1.Text = DateTime.Now.ToLongTimeString();

              label2.Text = DateTime.Now.ToLongDateString();*/
        }

        private void LoadComboBoxData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT name FROM customer";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader.GetString("name"));
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
                    string query = "SELECT whsecode, whsename FROM warehouse";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox3.Items.Add(new Warehouse
                        {
                            Code = reader.GetString("whsecode"),
                            Name = reader.GetString("whsename")
                        });
                    }

                    // Set draw mode to owner draw
                    comboBox3.DrawMode = DrawMode.OwnerDrawFixed;
                    comboBox3.DrawItem += comboBox3_DrawItem;
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
                    string query = "SELECT loccode, locname FROM location";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(new Warehouse
                        {
                            Code = reader.GetString("loccode"),
                            Name = reader.GetString("locname")
                        });
                    }

                    // Set draw mode to owner draw
                    comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
                    comboBox1.DrawItem += comboBox1_DrawItem;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var warehouse = comboBox3.Items[e.Index] as Warehouse;
            if (warehouse != null)
            {
                string displayText = $"{warehouse.Code.PadRight(10)} {warehouse.Name}";

                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(displayText, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }
        public class Warehouse
        {
            public string Code { get; set; }
            public string Name { get; set; }

            // What gets shown after selection
            public override string ToString()
            {
                return Code;
            }
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var location = comboBox1.Items[e.Index] as Warehouse;
            if (location != null)
            {
                string displayText = $"{location.Code.PadRight(10)} {location.Name}";

                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(displayText, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        public class location
        {
            public string Code { get; set; }
            public string Name { get; set; }

            // What gets shown after selection
            public override string ToString()
            {
                return Code;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            /*label1.Text = DateTime.Now.ToLongTimeString();
              timer1.Start();*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to back?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; // Exit without doing anything
            }

            // Proceed with cancel action
            this.Close(); // Close the form (if applicable)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1,0, button1.Height);
        }
    }
}
