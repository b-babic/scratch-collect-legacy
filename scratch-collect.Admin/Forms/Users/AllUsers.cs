using scratch_collect.Desktop.Services;
using scratch_collect.Model.Desktop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms.Users
{
    public partial class AllUsers : Form
    {
        public AllUsers()
        {
            InitializeComponent();
        }

        // Generic events
        private async void AllUsers_Load(object sender, EventArgs e)
        {
            SetupInitialLayout();
            await FetchUsersData();
        }

        // User events
        private void users_new_button_Click(object sender, EventArgs e)
        {
            var newPage = new NewUserForm(this);

            // Override styles
            newPage.Location = Location;

            // Show
            newPage.Show();
            Hide();
        }

        private void users_edit_button_Click(object sender, EventArgs e)
        {
            // Validation
            var selectedID = ValidateRowSelection("Edit User");
            if (selectedID == null) return;

            // Override styles
            var editForm = new EditUser(this, selectedID.ToString());
            editForm.Location = Location;

            // Show
            editForm.Show();
            Hide();
        }

        private async void users_delete_button_Click(object sender, EventArgs e)
        {
            // Validation
            var selectedID = ValidateRowSelection("Delete User");
            if (selectedID == null) return;

            // Loading
            StartLoading();
            DisableFilterActionControls();

            try
            {
                var deleted = await UserService.DeleteUser((int)selectedID);

                if (deleted)
                {
                    MessageBox.Show("User successfully delete", "User Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await FetchUsersData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong !", " User", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (users_datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("You have to select a row !", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var selectedID = users_datagrid.SelectedRows[0].Cells[0].Value;

            if (selectedID == null)
            {
                MessageBox.Show("You have to select a user ID !", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (int)selectedID;
        }

        // Users
        public async Task FetchUsersData()
        {
            StartLoading();

            try
            {
                var users = await UserService.GetAllUsers();

                if (users != null) HandleDataSuccess(users);
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

        private void HandleDataSuccess(List<UserVM> users)
        {
            // Populate the grid and resize columns
            users_datagrid.DataSource = users;
            users_datagrid.AutoResizeColumns();

            // Rename specific header columns
            users_datagrid.Columns["Id"].HeaderText = "#ID";
            users_datagrid.Columns["FirstName"].HeaderText = "First Name";
            users_datagrid.Columns["LastName"].HeaderText = "Last Name";
            users_datagrid.Columns["RegisteredAt"].HeaderText = "Registration Date";
            users_datagrid.Columns["Role"].HeaderText = "Role";

            // Override specific columns
            users_datagrid.Columns["UserPhoto"].Visible = false;

            // Disabled states
            EnableCommonElements();
        }

        private void HandleDataError()
        {
            MessageBox.Show("Error while loading users ! Please try again.", "Users Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Disabled states
            DisableCommonElements();
        }

        // Filters
        private async void users_filter_button_Click(object sender, EventArgs e)
        {
            await FetchFilteredUsers();
        }

        private async Task FetchFilteredUsers()
        {
            // Prepare data
            var emailQuery = users_email_filter.Text.Trim();
            var usernameQuery = users_username_filter.Text.Trim();

            // Disabled states
            StartLoading();
            DisableCommonElements();

            try
            {
                var users = await UserService.GetAllUsers(emailQuery, usernameQuery);

                if (users != null && users.Count > 0) HandleFilterSuccess(users);
                else MessageBox.Show("No users matching search criteria!", "Filter users", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void HandleFilterSuccess(List<UserVM> users)
        {
            // Data
            users_datagrid.DataSource = users;
            users_datagrid.Refresh();

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
            if (users_datagrid.Focused) EnableFilterActionControls();
        }

        private void DeselectInitialColumns()
        {
            users_datagrid.ClearSelection();
            users_datagrid.Rows[0].Selected = false;
            users_datagrid.CurrentCell = null;
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
            users_datagrid.Enabled = false;
            users_datagrid.Visible = false;

            // Filter action controls
            DisableFilterActionControls();

            // Filters
            users_filter_button.Enabled = false;
            users_username_filter.Enabled = false;
            users_email_filter.Enabled = false;
        }

        private void EnableCommonElements()
        {
            users_datagrid.Enabled = true;
            users_datagrid.Visible = true;

            users_filter_button.Enabled = true;
            users_username_filter.Enabled = true;
            users_email_filter.Enabled = true;
        }

        private void DisableFilterActionControls()
        {
            // Disable edit button
            users_edit_button.Enabled = false;
            users_edit_button.Visible = false;
            // Disable delete button
            users_delete_button.Enabled = false;
            users_delete_button.Visible = false;
        }

        private void EnableFilterActionControls()
        {
            // Disable edit button
            users_edit_button.Enabled = true;
            users_edit_button.Visible = true;
            // Disable delete button
            users_delete_button.Enabled = true;
            users_delete_button.Visible = true;
        }
    }
}