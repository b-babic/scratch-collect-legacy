using scratch_collect.Desktop.Forms.Users;
using scratch_collect.Desktop.Services;
using scratch_collect.Desktop.Services.Authentication;
using scratch_collect.Model.Desktop;
using System;
using System.Collections.Generic;
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
            // Default styles
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Hide initial elements
            usersDataGrid.Visible = false;
            DisableDeleteButton();
        }

        private static void FakeAuthentication()
        {
            AuthenticationService.FakeAuthentication();
        }

        public async Task FetchUsersPageData()
        {
            UseWaitCursor = true;

            try
            {
                var users = await _userService.GetAllUsers();

                if (users != null)
                {
                    await HandleDataSuccess(users);
                }
            }
            catch (Exception)
            {
                await HandleDataError();
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

        private async void filter_users_button_Click(object sender, EventArgs e)
        {
            await FilterUsers();
        }

        private async Task FilterUsers()
        {
            var emailQuery = filter_users_email.Text.Trim();
            var usernameQuery = filter_users_username.Text.Trim();

            UseWaitCursor = true;
            filter_users_button.Enabled = false;

            try
            {
                var users = await _userService.GetAllUsers(emailQuery, usernameQuery);

                if (users != null && users.Count > 0)
                {
                    usersDataGrid.DataSource = users;
                    usersDataGrid.Refresh();
                }
                else
                {
                    MessageBox.Show("No users matching search criteria!");
                }

                filter_users_button.Enabled = true;
                UseWaitCursor = false;
            }
            catch (Exception)
            {
                await HandleDataError();
            }
        }

        private Task HandleDataSuccess(List<UserVM> users)
        {
            // Populate the grid and resize columns
            usersDataGrid.DataSource = users;
            usersDataGrid.AutoResizeColumns();
            // Rename specific header columns
            usersDataGrid.Columns["Id"].HeaderText = "#ID";
            usersDataGrid.Columns["FirstName"].HeaderText = "First Name";
            usersDataGrid.Columns["LastName"].HeaderText = "Last Name";
            usersDataGrid.Columns["RegisteredAt"].HeaderText = "Registration Date";
            usersDataGrid.Columns["Role"].HeaderText = "Role";
            // Override specific columns
            usersDataGrid.Columns["UserPhoto"].Visible = false;

            usersDataGrid.Visible = true;
            UseWaitCursor = false;

            return Task.CompletedTask;
        }

        private Task HandleDataError()
        {
            MessageBox.Show("Error while loading users!");

            usersDataGrid.Enabled = false;
            usersDataGrid.Visible = false;

            UseWaitCursor = false;

            return Task.CompletedTask;
        }

        private void new_user_button_Click(object sender, EventArgs e)
        {
            var newUserForm = new NewUserForm(this);
            newUserForm.Location = this.Location;

            newUserForm.Show();
            Hide();
        }

        private void usersDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (usersDataGrid.Focused)
            {
                EnableDeleteButton();
            }
        }

        private void usersDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            usersDataGrid.ClearSelection();
            usersDataGrid.Rows[0].Selected = false;
            usersDataGrid.CurrentCell = null;
        }

        // Delete a user
        private async void delete_user_button_Click(object sender, EventArgs e)
        {
            if (usersDataGrid.Focused) return;

            if (usersDataGrid.SelectedRows.Count == 0) return;

            var toDeleteID = usersDataGrid.SelectedRows[0].Cells[0].Value;

            if (toDeleteID == null) return;

            DisableDeleteButton();
            UseWaitCursor = true;

            try
            {
                var deleted = await _userService.DeleteUser((int)toDeleteID);

                if (deleted)
                {
                    MessageBox.Show("Successfully deleted", " User", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DisableDeleteButton();
                    await FetchUsersPageData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong !", " User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableDeleteButton();

                throw;
            }
            finally
            {
                UseWaitCursor = false;
                usersDataGrid.ClearSelection();
            }
        }

        // Helpers
        private void DisableDeleteButton()
        {
            delete_user_button.Enabled = false;
            delete_user_button.Visible = false;
        }

        private void EnableDeleteButton()
        {
            delete_user_button.Enabled = true;
            delete_user_button.Visible = true;
        }
    }
}