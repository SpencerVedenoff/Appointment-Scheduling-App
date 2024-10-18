using Google.Protobuf.WellKnownTypes;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace C969_Spencer_Vedenoff
{
    public partial class LoginForm : Form
    {
        private string language;
        BindingList<User> users;
        public LoginForm()
        {
            users = DB.GetUsers();
            InitializeComponent();
            this.CenterToScreen();
            this.AcceptButton = Login_Button;
            LocalTimezone = TimeZone.CurrentTimeZone.StandardName;
            string ru = "Russia TZ 2 Standard Time";
            if (Timezone.Text == ru) ChangeLanguage();

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string targetUsername = Username_Box.Text.Trim();
            string targetPassword = Password_Box.Text.Trim();
            DB.loggedIn = true;
            DB.UserLoggedIn();

            // Lambda Expression per Rubric
            User foundUser = users.FirstOrDefault(u => u.username == targetUsername);

            try
            {
                if (foundUser != null)
                {
                    if (foundUser.password == targetPassword)
                    {
                        UserLog();
                        DB.currentUser = targetUsername;
                        MainForm mainForm = new MainForm();
                        this.Dispose();

                        // Warn about appointments within the next 15 minutes
                        DateTime warningTime = DateTime.Now.AddMinutes(15);
                        foreach (App apt in mainForm.allAppointments.Where(apt => apt.start <= warningTime && apt.start >= DateTime.Now))
                        {
                            MessageBox.Show($"Appointment of ID #{apt.appointmentId} will start in 15 Minutes");
                        }

                        mainForm.ShowDialog();
                    }
                    else
                    {
                        ShowMessage("Incorrect password", "Неправильный пароль");
                    }
                }
                else
                {
                    ShowMessage("Incorrect username", "Неправильное имя пользователя");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowMessage(string defaultMessage, string russianMessage)
        {
            MessageBox.Show(Timezone.Text != "Russia TZ 2 Standard Time" ? defaultMessage : russianMessage);
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Change Language
        private void ChangeLanguage()
        {
            LoginTitle.Text = "Страница входа";
            Username_Label.Text = "Имя пользователя";
            Password_Label.Text = "Пароль";
            Login_Button.Text = "Войти";
            Exit_Button.Text = "Выйти";
            this.Text = "Вход здесь";
        }

        public string LocalTimezone
        {
            get => Timezone.Text;
            set => Timezone.Text = value;
        }


        private void UserLog()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Login_History.txt");
            string loginDetails = $"{DateTime.UtcNow}: User \"{Username_Box.Text}\" logged in successfully{Environment.NewLine}";

            // Use File.AppendAllText for both existing and non-existing files, as it handles both cases
            File.AppendAllText(filePath, loginDetails);
        }

    }
}
