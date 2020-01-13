namespace AKUNTING
{
    partial class popupcostamount
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
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpopid = new System.Windows.Forms.TextBox();
            this.txtparentid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbjmlstock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(89, 81);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(243, 20);
            this.txtamount.TabIndex = 0;
            this.txtamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtamount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account ID";
            // 
            // txtpopid
            // 
            this.txtpopid.Location = new System.Drawing.Point(89, 49);
            this.txtpopid.Name = "txtpopid";
            this.txtpopid.ReadOnly = true;
            this.txtpopid.Size = new System.Drawing.Size(243, 20);
            this.txtpopid.TabIndex = 4;
            // 
            // txtparentid
            // 
            this.txtparentid.Location = new System.Drawing.Point(89, 23);
            this.txtparentid.Name = "txtparentid";
            this.txtparentid.ReadOnly = true;
            this.txtparentid.Size = new System.Drawing.Size(243, 20);
            this.txtparentid.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Paremt ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jumlah Stock :";
            // 
            // lbjmlstock
            // 
            this.lbjmlstock.AutoSize = true;
            this.lbjmlstock.Location = new System.Drawing.Point(169, 133);
            this.lbjmlstock.Name = "lbjmlstock";
            this.lbjmlstock.Size = new System.Drawing.Size(77, 13);
            this.lbjmlstock.TabIndex = 8;
            this.lbjmlstock.Text = "Jumlah Stock :";
            // 
            // popupcostamount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(366, 172);
            this.ControlBox = false;
            this.Controls.Add(this.lbjmlstock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtparentid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpopid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtamount);
            this.Name = "popupcostamount";
            this.Text = "popupcostamount";
            this.Load += new System.EventHandler(this.popupcostamount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpopid;
        private System.Windows.Forms.TextBox txtparentid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbjmlstock;
    }
}