namespace AKUNTING
{
    partial class NettProfitreport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cbtahun = new System.Windows.Forms.ComboBox();
            this.cbbulan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbreportdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbtotgross = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gridaccounts = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txttax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtdepreciation = new System.Windows.Forms.TextBox();
            this.txtamortization = new System.Windows.Forms.TextBox();
            this.txtinterest = new System.Windows.Forms.TextBox();
            this.lbket = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbnetprofit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridaccounts)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 81);
            this.panel1.TabIndex = 20;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(104, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nett Profits Reports";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.cbtahun);
            this.panel2.Controls.Add(this.cbbulan);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbreportdate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 165);
            this.panel2.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(153, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 24);
            this.button1.TabIndex = 37;
            this.button1.Text = "Get Value Gross";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbtahun
            // 
            this.cbtahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtahun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtahun.FormattingEnabled = true;
            this.cbtahun.Location = new System.Drawing.Point(153, 72);
            this.cbtahun.Name = "cbtahun";
            this.cbtahun.Size = new System.Drawing.Size(121, 28);
            this.cbtahun.TabIndex = 28;
            // 
            // cbbulan
            // 
            this.cbbulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbulan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbulan.FormattingEnabled = true;
            this.cbbulan.Location = new System.Drawing.Point(153, 37);
            this.cbbulan.Name = "cbbulan";
            this.cbbulan.Size = new System.Drawing.Size(121, 28);
            this.cbbulan.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Year Profit :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Month Profit :";
            // 
            // lbreportdate
            // 
            this.lbreportdate.AutoSize = true;
            this.lbreportdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbreportdate.Location = new System.Drawing.Point(153, 12);
            this.lbreportdate.Name = "lbreportdate";
            this.lbreportdate.Size = new System.Drawing.Size(135, 20);
            this.lbreportdate.TabIndex = 23;
            this.lbreportdate.Text = "Tanggal Reports :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tanggal Reports :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lbtotgross);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(340, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 47);
            this.panel3.TabIndex = 30;
            // 
            // lbtotgross
            // 
            this.lbtotgross.AutoSize = true;
            this.lbtotgross.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotgross.Location = new System.Drawing.Point(108, 7);
            this.lbtotgross.Name = "lbtotgross";
            this.lbtotgross.Size = new System.Drawing.Size(18, 20);
            this.lbtotgross.TabIndex = 23;
            this.lbtotgross.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Total Gross :";
            // 
            // gridaccounts
            // 
            this.gridaccounts.AllowUserToAddRows = false;
            this.gridaccounts.AllowUserToDeleteRows = false;
            this.gridaccounts.BackgroundColor = System.Drawing.Color.White;
            this.gridaccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridaccounts.Location = new System.Drawing.Point(12, 258);
            this.gridaccounts.Name = "gridaccounts";
            this.gridaccounts.ReadOnly = true;
            this.gridaccounts.Size = new System.Drawing.Size(828, 195);
            this.gridaccounts.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.txttax);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.txtdepreciation);
            this.panel4.Controls.Add(this.txtamortization);
            this.panel4.Controls.Add(this.txtinterest);
            this.panel4.Controls.Add(this.lbket);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Location = new System.Drawing.Point(340, 140);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 112);
            this.panel4.TabIndex = 36;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Turquoise;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(377, 56);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 49);
            this.button4.TabIndex = 42;
            this.button4.Text = "Cetak Report";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Turquoise;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(253, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 24);
            this.button3.TabIndex = 41;
            this.button3.Text = "Update Nett Profits";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txttax
            // 
            this.txttax.Location = new System.Drawing.Point(136, 85);
            this.txttax.Name = "txttax";
            this.txttax.Size = new System.Drawing.Size(100, 20);
            this.txttax.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Tax :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Turquoise;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(253, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 24);
            this.button2.TabIndex = 38;
            this.button2.Text = "Kalkulasi Report";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtdepreciation
            // 
            this.txtdepreciation.Location = new System.Drawing.Point(136, 62);
            this.txtdepreciation.Name = "txtdepreciation";
            this.txtdepreciation.Size = new System.Drawing.Size(100, 20);
            this.txtdepreciation.TabIndex = 35;
            this.txtdepreciation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdepreciation_KeyPress);
            // 
            // txtamortization
            // 
            this.txtamortization.Location = new System.Drawing.Point(136, 38);
            this.txtamortization.Name = "txtamortization";
            this.txtamortization.Size = new System.Drawing.Size(100, 20);
            this.txtamortization.TabIndex = 34;
            this.txtamortization.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtamortization_KeyPress);
            // 
            // txtinterest
            // 
            this.txtinterest.Location = new System.Drawing.Point(136, 12);
            this.txtinterest.Name = "txtinterest";
            this.txtinterest.Size = new System.Drawing.Size(100, 20);
            this.txtinterest.TabIndex = 33;
            this.txtinterest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinterest_KeyPress);
            // 
            // lbket
            // 
            this.lbket.AutoSize = true;
            this.lbket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbket.Location = new System.Drawing.Point(344, 12);
            this.lbket.Name = "lbket";
            this.lbket.Size = new System.Drawing.Size(14, 20);
            this.lbket.TabIndex = 32;
            this.lbket.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(242, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 31;
            this.label11.Text = "Keterangan :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "Depreciation :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "Amortization :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(58, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 20);
            this.label14.TabIndex = 24;
            this.label14.Text = "Interest :";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.lbnetprofit);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(584, 87);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(256, 47);
            this.panel5.TabIndex = 31;
            // 
            // lbnetprofit
            // 
            this.lbnetprofit.AutoSize = true;
            this.lbnetprofit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnetprofit.Location = new System.Drawing.Point(136, 7);
            this.lbnetprofit.Name = "lbnetprofit";
            this.lbnetprofit.Size = new System.Drawing.Size(18, 20);
            this.lbnetprofit.TabIndex = 23;
            this.lbnetprofit.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Total Nett Profit :";
            // 
            // NettProfitreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(858, 465);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.gridaccounts);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NettProfitreport";
            this.Text = "Nett Profit Report";
            this.Load += new System.EventHandler(this.NettProfitreport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridaccounts)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbtahun;
        private System.Windows.Forms.ComboBox cbbulan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbreportdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbtotgross;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView gridaccounts;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtdepreciation;
        private System.Windows.Forms.TextBox txtamortization;
        private System.Windows.Forms.TextBox txtinterest;
        private System.Windows.Forms.Label lbket;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbnetprofit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}