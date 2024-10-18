using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace C969_Spencer_Vedenoff
{
    public partial class ReportChoices : Form
    {
        public ReportChoices()
        {
            InitializeComponent();
        }

        private void ShowReport(int choice, string reportName)
        {
            Report report = new Report(choice)
            {
                Name = "Report",
                Report_Name = reportName
            };
            report.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            this.Close();
        }

        private void AppMonthBtn_Click(object sender, EventArgs e)
        {
            ShowReport(0, "Monthly Report");
        }

        private void UserScheduleBtn_Click(object sender, EventArgs e)
        {
            ShowReport(1, "User Schedules");
        }

        private void App_Countries_Click(object sender, EventArgs e)
        {
            ShowReport(2, "User Countries");
        }
    }
}
