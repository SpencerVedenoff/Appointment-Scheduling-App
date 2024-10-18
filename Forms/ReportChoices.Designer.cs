namespace C969_Spencer_Vedenoff
{
    partial class ReportChoices
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
            this.AppMonthBtn = new System.Windows.Forms.Button();
            this.UserScheduleBtn = new System.Windows.Forms.Button();
            this.App_Countries = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AppMonthBtn
            // 
            this.AppMonthBtn.Location = new System.Drawing.Point(9, 36);
            this.AppMonthBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AppMonthBtn.Name = "AppMonthBtn";
            this.AppMonthBtn.Size = new System.Drawing.Size(113, 62);
            this.AppMonthBtn.TabIndex = 0;
            this.AppMonthBtn.Text = "Apps/Month";
            this.AppMonthBtn.UseVisualStyleBackColor = true;
            this.AppMonthBtn.Click += new System.EventHandler(this.AppMonthBtn_Click);
            // 
            // UserScheduleBtn
            // 
            this.UserScheduleBtn.Location = new System.Drawing.Point(126, 36);
            this.UserScheduleBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UserScheduleBtn.Name = "UserScheduleBtn";
            this.UserScheduleBtn.Size = new System.Drawing.Size(112, 61);
            this.UserScheduleBtn.TabIndex = 1;
            this.UserScheduleBtn.Text = "User Schedules";
            this.UserScheduleBtn.UseVisualStyleBackColor = true;
            this.UserScheduleBtn.Click += new System.EventHandler(this.UserScheduleBtn_Click);
            // 
            // App_Countries
            // 
            this.App_Countries.Location = new System.Drawing.Point(242, 36);
            this.App_Countries.Margin = new System.Windows.Forms.Padding(2);
            this.App_Countries.Name = "App_Countries";
            this.App_Countries.Size = new System.Drawing.Size(113, 59);
            this.App_Countries.TabIndex = 2;
            this.App_Countries.Text = "App/Countries";
            this.App_Countries.UseVisualStyleBackColor = true;
            this.App_Countries.Click += new System.EventHandler(this.App_Countries_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Report Choices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 277);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(299, 99);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(56, 21);
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ReportChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 124);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.App_Countries);
            this.Controls.Add(this.UserScheduleBtn);
            this.Controls.Add(this.AppMonthBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReportChoices";
            this.Text = "Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AppMonthBtn;
        private System.Windows.Forms.Button UserScheduleBtn;
        private System.Windows.Forms.Button App_Countries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CloseBtn;
    }
}