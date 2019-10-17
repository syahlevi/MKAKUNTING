namespace AKUNTING
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cekKoneksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debtsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.earningsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.assetsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.profitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grossProfitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.netProfitsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationalCostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grossProfitsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nettProfitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoppingRetainedEarningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbaddress = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbnamecompany = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.rekeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.IndianRed;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cekKoneksiToolStripMenuItem});
            this.databaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // cekKoneksiToolStripMenuItem
            // 
            this.cekKoneksiToolStripMenuItem.Name = "cekKoneksiToolStripMenuItem";
            this.cekKoneksiToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.cekKoneksiToolStripMenuItem.Text = "Cek Koneksi";
            this.cekKoneksiToolStripMenuItem.Click += new System.EventHandler(this.cekKoneksiToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem,
            this.profitsToolStripMenuItem});
            this.masterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(70, 25);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.costToolStripMenuItem,
            this.stocksToolStripMenuItem,
            this.debtsToolStripMenuItem1,
            this.earningsToolStripMenuItem1,
            this.assetsToolStripMenuItem1});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.accountsToolStripMenuItem.Text = "Accounts";
            this.accountsToolStripMenuItem.Click += new System.EventHandler(this.accountsToolStripMenuItem_Click);
            // 
            // costToolStripMenuItem
            // 
            this.costToolStripMenuItem.Name = "costToolStripMenuItem";
            this.costToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.costToolStripMenuItem.Text = "Cost";
            this.costToolStripMenuItem.Click += new System.EventHandler(this.costToolStripMenuItem_Click);
            // 
            // stocksToolStripMenuItem
            // 
            this.stocksToolStripMenuItem.Name = "stocksToolStripMenuItem";
            this.stocksToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.stocksToolStripMenuItem.Text = "Stocks";
            this.stocksToolStripMenuItem.Click += new System.EventHandler(this.stocksToolStripMenuItem_Click);
            // 
            // debtsToolStripMenuItem1
            // 
            this.debtsToolStripMenuItem1.Name = "debtsToolStripMenuItem1";
            this.debtsToolStripMenuItem1.Size = new System.Drawing.Size(140, 26);
            this.debtsToolStripMenuItem1.Text = "Debts";
            this.debtsToolStripMenuItem1.Click += new System.EventHandler(this.debtsToolStripMenuItem1_Click);
            // 
            // earningsToolStripMenuItem1
            // 
            this.earningsToolStripMenuItem1.Name = "earningsToolStripMenuItem1";
            this.earningsToolStripMenuItem1.Size = new System.Drawing.Size(140, 26);
            this.earningsToolStripMenuItem1.Text = "Earnings";
            this.earningsToolStripMenuItem1.Click += new System.EventHandler(this.earningsToolStripMenuItem1_Click);
            // 
            // assetsToolStripMenuItem1
            // 
            this.assetsToolStripMenuItem1.Name = "assetsToolStripMenuItem1";
            this.assetsToolStripMenuItem1.Size = new System.Drawing.Size(140, 26);
            this.assetsToolStripMenuItem1.Text = "Assets";
            this.assetsToolStripMenuItem1.Click += new System.EventHandler(this.assetsToolStripMenuItem1_Click);
            // 
            // profitsToolStripMenuItem
            // 
            this.profitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grossProfitsToolStripMenuItem,
            this.netProfitsToolStripMenuItem1});
            this.profitsToolStripMenuItem.Name = "profitsToolStripMenuItem";
            this.profitsToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.profitsToolStripMenuItem.Text = "Profits";
            // 
            // grossProfitsToolStripMenuItem
            // 
            this.grossProfitsToolStripMenuItem.Name = "grossProfitsToolStripMenuItem";
            this.grossProfitsToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.grossProfitsToolStripMenuItem.Text = "Gross Profits";
            this.grossProfitsToolStripMenuItem.Click += new System.EventHandler(this.grossProfitsToolStripMenuItem_Click);
            // 
            // netProfitsToolStripMenuItem1
            // 
            this.netProfitsToolStripMenuItem1.Name = "netProfitsToolStripMenuItem1";
            this.netProfitsToolStripMenuItem1.Size = new System.Drawing.Size(169, 26);
            this.netProfitsToolStripMenuItem1.Text = "Net Profits";
            this.netProfitsToolStripMenuItem1.Click += new System.EventHandler(this.netProfitsToolStripMenuItem1_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationalCostToolStripMenuItem,
            this.grossProfitsToolStripMenuItem1,
            this.nettProfitsToolStripMenuItem,
            this.stoppingRetainedEarningsToolStripMenuItem});
            this.reportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(69, 25);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // operationalCostToolStripMenuItem
            // 
            this.operationalCostToolStripMenuItem.Name = "operationalCostToolStripMenuItem";
            this.operationalCostToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.operationalCostToolStripMenuItem.Text = "Operational Cost";
            this.operationalCostToolStripMenuItem.Click += new System.EventHandler(this.operationalCostToolStripMenuItem_Click);
            // 
            // grossProfitsToolStripMenuItem1
            // 
            this.grossProfitsToolStripMenuItem1.Name = "grossProfitsToolStripMenuItem1";
            this.grossProfitsToolStripMenuItem1.Size = new System.Drawing.Size(272, 26);
            this.grossProfitsToolStripMenuItem1.Text = "Gross Profits";
            this.grossProfitsToolStripMenuItem1.Click += new System.EventHandler(this.grossProfitsToolStripMenuItem1_Click);
            // 
            // nettProfitsToolStripMenuItem
            // 
            this.nettProfitsToolStripMenuItem.Name = "nettProfitsToolStripMenuItem";
            this.nettProfitsToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.nettProfitsToolStripMenuItem.Text = "Nett Profits";
            this.nettProfitsToolStripMenuItem.Click += new System.EventHandler(this.nettProfitsToolStripMenuItem_Click);
            // 
            // stoppingRetainedEarningsToolStripMenuItem
            // 
            this.stoppingRetainedEarningsToolStripMenuItem.Name = "stoppingRetainedEarningsToolStripMenuItem";
            this.stoppingRetainedEarningsToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.stoppingRetainedEarningsToolStripMenuItem.Text = "Stopping Retained Earnings";
            this.stoppingRetainedEarningsToolStripMenuItem.Click += new System.EventHandler(this.stoppingRetainedEarningsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.rekeningToolStripMenuItem});
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.aboutToolStripMenuItem.Text = "About ";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.companyToolStripMenuItem.Text = "Company";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.companyToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.lbaddress);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbnamecompany);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 81);
            this.panel1.TabIndex = 2;
            // 
            // lbaddress
            // 
            this.lbaddress.AutoSize = true;
            this.lbaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbaddress.ForeColor = System.Drawing.Color.White;
            this.lbaddress.Location = new System.Drawing.Point(104, 36);
            this.lbaddress.Name = "lbaddress";
            this.lbaddress.Size = new System.Drawing.Size(182, 24);
            this.lbaddress.TabIndex = 2;
            this.lbaddress.Text = "Accountant Software";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AKUNTING.Properties.Resources.ACCOUNTANT_512;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbnamecompany
            // 
            this.lbnamecompany.AutoSize = true;
            this.lbnamecompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnamecompany.ForeColor = System.Drawing.Color.White;
            this.lbnamecompany.Location = new System.Drawing.Point(104, 12);
            this.lbnamecompany.Name = "lbnamecompany";
            this.lbnamecompany.Size = new System.Drawing.Size(182, 24);
            this.lbnamecompany.TabIndex = 0;
            this.lbnamecompany.Text = "Accountant Software";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 110);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(680, 28);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButton1.Image = global::AKUNTING.Properties.Resources.ACCOUNTANT_512;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(93, 25);
            this.toolStripButton1.Text = "Accounts";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // rekeningToolStripMenuItem
            // 
            this.rekeningToolStripMenuItem.Name = "rekeningToolStripMenuItem";
            this.rekeningToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.rekeningToolStripMenuItem.Text = "Rekening";
            this.rekeningToolStripMenuItem.Click += new System.EventHandler(this.rekeningToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AKUNTING.Properties.Resources.picture_id831121290;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(680, 311);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Aplikasi Akutansi Versi 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cekKoneksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationalCostToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbnamecompany;
        private System.Windows.Forms.ToolStripMenuItem costToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debtsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem earningsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem assetsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem profitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grossProfitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem netProfitsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem grossProfitsToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem nettProfitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stoppingRetainedEarningsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.Label lbaddress;
        private System.Windows.Forms.ToolStripMenuItem rekeningToolStripMenuItem;
    }
}

