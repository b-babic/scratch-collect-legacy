using scratch_collect.Desktop.Services;
using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms
{
    public partial class AllWinnings : Form
    {
        public AllWinnings()
        {
            InitializeComponent();
        }

        // Generic events
        private async void AllWinnings_Load(object sender, EventArgs e)
        {
            SetupInitialLayout();
            await FetchWinnings();
        }

        // Selection
        private void winnings_datagrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DeselectInitialColumns();
        }

        // Data
        public async Task FetchWinnings()
        {
            StartLoading();

            // Prepare data
            var dateFromQuery = date_from_picker.Value;
            var dateToQuery = date_to_picker.Value;

            try
            {
                var merchants = await UserService.AllWonOffers(dateFromQuery, dateToQuery);

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

        private void HandleDataSuccess(List<UserOfferDTO> offers)
        {
            // Populate the grid and resize columns
            winnings_datagrid.DataSource = offers;
            winnings_datagrid.AutoResizeColumns();

            // Rename specific header columns
            winnings_datagrid.Columns["Id"].HeaderText = "#ID";
            winnings_datagrid.Columns["PlayedOn"].HeaderText = "PlayedOn";
            winnings_datagrid.Columns["Won"].HeaderText = "Won";
            winnings_datagrid.Columns["User"].HeaderText = "User";
            winnings_datagrid.Columns["Offer"].HeaderText = "Offer";

            // Override specific columns
            winnings_datagrid.Columns["Played"].Visible = false;
            winnings_datagrid.Columns["UserId"].Visible = false;
            winnings_datagrid.Columns["OfferId"].Visible = false;

            // Disabled states
            EnableCommonElements();
        }

        private void HandleDataError()
        {
            MessageBox.Show("Error while loading winnings ! Please try again.", "Winnings Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Disabled states
            DisableCommonElements();
        }

        // Filters
        // Filters
        private async void winnings_filter_button_Click(object sender, EventArgs e)
        {
            await FetchFilteredWinnings();
        }

        private async Task FetchFilteredWinnings()
        {
            // Prepare data
            var dateFromQuery = date_from_picker.Value;
            var dateToQuery = date_from_picker.Value;

            // Disabled states
            StartLoading();
            DisableCommonElements();

            try
            {
                var winnings = await UserService.AllWonOffers(dateFromQuery, dateToQuery);

                if (winnings != null && winnings.Count > 0) HandleFilterSuccess(winnings);
                else MessageBox.Show("No winnings matching search criteria!", "Filter winnings", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void HandleFilterSuccess(List<UserOfferDTO> winnings)
        {
            // Data
            winnings_datagrid.DataSource = winnings;
            winnings_datagrid.Refresh();

            // Selection
            DeselectInitialColumns();

            // Disabled states
            EnableCommonElements();
        }

        // Helpers
        private void DeselectInitialColumns()
        {
            winnings_datagrid.ClearSelection();
            winnings_datagrid.Rows[0].Selected = false;
            winnings_datagrid.CurrentCell = null;
        }

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

            // Set default date filters
            date_from_picker.Value = DateTime.Today.AddYears(-1);
            date_to_picker.Value = DateTime.Today;
        }

        private void DisableCommonElements()
        {
            // Disable grid
            winnings_datagrid.Enabled = false;
            winnings_datagrid.Visible = false;

            // Filters
            winnings_filter_button.Enabled = false;
            winnings_filter_button.Enabled = false;
        }

        private void EnableCommonElements()
        {
            winnings_datagrid.Enabled = true;
            winnings_datagrid.Visible = true;

            winnings_filter_button.Enabled = true;
            winnings_filter_button.Enabled = true;
        }
    }
}