using scratch_collect.Admin.Services;
using scratch_collect.Model;
using scratch_collect.Model.Desktop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms.Merchants
{
    public partial class AllMerchants : Form
    {
        public AllMerchants()
        {
            InitializeComponent();
        }

        // Generic events
        private async void AllMerchants_Load(object sender, EventArgs e)
        {
            SetupInitialLayout();
            await FetchMerchantsData();
        }

        // User events
        private void merchants_new_button_Click(object sender, EventArgs e)
        {
            var newPage = new NewMerchant(this);

            // Override styles
            newPage.Location = Location;

            // Show
            newPage.ShowDialog();
            Hide();
        }

        private void merchants_edit_button_Click(object sender, EventArgs e)
        {
            // Validation
            var selectedID = ValidateRowSelection("Edit Merchant");
            if (selectedID == null) return;

            // Override styles
            var editForm = new EditMerchant(this, selectedID.ToString());
            editForm.Location = Location;

            // Show
            editForm.ShowDialog();
            Hide();
        }

        private async void merchants_delete_button_Click(object sender, EventArgs e)
        {
            // Validation
            var selectedID = ValidateRowSelection("Delete Merchant");
            if (selectedID == null) return;

            // Loading
            StartLoading();
            DisableFilterActionControls();

            try
            {
                var deleted = await MerchantService.Delete((int)selectedID);

                if (deleted)
                {
                    MessageBox.Show("Merchant successfully deleted", "Merchant Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await FetchMerchantsData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong !", " Merchant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                StopLoading();
                DeselectInitialColumns();
            }
        }

        private int? ValidateRowSelection(string title)
        {
            // Validation
            if (merchants_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have to select a row !", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var selectedID = merchants_datagrid.SelectedRows[0].Cells[0].Value;

            if (selectedID == null)
            {
                MessageBox.Show("You have to select a merchant ID !", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (int)selectedID;
        }

        // Merchants
        public async Task FetchMerchantsData()
        {
            StartLoading();

            try
            {
                var merchants = await MerchantService.GetAll();

                if (merchants != null) HandleDataSuccess(merchants);
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

        private void HandleDataSuccess(List<MerchantDTO> merchants)
        {
            // Populate the grid and resize columns
            merchants_datagrid.DataSource = merchants;
            merchants_datagrid.AutoResizeColumns();

            // Rename specific header columns
            merchants_datagrid.Columns["Id"].HeaderText = "#ID";
            merchants_datagrid.Columns["Name"].HeaderText = "Name";
            merchants_datagrid.Columns["Address"].HeaderText = "Address";
            merchants_datagrid.Columns["Telephone"].HeaderText = "Telephone";
            merchants_datagrid.Columns["Country"].HeaderText = "Country";

            // Override specific columns

            // Disabled states
            EnableCommonElements();
        }

        private void HandleDataError()
        {
            MessageBox.Show("Error while loading merchants ! Please try again.", "Merchants Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Disabled states
            DisableCommonElements();
        }

        // Filters
        private async void merchants_filter_button_Click(object sender, EventArgs e)
        {
            await FetchFilteredMerchants();
        }

        private async Task FetchFilteredMerchants()
        {
            // Prepare data
            var textQuery = merchants_text_filter.Text.Trim();
            var countryQuery = merchants_country_filter.Text.Trim();

            // Disabled states
            StartLoading();
            DisableCommonElements();

            try
            {
                var merchants = await MerchantService.GetAll(textQuery, countryQuery);

                if (merchants != null && merchants.Count > 0) HandleFilterSuccess(merchants);
                else MessageBox.Show("No merchants matching search criteria!", "Filter merchants", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void HandleFilterSuccess(List<MerchantDTO> merchants)
        {
            // Data
            merchants_datagrid.DataSource = merchants;
            merchants_datagrid.Refresh();

            // Selection
            DeselectInitialColumns();

            // Disabled states
            EnableCommonElements();
        }

        // Selection
        private void merchants_datagrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DeselectInitialColumns();
        }

        private void merchants_datagrid_SelectionChanged(object sender, EventArgs e)
        {
            if (merchants_datagrid.Focused) EnableFilterActionControls();
        }

        private void DeselectInitialColumns()
        {
            merchants_datagrid.ClearSelection();
            merchants_datagrid.Rows[0].Selected = false;
            merchants_datagrid.CurrentCell = null;
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
            merchants_datagrid.Enabled = false;
            merchants_datagrid.Visible = false;

            // Filter action controls
            DisableFilterActionControls();

            // Filters
            merchants_filter_button.Enabled = false;
            merchants_text_filter.Enabled = false;
        }

        private void EnableCommonElements()
        {
            merchants_datagrid.Enabled = true;
            merchants_datagrid.Visible = true;

            merchants_filter_button.Enabled = true;
            merchants_text_filter.Enabled = true;
        }

        private void DisableFilterActionControls()
        {
            // Disable edit button
            merchants_edit_button.Enabled = false;
            merchants_edit_button.Visible = false;
            // Disable delete button
            merchants_delete_button.Enabled = false;
            merchants_delete_button.Visible = false;
        }

        private void EnableFilterActionControls()
        {
            // Disable edit button
            merchants_edit_button.Enabled = true;
            merchants_edit_button.Visible = true;
            // Disable delete button
            merchants_delete_button.Enabled = true;
            merchants_delete_button.Visible = true;
        }
    }
}