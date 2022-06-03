using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Desktop.Forms.Shared
{
    public partial class PageLayoutForm : Form
    {
        private Form _parentForm;

        public PageLayoutForm(Form parentForm)
        {
            InitializeComponent();

            _parentForm = parentForm;
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            _parentForm.Show();
            this.Close();
        }
    }
}