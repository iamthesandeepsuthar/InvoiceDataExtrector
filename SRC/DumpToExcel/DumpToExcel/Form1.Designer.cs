
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
            this.BtnExtractData = new System.Windows.Forms.Button();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.BtnExporttoExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.BtnPdf = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExtractData
            // 
            this.BtnExtractData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExtractData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExtractData.Location = new System.Drawing.Point(671, 19);
            this.BtnExtractData.Name = "BtnExtractData";
            this.BtnExtractData.Size = new System.Drawing.Size(107, 23);
            this.BtnExtractData.TabIndex = 0;
            this.BtnExtractData.Text = "Extract Data";
            this.BtnExtractData.UseVisualStyleBackColor = true;
            this.BtnExtractData.Click += new System.EventHandler(this.BtnExtractData_Click);
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Location = new System.Drawing.Point(30, 73);
            this.dgData.Name = "dgData";
            this.dgData.ReadOnly = true;
            this.dgData.Size = new System.Drawing.Size(748, 277);
            this.dgData.TabIndex = 1;
            this.dgData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgData_RowPostPaint);
            // 
            // BtnExporttoExcel
            // 
            this.BtnExporttoExcel.Enabled = false;
            this.BtnExporttoExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExporttoExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExporttoExcel.Location = new System.Drawing.Point(671, 360);
            this.BtnExporttoExcel.Name = "BtnExporttoExcel";
            this.BtnExporttoExcel.Size = new System.Drawing.Size(107, 23);
            this.BtnExporttoExcel.TabIndex = 2;
            this.BtnExporttoExcel.Text = "Export to Excel";
            this.BtnExporttoExcel.UseVisualStyleBackColor = true;
            this.BtnExporttoExcel.Click += new System.EventHandler(this.BtnExporttoExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select PDF file path:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(158, 21);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(369, 20);
            this.txtFilePath.TabIndex = 4;
            // 
            // BtnPdf
            // 
            this.BtnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPdf.Location = new System.Drawing.Point(542, 19);
            this.BtnPdf.Name = "BtnPdf";
            this.BtnPdf.Size = new System.Drawing.Size(123, 23);
            this.BtnPdf.TabIndex = 5;
            this.BtnPdf.Text = "PDF File Path";
            this.BtnPdf.UseVisualStyleBackColor = true;
            this.BtnPdf.Click += new System.EventHandler(this.BtnPdf_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.Location = new System.Drawing.Point(542, 360);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(123, 23);
            this.BtnReset.TabIndex = 6;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 397);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.BtnPdf);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnExporttoExcel);
            this.Controls.Add(this.dgData);
            this.Controls.Add(this.BtnExtractData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF to Excel data extraction";
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExtractData;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.Button BtnExporttoExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button BtnPdf;
        private System.Windows.Forms.Button BtnReset;
    }
}

