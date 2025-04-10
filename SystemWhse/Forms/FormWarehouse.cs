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

namespace SystemWhse.Forms
{
    public partial class FormWarehouse: Form
    {
        public FormWarehouse()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void FormWarehouse_Load(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to back?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; // Exit without doing anything
            }

            // Proceed with cancel action
            this.Close(); // Close the form (if applicable)
        }
    }
}
