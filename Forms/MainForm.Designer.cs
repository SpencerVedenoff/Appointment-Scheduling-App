namespace C969_Spencer_Vedenoff
{
    partial class MainForm
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
            this.MainFormLabel = new System.Windows.Forms.Label();
            this.OtherControls = new System.Windows.Forms.GroupBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ReportsButton = new System.Windows.Forms.Button();
            this.ApptGroupBox = new System.Windows.Forms.GroupBox();
            this.appDataGrid = new System.Windows.Forms.DataGridView();
            this.AddApp = new System.Windows.Forms.Button();
            this.UpdateApp = new System.Windows.Forms.Button();
            this.DeleteApp = new System.Windows.Forms.Button();
            this.ShowApps = new System.Windows.Forms.Button();
            this.DateSelect = new System.Windows.Forms.Button();
            this.mainMonthCal = new System.Windows.Forms.MonthCalendar();
            this.CustomersGroupBox = new System.Windows.Forms.GroupBox();
            this.customerDataGrid = new System.Windows.Forms.DataGridView();
            this.DeleteClient = new System.Windows.Forms.Button();
            this.UpdateClient = new System.Windows.Forms.Button();
            this.AddClient = new System.Windows.Forms.Button();
            this.OtherControls.SuspendLayout();
            this.ApptGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appDataGrid)).BeginInit();
            this.CustomersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainFormLabel
            // 
            this.MainFormLabel.AutoSize = true;
            this.MainFormLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainFormLabel.Location = new System.Drawing.Point(363, 7);
            this.MainFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MainFormLabel.Name = "MainFormLabel";
            this.MainFormLabel.Size = new System.Drawing.Size(82, 19);
            this.MainFormLabel.TabIndex = 0;
            this.MainFormLabel.Text = "Main Page";
            // 
            // OtherControls
            // 
            this.OtherControls.Controls.Add(this.LogoutButton);
            this.OtherControls.Controls.Add(this.ReportsButton);
            this.OtherControls.Location = new System.Drawing.Point(17, 471);
            this.OtherControls.Margin = new System.Windows.Forms.Padding(2);
            this.OtherControls.Name = "OtherControls";
            this.OtherControls.Padding = new System.Windows.Forms.Padding(2);
            this.OtherControls.Size = new System.Drawing.Size(232, 206);
            this.OtherControls.TabIndex = 4;
            this.OtherControls.TabStop = false;
            this.OtherControls.Text = "Other";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(34, 109);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(165, 43);
            this.LogoutButton.TabIndex = 7;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ReportsButton
            // 
            this.ReportsButton.Location = new System.Drawing.Point(34, 47);
            this.ReportsButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(165, 41);
            this.ReportsButton.TabIndex = 6;
            this.ReportsButton.Text = "Reports";
            this.ReportsButton.UseVisualStyleBackColor = true;
            this.ReportsButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // ApptGroupBox
            // 
            this.ApptGroupBox.Controls.Add(this.appDataGrid);
            this.ApptGroupBox.Controls.Add(this.AddApp);
            this.ApptGroupBox.Controls.Add(this.UpdateApp);
            this.ApptGroupBox.Controls.Add(this.DeleteApp);
            this.ApptGroupBox.Location = new System.Drawing.Point(13, 30);
            this.ApptGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.ApptGroupBox.Name = "ApptGroupBox";
            this.ApptGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.ApptGroupBox.Size = new System.Drawing.Size(901, 193);
            this.ApptGroupBox.TabIndex = 0;
            this.ApptGroupBox.TabStop = false;
            this.ApptGroupBox.Text = "Appointments";
            // 
            // appDataGrid
            // 
            this.appDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appDataGrid.Location = new System.Drawing.Point(0, 17);
            this.appDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.appDataGrid.Name = "appDataGrid";
            this.appDataGrid.RowHeadersWidth = 51;
            this.appDataGrid.RowTemplate.Height = 24;
            this.appDataGrid.Size = new System.Drawing.Size(877, 148);
            this.appDataGrid.TabIndex = 5;
            // 
            // AddApp
            // 
            this.AddApp.Location = new System.Drawing.Point(0, 170);
            this.AddApp.Margin = new System.Windows.Forms.Padding(2);
            this.AddApp.Name = "AddApp";
            this.AddApp.Size = new System.Drawing.Size(56, 24);
            this.AddApp.TabIndex = 0;
            this.AddApp.Text = "Add";
            this.AddApp.UseVisualStyleBackColor = true;
            this.AddApp.Click += new System.EventHandler(this.AddApp_Click);
            // 
            // UpdateApp
            // 
            this.UpdateApp.Location = new System.Drawing.Point(60, 170);
            this.UpdateApp.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateApp.Name = "UpdateApp";
            this.UpdateApp.Size = new System.Drawing.Size(56, 24);
            this.UpdateApp.TabIndex = 1;
            this.UpdateApp.Text = "Update";
            this.UpdateApp.UseVisualStyleBackColor = true;
            this.UpdateApp.Click += new System.EventHandler(this.UpdateApp_Click);
            // 
            // DeleteApp
            // 
            this.DeleteApp.Location = new System.Drawing.Point(120, 170);
            this.DeleteApp.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteApp.Name = "DeleteApp";
            this.DeleteApp.Size = new System.Drawing.Size(56, 24);
            this.DeleteApp.TabIndex = 2;
            this.DeleteApp.Text = "Delete";
            this.DeleteApp.UseVisualStyleBackColor = true;
            this.DeleteApp.Click += new System.EventHandler(this.DeleteApp_Click);
            // 
            // ShowApps
            // 
            this.ShowApps.Location = new System.Drawing.Point(673, 642);
            this.ShowApps.Margin = new System.Windows.Forms.Padding(2);
            this.ShowApps.Name = "ShowApps";
            this.ShowApps.Size = new System.Drawing.Size(96, 21);
            this.ShowApps.TabIndex = 7;
            this.ShowApps.Text = "Show All";
            this.ShowApps.UseVisualStyleBackColor = true;
            this.ShowApps.Click += new System.EventHandler(this.ShowApps_Click);
            // 
            // DateSelect
            // 
            this.DateSelect.Location = new System.Drawing.Point(794, 642);
            this.DateSelect.Margin = new System.Windows.Forms.Padding(2);
            this.DateSelect.Name = "DateSelect";
            this.DateSelect.Size = new System.Drawing.Size(96, 21);
            this.DateSelect.TabIndex = 6;
            this.DateSelect.Text = "Search for Date";
            this.DateSelect.UseVisualStyleBackColor = true;
            this.DateSelect.Click += new System.EventHandler(this.SelectDate_Click);
            // 
            // mainMonthCal
            // 
            this.mainMonthCal.Location = new System.Drawing.Point(673, 471);
            this.mainMonthCal.Margin = new System.Windows.Forms.Padding(7);
            this.mainMonthCal.Name = "mainMonthCal";
            this.mainMonthCal.TabIndex = 0;
            // 
            // CustomersGroupBox
            // 
            this.CustomersGroupBox.Controls.Add(this.customerDataGrid);
            this.CustomersGroupBox.Controls.Add(this.DeleteClient);
            this.CustomersGroupBox.Controls.Add(this.UpdateClient);
            this.CustomersGroupBox.Controls.Add(this.AddClient);
            this.CustomersGroupBox.Location = new System.Drawing.Point(13, 228);
            this.CustomersGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.CustomersGroupBox.Name = "CustomersGroupBox";
            this.CustomersGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.CustomersGroupBox.Size = new System.Drawing.Size(877, 206);
            this.CustomersGroupBox.TabIndex = 0;
            this.CustomersGroupBox.TabStop = false;
            this.CustomersGroupBox.Text = "Customers";
            // 
            // customerDataGrid
            // 
            this.customerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGrid.Location = new System.Drawing.Point(0, 17);
            this.customerDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.customerDataGrid.Name = "customerDataGrid";
            this.customerDataGrid.RowHeadersWidth = 51;
            this.customerDataGrid.RowTemplate.Height = 24;
            this.customerDataGrid.Size = new System.Drawing.Size(877, 160);
            this.customerDataGrid.TabIndex = 5;
            // 
            // DeleteClient
            // 
            this.DeleteClient.Location = new System.Drawing.Point(124, 182);
            this.DeleteClient.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteClient.Name = "DeleteClient";
            this.DeleteClient.Size = new System.Drawing.Size(56, 24);
            this.DeleteClient.TabIndex = 5;
            this.DeleteClient.Text = "Delete";
            this.DeleteClient.UseVisualStyleBackColor = true;
            this.DeleteClient.Click += new System.EventHandler(this.DeleteClient_Click);
            // 
            // UpdateClient
            // 
            this.UpdateClient.Location = new System.Drawing.Point(64, 182);
            this.UpdateClient.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateClient.Name = "UpdateClient";
            this.UpdateClient.Size = new System.Drawing.Size(56, 24);
            this.UpdateClient.TabIndex = 4;
            this.UpdateClient.Text = "Update";
            this.UpdateClient.UseVisualStyleBackColor = true;
            this.UpdateClient.Click += new System.EventHandler(this.UpdateClient_Click);
            // 
            // AddClient
            // 
            this.AddClient.Location = new System.Drawing.Point(4, 182);
            this.AddClient.Margin = new System.Windows.Forms.Padding(2);
            this.AddClient.Name = "AddClient";
            this.AddClient.Size = new System.Drawing.Size(56, 24);
            this.AddClient.TabIndex = 3;
            this.AddClient.Text = "Add";
            this.AddClient.UseVisualStyleBackColor = true;
            this.AddClient.Click += new System.EventHandler(this.AddClient_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 698);
            this.Controls.Add(this.ShowApps);
            this.Controls.Add(this.ApptGroupBox);
            this.Controls.Add(this.DateSelect);
            this.Controls.Add(this.CustomersGroupBox);
            this.Controls.Add(this.mainMonthCal);
            this.Controls.Add(this.OtherControls);
            this.Controls.Add(this.MainFormLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.OtherControls.ResumeLayout(false);
            this.ApptGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appDataGrid)).EndInit();
            this.CustomersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainFormLabel;
        private System.Windows.Forms.GroupBox OtherControls;
        private System.Windows.Forms.GroupBox ApptGroupBox;
        private System.Windows.Forms.GroupBox CustomersGroupBox;
        private System.Windows.Forms.Button AddApp;
        private System.Windows.Forms.Button UpdateApp;
        private System.Windows.Forms.Button DeleteApp;
        private System.Windows.Forms.Button DeleteClient;
        private System.Windows.Forms.Button UpdateClient;
        private System.Windows.Forms.Button AddClient;
        private System.Windows.Forms.DataGridView appDataGrid;
        private System.Windows.Forms.DataGridView customerDataGrid;
        private System.Windows.Forms.Button ReportsButton;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.MonthCalendar mainMonthCal;
        private System.Windows.Forms.Button DateSelect;
        private System.Windows.Forms.Button ShowApps;
    }
}