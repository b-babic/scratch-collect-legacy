using scratch_collect.Desktop.Forms.Shared;
using scratch_collect.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms.Users
{
    public partial class NewUserForm : PageLayoutForm
    {
        private readonly IUserService _userService;
        private static Homepage parentForm = new Homepage();

        public NewUserForm() : base(parentForm)
        {
            InitializeComponent();

            _userService = (IUserService)Program.ServiceProvider.GetService(typeof(IUserService));
        }
    }
}