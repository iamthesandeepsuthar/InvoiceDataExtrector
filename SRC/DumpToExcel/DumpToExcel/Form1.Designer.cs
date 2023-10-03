
namespace DumpToExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnExtractData = new System.Windows.Forms.Button();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pincode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAssemblyVersion = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.txtFilePath = new System.Windows.Forms.Label();
            this.BtnExporttoExcel = new System.Windows.Forms.Button();
            this.BtnPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExtractData
            // 
            this.BtnExtractData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnExtractData.BackColor = System.Drawing.Color.White;
            this.BtnExtractData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnExtractData.BackgroundImage")));
            this.BtnExtractData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExtractData.Enabled = false;
            this.BtnExtractData.FlatAppearance.BorderSize = 0;
            this.BtnExtractData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExtractData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExtractData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(32)))), ((int)(((byte)(67)))));
            this.BtnExtractData.Location = new System.Drawing.Point(788, 28);
            this.BtnExtractData.Name = "BtnExtractData";
            this.BtnExtractData.Size = new System.Drawing.Size(107, 25);
            this.BtnExtractData.TabIndex = 0;
            this.BtnExtractData.UseVisualStyleBackColor = false;
            this.BtnExtractData.Click += new System.EventHandler(this.BtnExtractData_Click);
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.BackgroundColor = System.Drawing.Color.White;
            this.dgData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.Email,
            this.ContactNo,
            this.Pincode,
            this.CustomerAddress});
            this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgData.Location = new System.Drawing.Point(0, 0);
            this.dgData.Name = "dgData";
            this.dgData.ReadOnly = true;
            this.dgData.RowHeadersWidth = 51;
            this.dgData.Size = new System.Drawing.Size(907, 357);
            this.dgData.TabIndex = 1;
            this.dgData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgData_RowPostPaint);
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.MinimumWidth = 6;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 375;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Visible = false;
            this.Email.Width = 300;
            // 
            // ContactNo
            // 
            this.ContactNo.DataPropertyName = "ContactNo";
            this.ContactNo.HeaderText = "Contact No";
            this.ContactNo.MinimumWidth = 6;
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.ReadOnly = true;
            this.ContactNo.Width = 295;
            // 
            // Pincode
            // 
            this.Pincode.DataPropertyName = "Pincode";
            this.Pincode.HeaderText = "Pincode";
            this.Pincode.MinimumWidth = 6;
            this.Pincode.Name = "Pincode";
            this.Pincode.ReadOnly = true;
            this.Pincode.Width = 225;
            // 
            // CustomerAddress
            // 
            this.CustomerAddress.DataPropertyName = "CustomerAddress";
            this.CustomerAddress.HeaderText = "Customer Address";
            this.CustomerAddress.MinimumWidth = 6;
            this.CustomerAddress.Name = "CustomerAddress";
            this.CustomerAddress.ReadOnly = true;
            this.CustomerAddress.Width = 375;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select PDF file path:";
            // 
            // BtnReset
            // 
            this.BtnReset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnReset.BackColor = System.Drawing.Color.White;
            this.BtnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnReset.BackgroundImage")));
            this.BtnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReset.FlatAppearance.BorderSize = 0;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.BtnReset.Location = new System.Drawing.Point(667, 14);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(107, 23);
            this.BtnReset.TabIndex = 6;
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.pnlTop.Controls.Add(this.BtnPdf);
            this.pnlTop.Controls.Add(this.txtFilePath);
            this.pnlTop.Controls.Add(this.BtnExtractData);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(907, 82);
            this.pnlTop.TabIndex = 8;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.BtnExporttoExcel);
            this.pnlBottom.Controls.Add(this.label2);
            this.pnlBottom.Controls.Add(this.lblAssemblyVersion);
            this.pnlBottom.Controls.Add(this.BtnReset);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 439);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(907, 50);
            this.pnlBottom.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(28, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Powered by Storeone";
            // 
            // lblAssemblyVersion
            // 
            this.lblAssemblyVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAssemblyVersion.AutoSize = true;
            this.lblAssemblyVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssemblyVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAssemblyVersion.Location = new System.Drawing.Point(31, 24);
            this.lblAssemblyVersion.Name = "lblAssemblyVersion";
            this.lblAssemblyVersion.Size = new System.Drawing.Size(0, 13);
            this.lblAssemblyVersion.TabIndex = 7;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pbLoading);
            this.pnlMiddle.Controls.Add(this.dgData);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 82);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(907, 357);
            this.pnlMiddle.TabIndex = 10;
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.BackColor = System.Drawing.Color.White;
            this.pbLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbLoading.Image")));
            this.pbLoading.Location = new System.Drawing.Point(372, 88);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(200, 200);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLoading.TabIndex = 2;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // txtFilePath
            // 
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtFilePath.Location = new System.Drawing.Point(162, 29);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(482, 24);
            this.txtFilePath.TabIndex = 7;
            this.txtFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnExporttoExcel
            // 
            this.BtnExporttoExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnExporttoExcel.BackColor = System.Drawing.Color.White;
            this.BtnExporttoExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnExporttoExcel.BackgroundImage")));
            this.BtnExporttoExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExporttoExcel.FlatAppearance.BorderSize = 0;
            this.BtnExporttoExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExporttoExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExporttoExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.BtnExporttoExcel.Location = new System.Drawing.Point(781, 14);
            this.BtnExporttoExcel.Name = "BtnExporttoExcel";
            this.BtnExporttoExcel.Size = new System.Drawing.Size(107, 23);
            this.BtnExporttoExcel.TabIndex = 9;
            this.BtnExporttoExcel.UseVisualStyleBackColor = false;
            this.BtnExporttoExcel.Click += new System.EventHandler(this.BtnExporttoExcel_Click);
            // 
            // BtnPdf
            // 
            this.BtnPdf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPdf.BackgroundImage")));
            this.BtnPdf.FlatAppearance.BorderSize = 0;
            this.BtnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPdf.Location = new System.Drawing.Point(661, 28);
            this.BtnPdf.Name = "BtnPdf";
            this.BtnPdf.Size = new System.Drawing.Size(120, 26);
            this.BtnPdf.TabIndex = 8;
            this.BtnPdf.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnPdf.UseVisualStyleBackColor = true;
            this.BtnPdf.Click += new System.EventHandler(this.BtnPdf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(907, 489);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExtractData;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label lblAssemblyVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pincode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddress;
        private System.Windows.Forms.Label txtFilePath;
        private System.Windows.Forms.Button BtnExporttoExcel;
        private System.Windows.Forms.Button BtnPdf;
    }
}

