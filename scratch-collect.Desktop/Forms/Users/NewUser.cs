using scratch_collect.Desktop.Services;
using System;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms.Users
{
    public partial class NewUserForm : Form
    {
        private readonly IUserService _userService;
        private Form _parentForm;

        public NewUserForm(Form parentForm)
        {
            InitializeComponent();

            // DI
            _userService = (IUserService)Program.ServiceProvider.GetService(typeof(IUserService));
            _parentForm = parentForm;

            SetupInitialLayout();
        }

        private void SetupInitialLayout()
        {
            page_title.Text = "Create new user";
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentForm.Show();
        }
    }
}