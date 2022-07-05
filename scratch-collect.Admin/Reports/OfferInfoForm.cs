using Microsoft.Reporting.WinForms;
using scratch_collect.Admin.Services;
using scratch_collect.Model.Report;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace scratch_collect.Admin.Reports
{
    public partial class OfferInfoForm : Form
    {
        private static OfferInfoRequest request;

        public OfferInfoForm(OfferInfoRequest initial)
        {
            InitializeComponent();

            request = initial;
        }

        private async void OfferInfoForm_Load(object sender, EventArgs e)
        {
            var items = await ReportService.OfferInfo(request);

            // Setup rds
            ReportDataSource rds = new ReportDataSource("dsOfferInfo", items as List<OfferInfo> ?? new List<OfferInfo>());
            this.offer_info_report_viewer.LocalReport.DataSources.Add(rds);

            // Params
            var parameters = new ReportParameter[]{
                new ReportParameter("pOfferId", request.OfferId.ToString())
            };

            this.offer_info_report_viewer.LocalReport.SetParameters(parameters);
            this.offer_info_report_viewer.ZoomMode = ZoomMode.PageWidth;

            offer_info_report_viewer.RefreshReport();
        }
    }
}