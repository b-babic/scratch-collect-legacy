using Microsoft.Reporting.WinForms;
using scratch_collect.Model.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scratch_collect.Admin.Reports
{
    public partial class OffersReportForm : Form
    {
        public OffersReportForm()
        {
            InitializeComponent();
        }

        private void OffersReportForm_Load(object sender, EventArgs e)
        {
            // API CALL
            List<OfferReportVM> dummy = new List<OfferReportVM>();
            dummy.Add(new OfferReportVM
            {
                Id = 1,
                Name = "Test",
                PlayedOn = DateTime.Now,
                Won = true,
                Category = "Test Category"
            });

            // Setup rds
            ReportDataSource rds = new ReportDataSource("DataSet1", dummy);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}