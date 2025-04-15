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
    public partial class FormAddOpening : Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable table;
        private MySqlConnection connection;
        private string connStr;
        Dictionary<string, string> customerMap = new Dictionary<string, string>();
        public FormAddOpening()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
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

        private void FormAddOpening_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
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
                        comboBox1.Items.Add(new Warehouse
                        {
                            Code = reader.GetString("whsecode"),
                            Name = reader.GetString("whsename")
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

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT binno, binname FROM bin";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox3.Items.Add(new Warehouse
                        {
                            Code = reader.GetString("binno"),
                            Name = reader.GetString("binname")
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
                        comboBox2.Items.Add(new Warehouse
                        {
                            Code = reader.GetString("loccode"),
                            Name = reader.GetString("locname")
                        });
                    }

                    // Set draw mode to owner draw
                    comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
                    comboBox2.DrawItem += comboBox2_DrawItem;
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
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCode = comboBox4.SelectedItem.ToString();

            if (customerMap.ContainsKey(selectedCode))
            {
                textBox3.Text = customerMap[selectedCode]; // Display the customer name
            }
        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var warehouse = comboBox1.Items[e.Index] as Warehouse;
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

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var location = comboBox2.Items[e.Index] as Warehouse;
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

        private void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var bin = comboBox3.Items[e.Index] as Warehouse;
            if (bin != null)
            {
                string displayText = $"{bin.Code.PadRight(10)} {bin.Name}";

                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(displayText, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        public class bin
        {
            public string Code { get; set; }
            public string Name { get; set; }

            // What gets shown after selection
            public override string ToString()
            {
                return Code;
            }
        }
    }
}

