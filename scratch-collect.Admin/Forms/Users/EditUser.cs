using scratch_collect.Admin.Services;
using scratch_collect.Desktop.Services;
using scratch_collect.Desktop.Utilities;
using scratch_collect.Model.Desktop;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms.Users
{
    public partial class EditUser : Form
    {
        private AllUsers _parentForm;
        private string _userID;

        public EditUser(AllUsers parentForm, string userID)
        {
            // DI
            _parentForm = parentForm;
            _userID = userID;

            InitializeComponent();

            SetupInitialLayout();
            PrepareSystemRoleDropdown();
            FetchUserDetails(userID);
        }

        private async void PrepareSystemRoleDropdown()
        {
            role_combobox.Enabled = false;
            UseWaitCursor = true;

            try
            {
                var roles = await RoleService.GetAllRoles();

                if (roles != null)
                {
                    // Populate data
                    role_combobox.DataSource = roles;
                    role_combobox.DisplayMember = "Name";
                    role_combobox.ValueMember = "Id";

                    UseWaitCursor = false;
                    role_combobox.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while fetching list of all roles !");
            }
        }

        private void SetupInitialLayout()
        {
            // Hide validation labels
            validation_label.Text = "";
            validation_label.Visible = false;
        }

        private async void FetchUserDetails(string userID)
        {
            if (string.IsNullOrEmpty(userID)) return;

            UseWaitCursor = true;
            update_user_button.Enabled = false;

            try
            {
                var user = await UserService.GetUserById(userID);

                if (user != null)
                {
                    // Populate grid data
                    username_input.Text = user.Username;
                    email_input.Text = user.Email;
                    first_name_input.Text = user.FirstName;
                    last_name_input.Text = user.LastName;
                    address_input.Text = user.Address;

                    role_combobox.SelectedIndex = (int)user.Role.Id - 1;

                    PopulateUserImage(user.UserPhoto);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", " User", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetFormFields();
            }
            finally
            {
                UseWaitCursor = false;
                update_user_button.Enabled = true;
            }
        }

        private void PopulateUserImage(byte[]? photo)
        {
            if (photo == null)
            {
                SetDefaultProfileImage();
            }
            else
            {
                user_photo_preview.Image = ImageHelper.ByteToImage(photo);
            }
        }

        private void ResetFormFields()
        {
            // Populate grid data
            username_input.Text = "";
            email_input.Text = "";
            first_name_input.Text = "";
            last_name_input.Text = "";
            address_input.Text = "";

            role_combobox.SelectedIndex = 0;

            SetDefaultProfileImage();

            new_user_error_provider.Clear();
        }

        private void SetDefaultProfileImage()
        {
            user_photo_preview.Image = Properties.Resources.account;
        }

        private async void go_back_button_Click(object sender, EventArgs e)
        {
            // Data
            await _parentForm.FetchUsersData();

            // Show
            Close();
            _parentForm.Show();
        }

        private async void update_user_button_Click(object sender, EventArgs e)
        {
            var fieldsAreValid = validateAllFields();

            // Validate fields and show message
            if (!fieldsAreValid)
            {
                validation_label.Text = "* Please enter correct data and try again!";
                validation_label.Visible = true;

                return;
            }
            else
            {
                // Reset fields
                validation_label.Text = "";
                validation_label.Visible = false;
            }

            try
            {
                update_user_button.Enabled = false;
                UseWaitCursor = true;

                var model = new UserUpdateVM
                {
                    Id = _userID,
                    FirstName = first_name_input.Text,
                    LastName = last_name_input.Text,
                    Email = email_input.Text,
                    Username = username_input.Text,
                    Address = address_input.Text,
                    RoleId = (int)role_combobox.SelectedValue,
                    RegisteredAt = DateTime.Now,
                    UserPhoto = ImageHelper.ImageToByte(user_photo_preview.Image)
                };

                var updatedUser = await UserService.UpdateUser(model);

                if (updatedUser != null)
                {
                    MessageBox.Show("Successfully updated", " User", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FetchUserDetails(updatedUser.Id.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", " User", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
            finally
            {
                UseWaitCursor = false;
                update_user_button.Enabled = true;
            }
        }

        private void upload_profile_image_button_Click(object sender, EventArgs e)
        {
            // Open system dialog
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
                user_photo_preview.Image = Bitmap.FromFile(open.FileName);
        }

        private bool validateAllFields()
        {
            var usernameValid = validateUsername();
            var emailValid = validateEmail();
            var firstNameValid = validateFirstName();
            var lastNameValid = validateLastName();
            var addressValid = validateAddress();

            return usernameValid &&
                emailValid &&
                firstNameValid &&
                lastNameValid &&
                addressValid;
        }

        // Validation events
        private void username_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateUsername();
        }

        private bool validateUsername()
        {
            var value = username_input.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_user_error_provider.SetError(username_input, "Username is required!");
                return false;
            }
            // Max length
            else if (value.Length > 20)
            {
                new_user_error_provider.SetError(username_input, "Username cannot have more than 20 characters !");
                return false;
            }
            else
            {
                new_user_error_provider.Clear();
                return true;
            }
        }

        private void email_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateEmail();
        }

        private bool validateEmail()
        {
            var value = email_input.Text;
            // email regex
            Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");
            Match match = regex.Match(value);

            // required
            if (string.IsNullOrWhiteSpace(value))
            {
                new_user_error_provider.SetError(email_input, "Email field cannot be empty!");
                return false;
            }
            // max length < 100
            else if (value.Length > 100)
            {
                new_user_error_provider.SetError(email_input, "Email field cannot exceed 100 characters!");
                return false;
            }
            else if (!match.Success)
            {
                new_user_error_provider.SetError(email_input, "Email field must contain valid email address!");
                return false;
            }
            else
            {
                // reset errors
                new_user_error_provider.Clear();
                return true;
            }
        }

        private void first_name_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateFirstName();
        }

        private bool validateFirstName()
        {
            var value = first_name_input.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_user_error_provider.SetError(first_name_input, "Username is required!");
                return false;
            }
            // Max length
            else if (value.Length > 20)
            {
                new_user_error_provider.SetError(first_name_input, "First Name cannot have more than 20 characters !");
                return false;
            }
            else
            {
                new_user_error_provider.Clear();
                return true;
            }
        }

        private void last_name_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateLastName();
        }

        private bool validateLastName()
        {
            var value = last_name_input.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_user_error_provider.SetError(last_name_input, "Username is required!");
                return false;
            }
            // Max length
            else if (value.Length > 20)
            {
                new_user_error_provider.SetError(last_name_input, "First Name cannot have more than 20 characters !");
                return false;
            }
            else
            {
                new_user_error_provider.Clear();
                return true;
            }
        }

        private void address_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateAddress();
        }

        private bool validateAddress()
        {
            var value = address_input.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_user_error_provider.SetError(address_input, "Username is required!");
                return false;
            }
            // Max length
            else if (value.Length > 30)
            {
                new_user_error_provider.SetError(address_input, "First Name cannot have more than 30 characters !");
                return false;
            }
            else
            {
                new_user_error_provider.Clear();
                return true;
            }
        }
    }
}