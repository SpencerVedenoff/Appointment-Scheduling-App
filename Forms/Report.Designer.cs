namespace C969_Spencer_Vedenoff
{
    partial class Report
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
            this.reportDataGrid = new System.Windows.Forms.DataGridView();
            this.ReportName = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // reportDataGrid
            // 
            this.reportDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportDataGrid.Location = new System.Drawing.Point(47, 46);
            this.reportDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.reportDataGrid.Name = "reportDataGrid";
            this.reportDataGrid.RowHeadersWidth = 51;
            this.reportDataGrid.RowTemplate.Height = 24;
            this.reportDataGrid.Size = new System.Drawing.Size(309, 180);
            this.reportDataGrid.TabIndex = 0;
            // 
            // ReportName
            // 
            this.ReportName.AutoSize = true;
            this.ReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportName.Location = new System.Drawing.Point(43, 22);
            this.ReportName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ReportName.Name = "ReportName";
            this.ReportName.Size = new System.Drawing.Size(115, 20);
            this.ReportName.TabIndex = 1;
            this.ReportName.Text = "Report Name";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(300, 23);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(56, 19);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 237);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ReportName);
            this.Controls.Add(this.reportDataGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Report";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView reportDataGrid;
        private System.Windows.Forms.Label ReportName;
        private System.Windows.Forms.Button CloseButton;
    }
}