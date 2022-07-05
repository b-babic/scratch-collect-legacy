using scratch_collect.Admin.Services;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms
{
    public partial class LoginForm : Form
    {
        private Label password_label;
        private TextBox email_input;
        private Label email_label;
        private PictureBox pictureBox1;
        private Button signin_button;
        private TextBox password_input;
        private Label validation_label;
        private ErrorProvider signin_error_provider;
        private IContainer components;
        private Panel panel1;

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

                bool signedIn = await AuthService.Login(emailValue, passwordValue);

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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.validation_label = new System.Windows.Forms.Label();
            this.signin_button = new System.Windows.Forms.Button();
            this.password_input = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.email_input = new System.Windows.Forms.TextBox();
            this.email_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.signin_error_provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signin_error_provider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.validation_label);
            this.panel1.Controls.Add(this.signin_button);
            this.panel1.Controls.Add(this.password_input);
            this.panel1.Controls.Add(this.password_label);
            this.panel1.Controls.Add(this.email_input);
            this.panel1.Controls.Add(this.email_label);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(32, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 641);
            this.panel1.TabIndex = 0;
            // 
            // validation_label
            // 
            this.validation_label.AutoSize = true;
            this.validation_label.ForeColor = System.Drawing.Color.IndianRed;
            this.validation_label.Location = new System.Drawing.Point(464, 478);
            this.validation_label.Name = "validation_label";
            this.validation_label.Size = new System.Drawing.Size(70, 16);
            this.validation_label.TabIndex = 6;
            this.validation_label.Text = "*validation";
            // 
            // signin_button
            // 
            this.signin_button.Location = new System.Drawing.Point(467, 511);
            this.signin_button.Name = "signin_button";
            this.signin_button.Size = new System.Drawing.Size(249, 56);
            this.signin_button.TabIndex = 5;
            this.signin_button.Text = "Login";
            this.signin_button.UseVisualStyleBackColor = true;
            this.signin_button.Click += new System.EventHandler(this.signin_button_Click);
            // 
            // password_input
            // 
            this.password_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_input.Location = new System.Drawing.Point(467, 388);
            this.password_input.Name = "password_input";
            this.password_input.Size = new System.Drawing.Size(249, 30);
            this.password_input.TabIndex = 4;
            this.password_input.Validating += new System.ComponentModel.CancelEventHandler(this.password_input_Validating);
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(463, 351);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(98, 25);
            this.password_label.TabIndex = 3;
            this.password_label.Text = "Password";
            // 
            // email_input
            // 
            this.email_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_input.Location = new System.Drawing.Point(467, 285);
            this.email_input.Name = "email_input";
            this.email_input.Size = new System.Drawing.Size(249, 30);
            this.email_input.TabIndex = 2;
            this.email_input.Validating += new System.ComponentModel.CancelEventHandler(this.email_input_Validating);
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_label.Location = new System.Drawing.Point(463, 247);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(60, 25);
            this.email_label.TabIndex = 1;
            this.email_label.Text = "Email";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::scratch_collect.Admin.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(468, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // signin_error_provider
            // 
            this.signin_error_provider.ContainerControl = this;
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(1214, 705);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(32);
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signin_error_provider)).EndInit();
            this.ResumeLayout(false);

        }
    }
}