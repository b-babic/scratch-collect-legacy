using scratch_collect.Desktop.Services;
using scratch_collect.Desktop.Utilities;
using scratch_collect.Model.Desktop;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms.Users
{
    public partial class NewUserForm : Form
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private AllUsers _parentForm;

        public NewUserForm(AllUsers parentForm)
        {
            InitializeComponent();

            // DI
            _userService = (IUserService)Program.ServiceProvider.GetService(typeof(IUserService));
            _roleService = (IRoleService)Program.ServiceProvider.GetService(typeof(IRoleService));
            _parentForm = parentForm;

            SetupInitialLayout();
            PrepareSystemRoleDropdown();
        }

        private async void PrepareSystemRoleDropdown()
        {
            role_combobox.Enabled = false;
            UseWaitCursor = true;

            try
            {
                var roles = await _roleService.GetAllRoles();

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

        private async void go_back_button_Click(object sender, EventArgs e)
        {
            // Data
            await _parentForm.FetchUsersData();

            // Show
            Close();
            _parentForm.Show();
        }

        private void upload_profile_image_button_Click(object sender, EventArgs e)
        {
            // Open system dialog
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
                user_photo_preview.Image = Bitmap.FromFile(open.FileName);
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

        private void password_input_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validatePassword();
        }

        private bool validatePassword()
        {
            var value = password_input.Text;

            // Required
            if (string.IsNullOrEmpty(value))
            {
                new_user_error_provider.SetError(password_input, "Password is required!");
                return false;
            }
            // Max length
            else if (value.Length > 50)
            {
                new_user_error_provider.SetError(password_input, "Password cannot have more than 50 characters !");
                return false;
            }
            // Reset password
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

        // Submit handler
        private async void create_user_button_Click(object sender, EventArgs e)
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

            // Prepare the data
            try
            {
                create_user_button.Enabled = false;
                UseWaitCursor = true;

                var model = new UserCreateVM
                {
                    FirstName = first_name_input.Text,
                    LastName = last_name_input.Text,
                    Email = email_input.Text,
                    Password = password_input.Text,
                    Username = username_input.Text,
                    Address = address_input.Text,
                    RoleId = (int)role_combobox.SelectedValue,
                    RegisteredAt = DateTime.Now,
                    UserPhoto = ImageHelper.ImageToByte(user_photo_preview.Image)
                };

                var createdUser = await _userService.CreateUser(model);

                if (createdUser != null)
                {
                    MessageBox.Show("Successfully created", " User", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetFormFields();
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
                create_user_button.Enabled = true;
            }
        }

        private void ResetFormFields()
        {
            username_input.Text = "";
            password_input.Text = "";
            email_input.Text = "";
            role_combobox.SelectedIndex = 0;
            first_name_input.Text = "";
            last_name_input.Text = "";
            address_input.Text = "";

            SetDefaultProfileImage();

            new_user_error_provider.Clear();
        }

        private void SetDefaultProfileImage()
        {
            user_photo_preview.Image = Properties.Resources.account;
        }

        private bool validateAllFields()
        {
            var usernameValid = validateUsername();
            var passwordValid = validatePassword();
            var emailValid = validateEmail();
            var firstNameValid = validateFirstName();
            var lastNameValid = validateLastName();
            var addressValid = validateAddress();

            return usernameValid &&
                passwordValid &&
                emailValid &&
                firstNameValid &&
                lastNameValid &&
                addressValid;
        }
    }
}