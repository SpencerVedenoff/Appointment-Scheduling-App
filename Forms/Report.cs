using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Spencer_Vedenoff
{
    public partial class Report : Form
    {
        public Report(int choice)
        {
            InitializeComponent();
            LoadReportData(choice);
        }

        private void LoadReportData(int choice)
        {
            reportDataGrid.DataSource = DB.Report(choice);
        }

        public string Report_Name
        {
            get { return ReportName.Text; }
            set { ReportName.Text = value; }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseReport();
        }

        private void CloseReport()
        {
            this.Close();
        }
    }

}
