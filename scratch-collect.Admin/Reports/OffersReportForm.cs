using Microsoft.Reporting.WinForms;
using scratch_collect.Admin.Services;
using scratch_collect.Model.Desktop;
using scratch_collect.Model.Report;
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
        private static SuccessOffersRequest request;

        public OffersReportForm(SuccessOffersRequest initial)
        {
            InitializeComponent();

            request = initial;
        }

        private async void OffersReportForm_Load(object sender, EventArgs e)
        {
            var items = await ReportService.SuccessOffers(request);

            // Setup rds
            ReportDataSource rds = new ReportDataSource("dsSuccessOffers", items as List<SuccessOffer> ?? new List<SuccessOffer>());
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            // Params
            var parameters = new ReportParameter[]{
                new ReportParameter("pFromDate", !string.IsNullOrEmpty(request.TimeFrom.ToString()) ? request.TimeFrom.ToString() : "All dates"),
                new ReportParameter("pToDate", !string.IsNullOrEmpty(request.TimeTo.ToString()) ? request.TimeTo.ToString() : "All dates"),
                new ReportParameter("pCategory", request.Category)
            };

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }
    }
}