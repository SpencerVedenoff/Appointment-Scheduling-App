namespace C969_Spencer_Vedenoff
{
    partial class LoginForm
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
            this.Username_Label = new System.Windows.Forms.Label();
            this.Password_Label = new System.Windows.Forms.Label();
            this.TimeZone_Label = new System.Windows.Forms.Label();
            this.Timezone = new System.Windows.Forms.Label();
            this.Username_Box = new System.Windows.Forms.TextBox();
            this.Password_Box = new System.Windows.Forms.TextBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.LoginTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Location = new System.Drawing.Point(64, 72);
            this.Username_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(55, 13);
            this.Username_Label.TabIndex = 0;
            this.Username_Label.Text = "Username";
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(66, 122);
            this.Password_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(53, 13);
            this.Password_Label.TabIndex = 2;
            this.Password_Label.Text = "Password";
            this.Password_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Password_Label.UseMnemonic = false;
            // 
            // TimeZone_Label
            // 
            this.TimeZone_Label.AutoSize = true;
            this.TimeZone_Label.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeZone_Label.Location = new System.Drawing.Point(97, 280);
            this.TimeZone_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeZone_Label.Name = "TimeZone_Label";
            this.TimeZone_Label.Size = new System.Drawing.Size(58, 15);
            this.TimeZone_Label.TabIndex = 4;
            this.TimeZone_Label.Text = "Timezone";
            // 
            // Timezone
            // 
            this.Timezone.AutoSize = true;
            this.Timezone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Timezone.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timezone.ForeColor = System.Drawing.Color.DarkGreen;
            this.Timezone.Location = new System.Drawing.Point(271, 278);
            this.Timezone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Timezone.Name = "Timezone";
            this.Timezone.Size = new System.Drawing.Size(48, 17);
            this.Timezone.TabIndex = 5;
            this.Timezone.Text = "Default";
            // 
            // Username_Box
            // 
            this.Username_Box.Location = new System.Drawing.Point(67, 87);
            this.Username_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(279, 20);
            this.Username_Box.TabIndex = 6;
            // 
            // Password_Box
            // 
            this.Password_Box.Location = new System.Drawing.Point(67, 137);
            this.Password_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.Size = new System.Drawing.Size(279, 20);
            this.Password_Box.TabIndex = 7;
            this.Password_Box.UseSystemPasswordChar = true;
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(67, 161);
            this.Login_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(118, 42);
            this.Login_Button.TabIndex = 8;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.Location = new System.Drawing.Point(230, 161);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(116, 42);
            this.Exit_Button.TabIndex = 9;
            this.Exit_Button.Text = "Exit";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginTitle
            // 
            this.LoginTitle.AutoSize = true;
            this.LoginTitle.Font = new System.Drawing.Font("Times New Roman", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginTitle.Location = new System.Drawing.Point(93, 28);
            this.LoginTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.Size = new System.Drawing.Size(214, 25);
            this.LoginTitle.TabIndex = 1;
            this.LoginTitle.Text = "Appointment Login:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 304);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Password_Box);
            this.Controls.Add(this.Username_Box);
            this.Controls.Add(this.Timezone);
            this.Controls.Add(this.TimeZone_Label);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.LoginTitle);
            this.Controls.Add(this.Username_Label);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.Label TimeZone_Label;
        private System.Windows.Forms.Label Timezone;
        private System.Windows.Forms.TextBox Username_Box;
        private System.Windows.Forms.TextBox Password_Box;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Label LoginTitle;
    }
}

