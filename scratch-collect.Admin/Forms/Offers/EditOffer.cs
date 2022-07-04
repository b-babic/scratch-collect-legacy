using scratch_collect.Admin.Services;
using scratch_collect.Model.Enums;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms
{
    public partial class EditOffer : Form
    {
        private AllOffers _parentForm;
        private string _offerID;

        public EditOffer(AllOffers parentForm, string offerID)
        {
            InitializeComponent();

            // DI
            _parentForm = parentForm;
            _offerID = offerID;

            SetupInitialLayout();
            PreparePriceDropdown();
            PrepareCategoriesDropdown();

            FetchOfferDetails(offerID);
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

        // User events
        private async void edit_offer_button_Click(object sender, EventArgs e)
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

            try
            {
                edit_offer_button.Enabled = false;
                UseWaitCursor = true;

                var model = new OfferUpsertRequest
                {
                    Id = Int32.Parse(_offerID),
                    Title = title_input.Text,
                    Description = description_input.Text,
                    RequiredPrice = (int)price_combobox.SelectedValue,
                    Quantity = (int)quantity_input.Value,
                    CategoryId = (int)category_combobox.SelectedValue,
                    UpdatedAt = DateTime.Now
                };

                var updated = await OfferService.Update(model);

                if (updated != null)
                {
                    MessageBox.Show("Successfully updated", " Offer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FetchOfferDetails(updated.Id.ToString());
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
                edit_offer_button.Enabled = true;
            }
        }

        // Data
        private async void FetchOfferDetails(string offerID)
        {
            if (string.IsNullOrEmpty(offerID)) return;

            UseWaitCursor = true;
            edit_offer_button.Enabled = false;

            try
            {
                var offer = await OfferService.GetById(Int32.Parse(offerID));
                var currentCategory = category_combobox.SelectedValue;

                if (offer != null)
                {
                    var requiredPrice = offer.RequiredPrice;

                    // Populate grid data
                    title_input.Text = offer.Title;
                    description_input.Text = offer.Description;
                    quantity_input.Value = offer.Quantity;
                    price_combobox.SelectedIndex = GetRequiredPriceIndex(requiredPrice);
                    category_combobox.SelectedValue = (int)offer.Category.Id;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", " Offer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetFormFields();
            }
            finally
            {
                UseWaitCursor = false;
                edit_offer_button.Enabled = true;
            }
        }

        private int GetRequiredPriceIndex(int price)
        {
            switch (price)
            {
                case 15:
                    return 0;

                case 30:
                    return 1;

                case 50:
                    return 2;

                default:
                    return 0;
            }
        }

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
                var categories = await CategoryService.Get();

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
                edit_offer_error_provider.SetError(price_combobox, "Price is required!");
                return false;
            }
            else
            {
                edit_offer_error_provider.Clear();
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
                edit_offer_error_provider.SetError(category_combobox, "Category is required!");
                return false;
            }
            else
            {
                edit_offer_error_provider.Clear();
                return true;
            }
        }

        private bool validateRequiredText(TextBox control, string requiredMessage, string lengthMessage)
        {
            var value = control.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                edit_offer_error_provider.SetError(control, requiredMessage);
                return false;
            }
            // Max length
            else if (value.Length > 30)
            {
                edit_offer_error_provider.SetError(control, lengthMessage);
                return false;
            }
            else
            {
                edit_offer_error_provider.Clear();
                return true;
            }
        }

        private bool validateRequiredText(RichTextBox control, string requiredMessage, string lengthMessage)
        {
            var value = control.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                edit_offer_error_provider.SetError(control, requiredMessage);
                return false;
            }
            // Max length
            else if (value.Length > 30)
            {
                edit_offer_error_provider.SetError(control, lengthMessage);
                return false;
            }
            else
            {
                edit_offer_error_provider.Clear();
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

            edit_offer_error_provider.Clear();
        }
    }
}