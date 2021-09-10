namespace MyBill
{
    partial class MDIParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.taxMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMaster});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuMaster
            // 
            this.mnuMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMnuCustomer,
            this.taxMasterToolStripMenuItem,
            this.mnuProductMaster,
            this.mnuInvoice});
            this.mnuMaster.Name = "mnuMaster";
            this.mnuMaster.Size = new System.Drawing.Size(55, 20);
            this.mnuMaster.Text = "Master";
            // 
            // toolStripMnuCustomer
            // 
            this.toolStripMnuCustomer.Name = "toolStripMnuCustomer";
            this.toolStripMnuCustomer.Size = new System.Drawing.Size(165, 22);
            this.toolStripMnuCustomer.Text = "Customer Master";
            this.toolStripMnuCustomer.Click += new System.EventHandler(this.toolStripMnuCustomer_Click);
            // 
            // mnuProductMaster
            // 
            this.mnuProductMaster.Name = "mnuProductMaster";
            this.mnuProductMaster.Size = new System.Drawing.Size(165, 22);
            this.mnuProductMaster.Text = "Product Mater";
            this.mnuProductMaster.Click += new System.EventHandler(this.mnuProductMaster_Click);
            // 
            // mnuInvoice
            // 
            this.mnuInvoice.Name = "mnuInvoice";
            this.mnuInvoice.Size = new System.Drawing.Size(165, 22);
            this.mnuInvoice.Text = "Invoice";
            this.mnuInvoice.Click += new System.EventHandler(this.mnuInvoice_Click);
            // 
            // taxMasterToolStripMenuItem
            // 
            this.taxMasterToolStripMenuItem.Name = "taxMasterToolStripMenuItem";
            this.taxMasterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.taxMasterToolStripMenuItem.Text = "Tax Master";
            this.taxMasterToolStripMenuItem.Click += new System.EventHandler(this.taxMasterToolStripMenuItem_Click);
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MDIParent";
            this.Text = "My Bill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuMaster;
        private System.Windows.Forms.ToolStripMenuItem mnuProductMaster;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoice;
        private System.Windows.Forms.ToolStripMenuItem taxMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMnuCustomer;
    }
}



