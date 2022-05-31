using scratch_collect.Desktop.Services;
using scratch_collect.Desktop.Services.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms
{
    public partial class Homepage : Form
    {
        private readonly IUserService _userService;

        public Homepage()
        {
            InitializeComponent();
            // Fake Authentication for DEV purposes.
            FakeAuthentication();

            _userService = (IUserService)Program.ServiceProvider.GetService(typeof(IUserService));
        }

        private void SetupInitialLayout()
        {
            // Hide initial elements
            usersDataGrid.Visible = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private static void FakeAuthentication()
        {
            AuthenticationService.FakeAuthentication();
        }

        private async Task FetchUsersPageData()
        {
            UseWaitCursor = true;

            try
            {
                var users = await _userService.GetAllUsers();

                if (users != null)
                {
                    // Populate the grid and resize columns
                    usersDataGrid.DataSource = users;
                    usersDataGrid.AutoResizeColumns();
                    // Rename specific header columns
                    usersDataGrid.Columns["Id"].HeaderText = "#ID";
                    usersDataGrid.Columns["FirstName"].HeaderText = "First Name";
                    usersDataGrid.Columns["LastName"].HeaderText = "Last Name";
                    usersDataGrid.Columns["RegisteredAt"].HeaderText = "Registration Date";
                    usersDataGrid.Columns["UserRole"].HeaderText = "User Role";
                    // Override specific columns
                    usersDataGrid.Columns["UserPhoto"].Visible = false;

                    usersDataGrid.Visible = true;
                    UseWaitCursor = false;
                }
            }
            catch (Exception)
            {
                // TODO: Show validation label or placeholder screen instead of data grid ?
                MessageBox.Show("Error while loading users!");

                usersDataGrid.Enabled = false;
                usersDataGrid.Visible = false;

                UseWaitCursor = false;
            }
        }

        private void ConstructNavigation()
        {
            tabPage1.Text = "Users";
            tabPage2.Text = "Vouchers";
            tabPage3.Text = "Offers";
            tabPage4.Text = "Winnings";
        }

        private async void Homepage_Load(object sender, EventArgs e)
        {
            ConstructNavigation();
            SetupInitialLayout();
            await FetchUsersPageData();
        }
    }
}