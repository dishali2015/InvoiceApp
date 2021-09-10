namespace MyBill
{
    partial class frmProductMaster
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSalesRate = new System.Windows.Forms.TextBox();
            this.txtPurchaseRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOpenBalance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbHSN = new System.Windows.Forms.ComboBox();
            this.cmbTax = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHSNCode = new System.Windows.Forms.Label();
            this.drpUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSalesRate);
            this.groupBox1.Controls.Add(this.txtPurchaseRate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtOpenBalance);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbHSN);
            this.groupBox1.Controls.Add(this.cmbTax);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblHSNCode);
            this.groupBox1.Controls.Add(this.drpUnit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPrDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPrCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Sales Rate";
            // 
            // txtSalesRate
            // 
            this.txtSalesRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesRate.Location = new System.Drawing.Point(154, 278);
            this.txtSalesRate.Name = "txtSalesRate";
            this.txtSalesRate.Size = new System.Drawing.Size(100, 23);
            this.txtSalesRate.TabIndex = 15;
            this.txtSalesRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalesRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesRate_KeyPress);
            // 
            // txtPurchaseRate
            // 
            this.txtPurchaseRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseRate.Location = new System.Drawing.Point(154, 241);
            this.txtPurchaseRate.Name = "txtPurchaseRate";
            this.txtPurchaseRate.Size = new System.Drawing.Size(100, 23);
            this.txtPurchaseRate.TabIndex = 14;
            this.txtPurchaseRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPurchaseRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseRate_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Purchase Rate";
            // 
            // txtOpenBalance
            // 
            this.txtOpenBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpenBalance.Location = new System.Drawing.Point(154, 205);
            this.txtOpenBalance.Name = "txtOpenBalance";
            this.txtOpenBalance.Size = new System.Drawing.Size(100, 23);
            this.txtOpenBalance.TabIndex = 12;
            this.txtOpenBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOpenBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpenBalance_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Opening Balance";
            // 
            // cmbHSN
            // 
            this.cmbHSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHSN.FormattingEnabled = true;
            this.cmbHSN.Location = new System.Drawing.Point(154, 133);
            this.cmbHSN.Name = "cmbHSN";
            this.cmbHSN.Size = new System.Drawing.Size(269, 24);
            this.cmbHSN.TabIndex = 10;
            // 
            // cmbTax
            // 
            this.cmbTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTax.FormattingEnabled = true;
            this.cmbTax.Location = new System.Drawing.Point(154, 170);
            this.cmbTax.Name = "cmbTax";
            this.cmbTax.Size = new System.Drawing.Size(269, 24);
            this.cmbTax.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tax";
            // 
            // lblHSNCode
            // 
            this.lblHSNCode.AutoSize = true;
            this.lblHSNCode.Location = new System.Drawing.Point(11, 139);
            this.lblHSNCode.Name = "lblHSNCode";
            this.lblHSNCode.Size = new System.Drawing.Size(106, 16);
            this.lblHSNCode.TabIndex = 6;
            this.lblHSNCode.Text = "HSN/SAC Code";
            // 
            // drpUnit
            // 
            this.drpUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpUnit.FormattingEnabled = true;
            this.drpUnit.Location = new System.Drawing.Point(154, 99);
            this.drpUnit.Name = "drpUnit";
            this.drpUnit.Size = new System.Drawing.Size(99, 24);
            this.drpUnit.TabIndex = 5;
            this.drpUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrCode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unit";
            // 
            // txtPrDesc
            // 
            this.txtPrDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrDesc.Location = new System.Drawing.Point(154, 64);
            this.txtPrDesc.MaxLength = 500;
            this.txtPrDesc.Name = "txtPrDesc";
            this.txtPrDesc.Size = new System.Drawing.Size(445, 23);
            this.txtPrDesc.TabIndex = 3;
            this.txtPrDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrCode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product Description";
            // 
            // txtPrCode
            // 
            this.txtPrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrCode.Location = new System.Drawing.Point(154, 23);
            this.txtPrCode.MaxLength = 50;
            this.txtPrCode.Name = "txtPrCode";
            this.txtPrCode.Size = new System.Drawing.Size(269, 23);
            this.txtPrCode.TabIndex = 1;
            this.txtPrCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrCode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Code";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(434, 316);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrCode_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(525, 315);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrCode_KeyPress);
            // 
            // frmProductMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(619, 358);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductMaster";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Creation";
            this.Load += new System.EventHandler(this.frmProductMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPrCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHSNCode;
        private System.Windows.Forms.ComboBox cmbTax;
        private System.Windows.Forms.ComboBox cmbHSN;
        private System.Windows.Forms.TextBox txtOpenBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSalesRate;
        private System.Windows.Forms.TextBox txtPurchaseRate;
        private System.Windows.Forms.Label label6;
    }
}