using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemWhse
{
    public partial class Dashboard: Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        //Constructor
        public Dashboard()
        {
            InitializeComponent();
            random = new Random();
        }

        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index) {
               index= random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }

        private void DisableButton() 
        {
            foreach (Control previousBtn in sidebar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(133, 193, 233);
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Inventory_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand) {
                sidebar.Width -= 10;
                if (sidebar.Width <= 42) {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            } else {
                sidebar.Width += 10;
                if(sidebar.Width >= 199) {
                   sidebarExpand = true;
                   sidebarTransition.Stop();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDashboard(), sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormInventory(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormOpening(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormReceiving(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPullout(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormHistory(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormReport(), sender);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {

        }
    }
}
