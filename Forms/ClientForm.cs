using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Spencer_Vedenoff
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();

            var allCountries = GetCountryNames();

            foreach (var country in allCountries)
            {
            // Escape single quotes manually for the query
            string sanitizedCountry = country.Replace("'", "''");

            
            string query = $"SELECT country FROM country WHERE country = '{sanitizedCountry}'";
            var existingCountry = DB.SingularQuery(query);

                if (string.IsNullOrEmpty(existingCountry))
                {
                    DB.AddCountry(new Country(
                    DB.NextIndex("countryId", "country"),
                    country,
                    DateTime.Now,
                    DB.currentUser,
                    DateTime.Now,
                    DB.currentUser));

                }

            }

            CountryChoices.DataSource = allCountries;
            CountryChoices.SelectedItem = "United States";
        }

    private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        public string Id
        {
            get => textBoxID.Text;
            set => textBoxID.Text = value;
        }

        public string CName
        {
            get => textBoxName.Text;
            set => textBoxName.Text = value;
        }

        public string Address
        {
            get => textBoxAddress.Text;
            set => textBoxAddress.Text = value;
        }

        public string Phone
        {
            get => textBoxPhone.Text.Trim();
            set => textBoxPhone.Text = value;
        }

        private void Country_OfSelectedIndex(object sender, EventArgs e)
        {
            CountryName = CountryChoices.SelectedValue.ToString();
        }

        public string GetSelectedCountry()
        {
            return CountryChoices.SelectedValue?.ToString() ?? string.Empty;
        }

        public string CountryName { get; set; }

        public string CityName
        {
            get => textBoxCity.Text;
            set => textBoxCity.Text = value;
        }

        public string PostalCode
        {
            get => textBoxPostal.Text;
            set => textBoxPostal.Text = value;
        }

        public string CustomerName
        {
            get => textBoxName.Text;
            set => textBoxName.Text = value;
        }

        private List<string> GetCountryNames() =>
            CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(cult => new RegionInfo(cult.LCID).DisplayName)
                .Distinct()
                .OrderBy(name => name)
                .ToList();
    }
}
