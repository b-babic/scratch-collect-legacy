using scratch_collect.Admin.Forms.Coupons;
using scratch_collect.Admin.Forms.Merchants;
using scratch_collect.Admin.Forms.Users;
using scratch_collect.Admin.Reports;
using scratch_collect.Admin.Services;
using System;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // TODO: Remove this before MVP
            // Fake Authentication for DEV purposes.
            FakeAuthentication();
        }

        // Generic Events
        private void users_control_menu_Click(object sender, EventArgs e)
        {
            var homepage = new AllUsers();

            homepage.ShowDialog();
        }

        private void vouchers_control_menu_Click(object sender, EventArgs e)
        {
            var vouchers = new AllCoupons();

            vouchers.ShowDialog();
        }

        private void merchants_control_menu_Click(object sender, EventArgs e)
        {
            var merchants = new AllMerchants();

            merchants.ShowDialog();
        }

        private void offers_control_menu_Click(object sender, EventArgs e)
        {
            var offers = new AllOffers();

            offers.ShowDialog();
        }

        private void winnings_control_menu_Click(object sender, EventArgs e)
        {
            var winnings = new AllWinnings();

            winnings.ShowDialog();
        }

        private void btn_offers_report_Click(object sender, EventArgs e)
        {
            var offersReport = new OffersReportForm();

            offersReport.ShowDialog();
        }

        // Helpers
        private static void FakeAuthentication()
        {
            AuthService.FakeAuthentication();
        }
    }
}