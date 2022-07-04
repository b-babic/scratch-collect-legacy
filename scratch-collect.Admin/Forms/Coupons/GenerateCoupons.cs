using scratch_collect.Admin.Services;
using System;
using System.Windows.Forms;

namespace scratch_collect.Admin.Forms.Coupons
{
    public partial class GenerateCoupons : Form
    {
        private AllCoupons _parentForm;

        public GenerateCoupons(AllCoupons parentForm)
        {
            InitializeComponent();

            // DI
            _parentForm = parentForm;
        }

        // Generic events
        private async void coupons_generate_button_Click(object sender, EventArgs e)
        {
            var amount = coupons_generate_numeric_input.Value;

            // Loading
            StartLoading();
            DisableCommonControls();

            try
            {
                var generated = await CouponService.Generate((int)amount);

                if (generated)
                {
                    MessageBox.Show("Coupons generated !", "Coupons Generate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while generating coupons! Please try again.", "Coupons Generate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                StopLoading();
                EnableCommonControls();
            }
        }

        private async void go_back_button_Click(object sender, EventArgs e)
        {
            await _parentForm.FetchCouponsData();
            _parentForm.Show();

            Close();
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

        private void DisableCommonControls()
        {
            coupons_generate_numeric_input.Enabled = false;
            coupons_generate_button.Enabled = false;
        }

        private void EnableCommonControls()
        {
            coupons_generate_numeric_input.Enabled = true;
            coupons_generate_button.Enabled = true;
        }
    }
}