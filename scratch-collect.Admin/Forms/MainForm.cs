using scratch_collect.Admin.Forms.Coupons;
using scratch_collect.Admin.Forms.Merchants;
using scratch_collect.Admin.Forms.Users;
using scratch_collect.Admin.Reports;
using scratch_collect.Admin.Services;
using scratch_collect.Model;
using scratch_collect.Model.Report;
using System;
using System.Threading.Tasks;
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

            PopulateReportsParams();
        }

        private void PopulateReportsParams()
        {
            PopulateSuccessReportParams();
        }

        private async Task PopulateSuccessReportParams()
        {
            UseWaitCursor = true;

            try
            {
                var categories = await CategoryService.Get();

                if (categories != null)
                {
                    // Populate data
                    offers_report_category_combobox.DataSource = categories;
                    offers_report_category_combobox.DisplayMember = "Name";
                    offers_report_category_combobox.ValueMember = "Id";

                    UseWaitCursor = false;
                    offers_report_category_combobox.Enabled = true;
                }

                // Date from two years ago
                var dummyYear = 2020;
                offers_report_date_from_picker.Value = new DateTime(dummyYear, 12, 31);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while fetching list of all categories !");
            }
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
            var request = new SuccessOffersRequest
            {
                CategoryId = ((CategoryDTO)offers_report_category_combobox.SelectedItem).Id,
                Category = ((CategoryDTO)offers_report_category_combobox.SelectedItem).Name,
                TimeFrom = offers_report_date_from_picker.Text,
                TimeTo = offers_report_date_to_picker.Text
            };

            var offersReport = new OffersReportForm(request);

            offersReport.ShowDialog();
        }

        private void btn_users_report_Click(object sender, EventArgs e)
        {
            var usersReport = new UsersReportForm();

            usersReport.ShowDialog();
        }

        // Helpers
        private static void FakeAuthentication()
        {
            AuthService.FakeAuthentication();
        }
    }
}