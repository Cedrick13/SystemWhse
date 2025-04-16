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
    public partial class FormReturn: Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable table;
        private MySqlConnection connection;
        private string connStr;
        public FormReturn()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox8.Enabled = false;
            textBox7.Enabled = false;
            textBox6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormReturn_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
