using scratch_collect.Desktop.Services;
using scratch_collect.Model.Enums;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms
{
    public partial class NewOffer : Form
    {
        private readonly IOfferService _offerService;
        private readonly ICategoryService _categoryService;
        private AllOffers _parentForm;

        public NewOffer(AllOffers parentForm)
        {
            InitializeComponent();

            // DI
            _offerService = (IOfferService)Program.ServiceProvider.GetService(typeof(IOfferService));
            _categoryService = (ICategoryService)Program.ServiceProvider.GetService(typeof(ICategoryService));
            _parentForm = parentForm;

            SetupInitialLayout();
            PreparePriceDropdown();
            PrepareCategoriesDropdown();
        }

        // Generic events
        private async void go_back_button_Click(object sender, EventArgs e)
        {
            // Data
            await _parentForm.FetchOffersData();

            // Show
            Close();
            _parentForm.Show();
        }

        // Submit handler
        private async void create_offer_button_Click(object sender, EventArgs e)
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
                create_offer_button.Enabled = false;
                UseWaitCursor = true;

                var model = new OfferUpsertRequest
                {
                    Title = title_input.Text,
                    Description = description_input.Text,
                    RequiredPrice = (int)price_combobox.SelectedValue,
                    Quantity = (int)quantity_input.Value,
                    CategoryId = (int)category_combobox.SelectedValue,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var newOffer = await _offerService.Insert(model);

                if (newOffer != null)
                {
                    MessageBox.Show("Successfully created", " Offer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetFormFields();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", " Offer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
            finally
            {
                UseWaitCursor = false;
                create_offer_button.Enabled = true;
            }
        }

        // Data
        private void PreparePriceDropdown()
        {
            price_combobox.DataSource = new List<int>() { (int)CouponValues.Small, (int)CouponValues.Medium, (int)CouponValues.Large };

            price_combobox.SelectedIndex = 0;
        }

        private async void PrepareCategoriesDropdown()
        {
            category_combobox.Enabled = false;
            UseWaitCursor = true;

            try
            {
                var categories = await _categoryService.Get();

                if (categories != null)
                {
                    // Populate data
                    category_combobox.DataSource = categories;
                    category_combobox.DisplayMember = "Name";
                    category_combobox.ValueMember = "Id";

                    UseWaitCursor = false;
                    category_combobox.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while fetching list of all categories !");
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
            title_input.Text = "";
            description_input.Text = "";
            price_combobox.SelectedIndex = 1;
            category_combobox.SelectedIndex = 1;

            new_offer_error_provider.Clear();
        }

        // Validation events
        private void title_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateTitle();
        }

        private bool validateTitle()
        {
            return validateRequiredText(title_input, "Title is required!", "Title cannot have more than 100 characters !");
        }

        private void description_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDescription();
        }

        private bool validateDescription()
        {
            return validateRequiredText(description_input, "Description is required !", "Description cannot have more than 100 characters!");
        }

        private void price_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validatePrice();
        }

        private bool validatePrice()
        {
            var value = price_combobox.SelectedIndex;

            if (value < 0)
            {
                new_offer_error_provider.SetError(price_combobox, "Price is required!");
                return false;
            }
            else
            {
                new_offer_error_provider.Clear();
                return true;
            }
        }

        private void category_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateCategory();
        }

        private bool validateCategory()
        {
            var value = category_combobox.SelectedIndex;

            if (value < 0)
            {
                new_offer_error_provider.SetError(category_combobox, "Category is required!");
                return false;
            }
            else
            {
                new_offer_error_provider.Clear();
                return true;
            }
        }

        private bool validateRequiredText(TextBox control, string requiredMessage, string lengthMessage)
        {
            var value = control.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_offer_error_provider.SetError(control, requiredMessage);
                return false;
            }
            // Max length
            else if (value.Length > 30)
            {
                new_offer_error_provider.SetError(control, lengthMessage);
                return false;
            }
            else
            {
                new_offer_error_provider.Clear();
                return true;
            }
        }

        private bool validateRequiredText(RichTextBox control, string requiredMessage, string lengthMessage)
        {
            var value = control.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_offer_error_provider.SetError(control, requiredMessage);
                return false;
            }
            // Max length
            else if (value.Length > 30)
            {
                new_offer_error_provider.SetError(control, lengthMessage);
                return false;
            }
            else
            {
                new_offer_error_provider.Clear();
                return true;
            }
        }

        private bool validateAllFields()
        {
            var titleValid = validateTitle();
            var descriptionValid = validateDescription();
            var priceValid = validatePrice();
            var categoryValid = validateCategory();

            return titleValid &&
                descriptionValid &&
                priceValid &&
                categoryValid;
        }
    }
}