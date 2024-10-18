using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Spencer_Vedenoff
{
    public partial class AppForm : Form
    {
        private int GetDay(int selectedDay)
        {
            DateTime currDate = DateTime.Now;
            DayOfWeek currentDayOfWeek = currDate.DayOfWeek;
            int today = currDate.Day;
            int daysToAdd;

            if ((DayOfWeek)selectedDay > currentDayOfWeek)
            {
                daysToAdd = selectedDay - (int)currentDayOfWeek;
            }
            else
            {
                daysToAdd = 7 - (int)currentDayOfWeek + selectedDay;
            }

            return today + daysToAdd;
        }

        public AppForm()
        {
            InitializeComponent();

            // Set appointment ID
            ID_textbox.Text = DB.NextIndex("appointmentId", "appointment").ToString();

            // Initialize Contact ComboBox with customer data
            Contact_Box.DataSource = DB.GetCustomers();
            Contact_Box.DisplayMember = "name";

            // Initialize types for the Type ComboBox
            BindingList<string> types = new BindingList<string>
            {
                "Presentation",
                "Meeting",
                "Other"
            };

            //Initialize days for the StartDay ComboBox
            BindingList<string> days = new BindingList<string>
            {
                DayOfWeek.Monday.ToString().Substring(0, 1),
                DayOfWeek.Tuesday.ToString().Substring(0, 2),
                DayOfWeek.Wednesday.ToString().Substring(0, 1),
                DayOfWeek.Thursday.ToString().Substring(0, 2),
                DayOfWeek.Friday.ToString().Substring(0, 1)
            };



            // Set data sources for Type and Day ComboBoxes
            Type_Box.DataSource = types;
            
            // Set data sources for Start and End time ComboBoxes
            Start_Box.DataSource = TimeSlots();
            End_Box.DataSource = TimeSlots();
        }

        private DateTime date_Time_picked;
        private void dateTimePick_Value(object sender, EventArgs e)
        {
            try
            {
                // Get the selected date from the DateTimePicker
                date_Time_picked = date_Time_pick.Value;

                // Check if the selected date is in the past
                if (date_Time_picked < DateTime.Now.Date)
                {
                    // Temporarily disable the event to avoid infinite loop
                    date_Time_pick.ValueChanged -= dateTimePick_Value;

                    // Reset the date to the current date or another valid date
                    date_Time_pick.Value = DateTime.Now;

                    // Re-enable the event
                    date_Time_pick.ValueChanged += dateTimePick_Value;

                    // Show error message
                    MessageBox.Show("Appointments cannot be scheduled in the past.");
                }
                // Check if the selected date is a weekend
                else if (date_Time_picked.DayOfWeek == DayOfWeek.Saturday || date_Time_picked.DayOfWeek == DayOfWeek.Sunday)
                {
                    // Temporarily disable the event to avoid infinite loop
                    date_Time_pick.ValueChanged -= dateTimePick_Value;

                    // Reset the date to the current date or another valid date
                    date_Time_pick.Value = DateTime.Now;

                    // Re-enable the event
                    date_Time_pick.ValueChanged += dateTimePick_Value;

                    // Show error message
                    MessageBox.Show("Appointments can only be scheduled between Monday and Friday.");
                }
                else
                {
                    // Proceed with using the valid date
                    MessageBox.Show($"Selected date: {date_Time_picked.ToShortDateString()}");
                }
            }
            catch (Exception ex)
            {
                // General exception handling for any unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

        private List<string> TimeSlots()
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0, DateTimeKind.Utc);
            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 21, 0, 0, DateTimeKind.Utc);

            List<string> timeSlots = new List<string>();
            DateTime currentSlot = startTime;

            while (currentSlot <= endTime)
            {
                timeSlots.Add(currentSlot.ToLocalTime().ToString("HH:mm"));
                currentSlot = currentSlot.AddMinutes(30);
            }

            return timeSlots;
        }

        public string AppointmentID
        {
            get => ID_textbox.Text;
            set => ID_textbox.Text = value;
        }

        public string Contact
        {
            get => (Contact_Box.SelectedItem as Customer)?.name ?? string.Empty;
            set
            {
                foreach (var item in Contact_Box.Items)
                {
                    if (item is Customer customer && customer.name == value)
                    {
                        Contact_Box.SelectedItem = customer;
                        break;
                    }
                }
            }
        }

        public string Title
        {
            get => Title_Box.Text;
            set => Title_Box.Text = value;
        }

        public string Description
        {
            get => DescBox.Text;
            set => DescBox.Text = value;
        }

        public string Location
        {
            get => Location_Box.Text;
            set => Location_Box.Text = value;
        }

        public string Type
        {
            get => Type_Box.SelectedItem?.ToString() ?? string.Empty;
            set => Type_Box.SelectedItem = value;
        }

        public string URL
        {
            get => UrlText_Box.Text;
            set => UrlText_Box.Text = value;
        }

        public DateTime StartTime
        {
            get
            {
                // Assuming date_Time_picked holds the selected date from the DateTimePicker
                if (Start_Box.SelectedValue is string startTimeString)
                {
                    DateTime time = DateTime.ParseExact(startTimeString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    // Use the picked date (date_Time_picked) with the selected time
                    return new DateTime(
                        date_Time_picked.Year,
                        date_Time_picked.Month,
                        date_Time_picked.Day,
                        time.Hour,
                        time.Minute,
                        0);
                }
                return DateTime.MinValue; // Default value if parsing fails
            }
            set
            {
                Start_Box.SelectedItem = value.ToString("HH:mm");
            }
        }


        public DateTime EndTime
        {
            get
            {
                // Assuming date_Time_picked holds the selected date from the DateTimePicker
                if (End_Box.SelectedValue is string endTimeString)
                {
                    DateTime time2 = DateTime.ParseExact(endTimeString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    // Use the picked date with the selected time
                    return new DateTime(
                        date_Time_picked.Year,
                        date_Time_picked.Month,
                        date_Time_picked.Day,
                        time2.Hour,
                        time2.Minute,
                        0);
                }
                return DateTime.MinValue; // Default value if parsing fails
            }
            set
            {
                End_Box.SelectedItem = value.ToString("HH:mm");
            }
        }



        public string StartTimeComboBox
        {
            get => Start_Box.SelectedItem?.ToString() ?? string.Empty;
            set => Start_Box.SelectedItem = value;
        }

        public string EndTimeComboBox
        {
            get => End_Box.SelectedItem?.ToString() ?? string.Empty;
            set => End_Box.SelectedItem = value;
        }

        public App Appointment { get; set; }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Validate Title and Description
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Description))
            {
                MessageBox.Show("Appointment MUST have a Title AND a Description.");
                return;
            }

            try
            {
                // Retrieve customerId and userId
                int customerId = Convert.ToInt32(DB.SingularQuery($"SELECT customerId FROM customer WHERE customerName = '{Contact}'"));
                int userId = Convert.ToInt32(DB.SingularQuery($"SELECT userId FROM user WHERE userName = '{DB.currentUser}'"));

                // Create new Appointment
                Appointment = new App(
                    Convert.ToInt32(AppointmentID),
                    customerId,
                    userId,
                    Title,
                    Description,
                    Location,
                    Contact,
                    Type,
                    URL,
                    StartTime,
                    EndTime,
                    DateTime.UtcNow,
                    DB.currentUser,
                    DateTime.UtcNow,
                    DB.currentUser
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving appointment: {ex.Message}");
            }
        }
    }
}
