namespace AKUNTING
{
    partial class operationalcostreport
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
            this.dgreport = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbtotop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbtotstocks = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbtotcash = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbselisih = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbreportdate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbreportprint = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbket = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbulan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbtahun = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgreport)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgreport
            // 
            this.dgreport.AllowUserToAddRows = false;
            this.dgreport.AllowUserToDeleteRows = false;
            this.dgreport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgreport.BackgroundColor = System.Drawing.Color.White;
            this.dgreport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgreport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgreport.Location = new System.Drawing.Point(3, 16);
            this.dgreport.Name = "dgreport";
            this.dgreport.ReadOnly = true;
            this.dgreport.Size = new System.Drawing.Size(754, 253);
            this.dgreport.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Operasional :";
            // 
            // lbtotop
            // 
            this.lbtotop.AutoSize = true;
            this.lbtotop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotop.Location = new System.Drawing.Point(163, 18);
            this.lbtotop.Name = "lbtotop";
            this.lbtotop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbtotop.Size = new System.Drawing.Size(14, 20);
            this.lbtotop.TabIndex = 4;
            this.lbtotop.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total Stocks :";
            // 
            // lbtotstocks
            // 
            this.lbtotstocks.AutoSize = true;
            this.lbtotstocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotstocks.Location = new System.Drawing.Point(163, 58);
            this.lbtotstocks.Name = "lbtotstocks";
            this.lbtotstocks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbtotstocks.Size = new System.Drawing.Size(14, 20);
            this.lbtotstocks.TabIndex = 6;
            this.lbtotstocks.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Cash :";
            // 
            // lbtotcash
            // 
            this.lbtotcash.AutoSize = true;
            this.lbtotcash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotcash.Location = new System.Drawing.Point(163, 38);
            this.lbtotcash.Name = "lbtotcash";
            this.lbtotcash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbtotcash.Size = new System.Drawing.Size(14, 20);
            this.lbtotcash.TabIndex = 8;
            this.lbtotcash.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbtotcash);
            this.panel1.Controls.Add(this.lbtotstocks);
            this.panel1.Controls.Add(this.lbtotop);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(483, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 100);
            this.panel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgreport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 272);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(271, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sisa Stocks (Stocks - Operasional) = ";
            // 
            // lbselisih
            // 
            this.lbselisih.AutoSize = true;
            this.lbselisih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbselisih.Location = new System.Drawing.Point(281, 6);
            this.lbselisih.Name = "lbselisih";
            this.lbselisih.Size = new System.Drawing.Size(14, 20);
            this.lbselisih.TabIndex = 9;
            this.lbselisih.Text = "-";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lbselisih);
            this.panel2.Location = new System.Drawing.Point(12, 194);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 40);
            this.panel2.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(143, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Report Date :";
            // 
            // lbreportdate
            // 
            this.lbreportdate.AutoSize = true;
            this.lbreportdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbreportdate.Location = new System.Drawing.Point(126, 31);
            this.lbreportdate.Name = "lbreportdate";
            this.lbreportdate.Size = new System.Drawing.Size(14, 20);
            this.lbreportdate.TabIndex = 9;
            this.lbreportdate.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Print Report :";
            // 
            // lbreportprint
            // 
            this.lbreportprint.AutoSize = true;
            this.lbreportprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbreportprint.Location = new System.Drawing.Point(123, 11);
            this.lbreportprint.Name = "lbreportprint";
            this.lbreportprint.Size = new System.Drawing.Size(14, 20);
            this.lbreportprint.TabIndex = 15;
            this.lbreportprint.Text = "-";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lbreportprint);
            this.panel3.Controls.Add(this.lbreportdate);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(483, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 67);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lbket);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(12, 240);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(398, 40);
            this.panel4.TabIndex = 13;
            // 
            // lbket
            // 
            this.lbket.AutoSize = true;
            this.lbket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbket.Location = new System.Drawing.Point(115, 6);
            this.lbket.Name = "lbket";
            this.lbket.Size = new System.Drawing.Size(14, 20);
            this.lbket.TabIndex = 10;
            this.lbket.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Keterangan =";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(224, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(760, 81);
            this.panel5.TabIndex = 19;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(104, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Operational Costs Report";
            // 
            // cbbulan
            // 
            this.cbbulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbulan.FormattingEnabled = true;
            this.cbbulan.Location = new System.Drawing.Point(62, 101);
            this.cbbulan.Name = "cbbulan";
            this.cbbulan.Size = new System.Drawing.Size(121, 21);
            this.cbbulan.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Bulan";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tahun";
            // 
            // cbtahun
            // 
            this.cbtahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtahun.FormattingEnabled = true;
            this.cbtahun.Location = new System.Drawing.Point(62, 128);
            this.cbtahun.Name = "cbtahun";
            this.cbtahun.Size = new System.Drawing.Size(121, 21);
            this.cbtahun.TabIndex = 22;
            // 
            // operationalcostreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 558);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbtahun);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbbulan);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "operationalcostreport";
            this.Text = "Operational Cost Report";
            this.Load += new System.EventHandler(this.operationalcostreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgreport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgreport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbtotop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbtotstocks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbtotcash;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbselisih;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbreportdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbreportprint;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbket;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button button3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbulan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbtahun;
    }
}