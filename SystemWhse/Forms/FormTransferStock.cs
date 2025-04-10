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
    public partial class FormTransferStock: Form
    {
        string connectionString = "server=192.168.1.230;user=Server;password=12345;database=tlcwms;";
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable table;
        private MySqlConnection connection;
        private string connStr;

        public FormTransferStock()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void FormTransferStock_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            //label1.Text = DateTime.Now.ToLongTimeString();

            //label2.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToLongTimeString();
            //timer1.Start();
        }
    }
}
