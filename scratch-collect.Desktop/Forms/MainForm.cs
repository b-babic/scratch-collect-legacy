using scratch_collect.Desktop.Forms.Coupons;
using scratch_collect.Desktop.Forms.Merchants;
using scratch_collect.Desktop.Forms.Users;
using scratch_collect.Desktop.Services;
using scratch_collect.Desktop.Services.Authentication;
using System;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms
{
    public partial class MainForm : Form
    {
        private readonly IUserService _userService;

        public MainForm()
        {
            InitializeComponent();
            // Fake Authentication for DEV purposes.
            FakeAuthentication();

            // DI
            _userService = (IUserService)Program.ServiceProvider.GetService(typeof(IUserService));
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

        // Helpers
        private static void FakeAuthentication()
        {
            AuthenticationService.FakeAuthentication();
        }
    }
}