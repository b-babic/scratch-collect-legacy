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

namespace scratch_collect.Desktop.Controls
{
    public partial class VoucherPage : UserControl
    {
        private readonly IVoucherService _voucherService;

        public VoucherPage()
        {
            InitializeComponent();

            // DI
            _voucherService = (IVoucherService)Program.ServiceProvider.GetService(typeof(IVoucherService));

            // Setup
            SetupInitialLayout();
            FetchVouchersData();
        }

        public async Task Setup()
        {
            // Setup
            SetupInitialLayout();
            await FetchVouchersData();
        }

        private void SetupInitialLayout()
        {
            // Hide initial elements
            vouchers_datagrid.Visible = false;
        }

        public async Task FetchVouchersData()
        {
            UseWaitCursor = true;

            try
            {
                var vouchers = await _voucherService.GetAllVouchers();

                if (vouchers != null)
                {
                    await HandleDataSuccess(vouchers);
                }
            }
            catch (Exception)
            {
                await HandleDataError();
            }
        }

        private Task HandleDataSuccess(List<CouponDTO> vouchers)
        {
            // Populate the grid and resize columns
            vouchers_datagrid.DataSource = vouchers;
            vouchers_datagrid.AutoResizeColumns();
            // Rename specific header columns
            vouchers_datagrid.Columns["Id"].HeaderText = "#ID";
            vouchers_datagrid.Columns["Text"].HeaderText = "Text";
            vouchers_datagrid.Columns["Value"].HeaderText = "Value";
            vouchers_datagrid.Columns["CreatedAt"].HeaderText = "Created on";

            vouchers_datagrid.Visible = true;
            UseWaitCursor = false;

            return Task.CompletedTask;
        }

        private Task HandleDataError()
        {
            MessageBox.Show("Error while loading users!");

            vouchers_datagrid.Enabled = false;
            vouchers_datagrid.Visible = false;

            UseWaitCursor = false;

            return Task.CompletedTask;
        }
    }
}