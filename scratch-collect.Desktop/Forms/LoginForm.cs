using scratch_collect.Desktop.Forms;
using scratch_collect.Desktop.Services.Authentication;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace scratch_collect.Desktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // Hide validation labels
            validation_label.Text = "";
            validation_label.Visible = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private async void signin_button_Click(object sender, EventArgs e)
        {
            var emailValue = email_input.Text;
            var passwordValue = password_input.Text;

            var fieldsAreValid = validateSigninFields();

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

            // Login

            try
            {
                this.UseWaitCursor = true;
                signin_button.Enabled = false;

                bool signedIn = await AuthenticationService.Login(emailValue, passwordValue);

                // Show validation if not signed
                if (!signedIn)
                {
                    validation_label.Text = "Something went wrong! Please try again";
                    validation_label.Visible = true;
                    return;
                }
                else
                {
                    // Persist user details object as shared ref ?
                    RedirectToHomepage();
                }
            }
            finally
            {
                this.UseWaitCursor = false;
                signin_button.Enabled = true;
            }
        }

        private void RedirectToHomepage()
        {
            Form homepage = new MainForm();
            homepage.Show();

            // Close login form
            this.Visible = false;
        }

        // Validation
        private bool validateSigninFields()
        {
            var emailValid = validateEmail(email_input);
            var passwordValid = validatePassword(password_input);

            return emailValid && passwordValid;
        }

        private bool validateEmail(TextBox inputControl)
        {
            var value = inputControl.Text;
            // email regex
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(value);

            // required
            if (string.IsNullOrWhiteSpace(value))
            {
                signin_error_provider.SetError(inputControl, "Email field cannot be empty!");
                return false;
            }
            // max length < 100
            else if (value.Length > 100)
            {
                signin_error_provider.SetError(inputControl, "Email field cannot exceed 100 characters!");
                return false;
            }
            else if (!match.Success)
            {
                signin_error_provider.SetError(inputControl, "Email field must contain valid email address!");
                return false;
            }
            else
            {
                // reset errors
                signin_error_provider.Clear();
                return true;
            }
        }

        private bool validatePassword(TextBox inputControl)
        {
            var value = inputControl.Text;

            if (string.IsNullOrWhiteSpace(value))
            {
                signin_error_provider.SetError(inputControl, "Password field cannot be empty!");
                return false;
            }
            else if (value.Length >= 50)
            {
                signin_error_provider.SetError(inputControl, "Password must contain less than 50 characters!");
                return false;
            }
            else
            {
                // reset errors
                signin_error_provider.Clear();
                return true;
            }
        }

        // Validation events
        private void email_input_Validating(object sender, CancelEventArgs e)
        {
            validateEmail(email_input);
        }

        private void password_input_Validating(object sender, CancelEventArgs e)
        {
            validatePassword(password_input);
        }
    }
}