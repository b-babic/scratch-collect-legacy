using scratch_collect.Admin.Reports;
using scratch_collect.Admin.Services;
using scratch_collect.Model;
using scratch_collect.Model.Report;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms
{
    public partial class AllOffers : Form
    {
        public AllOffers()
        {
            InitializeComponent();
        }

        // Generic events
        private async void AllOffers_Load(object sender, EventArgs e)
        {
            SetupInitialLayout();

            await FetchCategoriesData();
            await FetchOffersData();
        }

        // User events
        private async void offers_delete_button_Click(object sender, EventArgs e)
        {
            // Validation
            var selectedID = ValidateRowSelection("Delete Offer");
            if (selectedID == null) return;

            // Loading
            StartLoading();
            DisableFilterActionControls();

            try
            {
                var deleted = await OfferService.Delete((int)selectedID);

                if (deleted)
                {
                    MessageBox.Show("Offer successfully deleted", "Offer Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await FetchOffersData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong !", " Offer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                StopLoading();
                DeselectInitialColumns();
            }
        }

        private void offers_edit_button_Click(object sender, EventArgs e)
        {
            // Validation
            var selectedID = ValidateRowSelection("Edit Offer");
            if (selectedID == null) return;

            // Override styles
            var editForm = new EditOffer(this, selectedID.ToString());
            editForm.Location = Location;

            // Show
            editForm.ShowDialog();
            Hide();
        }

        private void offers_new_button_Click(object sender, EventArgs e)
        {
            var newPage = new NewOffer(this);

            // Override styles
            newPage.Location = Location;

            // Show
            newPage.ShowDialog();
            Hide();
        }

        private void offer_info_report_button_Click(object sender, EventArgs e)
        {
            // Validation
            var selectedID = ValidateRowSelection("Generate offer stats report");
            if (selectedID == null) return;

            // Override styles
            var offerStats = new OfferInfoForm(new OfferInfoRequest()
            {
                OfferId = Int32.Parse(selectedID.ToString()),
            });
            offerStats.Location = Location;

            // Show
            offerStats.ShowDialog();
            Hide();
        }

        private int? ValidateRowSelection(string title)
        {
            // Validation
            if (offers_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have to select a row !", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var selectedID = offers_datagrid.SelectedRows[0].Cells[0].Value;

            if (selectedID == null)
            {
                MessageBox.Show("You have to select an offer ID !", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (int)selectedID;
        }

        // Categories
        public async Task FetchCategoriesData()
        {
            StartLoading();

            try
            {
                var categories = await CategoryService.Get();

                if (categories != null) HandleCategoriesDataSuccess(categories);
            }
            catch (Exception)
            {
                HandleCategoriesDataError();
            }
            finally
            {
                StopLoading();
            }
        }

        private void HandleCategoriesDataSuccess(List<CategoryDTO> categories)
        {
            // Populate the category filter
            filter_category_combobox.DataSource = categories;
            filter_category_combobox.DisplayMember = "Name";
            filter_category_combobox.ValueMember = "Id";

            // Set default
            filter_category_combobox.SelectedIndex = 0;
        }

        private void HandleCategoriesDataError()
        {
            MessageBox.Show("Error getting categories! Please try again.", "Categories", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Offers
        public async Task FetchOffersData()
        {
            StartLoading();

            try
            {
                var offers = await OfferService.GetAll("3");

                if (offers != null) HandleDataSuccess(offers);
            }
            catch (Exception)
            {
                HandleDataError();
            }
            finally
            {
                StopLoading();
            }
        }

        private void HandleDataSuccess(List<OfferDTO> offers)
        {
            // Populate the grid and resize columns
            offers_datagrid.DataSource = offers;
            offers_datagrid.AutoResizeColumns();

            // Rename specific header columns
            offers_datagrid.Columns["Id"].HeaderText = "#ID";
            offers_datagrid.Columns["Title"].HeaderText = "Title";
            offers_datagrid.Columns["Description"].HeaderText = "Description";
            offers_datagrid.Columns["Quantity"].HeaderText = "Quantity";
            offers_datagrid.Columns["RequiredPrice"].HeaderText = "Price";
            offers_datagrid.Columns["CreatedAt"].HeaderText = "Created On";
            offers_datagrid.Columns["UpdatedAt"].HeaderText = "Updated On";
            offers_datagrid.Columns["Category"].HeaderText = "Category";

            // Override specific columns
            offers_datagrid.Columns["RecommendedItems"].Visible = false;

            // Disabled states
            EnableCommonElements();
        }

        private void HandleDataError()
        {
            MessageBox.Show("Error while loading offers ! Please try again.", "Offers Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Disabled states
            DisableCommonElements();
        }

        // Filters
        private async void offers_filter_button_Click(object sender, EventArgs e)
        {
            await FetchFilteredOffers();
        }

        private async Task FetchFilteredOffers()
        {
            // Prepare data
            var categoryValue = (int)filter_category_combobox.SelectedValue;
            if (categoryValue == 0) return;

            var categoryQuery = categoryValue.ToString();

            // Disabled states
            StartLoading();
            DisableCommonElements();

            try
            {
                var offers = await OfferService.GetAll(categoryQuery);

                if (offers != null && offers.Count > 0) HandleFilterSuccess(offers);
                else MessageBox.Show("No offers matching search criteria!", "Filter offers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                HandleDataError();
            }
            finally
            {
                EnableCommonElements();
                StopLoading();
            }
        }

        private void HandleFilterSuccess(List<OfferDTO> offers)
        {
            // Data
            offers_datagrid.DataSource = offers;
            offers_datagrid.Refresh();

            // Selection
            DeselectInitialColumns();

            // Disabled states
            EnableCommonElements();
        }

        // Selection
        private void offers_datagrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DeselectInitialColumns();
        }

        private void offers_datagrid_SelectionChanged(object sender, EventArgs e)
        {
            if (offers_datagrid.Focused) EnableFilterActionControls();
        }

        private void DeselectInitialColumns()
        {
            offers_datagrid.ClearSelection();
            offers_datagrid.Rows[0].Selected = false;
            offers_datagrid.CurrentCell = null;
        }

        // Helpers
        private void StartLoading()
        {
            UseWaitCursor = true;
        }

        private void StopLoading()
        {
            UseWaitCursor = false;
        }

        private void SetupInitialLayout()
        {
            // Default styles
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Disabled states
            DisableCommonElements();
        }

        private void DisableCommonElements()
        {
            // Disable grid
            offers_datagrid.Enabled = false;
            offers_datagrid.Visible = false;

            // Filter action controls
            DisableFilterActionControls();

            // Filters
            offers_filter_button.Enabled = false;
            filter_category_combobox.Enabled = false;
        }

        private void EnableCommonElements()
        {
            offers_datagrid.Enabled = true;
            offers_datagrid.Visible = true;

            offers_filter_button.Enabled = true;
            filter_category_combobox.Enabled = true;
        }

        private void DisableFilterActionControls()
        {
            // Disable edit button
            offers_edit_button.Enabled = false;
            offers_edit_button.Visible = false;
            // Disable delete button
            offers_delete_button.Enabled = false;
            offers_delete_button.Visible = false;
            // Report generate button
            offer_info_report_button.Enabled = false;
            offer_info_report_button.Visible = false;
        }

        private void EnableFilterActionControls()
        {
            // Disable edit button
            offers_edit_button.Enabled = true;
            offers_edit_button.Visible = true;
            // Disable delete button
            offers_delete_button.Enabled = true;
            offers_delete_button.Visible = true;
            // Report generate button
            offer_info_report_button.Enabled = true;
            offer_info_report_button.Visible = true;
        }
    }
}