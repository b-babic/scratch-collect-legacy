using scratch_collect.Desktop.Services;
using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms.Coupons
{
    public partial class AllCoupons : Form
    {
        private readonly ICouponService _couponService;

        public AllCoupons()
        {
            InitializeComponent();

            // DI
            _couponService = (ICouponService)Program.ServiceProvider.GetService(typeof(ICouponService));
        }

        // Generic events
        private async void AllCoupons_Load(object sender, EventArgs e)
        {
            SetupInitialLayout();
            await FetchCouponsData();
        }

        // Coupon events
        private async void vouchers_delete_button_Click(object sender, EventArgs e)
        {
            // Validation
            var selectedID = ValidateRowSelection("Delete User");
            if (selectedID == null) return;

            // Loading
            StartLoading();
            DisableFilterActionControls();

            try
            {
                var deleted = await _couponService.DeleteCoupon((int)selectedID);

                if (deleted)
                {
                    MessageBox.Show("Coupon successfully deleted", "Coupon Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await FetchCouponsData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong !", " Coupon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                StopLoading();
                DeselectInitialColumns();
            }
        }

        private void vouchers_generate_button_Click(object sender, EventArgs e)
        {
            var generateCoupons = new GenerateCoupons(this);

            generateCoupons.Show();
            Hide();
        }

        private int? ValidateRowSelection(string title)
        {
            // Validation
            if (vouchers_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have to select a row !", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var selectedID = vouchers_datagrid.SelectedRows[0].Cells[0].Value;

            if (selectedID == null)
            {
                MessageBox.Show("You have to select a coupon ID !", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (int)selectedID;
        }

        // Data
        public async Task FetchCouponsData()
        {
            StartLoading();

            try
            {
                var coupons = await _couponService.GetAllVouchers();

                if (coupons != null)
                {
                    HandleDataSuccess(coupons);
                }
                else
                {
                    MessageBox.Show("Error while loading couposn. Please try again !", "Coupons loading", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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

        private void HandleDataSuccess(List<CouponDTO> coupons)
        {
            // Populate the grid and resize columns
            vouchers_datagrid.DataSource = coupons;
            vouchers_datagrid.AutoResizeColumns();

            // Rename specific header columns
            vouchers_datagrid.Columns["Id"].HeaderText = "#ID";
            vouchers_datagrid.Columns["Text"].HeaderText = "Text";
            vouchers_datagrid.Columns["Value"].HeaderText = "Value";
            vouchers_datagrid.Columns["CreatedAt"].HeaderText = "Created On";

            // Disabled states
            EnableCommonElements();
        }

        private void HandleDataError()
        {
            MessageBox.Show("Error while loading coupons ! Please try again.", "Coupons Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Disabled states
            DisableCommonElements();
        }

        // Filters
        private async void vouchers_filters_button_Click(object sender, EventArgs e)
        {
            await FetchFilteredCouponsData();
        }

        private async Task FetchFilteredCouponsData()
        {
            // Prepare data
            var textQuery = vouchers_text_filter.Text.Trim();

            // Disabled states
            StartLoading();
            DisableCommonElements();

            try
            {
                var coupons = await _couponService.GetAllVouchers(textQuery);

                if (coupons != null && coupons.Count > 0) HandleFilterSuccess(coupons);
                else MessageBox.Show("No coupons matching search criteria!", "Filter coupons", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void HandleFilterSuccess(List<CouponDTO> users)
        {
            // Data
            vouchers_datagrid.DataSource = users;
            vouchers_datagrid.Refresh();

            // Selection
            DeselectInitialColumns();

            // Disabled states
            EnableCommonElements();
        }

        // Selection
        private void users_datagrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DeselectInitialColumns();
        }

        private void users_datagrid_SelectionChanged(object sender, EventArgs e)
        {
            if (vouchers_datagrid.Focused) EnableFilterActionControls();
        }

        private void DeselectInitialColumns()
        {
            vouchers_datagrid.ClearSelection();
            vouchers_datagrid.Rows[0].Selected = false;
            vouchers_datagrid.CurrentCell = null;
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
            vouchers_datagrid.Enabled = false;
            vouchers_datagrid.Visible = false;

            // Filter action controls
            DisableFilterActionControls();

            // Filters
            vouchers_filter_button.Enabled = false;
            vouchers_text_filter.Enabled = false;
        }

        private void EnableCommonElements()
        {
            vouchers_datagrid.Enabled = true;
            vouchers_datagrid.Visible = true;

            vouchers_filter_button.Enabled = true;
            vouchers_text_filter.Enabled = true;
        }

        private void DisableFilterActionControls()
        {
            // Disable delete button
            vouchers_delete_button.Enabled = false;
            vouchers_delete_button.Visible = false;
        }

        private void EnableFilterActionControls()
        {
            // Disable delete button
            vouchers_delete_button.Enabled = true;
            vouchers_delete_button.Visible = true;
        }
    }
}