using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace C969_Spencer_Vedenoff
{
    public partial class MainForm : Form
    {
        public BindingList<City> allCities = DB.GetCities();
        public BindingList<Country> allCountries = DB.GetCountries();
        public BindingList<App> allAppointments = DB.GetApps();
        public BindingList<Customer> allCustomers = DB.GetCustomers();
        public BindingList<Address> allAddresses = DB.GetAddresses();

        public MainForm()
        {
            InitializeComponent();
            SetUpDataGrids();
        }

        private void SetUpDataGrids()
        {
            customerDataGrid.DataSource = GetClientViews();
            appDataGrid.DataSource = GetAppViews();
        }


        private void AddApp_Click(object sender, EventArgs e)
        {
            AppForm addAppForm = new AppForm();

            if (addAppForm.ShowDialog() == DialogResult.OK)
            {
                if (IsAppDataInvalid(addAppForm))
                {
                    return;
                }

                if (IsInvalidAppTime(addAppForm))
                {
                    ShowInvalidTimeMessage();
                    return;
                }

                if (DoesOverlap(addAppForm.Appointment))
                {
                    ShowOverlappingAppMessage();
                    return;
                }

                SaveNewAppointment(addAppForm.Appointment);
            }
            else
            {
                addAppForm.Close();
            }
        }

        private bool IsAppDataInvalid(AppForm form)
        {
            return string.IsNullOrWhiteSpace(form.Description) ||
                   string.IsNullOrWhiteSpace(form.Title) ||
                   string.IsNullOrWhiteSpace(form.Location);
        }

        private bool IsInvalidAppTime(AppForm form)
        {
            return form.StartTime >= form.EndTime;
        }

        private void SaveNewAppointment(App newAppointment)
        {
            allAppointments = DB.GetApps();

            DB.AddApp(newAppointment);

            allAppointments.Clear();
            allAppointments = DB.GetApps();

            appDataGrid.DataSource = GetAppViews();
            appDataGrid.Refresh();
        }

        // Updated this code to ensure proper logic for determing overlapping appointments
        public bool DoesOverlap(App apt)
        {
            if (apt == null) return false;

            foreach (var existingApp in GetAppViews())
            {
                if (existingApp == null) continue;

                // Convert times to UTC for consistent comparison
                DateTime existingStart = existingApp.StartTime.ToUniversalTime();
                DateTime existingEnd = existingApp.EndTime.ToUniversalTime();
                DateTime newStart = apt.start.ToUniversalTime();
                DateTime newEnd = apt.end.ToUniversalTime();

                // Check if the new appointment overlaps with the existing one
                bool overlapping = newStart < existingEnd && newEnd > existingStart;

                if (overlapping)
                {
                    return true; // Overlap found, no need to continue checking
                }
            }

            return false; // No overlaps found
        }


        private void LogoutButton_Click(object sender, EventArgs e)
        {
            PerformLogout();
            ShowLoginForm();
        }

        private void PerformLogout()
        {
            DB.loggedIn = false;
            DB.UserLoggedIn();
            this.Close();
            this.Dispose();
        }

        private void ShowLoginForm()
        {
            using (LoginForm loginAgain = new LoginForm())
            {
                loginAgain.ShowDialog();
            }
        }


        private void radioApps_Changed(object sender, EventArgs e)
        {
            SetAppointmentDataSource(allAppointments);
        }

        private void SetAppointmentDataSource(BindingList<App> appointments)
        {
            appDataGrid.DataSource = appointments;
        }

        private void radioMonth_Changed(object sender, EventArgs e)
        {
            FilterAppointmentsByDate(DateTime.Now.Month, DateFilterType.Month);
        }

        private void radioWeek_Changed(object sender, EventArgs e)
        {
            FilterAppointmentsByDate(DateTime.Now.Day, DateFilterType.Day);
        }

        private void FilterAppointmentsByDate(int timeValue, DateFilterType filterType)
        {
            var filteredApts = allAppointments
                .Where<App>(a => filterType == DateFilterType.Month ? a.createDate.Month == timeValue : a.createDate.Day == timeValue)
                .ToList();

            UpdateAppointmentDataGrid(filteredApts);
        }

        private void UpdateAppointmentDataGrid(List<App> filteredApp)
        {
            appDataGrid.DataSource = filteredApp;
        }

        private enum DateFilterType
        {
            Month,
            Day
        }

        // Per evalaution report from attempt 1:
        // Modified this code so that selected date + clicking "Search for Date" button on main form displays filtered apps
        // "Show all" will revert view to whole list

        private void SelectDate_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = mainMonthCal.SelectionRange.Start;

            // If no date is selected, show all appointments
            if (selectedDate == null)
            {
                appDataGrid.DataSource = allAppointments;
                return;
            }

            // Filter appointments based on the selected date
            var appt = allAppointments
                .Where(a => a.start.Date == selectedDate.Date)
                .ToList();

            // Update data grid with filtered appointments or show all if none found
            if (appt.Count > 0)
            {
                appDataGrid.DataSource = appt;
            }
            else
            {
                appDataGrid.DataSource = allAppointments;
            }
        }



        //private DateTime? GetSelectedDate()
        //{
            //return mainMonthCal.SelectionRange.Start != null
                //? mainMonthCal.SelectionRange.Start
                //: (DateTime?)null;
        //}

        //private void FilterAppointmentsBySelectedDate(DateTime date)
        //{
            //var filteredApts = allAppointments
                //.Where<App>(a => a.start.Day == date.Day)
                //.ToList();

            //if (filteredApts.Count > 0)
            //{
                //appDataGrid.DataSource = filteredApts;
            //}
        //}

        private void ShowApps_Click(object sender, EventArgs e)
        {
            DisplayAllAppointments();
        }

        private void DisplayAllAppointments()
        {
            appDataGrid.DataSource = allAppointments;
        }


        private void AddClient_Click(object sender, EventArgs e)
        {
            ClientForm addCustomer = new ClientForm();
            addCustomer.Id = DB.NextIndex("customerId", "customer").ToString();

            if (addCustomer.ShowDialog() == DialogResult.OK)
            {
                if (AreClientFieldsEmpty(addCustomer))
                {
                    MessageBox.Show("Fill out all fields!");
                    return;
                }

                AddCountryIfNotExists(addCustomer);
                AddCityIfNotExists(addCustomer);

                // Validate phone and exit if invalid
                if (!IsPhoneValid(addCustomer.Phone))
                {
                    MessageBox.Show("Invalid phone number. Only digits and dashes allowed.");
                    return;
                }

                AddAddressIfNotExists(addCustomer);
                AddCustomerIfNotExists(addCustomer);

                // Refresh the data grid with new data
                RefreshCustomerData();
                RefreshCustomerGrid();
            }
            else
            {
                addCustomer.Close();
            }
        }

        // Method to check if the required fields are empty
        private bool AreClientFieldsEmpty(ClientForm addCustomer)
        {
            return string.IsNullOrWhiteSpace(addCustomer.CName) ||
                   string.IsNullOrWhiteSpace(addCustomer.Address) ||
                   string.IsNullOrWhiteSpace(addCustomer.Phone) ||
                   string.IsNullOrWhiteSpace(addCustomer.PostalCode) ||
                   string.IsNullOrWhiteSpace(addCustomer.CityName);
        }

        // Method to add a country if it doesn't exist in the database
        private void AddCountryIfNotExists(ClientForm addCustomer)
        {
            if (!DB.IsInTable(addCustomer.CountryName, "country", "country"))
            {
                DB.AddCountry(new Country(
                    DB.NextIndex("countryId", "country"),
                    addCustomer.CountryName,
                    DateTime.Now,
                    DB.currentUser,
                    DateTime.Now,
                    DB.currentUser
                ));
            }
        }

        // Method to add a city if it doesn't exist in the database
        private void AddCityIfNotExists(ClientForm addCustomer)
        {
            if (!DB.IsInTable(addCustomer.CityName, "city", "city"))
            {
                DB.AddCity(new City(
                    DB.NextIndex("cityId", "city"),
                    addCustomer.CityName,
                    Convert.ToInt32(DB.SingularQuery($"SELECT countryId FROM Country WHERE country = '{addCustomer.CountryName}'")),
                    DateTime.Now,
                    DB.currentUser,
                    DateTime.Now,
                    DB.currentUser
                ));
            }
        }

        // Phone validation method (checks for digits and dashes)
        private bool IsPhoneValid(string phone)
        {
            foreach (var ch in phone)
            {
                if (ch != '-' && !char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        // Method to add address if it doesn't exist in the database
        private void AddAddressIfNotExists(ClientForm addCustomer)
        {
            if (DB.SingularQuery($"SELECT * FROM address WHERE address = '{addCustomer.Address}' AND" +
                                 $" phone = '{addCustomer.Phone}' AND postalCode = '{addCustomer.PostalCode}'").Equals(""))
            {
                DB.AddAddress(new Address(
                    DB.NextIndex("addressId", "address"),
                    addCustomer.Address,
                    null,
                    Convert.ToInt32(DB.SingularQuery($"SELECT cityId FROM city WHERE city = '{addCustomer.CityName}'")),
                    addCustomer.PostalCode,
                    addCustomer.Phone,
                    DateTime.Now,
                    DB.currentUser,
                    DateTime.Now,
                    DB.currentUser
                ));
            }
        }

        // Method to add customer if it doesn't exist in the database
        private void AddCustomerIfNotExists(ClientForm addCustomer)
        {
            if (!DB.IsInTable(addCustomer.CustomerName, "customerName", "customer"))
            {
                DB.AddCustomer(new Customer(
                    DB.NextIndex("customerId", "customer"),
                    addCustomer.CustomerName,
                    Convert.ToInt32(DB.SingularQuery($"SELECT addressId FROM address WHERE address = '{addCustomer.Address}'")),
                    "1",
                    DateTime.Now,
                    DB.currentUser,
                    DateTime.Now,
                    DB.currentUser
                ));
            }
        }

        // Refresh customer data method
        private void ReloadCustomerData()
        {
            allCountries.Clear();
            allCities.Clear();
            allAddresses.Clear();
            allCustomers.Clear();

            allCountries = DB.GetCountries();
            allCities = DB.GetCities();
            allAddresses = DB.GetAddresses();
            allCustomers = DB.GetCustomers();
        }

        // Refresh the customer grid
        private void RefreshCustomerGrid()
        {
            customerDataGrid.DataSource = null;
            customerDataGrid.Rows.Clear();
            customerDataGrid.DataSource = GetClientViews();
            customerDataGrid.Refresh();
        }

        public BindingList<ClientView> GetClientViews()
        {
            var customerViews = new BindingList<ClientView>();

            foreach (Customer customer in allCustomers)
            {
                var matchingAddress = GetMatchingAddress(customer.addressId);
                if (matchingAddress != null)
                {
                    var matchingCity = GetMatchingCity(matchingAddress.cityId);
                    if (matchingCity != null)
                    {
                        var matchingCountry = GetMatchingCountry(matchingCity.countryId);
                        if (matchingCountry != null)
                        {
                            customerViews.Add(new ClientView(customer, matchingAddress, matchingCity, matchingCountry));
                        }
                    }
                }
            }

            return customerViews;
        }

        private Address GetMatchingAddress(int addressId)
        {
            var matchingAddress = allAddresses.FirstOrDefault<Address>(a => a.addressId == addressId);
            if (matchingAddress == null)
            {
                MessageBox.Show($"NO MATCHING Address {addressId} {addressId.GetType()}");
            }
            return matchingAddress;
        }

        private City GetMatchingCity(int cityId)
        {
            var matchingCity = allCities.FirstOrDefault<City>(c => c.cityId == cityId);
            if (matchingCity == null)
            {
                MessageBox.Show("NO MATCHING City");
            }
            return matchingCity;
        }

        private Country GetMatchingCountry(int countryId)
        {
            var matchingCountry = allCountries.FirstOrDefault<Country>(c => c.countryId == countryId);
            if (matchingCountry == null)
            {
                MessageBox.Show("NO MATCHING Country");
            }
            return matchingCountry;
        }


        public BindingList<AppView> GetAppViews()
        {
            var appointmentViews = new BindingList<AppView>();

            AddAppointmentsToView(appointmentViews);

            return appointmentViews;
        }

        private void AddAppointmentsToView(BindingList<AppView> appointmentViews)
        {
            foreach (var appointment in allAppointments)
            {
                appointmentViews.Add(CreateAppointmentView(appointment));
            }
        }

        private AppView CreateAppointmentView(App appointment)
        {
            return new AppView(appointment);
        }


        private void UpdateClient_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                var customer = (ClientView)customerDataGrid.SelectedRows[0].DataBoundItem;
                ClientForm modifyCustomer = InitializeClientFormWithCustomerData(customer);

                if (modifyCustomer.ShowDialog() == DialogResult.OK)
                {
                    UpdateCustomerData(modifyCustomer, customer);
                    RefreshCustomerData();
                    RefreshGrids();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer record to update");
            }
        }

        private ClientForm InitializeClientFormWithCustomerData(ClientView customer)
        {
            ClientForm modifyCustomer = new ClientForm
            {
                Id = customer.ID.ToString(),
                CName = customer.Name,
                Address = customer.Address,
                Phone = customer.PhoneNumber,
                CityName = customer.City,
                PostalCode = customer.PostalCode,
                CountryName = customer.Country
            };

            return modifyCustomer;
        }

        // Updated this with the same check from DB.cs file to ensure fields are filled correctly
        private void UpdateCustomerData(ClientForm modifyCustomer, ClientView customer)
        {
            // Validate the name and address fields
            if (!IsFieldValid(modifyCustomer.CName) || !IsFieldValid(modifyCustomer.Address))
            {
                MessageBox.Show("Name and Address fields cannot be empty or contain only whitespace.");
                return;
            }

            // If all validations pass, proceed with updating the customer
            customer.Name = modifyCustomer.CName.Trim();
            customer.Address = modifyCustomer.Address.Trim();
            customer.PhoneNumber = modifyCustomer.Phone;
            customer.City = modifyCustomer.CityName;
            customer.PostalCode = modifyCustomer.PostalCode;
            customer.Country = modifyCustomer.CountryName;

            DB.UpdateCustomer(customer);
        }
        private static bool IsFieldValid(string field)
        {
            return !string.IsNullOrWhiteSpace(field); // Check if it's not null or only whitespace
        }

        private void RefreshCustomerData()
        {
            allCountries.Clear();
            allCities.Clear();
            allAddresses.Clear();
            allCustomers.Clear();

            allCountries = DB.GetCountries();
            allCities = DB.GetCities();
            allAddresses = DB.GetAddresses();
            allCustomers = DB.GetCustomers();
        }

        private void RefreshGrids()
        {
            customerDataGrid.DataSource = null;
            customerDataGrid.Rows.Clear();
            customerDataGrid.DataSource = GetClientViews();
            customerDataGrid.Refresh();
            appDataGrid.Refresh();
        }

        private void DeleteClient_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                ClientView customer = (ClientView)customerDataGrid.SelectedRows[0].DataBoundItem;
                if (ConfirmClientDelete(customer))
                {
                    if (HasAppointments(customer))
                    {
                        MessageBox.Show($"Cannot delete {customer.Name} when they have appointment(s)!");
                        return;
                    }

                    DeleteClientAndRefreshData(customer);
                }
            }
            else
            {
                MessageBox.Show("You must select a record to delete...");
            }
        }

        private bool ConfirmClientDelete(ClientView customer)
        {
            var dialogResult = MessageBox.Show($"Are you sure you want to delete the customer \"{customer.Name}\"", "Confirm", MessageBoxButtons.YesNo);
            return dialogResult == DialogResult.Yes;
        }

        private bool HasAppointments(ClientView customer)
        {
            return !DB.SingularQuery($"SELECT appointmentId FROM appointment WHERE customerId = {customer.ID}").Equals("");
        }

        private void DeleteClientAndRefreshData(ClientView customer)
        {
            DB.DeleteCustomer(customer);
            ClearAndReloadClientData();
            RefreshClientGrid();
        }

        private void ClearAndReloadClientData()
        {
            allCountries.Clear();
            allCities.Clear();
            allAddresses.Clear();
            allCustomers.Clear();

            allCountries = DB.GetCountries();
            allCities = DB.GetCities();
            allAddresses = DB.GetAddresses();
            allCustomers = DB.GetCustomers();
        }

        private void RefreshClientGrid()
        {
            customerDataGrid.DataSource = null;
            customerDataGrid.Rows.Clear();
            customerDataGrid.DataSource = GetClientViews();
            customerDataGrid.Refresh();
        }


        private void ReportButton_Click(object sender, EventArgs e)
        {
            ShowReportChoices();
        }

        private void ShowReportChoices()
        {
            ReportChoices reportChoicesForm = new ReportChoices();
            reportChoicesForm.Show();
        }

        private void UpdateApp_Click(object sender, EventArgs e)
        {
            if (appDataGrid.SelectedRows.Count > 0)
            {
                AppView app = appDataGrid.SelectedRows[0].DataBoundItem as AppView;
                AppForm modifyApp = InitializeAppFormWithAppointmentData(app);

                if (modifyApp.ShowDialog() == DialogResult.OK)
                {
                    if (IsAppointmentTimeInvalid(modifyApp))
                    {
                        ShowInvalidTimeMessage();
                    }
                    else if (IsAppointmentOverlapping(modifyApp))
                    {
                        ShowOverlappingAppMessage();
                    }
                    else
                    {
                        UpdateAppointmentInDatabase(modifyApp, app);
                        RefreshAppointments();
                    }
                }
            }
            else
            {
                MessageBox.Show("No appointment row selected.");
            }
        }

        private AppForm InitializeAppFormWithAppointmentData(AppView app)
        {
            AppForm modifyApt = new AppForm
            {
                AppointmentID = app.ID.ToString(),
                Contact = app.Contact,
                Title = app.Title,
                Description = app.Description,
                Location = app.Location,
                Type = app.Type,
                URL = app.URL,
                StartTimeComboBox = app.StartTime.ToLocalTime().ToString("HH:mm"),
                EndTimeComboBox = app.EndTime.ToLocalTime().ToString("HH:mm")
            };

            return modifyApt;
        }

        private bool IsAppointmentTimeInvalid(AppForm modifyApp)
        {
            return modifyApp.StartTime >= modifyApp.EndTime;
        }

        private void ShowInvalidTimeMessage()
        {
            MessageBox.Show("Cannot have an appointment end before it starts.");
            this.Focus();
        }

        private bool IsAppointmentOverlapping(AppForm modifyApp)
        {
            allAppointments = DB.GetApps();
            return DoesOverlap(modifyApp.Appointment);
        }

        private void ShowOverlappingAppMessage()
        {
            MessageBox.Show("Sorry, Overlapping appointments aren't allowed.");
        }

        private void UpdateAppointmentInDatabase(AppForm modifyApp, AppView app)
        {
            app.ID = Convert.ToInt32(modifyApp.AppointmentID);
            app.Contact = modifyApp.Contact;
            app.Title = modifyApp.Title;
            app.Description = modifyApp.Description;
            app.Location = modifyApp.Location;
            app.Type = modifyApp.Type;
            app.URL = modifyApp.URL;
            app.StartTime = modifyApp.StartTime;
            app.EndTime = modifyApp.EndTime;

            DB.ModifyApp(app);
        }

        private void RefreshAppointments()
        {
            allAppointments.Clear();
            allAppointments = DB.GetApps();
            appDataGrid.DataSource = GetAppViews();
            appDataGrid.Refresh();
        }


        private void DeleteApp_Click(object sender, EventArgs e)
        {
            if (IsAppointmentSelected())
            {
                AppView selectedApp = GetSelectedAppointment();
                DeleteAppointment(selectedApp);
                RefreshAppointments();
            }
        }

        private bool IsAppointmentSelected()
        {
            return appDataGrid.SelectedRows.Count > 0;
        }

        private AppView GetSelectedAppointment()
        {
            return appDataGrid.SelectedRows[0].DataBoundItem as AppView;
        }

        private void DeleteAppointment(AppView app)
        {
            DB.DeleteAppointment(app);
        }

        private void RefreshApp()
        {
            allAppointments = DB.GetApps();
            appDataGrid.DataSource = GetAppViews();
            appDataGrid.Refresh();
        }
    }

    public class ClientView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public ClientView(Customer customer, Address address, City city, Country country)
        {
            InitializeCustomerView(customer, address, city, country);
        }

        private void InitializeCustomerView(Customer customer, Address address, City city, Country country)
        {
            ID = customer.id;
            Name = customer.name;
            Address = address.address;
            PhoneNumber = address.phone;
            City = city.cityName;
            PostalCode = address.postalCode;
            Country = country.countryName;
        }
    }


    public class AppView
    {
        public int ID { get; set; }
        public string Contact { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public AppView(App appointment)
        {
            InitializeAppView(appointment);
        }

        private void InitializeAppView(App appointment)
        {
            ID = appointment.appointmentId;
            Contact = GetContactName(appointment.customerId);
            Title = appointment.title;
            Description = appointment.description;
            Location = appointment.location;
            Type = appointment.type;
            URL = appointment.url;
            StartTime = appointment.start;
            EndTime = appointment.end;
        }

        private string GetContactName(int customerId)
        {
            return DB.SingularQuery($"SELECT customerName FROM customer WHERE customerId = {customerId}");
        }
    }
}
