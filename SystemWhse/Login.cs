using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemWhse
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private bool isValid()
        {
           if (txtUsername.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Enter Valid Username", "error");
                return false;

            } else if (txtPassword.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Enter Valid Password", "error");
                return false;
            }
            return true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           if (isValid())
           {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cedrick\source\repos\SystemWhse\SystemWhse\Database1.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM LOGIN WHERE username = '" + txtUsername.Text.Trim() + "'AND password = '" + txtPassword.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);
                    if (dta.Rows.Count == 1)
                    {
                        Dashboard dashboard = new Dashboard();
                        this.Hide();
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password", "Error");
                    }

                    if (checkBox1.Checked == true) 
                    {
                        Properties.Settings.Default.Username = txtUsername.Text.Trim();
                        Properties.Settings.Default.Password = txtPassword.Text.Trim();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Username = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Save();
                    }

                }
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
