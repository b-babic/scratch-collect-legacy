namespace scratch_collect.Admin.Forms
{
    partial class MainForm
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
            this.table_layout_main = new System.Windows.Forms.TableLayoutPanel();
            this.logo_title = new System.Windows.Forms.Label();
            this.main_layout = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.users_control_menu = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.vouchers_control_menu = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.merchants_control_menu = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.offers_control_menu = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.winnings_control_menu = new System.Windows.Forms.ToolStripLabel();
            this.main_panel_wrapper = new System.Windows.Forms.Panel();
            this.second_report = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_users_report = new System.Windows.Forms.Button();
            this.report_offers = new System.Windows.Forms.GroupBox();
            this.offers_report_category_combobox = new System.Windows.Forms.ComboBox();
            this.offers_report_date_from_picker = new System.Windows.Forms.DateTimePicker();
            this.offers_report_date_to_picker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_offers_report = new System.Windows.Forms.Button();
            this.table_layout_main.SuspendLayout();
            this.main_layout.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.main_panel_wrapper.SuspendLayout();
            this.second_report.SuspendLayout();
            this.report_offers.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_layout_main
            // 
            this.table_layout_main.ColumnCount = 1;
            this.table_layout_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_layout_main.Controls.Add(this.logo_title, 0, 0);
            this.table_layout_main.Controls.Add(this.main_layout, 0, 1);
            this.table_layout_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_main.Location = new System.Drawing.Point(32, 26);
            this.table_layout_main.Margin = new System.Windows.Forms.Padding(2);
            this.table_layout_main.Name = "table_layout_main";
            this.table_layout_main.RowCount = 2;
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.539474F));
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.46053F));
            this.table_layout_main.Size = new System.Drawing.Size(1265, 583);
            this.table_layout_main.TabIndex = 2;
            // 
            // logo_title
            // 
            this.logo_title.AutoSize = true;
            this.logo_title.Dock = System.Windows.Forms.DockStyle.Right;
            this.logo_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.logo_title.ForeColor = System.Drawing.SystemColors.InfoText;
            this.logo_title.Location = new System.Drawing.Point(1026, 0);
            this.logo_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.logo_title.Name = "logo_title";
            this.logo_title.Size = new System.Drawing.Size(237, 55);
            this.logo_title.TabIndex = 2;
            this.logo_title.Text = "Scratch && Collect";
            this.logo_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // main_layout
            // 
            this.main_layout.ColumnCount = 1;
            this.main_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.main_layout.Controls.Add(this.toolStrip1, 0, 0);
            this.main_layout.Controls.Add(this.main_panel_wrapper, 0, 1);
            this.main_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_layout.Location = new System.Drawing.Point(2, 57);
            this.main_layout.Margin = new System.Windows.Forms.Padding(2);
            this.main_layout.Name = "main_layout";
            this.main_layout.RowCount = 2;
            this.main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666F));
            this.main_layout.Size = new System.Drawing.Size(1261, 524);
            this.main_layout.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.users_control_menu,
            this.toolStripSeparator1,
            this.vouchers_control_menu,
            this.toolStripSeparator2,
            this.merchants_control_menu,
            this.toolStripSeparator3,
            this.offers_control_menu,
            this.toolStripSeparator4,
            this.winnings_control_menu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1261, 43);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // users_control_menu
            // 
            this.users_control_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.users_control_menu.Name = "users_control_menu";
            this.users_control_menu.Size = new System.Drawing.Size(44, 40);
            this.users_control_menu.Text = "Users";
            this.users_control_menu.ToolTipText = "Go to users page";
            this.users_control_menu.Click += new System.EventHandler(this.users_control_menu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // vouchers_control_menu
            // 
            this.vouchers_control_menu.Name = "vouchers_control_menu";
            this.vouchers_control_menu.Size = new System.Drawing.Size(68, 40);
            this.vouchers_control_menu.Text = "Vouchers";
            this.vouchers_control_menu.ToolTipText = "Go to vouchers  page";
            this.vouchers_control_menu.Click += new System.EventHandler(this.vouchers_control_menu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // merchants_control_menu
            // 
            this.merchants_control_menu.Name = "merchants_control_menu";
            this.merchants_control_menu.Size = new System.Drawing.Size(77, 40);
            this.merchants_control_menu.Text = "Merchants";
            this.merchants_control_menu.ToolTipText = "Go to merchants page";
            this.merchants_control_menu.Click += new System.EventHandler(this.merchants_control_menu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // offers_control_menu
            // 
            this.offers_control_menu.Name = "offers_control_menu";
            this.offers_control_menu.Size = new System.Drawing.Size(49, 40);
            this.offers_control_menu.Text = "Offers";
            this.offers_control_menu.ToolTipText = "Go to offers page";
            this.offers_control_menu.Click += new System.EventHandler(this.offers_control_menu_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            // 
            // winnings_control_menu
            // 
            this.winnings_control_menu.Name = "winnings_control_menu";
            this.winnings_control_menu.Size = new System.Drawing.Size(70, 40);
            this.winnings_control_menu.Text = "Winnings";
            this.winnings_control_menu.ToolTipText = "Go to winnings page";
            this.winnings_control_menu.Click += new System.EventHandler(this.winnings_control_menu_Click);
            // 
            // main_panel_wrapper
            // 
            this.main_panel_wrapper.Controls.Add(this.second_report);
            this.main_panel_wrapper.Controls.Add(this.report_offers);
            this.main_panel_wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel_wrapper.Location = new System.Drawing.Point(3, 45);
            this.main_panel_wrapper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.main_panel_wrapper.Name = "main_panel_wrapper";
            this.main_panel_wrapper.Size = new System.Drawing.Size(1255, 477);
            this.main_panel_wrapper.TabIndex = 1;
            // 
            // second_report
            // 
            this.second_report.Controls.Add(this.label4);
            this.second_report.Controls.Add(this.btn_users_report);
            this.second_report.Location = new System.Drawing.Point(28, 170);
            this.second_report.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.second_report.Name = "second_report";
            this.second_report.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.second_report.Size = new System.Drawing.Size(1197, 100);
            this.second_report.TabIndex = 1;
            this.second_report.TabStop = false;
            this.second_report.Text = "Active Users Report";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "List of most active users on the platform.";
            // 
            // btn_users_report
            // 
            this.btn_users_report.Location = new System.Drawing.Point(1014, 39);
            this.btn_users_report.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_users_report.Name = "btn_users_report";
            this.btn_users_report.Size = new System.Drawing.Size(150, 29);
            this.btn_users_report.TabIndex = 1;
            this.btn_users_report.Text = "Generate report";
            this.btn_users_report.UseVisualStyleBackColor = true;
            this.btn_users_report.Click += new System.EventHandler(this.btn_users_report_Click);
            // 
            // report_offers
            // 
            this.report_offers.Controls.Add(this.offers_report_category_combobox);
            this.report_offers.Controls.Add(this.offers_report_date_from_picker);
            this.report_offers.Controls.Add(this.offers_report_date_to_picker);
            this.report_offers.Controls.Add(this.label3);
            this.report_offers.Controls.Add(this.label2);
            this.report_offers.Controls.Add(this.label1);
            this.report_offers.Controls.Add(this.btn_offers_report);
            this.report_offers.Location = new System.Drawing.Point(28, 30);
            this.report_offers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.report_offers.Name = "report_offers";
            this.report_offers.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.report_offers.Size = new System.Drawing.Size(1197, 100);
            this.report_offers.TabIndex = 0;
            this.report_offers.TabStop = false;
            this.report_offers.Text = "Offers Success Report";
            // 
            // offers_report_category_combobox
            // 
            this.offers_report_category_combobox.FormattingEnabled = true;
            this.offers_report_category_combobox.Location = new System.Drawing.Point(195, 47);
            this.offers_report_category_combobox.Name = "offers_report_category_combobox";
            this.offers_report_category_combobox.Size = new System.Drawing.Size(121, 24);
            this.offers_report_category_combobox.TabIndex = 5;
            // 
            // offers_report_date_from_picker
            // 
            this.offers_report_date_from_picker.Location = new System.Drawing.Point(399, 45);
            this.offers_report_date_from_picker.Name = "offers_report_date_from_picker";
            this.offers_report_date_from_picker.Size = new System.Drawing.Size(200, 22);
            this.offers_report_date_from_picker.TabIndex = 4;
            // 
            // offers_report_date_to_picker
            // 
            this.offers_report_date_to_picker.Location = new System.Drawing.Point(672, 47);
            this.offers_report_date_to_picker.Name = "offers_report_date_to_picker";
            this.offers_report_date_to_picker.Size = new System.Drawing.Size(200, 22);
            this.offers_report_date_to_picker.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(639, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category:";
            // 
            // btn_offers_report
            // 
            this.btn_offers_report.Location = new System.Drawing.Point(1014, 42);
            this.btn_offers_report.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_offers_report.Name = "btn_offers_report";
            this.btn_offers_report.Size = new System.Drawing.Size(150, 29);
            this.btn_offers_report.TabIndex = 0;
            this.btn_offers_report.Text = "Generate report";
            this.btn_offers_report.UseVisualStyleBackColor = true;
            this.btn_offers_report.Click += new System.EventHandler(this.btn_offers_report_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 635);
            this.Controls.Add(this.table_layout_main);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(32, 26, 32, 26);
            this.Text = "Homepage";
            this.table_layout_main.ResumeLayout(false);
            this.table_layout_main.PerformLayout();
            this.main_layout.ResumeLayout(false);
            this.main_layout.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.main_panel_wrapper.ResumeLayout(false);
            this.second_report.ResumeLayout(false);
            this.second_report.PerformLayout();
            this.report_offers.ResumeLayout(false);
            this.report_offers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel table_layout_main;
        private System.Windows.Forms.Label logo_title;
        private System.Windows.Forms.TableLayoutPanel main_layout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel users_control_menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel vouchers_control_menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel merchants_control_menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel offers_control_menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel winnings_control_menu;
        private System.Windows.Forms.Panel main_panel_wrapper;
        private System.Windows.Forms.GroupBox second_report;
        private System.Windows.Forms.GroupBox report_offers;
        private System.Windows.Forms.Button btn_offers_report;
        private System.Windows.Forms.Button btn_users_report;
        private System.Windows.Forms.ComboBox offers_report_category_combobox;
        private System.Windows.Forms.DateTimePicker offers_report_date_from_picker;
        private System.Windows.Forms.DateTimePicker offers_report_date_to_picker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}