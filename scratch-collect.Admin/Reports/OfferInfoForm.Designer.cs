namespace scratch_collect.Admin.Reports
{
    partial class OfferInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.offer_info_report_viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.offer_info_report_viewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(32, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 485);
            this.panel1.TabIndex = 0;
            // 
            // offer_info_report_viewer
            // 
            this.offer_info_report_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.offer_info_report_viewer.LocalReport.ReportEmbeddedResource = "scratch_collect.Admin.Reports.OfferInfo.rdlc";
            this.offer_info_report_viewer.Location = new System.Drawing.Point(0, 0);
            this.offer_info_report_viewer.Name = "offer_info_report_viewer";
            this.offer_info_report_viewer.ServerReport.BearerToken = null;
            this.offer_info_report_viewer.Size = new System.Drawing.Size(926, 485);
            this.offer_info_report_viewer.TabIndex = 0;
            // 
            // OfferInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 549);
            this.Controls.Add(this.panel1);
            this.Name = "OfferInfoForm";
            this.Padding = new System.Windows.Forms.Padding(32);
            this.Text = "Offer Info Report";
            this.Load += new System.EventHandler(this.OfferInfoForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer offer_info_report_viewer;
    }
}