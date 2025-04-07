namespace SystemWhse.Forms
{
    partial class FormPullout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPullout));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnlast = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnprev = new System.Windows.Forms.Button();
            this.btnfirst = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(616, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(614, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Time";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.comboBox1.Location = new System.Drawing.Point(64, 492);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(45, 21);
            this.comboBox1.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(9, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 66;
            this.label3.Text = "Showing";
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(536, 49);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(51, 16);
            this.Label6.TabIndex = 64;
            this.Label6.Text = "Search :";
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Location = new System.Drawing.Point(590, 48);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(198, 20);
            this.txtsearch.TabIndex = 63;
            // 
            // btnlast
            // 
            this.btnlast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlast.BackColor = System.Drawing.Color.Transparent;
            this.btnlast.ForeColor = System.Drawing.Color.Black;
            this.btnlast.Location = new System.Drawing.Point(757, 489);
            this.btnlast.Name = "btnlast";
            this.btnlast.Size = new System.Drawing.Size(31, 29);
            this.btnlast.TabIndex = 59;
            this.btnlast.Text = ">>";
            this.btnlast.UseVisualStyleBackColor = false;
            // 
            // btnnext
            // 
            this.btnnext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnnext.BackColor = System.Drawing.Color.Transparent;
            this.btnnext.ForeColor = System.Drawing.Color.Black;
            this.btnnext.Location = new System.Drawing.Point(722, 489);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(31, 29);
            this.btnnext.TabIndex = 60;
            this.btnnext.Text = ">";
            this.btnnext.UseVisualStyleBackColor = false;
            // 
            // btnprev
            // 
            this.btnprev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprev.BackColor = System.Drawing.Color.Transparent;
            this.btnprev.ForeColor = System.Drawing.Color.Black;
            this.btnprev.Location = new System.Drawing.Point(687, 489);
            this.btnprev.Name = "btnprev";
            this.btnprev.Size = new System.Drawing.Size(31, 29);
            this.btnprev.TabIndex = 61;
            this.btnprev.Text = "<";
            this.btnprev.UseVisualStyleBackColor = false;
            // 
            // btnfirst
            // 
            this.btnfirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnfirst.BackColor = System.Drawing.Color.Transparent;
            this.btnfirst.ForeColor = System.Drawing.Color.Black;
            this.btnfirst.Location = new System.Drawing.Point(652, 489);
            this.btnfirst.Name = "btnfirst";
            this.btnfirst.Size = new System.Drawing.Size(31, 29);
            this.btnfirst.TabIndex = 62;
            this.btnfirst.Text = "<<";
            this.btnfirst.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 396);
            this.dataGridView1.TabIndex = 57;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(221)))));
            this.label11.Location = new System.Drawing.Point(300, 539);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 13);
            this.label11.TabIndex = 83;
            this.label11.Text = "© 2025 timecargo.ph All rights reserved.";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(221)))));
            this.panel5.Location = new System.Drawing.Point(0, 534);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(799, 24);
            this.panel5.TabIndex = 84;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(197)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(11, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 31);
            this.button1.TabIndex = 85;
            this.button1.Text = "       Create a new PullOut";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(434, 495);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 16);
            this.label7.TabIndex = 88;
            this.label7.Text = "1";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(394, 495);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 16);
            this.label5.TabIndex = 87;
            this.label5.Text = "1";
            // 
            // Label9
            // 
            this.Label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label9.Location = new System.Drawing.Point(335, 495);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(128, 16);
            this.Label9.TabIndex = 86;
            this.Label9.Text = "Showing          to           ";
            // 
            // FormPullout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(800, 558);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.btnlast);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.btnprev);
            this.Controls.Add(this.btnfirst);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "FormPullout";
            this.Text = "Pullout";
            this.Load += new System.EventHandler(this.FormPullout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtsearch;
        internal System.Windows.Forms.Button btnlast;
        internal System.Windows.Forms.Button btnnext;
        internal System.Windows.Forms.Button btnprev;
        internal System.Windows.Forms.Button btnfirst;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label Label9;
    }
}