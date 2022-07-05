using Microsoft.Reporting.WinForms;
using scratch_collect.Admin.Services;
using scratch_collect.Model.Report;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace scratch_collect.Admin.Reports
{
    public partial class UsersReportForm : Form
    {
        private ReportViewer active_users_report_viewer;
        private Panel panel1;

        public UsersReportForm()
        {
            InitializeComponent();
        }

        private async void UsersReportForm_Load(object sender, EventArgs e)
        {
            var items = await ReportService.ActiveUsers();

            // Setup rds
            ReportDataSource rds = new ReportDataSource("dsActiveUsers", items as List<ActiveUser> ?? new List<ActiveUser>());
            this.active_users_report_viewer.LocalReport.DataSources.Add(rds);

            this.active_users_report_viewer.ZoomMode = ZoomMode.PageWidth;

            active_users_report_viewer.RefreshReport();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.active_users_report_viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.active_users_report_viewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(32, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 485);
            this.panel1.TabIndex = 0;
            // 
            // active_users_report_viewer
            // 
            this.active_users_report_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.active_users_report_viewer.LocalReport.ReportEmbeddedResource = "scratch_collect.Admin.Reports.UsersReport.rdlc";
            this.active_users_report_viewer.Location = new System.Drawing.Point(0, 0);
            this.active_users_report_viewer.Name = "active_users_report_viewer";
            this.active_users_report_viewer.ServerReport.BearerToken = null;
            this.active_users_report_viewer.Size = new System.Drawing.Size(928, 485);
            this.active_users_report_viewer.TabIndex = 0;
            // 
            // UsersReportForm
            // 
            this.ClientSize = new System.Drawing.Size(992, 549);
            this.Controls.Add(this.panel1);
            this.Name = "UsersReportForm";
            this.Padding = new System.Windows.Forms.Padding(32);
            this.Text = "Most Active Users Report";
            this.Load += new System.EventHandler(this.UsersReportForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void UsersReportForm_Load_1(object sender, EventArgs e)
        {
            this.active_users_report_viewer.RefreshReport();
        }
    }
}