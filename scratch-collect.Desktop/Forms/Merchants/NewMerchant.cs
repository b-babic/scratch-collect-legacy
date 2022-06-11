using scratch_collect.Desktop.Services;
using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms.Merchants
{
    public partial class NewMerchant : Form
    {
        private readonly IMerchantService _merchantService;
        private readonly ICountryService _countryService;
        private AllMerchants _parentForm;

        public NewMerchant(AllMerchants parentForm)
        {
            InitializeComponent();

            // DI
            _merchantService = (IMerchantService)Program.ServiceProvider.GetService(typeof(IMerchantService));
            _countryService = (ICountryService)Program.ServiceProvider.GetService(typeof(ICountryService));
            _parentForm = parentForm;

            SetupInitialLayout();
            PrepareSystemRoleDropdown();
        }

        // Generic events
        private async void go_back_button_Click(object sender, EventArgs e)
        {
            // Data
            await _parentForm.FetchMerchantsData();

            // Show
            _parentForm.Show();
            Close();
        }

        // Submit handler
        private async void create_merchant_button_Click(object sender, EventArgs e)
        {
            var fieldsAreValid = validateAllFields();

            // Validate fields and show message
            if (!fieldsAreValid)
            {
                validation_label.Text = "* Please enter correct data and try again!";
                validation_label.Visible = true;

                return;
            }
            else
            {
                // Reset fields
                validation_label.Text = "";
                validation_label.Visible = false;
            }

            // Prepare the data
            try
            {
                create_merchant_button.Enabled = false;
                UseWaitCursor = true;

                var model = new MerchantUpsertRequest
                {
                    Name = name_input.Text,
                    Address = address_input.Text,
                    Telephone = telephone_input.Text,
                    CountryId = (int)country_combobox.SelectedValue,
                    CreatedAt = DateTime.Now
                };

                var newMerchant = await _merchantService.Insert(model);

                if (newMerchant != null)
                {
                    MessageBox.Show("Successfully created", " Merchant", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetFormFields();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", " Merchant", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
            finally
            {
                UseWaitCursor = false;
                create_merchant_button.Enabled = true;
            }
        }

        // Data
        private async void PrepareSystemRoleDropdown()
        {
            country_combobox.Enabled = false;
            UseWaitCursor = true;

            try
            {
                var countries = await _countryService.GetAll();

                if (countries != null)
                {
                    // Populate data
                    country_combobox.DataSource = countries;
                    country_combobox.DisplayMember = "Name";
                    country_combobox.ValueMember = "Id";

                    UseWaitCursor = false;
                    country_combobox.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while fetching list of all countries !");
            }
        }

        // Helpers
        private void SetupInitialLayout()
        {
            // Hide validation labels
            validation_label.Text = "";
            validation_label.Visible = false;
        }

        private void ResetFormFields()
        {
            name_input.Text = "";
            address_input.Text = "";
            telephone_input.Text = "";
            country_combobox.SelectedIndex = 0;

            new_merchant_error_provider.Clear();
        }

        // Validation events
        private void name_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateName();
        }

        private bool validateName()
        {
            return validateRequiredText(name_input, "Name is required!", "Name cannot have more than 30 characters !");
        }

        private void address_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateAddress();
        }

        private bool validateAddress()
        {
            return validateRequiredText(address_input, "Address is required !", "Address cannot have more than 30 characters!");
        }

        private void telephone_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateTelephone();
        }

        private bool validateTelephone()
        {
            var value = telephone_input.Text;

            MatchCollection match = Regex.Matches(value, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_merchant_error_provider.SetError(telephone_input, "Telephone is required !");
                return false;
            }
            else if (match.Count <= 0)
            {
                new_merchant_error_provider.SetError(telephone_input, "Telephone requires valid number !");
                return false;
            }
            else
            {
                new_merchant_error_provider.Clear();
                return true;
            }
        }

        private bool validateRequiredText(TextBox control, string requiredMessage, string lengthMessage)
        {
            var value = control.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_merchant_error_provider.SetError(control, requiredMessage);
                return false;
            }
            // Max length
            else if (value.Length > 30)
            {
                new_merchant_error_provider.SetError(control, lengthMessage);
                return false;
            }
            else
            {
                new_merchant_error_provider.Clear();
                return true;
            }
        }

        private bool validateAllFields()
        {
            var nameValid = validateName();
            var addressValid = validateAddress();
            var telephoneValid = validateTelephone();

            return nameValid &&
                addressValid &&
                telephoneValid;
        }
    }
}