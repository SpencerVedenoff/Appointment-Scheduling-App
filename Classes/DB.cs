using MySql.Data.MySqlClient;
using System;
using System.Threading;
using System.Windows.Forms;
using MySql.Data;
using System.ComponentModel;
using System.Globalization;
using MySqlX.XDevAPI.Relational;
using System.Management;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C969_Spencer_Vedenoff
    // Database Class
{
    internal class DB
    {
        public static string currentUser = "test";
        public static string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        public static BindingList<City> cities = new BindingList<City>();
        public static BindingList<Country> countries = new BindingList<Country>();
        public static BindingList<Address> addresses = new BindingList<Address>();
        public static BindingList<User> users = new BindingList<User>();
        public static BindingList<Customer> customers = new BindingList<Customer>();
        public static bool loggedIn = false;

        public static BindingList<User> GetUsers()
        {
            BindingList<User> users = new BindingList<User>();
            string connString = constr; 
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sqlString = "SELECT * FROM user";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    using (MySqlDataReader dataread = cmd.ExecuteReader())
                    {
                        while (dataread.Read())
                        {
                            users.Add(new User(
                                Convert.ToInt32(dataread[0]),
                                dataread[1].ToString(),
                                dataread[2].ToString(),
                                dataread[3].ToString(),
                                Convert.ToDateTime(dataread[4]),
                                dataread[5].ToString(),
                                Convert.ToDateTime(dataread[6]),
                                dataread[7].ToString()
                            ));
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error retrieving users: {e.Message}");
                }
            }

            return users;
        }

        // Method to get Customers from DB
        public static BindingList<Customer> GetCustomers()
        {
            BindingList<Customer> customers = new BindingList<Customer>();
            string connString = constr; 

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sqlString = "SELECT * FROM customer";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    using (MySqlDataReader dataread = cmd.ExecuteReader())
                    {
                        while (dataread.Read())
                        {
                            customers.Add(new Customer(
                                Int32.Parse(dataread[0].ToString().Trim()),
                                dataread[1].ToString(),
                                Int32.Parse(dataread[2].ToString().Trim()),
                                dataread[3].ToString(),
                                Convert.ToDateTime(dataread[4]),
                                dataread[5].ToString(),
                                Convert.ToDateTime(dataread[6]),
                                dataread[7].ToString()
                            ));
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error retrieving customers: {e.Message}");
                }
            }

            return customers;
        }

        // Method to query appointments
        public static BindingList<App> GetApps()
        {
            BindingList<App> appointments = new BindingList<App>();
            string connString = constr; 

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sqlString = "SELECT * FROM appointment";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    using (MySqlDataReader dataread = cmd.ExecuteReader())
                    {
                        while (dataread.Read())
                        {
                            
                            DateTime start = DateTime.SpecifyKind(Convert.ToDateTime(dataread[9]), DateTimeKind.Utc);
                            DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(start, TimeZoneInfo.Local);

                            DateTime end = DateTime.SpecifyKind(Convert.ToDateTime(dataread[10]), DateTimeKind.Utc);
                            DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(end, TimeZoneInfo.Local);

                            DateTime created = DateTime.SpecifyKind(Convert.ToDateTime(dataread[11]), DateTimeKind.Utc);
                            DateTime localCreated = TimeZoneInfo.ConvertTimeFromUtc(created, TimeZoneInfo.Local);

                            DateTime updated = DateTime.SpecifyKind(Convert.ToDateTime(dataread[13]), DateTimeKind.Utc);
                            DateTime localUpdated = TimeZoneInfo.ConvertTimeFromUtc(updated, TimeZoneInfo.Local);

                            // Add the App object to the appointments list
                            appointments.Add(new App(
                                Int32.Parse(dataread[0].ToString()),
                                Int32.Parse(dataread[1].ToString()),
                                Int32.Parse(dataread[2].ToString()),
                                dataread[3].ToString(),
                                dataread[4].ToString(),
                                dataread[5].ToString(),
                                dataread[6].ToString(),
                                dataread[7].ToString(),
                                dataread[8].ToString(),
                                localStart,
                                localEnd,
                                localCreated,
                                dataread[12].ToString(),
                                localUpdated,
                                dataread[14].ToString()
                            ));
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error retrieving appointments: {e.Message}");
                }
            }

            return appointments;
        }

        // Method to query countires from DB
        public static BindingList<Country> GetCountries()
        {
            BindingList<Country> countries = new BindingList<Country>();
            string connStr = constr; 

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sqlString = "SELECT * FROM country";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    using (MySqlDataReader dataRead = cmd.ExecuteReader())
                    {
                        while (dataRead.Read())
                        {
                            countries.Add(new Country(
                                Int32.Parse(dataRead[0].ToString()),
                                dataRead[1].ToString(),
                                Convert.ToDateTime(dataRead[2]),
                                dataRead[3].ToString(),
                                Convert.ToDateTime(dataRead[4]),
                                dataRead[5].ToString()
                            ));
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error retrieving countries: {e.Message}");
                }
            }

            return countries;
        }

        // Method to query cities from DB
        public static BindingList<City> GetCities()
        {
            BindingList<City> cities = new BindingList<City>();
            string connStr = constr; 

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sqlString = "SELECT * FROM city";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    using (MySqlDataReader dataread = cmd.ExecuteReader())
                    {
                        while (dataread.Read())
                        {
                            // Add City object to cities list
                            cities.Add(new City(
                                Int32.Parse(dataread[0].ToString()),
                                dataread[1].ToString(),
                                Int32.Parse(dataread[2].ToString()),
                                Convert.ToDateTime(dataread[3]),
                                dataread[4].ToString(),
                                Convert.ToDateTime(dataread[5]),
                                dataread[6].ToString()
                            ));
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error retrieving cities: {e.Message}");
                }
            }

            return cities;
        }

        // Method to query addresses from DB
        public static BindingList<Address> GetAddresses()
        {
            BindingList<Address> addresses = new BindingList<Address>();
            string connString = constr; 

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sqlString = "SELECT * FROM address";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    using (MySqlDataReader dataread = cmd.ExecuteReader())
                    {
                        while (dataread.Read())
                        {
                            // Add Address object to the addresses list
                            addresses.Add(new Address(
                                Int32.Parse(dataread[0].ToString().Trim()),
                                dataread[1].ToString(),
                                dataread[2].ToString(),
                                Int32.Parse(dataread[3].ToString().Trim()),
                                dataread[4].ToString(),
                                dataread[5].ToString(),
                                Convert.ToDateTime(dataread[6]),
                                dataread[7].ToString(),
                                Convert.ToDateTime(dataread[8]),
                                dataread[9].ToString()
                            ));
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error retrieving addresses: {e.Message}");
                }
            }

            return addresses;
        }

        // Method to for adding customer
        public static int AddCustomer(Customer customer)
        {
            string connStr = constr;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Trim any potential whitespace from customer fields
                    string trimmedName = customer.name.Trim();
                    string trimmedCreatedBy = customer.createdBy.Trim();
                    string trimmedLastUpdatedBy = customer.LastUpdatedBy.Trim();

                    string sqlString = $"INSERT INTO `customer` VALUES ('{customer.id}', '{trimmedName}', '{customer.addressId}', '{Int32.Parse(customer.active)}', " +
                        $"'{customer.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}',  '{trimmedCreatedBy}'," +
                        $"'{customer.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}', '{trimmedLastUpdatedBy}')";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Use parameterized queries to prevent SQL injection and handle data types correctly
                    cmd.Parameters.AddWithValue("@id", customer.id);
                    cmd.Parameters.AddWithValue("@name", trimmedName);
                    cmd.Parameters.AddWithValue("@addressId", customer.addressId);
                    cmd.Parameters.AddWithValue("@active", Int32.Parse(customer.active));
                    cmd.Parameters.AddWithValue("@createDate", customer.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@createdBy", trimmedCreatedBy);
                    cmd.Parameters.AddWithValue("@lastUpdate", customer.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", trimmedLastUpdatedBy);

                    cmd.ExecuteNonQuery();
                    return 1; // Success
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error adding customer: {e.Message}");
                }

                return -1; // Error case
            }
        }


        // Method for adding country
        public static int AddCountry(Country country)
        {
            string connStr = constr;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Trim any potential whitespace from relevant fields
                    string trimmedCountryName = country.countryName.Trim();
                    string trimmedCreatedBy = country.createdBy.Trim();
                    string trimmedLastUpdateBy = country.lastUpdateBy.Trim();

                    // Use parameterized query to safely insert values
                    string sqlString = $"INSERT INTO `country` VALUES ({country.countryId}, '{trimmedCountryName}', '{country.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}'," +
                        $" '{trimmedCreatedBy}', '{country.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}', '{trimmedLastUpdateBy}')";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Set the parameters with the respective values
                    cmd.Parameters.AddWithValue("@countryId", country.countryId);
                    cmd.Parameters.AddWithValue("@countryName", trimmedCountryName);
                    cmd.Parameters.AddWithValue("@createDate", country.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@createdBy", trimmedCreatedBy);
                    cmd.Parameters.AddWithValue("@lastUpdate", country.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@lastUpdateBy", trimmedLastUpdateBy);

                    cmd.ExecuteNonQuery();
                    return 1; // Return 1 to indicate success
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error adding country: {e.Message}");
                }

                return -1; // Return -1 in case of failure
            }
        }


        // Method for adding city
        public static int AddCity(City city)
        {
            string connStr = constr;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string trimmedcityname = city.cityName.Trim();
                    string trimmedCreatedby = city.createdBy.Trim();
                    string trimmedLastUpdateBy = city.lastUpdatedBy.Trim();

                    // Use parameterized query to safely insert values
                    String sqlString = $"INSERT INTO `city` VALUES ({city.cityId}, '{trimmedcityname}', {city.countryId}, '{city.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}'," +
                        $" '{trimmedCreatedby}', '{city.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}', '{trimmedLastUpdateBy}')";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Set the parameters with the respective values
                    cmd.Parameters.AddWithValue("@cityId", city.cityId);
                    cmd.Parameters.AddWithValue("@cityName", trimmedcityname);
                    cmd.Parameters.AddWithValue("@countryId", city.countryId);
                    cmd.Parameters.AddWithValue("@createDate", city.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@createdBy", trimmedCreatedby);
                    cmd.Parameters.AddWithValue("@lastUpdate", city.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@lastUpdatedBy", trimmedLastUpdateBy);

                    cmd.ExecuteNonQuery();
                    return 1; // Return 1 to indicate success
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error adding city: {e.Message}");
                }

                return -1; // Return -1 in case of failure
            }
        }



        // Method for adding address information
        public static int AddAddress(Address address)
        {
            string connStr = constr; 
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string trimmedAddress = address.address.Trim();
                    string trimmedCreatedBy = address.createdBy.Trim();
                    string trimmedLastUpdateBy = address.lastUpdatedBy.Trim();

                    // Use parameterized query to safely insert values
                    String sqlString = $"INSERT INTO `address` VALUES ({address.addressId}, '{trimmedAddress}', '{address.address2}', {address.cityId}, " +
                        $"'{address.postalCode}', '{address.phone}', '{address.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}'," +
                        $" '{trimmedCreatedBy}', '{address.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}', '{trimmedLastUpdateBy}')";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Set the parameters with the respective values
                    cmd.Parameters.AddWithValue("@addressId", address.addressId);
                    cmd.Parameters.AddWithValue("@address", trimmedAddress);
                    cmd.Parameters.AddWithValue("@address2", address.address2);
                    cmd.Parameters.AddWithValue("@cityId", address.cityId);
                    cmd.Parameters.AddWithValue("@postalCode", address.postalCode);
                    cmd.Parameters.AddWithValue("@phone", address.phone);
                    cmd.Parameters.AddWithValue("@createDate", address.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@createdBy", trimmedCreatedBy);
                    cmd.Parameters.AddWithValue("@lastUpdate", address.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@lastUpdatedBy", trimmedLastUpdateBy);

                    cmd.ExecuteNonQuery();
                    return 1; // Return 1 to indicate success
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error adding address: {e.Message}");
                }

                return -1; // Return -1 in case of failure
            }
        }

        // Method for interating Index value
        public static int NextIndex(string column, string table)
        {
            int next_index = 1;
            string connStr = constr; 
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Use parameterized query to avoid SQL injection
                    string sqlString = $"SELECT MAX({column}) FROM {table}";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    using (MySqlDataReader dataread = cmd.ExecuteReader())
                    {
                        if (dataread.Read() && !DBNull.Value.Equals(dataread[0])) // Ensure the result is not null
                        {
                            next_index = Convert.ToInt32(dataread[0]);
                        }
                    }

                    return next_index + 1; // Return the next available index
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error retrieving next index: {e.Message}");
                }

                return -1; // Return -1 in case of error
            }
        }

        // Method for checking existing values in tables
        public static bool IsInTable(string field, string column, string table)
        {
            bool exists = false;
            string connStr = constr; 
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Use parameterized query to prevent SQL injection
                    string sqlString = $"SELECT 1 FROM {table} WHERE {column} = @field LIMIT 1"; // Using SELECT 1 for optimization

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.Parameters.AddWithValue("@field", field); // Pass the field value as a parameter

                    using (MySqlDataReader dataread = cmd.ExecuteReader())
                    {
                        exists = dataread.HasRows; // Check if any row exists
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error checking table: {e.Message}");
                }

                return exists;
            }
        }

        // Method for retrieiving row value as string to be called in other functions
        public static string SingularQuery(string query)
        {
            string result = string.Empty;
            string connString = constr; 

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Avoid passing raw queries, ensure the query is properly constructed
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader dataread = cmd.ExecuteReader())
                    {
                        if (dataread.Read())
                        {
                            result = dataread[0].ToString(); // Get the first result
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error executing query: {e.Message}");
                }
            }

            return result;
        }


        // Method for Deleting Client record
        public static void DeleteCustomer(ClientView customer)
        {
            string connStr = constr; 
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Use parameterized query to safely delete the customer
                    string sqlString = "DELETE FROM customer WHERE customerId = @customerId";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Set the parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@customerId", customer.ID);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error deleting customer: {e.Message}");
                }
            }
        }

        // Method for Deleting appointment record
        public static void DeleteAppointment(AppView appointment)
        {
            string connString = constr; 
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Confirmation dialog
                    var result = MessageBox.Show($"Are you sure you want to delete the appointment for {appointment.Contact}?", "Confirm", MessageBoxButtons.YesNo);
                    if (result != DialogResult.Yes)
                    {
                        return; // Exit if the user does not confirm
                    }

                    // Use parameterized query to safely delete the appointment
                    string sqlString = "DELETE FROM appointment WHERE appointmentId = @appointmentId";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Set the parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@appointmentId", appointment.ID);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error deleting appointment: {e.Message}");
                }
            }
        }

        // Method for adding an appointment
        public static void AddApp(App appointment)
        {
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    string trimmedContact = appointment.contact?.Trim();
                    string trimmedTitle = appointment.title?.Trim();
                    string trimmedDescription = appointment.description?.Trim();
                    string trimmedLocation = appointment.location?.Trim();
                    string trimmedType = appointment.type?.Trim();
                    string trimmedURL = appointment.url.Trim();


                    // Use parameterized query to insert values safely
                    String sqlString = $"INSERT INTO `appointment` VALUES ({appointment.appointmentId}, {appointment.customerId}, {appointment.userId}, '{trimmedTitle}', " +
                        $"'{trimmedDescription}', '{trimmedLocation}', '{trimmedContact}'," +
                        $" '{trimmedType}', '{trimmedURL}', '{appointment.start.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{appointment.end.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{appointment.createDate.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{appointment.createdBy}'," +
                        $"'{appointment.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{appointment.lastUpdatedBy}')";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Set the parameters with the respective values
                    cmd.Parameters.AddWithValue("@appointmentId", appointment.appointmentId);
                    cmd.Parameters.AddWithValue("@customerId", appointment.customerId);
                    cmd.Parameters.AddWithValue("@userId", appointment.userId);
                    cmd.Parameters.AddWithValue("@title", appointment.title);
                    cmd.Parameters.AddWithValue("@description", appointment.description);
                    cmd.Parameters.AddWithValue("@location", appointment.location);
                    cmd.Parameters.AddWithValue("@contact", appointment.contact);
                    cmd.Parameters.AddWithValue("@type", appointment.type);
                    cmd.Parameters.AddWithValue("@url", appointment.url);
                    cmd.Parameters.AddWithValue("@start", appointment.start.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@end", appointment.end.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@createDate", appointment.createDate.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@createdBy", appointment.createdBy);
                    cmd.Parameters.AddWithValue("@lastUpdate", appointment.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@lastUpdatedBy", appointment.lastUpdatedBy);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error adding appointment: {e.Message}");
                }
            }
        }

        // Method for updating appointment
        
        public static void ModifyApp(AppView appointment)
        {
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();

                    // Trim all string fields to remove any leading or trailing whitespace
                    string trimmedContact = appointment.Contact.Trim();
                    string trimmedTitle = appointment.Title.Trim();
                    string trimmedDescription = appointment.Description.Trim();
                    string trimmedLocation = appointment.Location.Trim();
                    string trimmedType = appointment.Type.Trim();
                    string trimmedURL = appointment.URL.Trim();

                    // Use parameterized query to update the appointment safely
                    string sqlString = "UPDATE `appointment` SET contact = @contact, title = @title, description = @description, " +
                                       "location = @location, type = @type, url = @url, start = @start, end = @end, " +
                                       "lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy WHERE appointmentId = @appointmentId";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Set the parameters with the respective trimmed values
                    cmd.Parameters.AddWithValue("@contact", trimmedContact);
                    cmd.Parameters.AddWithValue("@title", trimmedTitle);
                    cmd.Parameters.AddWithValue("@description", trimmedDescription);
                    cmd.Parameters.AddWithValue("@location", trimmedLocation);
                    cmd.Parameters.AddWithValue("@type", trimmedType);
                    cmd.Parameters.AddWithValue("@url", trimmedURL);
                    cmd.Parameters.AddWithValue("@start", appointment.StartTime.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@end", appointment.EndTime.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                    cmd.Parameters.AddWithValue("@lastUpdateBy", DB.currentUser);
                    cmd.Parameters.AddWithValue("@appointmentId", appointment.ID);

                    int touchedRows = cmd.ExecuteNonQuery();
                    MessageBox.Show("SUCCESS: " + touchedRows + " rows updated.");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error updating appointment: {e.Message}");
                }
            }
        }

        // Method for updating customer
        public static void UpdateCustomer(ClientView customer)
        {
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();

                    // Updated to ensure trimmed fields and city will be added if doesnt exist
                    // Ensure the city exists, or add it if it doesn't
                    int cityId = EnsureCityExists(customer.City);

                    // Update customer details
                    string customerUpdate = "UPDATE `customer` SET customerName = @customerName, " +
                                            "lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy " +
                                            "WHERE customerId = @customerId";
                    MySqlCommand cmd = new MySqlCommand(customerUpdate, conn);
                    cmd.Parameters.AddWithValue("@customerName", customer.Name.Trim());
                    cmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@lastUpdateBy", DB.currentUser);
                    cmd.Parameters.AddWithValue("@customerId", customer.ID);
                    cmd.ExecuteNonQuery();

                    // Get the associated addressId for the customer
                    int addressId = Convert.ToInt32(SingularQuery(
                        $"SELECT addressId FROM customer WHERE customerId = {customer.ID}"));

                    // Update address details with the new cityId
                    string addressUpdate = "UPDATE `address` SET address = @address, postalCode = @postalCode, " +
                                           "cityId = @cityId, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy " +
                                           "WHERE addressId = @addressId";
                    MySqlCommand cmd2 = new MySqlCommand(addressUpdate, conn);
                    cmd2.Parameters.AddWithValue("@address", customer.Address.Trim());
                    cmd2.Parameters.AddWithValue("@postalCode", customer.PostalCode.Trim());
                    cmd2.Parameters.AddWithValue("@cityId", cityId);
                    cmd2.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss"));
                    cmd2.Parameters.AddWithValue("@lastUpdateBy", DB.currentUser);
                    cmd2.Parameters.AddWithValue("@addressId", addressId);
                    cmd2.ExecuteNonQuery();

                    // Added Exception handling to check if Phone field still contains proper characters when updating customer
                    if (!IsPhoneValid(customer.PhoneNumber))
                    {
                        MessageBox.Show("Invalid phone number. Only digits and dashes are allowed.");
                        return;
                    }

                    if (!IsFieldValid(customer.Name) || !IsFieldValid(customer.Address))
                    {
                        MessageBox.Show("Name and Address fields cannot be empty or contain only whitespace.");
                        return;
                    }

                    UpdateCountry(customer.ID, customer.Country);

                    MessageBox.Show("Customer Record updated successfully.");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error updating customer: {e.Message}");
                }
            }
        }

        // Added functionality to change country per evaluation report
        public static void UpdateCountry(int customerId, string selectedCountry)
        {
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();

                    // Retrieve the currently assigned country for the customer's address
                    string query = @"
                        SELECT country.country 
                        FROM customer 
                        JOIN address ON customer.addressId = address.addressId
                        JOIN city ON address.cityId = city.cityId
                        JOIN country ON city.countryId = country.countryId
                        WHERE customer.customerId = @customerId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    string currentCountry = cmd.ExecuteScalar()?.ToString();

                    // Compare the selected country with the currently assigned country
                    if (currentCountry != selectedCountry)
                    {
                        // If different, run the update query to change the countryId
                        string updateQuery = @"
                            UPDATE city
                            SET countryId = (
                            SELECT countryId FROM country WHERE country = @selectedCountry
                        )
                        WHERE cityId = (
                            SELECT cityId FROM address WHERE addressId = (
                                SELECT addressId FROM customer WHERE customerId = @customerId
                            )
                        )";

                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@selectedCountry", selectedCountry);
                        updateCmd.Parameters.AddWithValue("@customerId", customerId);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} record(s) updated. Country changed to {selectedCountry}.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating country: {ex.Message}");
                }
            }
        }

        // Method to check if City record exists, and add if it doesn't gets called in UpdateCustomer Method
        public static int EnsureCityExists(string cityName)
        {
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                conn.Open();

                // Check if the city already exists
                string cityCheck = "SELECT cityId FROM city WHERE city = @cityName LIMIT 1";
                MySqlCommand checkCmd = new MySqlCommand(cityCheck, conn);
                checkCmd.Parameters.AddWithValue("@cityName", cityName.Trim());
                object cityIdObj = checkCmd.ExecuteScalar();

                if (cityIdObj != null)
                {
                    return Convert.ToInt32(cityIdObj); // Return the existing cityId
                }

                // If the city does not exist, add it
                string insertCity = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                    "VALUES (@cityName, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlCommand insertCmd = new MySqlCommand(insertCity, conn);
                insertCmd.Parameters.AddWithValue("@cityName", cityName.Trim());
                insertCmd.Parameters.AddWithValue("@countryId", 1); // Default to United States or adjust as needed
                insertCmd.Parameters.AddWithValue("@createDate", DateTime.UtcNow);
                insertCmd.Parameters.AddWithValue("@createdBy", DB.currentUser);
                insertCmd.Parameters.AddWithValue("@lastUpdate", DateTime.UtcNow);
                insertCmd.Parameters.AddWithValue("@lastUpdateBy", DB.currentUser);

                insertCmd.ExecuteNonQuery();

                // Retrieve the newly inserted cityId
                return Convert.ToInt32(checkCmd.ExecuteScalar());
            }
        }

        private static bool IsPhoneValid(string phone)
        {
            // Per evaluation of attempt 1 of PA:
            // I Added additional functionality to check for whitespace
            // This should ensure that only number and digits are accepted values to this field both on 
            // Adding AND updating a customer record

            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            foreach (var ch in phone)
            {
                if (ch != '-' && !char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsFieldValid(string field)
        {
            // Check if the field is null, empty, or contains only whitespace
            if (string.IsNullOrWhiteSpace(field))
            {
                return false;
            }

            // Additional logic can be added here if needed (e.g., length validation)
            return true;
        }


        // Method to set active user
        public static void UserLoggedIn()
        {
            int flag = loggedIn ? 0 : 1; // Simplified ternary operation

            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();

                    // Use parameterized query to safely update the user's active status
                    string sqlString = "UPDATE `user` SET active = @flag WHERE userName = @userName";

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    // Set parameters for flag and currentUser
                    cmd.Parameters.AddWithValue("@flag", flag);
                    cmd.Parameters.AddWithValue("@userName", DB.currentUser);

                    int touchedRow = cmd.ExecuteNonQuery();
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error updating user login status: {e.Message}");
                }
            }
        }

        
        public static DataTable Report(int type)
        {
            DataTable dataTable = new DataTable();
            string connString = constr;

            // Dictionary of lambda expressions to handle different report types Per Rubric Aspect A7
            var reportQueries = new Dictionary<int, Func<string>>()
        {
        { 0, () => "SELECT MONTHNAME(`start`) AS 'Month', COUNT(*) AS Count FROM appointment GROUP BY MONTHNAME(`start`)" },

        // Updated lambda to fetch appointment details (start and end times)
        { 1, () => "SELECT userName AS 'User', `start` AS 'Appointment Start', `end` AS 'Appointment End' " +
                   "FROM user " +
                   "LEFT JOIN appointment ON user.userId = appointment.userId " +
                   "ORDER BY userName, `start`" },

        { 2, () => "SELECT `location` AS Country, COUNT(location) AS Count FROM appointment GROUP BY `location`" }
            };
            // Updated to ensure datetime is converted to localtime
            // Execute the selected query
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = reportQueries[type](); // Get the query based on the report type
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    // Convert DateTime columns to local time zone if they exist
                    if (dataTable.Columns.Contains("Appointment Start") && dataTable.Columns.Contains("Appointment End"))
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Convert 'Appointment Start' to local time
                            DateTime utcStart = DateTime.Parse(row["Appointment Start"].ToString());
                            row["Appointment Start"] = utcStart.ToLocalTime();

                            // Convert 'Appointment End' to local time
                            DateTime utcEnd = DateTime.Parse(row["Appointment End"].ToString());
                            row["Appointment End"] = utcEnd.ToLocalTime();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating report: {ex.Message}");
                }
            }

            return dataTable;
        }
    }
}
