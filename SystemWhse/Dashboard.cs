using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemWhse.Forms;

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
            btnCloseChildForm.Visible = false;
          //this.Text = string.Empty;
          //this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

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
                    btnCloseChildForm.Visible = true;

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
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Open Login Form
                Login login = new Login();
                login.Show();

                // Close the current form
                this.Close();
            }
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
            //sidebarTransition.Start();
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
            //OpenChildForm(new Forms.FormInventory(), sender);
            contextMenuStrip1.Show(button2,button2.Width,1);
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

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if(activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            Navbar.BackColor = Color.FromArgb(218, 219, 221);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Navbar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReturn form2 = new FormReturn();

            // Disable Form1 while Form2 is open
            this.Enabled = false;

            // Show Form2 as modal
            form2.ShowDialog();

            // Re-enable Form1 after Form2 closes
            this.Enabled = true;

            // Bring Form1 back to front
            this.BringToFront();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTransfer form2 = new FormTransfer();

            // Disable Form1 while Form2 is open
            this.Enabled = false;

            // Show Form2 as modal
            form2.ShowDialog();

            // Re-enable Form1 after Form2 closes
            this.Enabled = true;

            // Bring Form1 back to front
            this.BringToFront();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Dashboard_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void transferOfStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTransferStock form2 = new FormTransferStock();

            // Disable Form1 while Form2 is open
            this.Enabled = false;

            // Show Form2 as modal
            form2.ShowDialog();

            // Re-enable Form1 after Form2 closes
            this.Enabled = true;

            // Bring Form1 back to front
            this.BringToFront();
        }

        private void wToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWarehouse form2 = new FormWarehouse();

            // Disable Form1 while Form2 is open
            this.Enabled = false;

            // Show Form2 as modal
            form2.ShowDialog();

            // Re-enable Form1 after Form2 closes
            this.Enabled = true;

            // Bring Form1 back to front
            this.BringToFront();
        }
    }
}
