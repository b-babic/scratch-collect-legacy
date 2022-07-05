namespace scratch_collect.Admin.Forms
{
    partial class AllOffers
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
            this.all_users_main_layout = new System.Windows.Forms.TableLayoutPanel();
            this.all_users_panel = new System.Windows.Forms.Panel();
            this.filter_category_combobox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.offers_delete_button = new System.Windows.Forms.Button();
            this.offers_edit_button = new System.Windows.Forms.Button();
            this.offers_new_button = new System.Windows.Forms.Button();
            this.offers_filter_button = new System.Windows.Forms.Button();
            this.users_layout_content_panel = new System.Windows.Forms.Panel();
            this.offers_datagrid = new System.Windows.Forms.DataGridView();
            this.all_users_main_layout.SuspendLayout();
            this.all_users_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.users_layout_content_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offers_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // all_users_main_layout
            // 
            this.all_users_main_layout.AutoSize = true;
            this.all_users_main_layout.ColumnCount = 1;
            this.all_users_main_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.all_users_main_layout.Controls.Add(this.all_users_panel, 0, 0);
            this.all_users_main_layout.Controls.Add(this.users_layout_content_panel, 0, 1);
            this.all_users_main_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.all_users_main_layout.Location = new System.Drawing.Point(32, 26);
            this.all_users_main_layout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.all_users_main_layout.Name = "all_users_main_layout";
            this.all_users_main_layout.RowCount = 2;
            this.all_users_main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.40351F));
            this.all_users_main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.59649F));
            this.all_users_main_layout.Size = new System.Drawing.Size(1261, 583);
            this.all_users_main_layout.TabIndex = 2;
            // 
            // all_users_panel
            // 
            this.all_users_panel.Controls.Add(this.filter_category_combobox);
            this.all_users_panel.Controls.Add(this.panel2);
            this.all_users_panel.Controls.Add(this.panel3);
            this.all_users_panel.Controls.Add(this.offers_filter_button);
            this.all_users_panel.Location = new System.Drawing.Point(2, 2);
            this.all_users_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.all_users_panel.Name = "all_users_panel";
            this.all_users_panel.Size = new System.Drawing.Size(1256, 62);
            this.all_users_panel.TabIndex = 2;
            // 
            // filter_category_combobox
            // 
            this.filter_category_combobox.FormattingEnabled = true;
            this.filter_category_combobox.Location = new System.Drawing.Point(37, 23);
            this.filter_category_combobox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filter_category_combobox.Name = "filter_category_combobox";
            this.filter_category_combobox.Size = new System.Drawing.Size(226, 24);
            this.filter_category_combobox.TabIndex = 5;
            this.filter_category_combobox.Text = "Select Category";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(865, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 38);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.offers_delete_button);
            this.panel3.Controls.Add(this.offers_edit_button);
            this.panel3.Controls.Add(this.offers_new_button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(894, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 62);
            this.panel3.TabIndex = 3;
            // 
            // offers_delete_button
            // 
            this.offers_delete_button.BackColor = System.Drawing.Color.Brown;
            this.offers_delete_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.offers_delete_button.ForeColor = System.Drawing.Color.LightCoral;
            this.offers_delete_button.Location = new System.Drawing.Point(32, 17);
            this.offers_delete_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.offers_delete_button.Name = "offers_delete_button";
            this.offers_delete_button.Size = new System.Drawing.Size(90, 31);
            this.offers_delete_button.TabIndex = 6;
            this.offers_delete_button.Text = "Delete";
            this.offers_delete_button.UseVisualStyleBackColor = false;
            this.offers_delete_button.Click += new System.EventHandler(this.offers_delete_button_Click);
            // 
            // offers_edit_button
            // 
            this.offers_edit_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.offers_edit_button.Location = new System.Drawing.Point(150, 17);
            this.offers_edit_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.offers_edit_button.Name = "offers_edit_button";
            this.offers_edit_button.Size = new System.Drawing.Size(90, 31);
            this.offers_edit_button.TabIndex = 5;
            this.offers_edit_button.Text = "Edit";
            this.offers_edit_button.UseVisualStyleBackColor = true;
            this.offers_edit_button.Click += new System.EventHandler(this.offers_edit_button_Click);
            // 
            // offers_new_button
            // 
            this.offers_new_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.offers_new_button.Location = new System.Drawing.Point(262, 17);
            this.offers_new_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.offers_new_button.Name = "offers_new_button";
            this.offers_new_button.Size = new System.Drawing.Size(90, 31);
            this.offers_new_button.TabIndex = 4;
            this.offers_new_button.Text = "New";
            this.offers_new_button.UseVisualStyleBackColor = true;
            this.offers_new_button.Click += new System.EventHandler(this.offers_new_button_Click);
            // 
            // offers_filter_button
            // 
            this.offers_filter_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.offers_filter_button.Location = new System.Drawing.Point(306, 16);
            this.offers_filter_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.offers_filter_button.Name = "offers_filter_button";
            this.offers_filter_button.Size = new System.Drawing.Size(90, 31);
            this.offers_filter_button.TabIndex = 1;
            this.offers_filter_button.Text = "Filter";
            this.offers_filter_button.UseVisualStyleBackColor = true;
            this.offers_filter_button.Click += new System.EventHandler(this.offers_filter_button_Click);
            // 
            // users_layout_content_panel
            // 
            this.users_layout_content_panel.Controls.Add(this.offers_datagrid);
            this.users_layout_content_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_layout_content_panel.Location = new System.Drawing.Point(2, 68);
            this.users_layout_content_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.users_layout_content_panel.Name = "users_layout_content_panel";
            this.users_layout_content_panel.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.users_layout_content_panel.Size = new System.Drawing.Size(1257, 513);
            this.users_layout_content_panel.TabIndex = 3;
            // 
            // offers_datagrid
            // 
            this.offers_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.offers_datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.offers_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.offers_datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.offers_datagrid.Location = new System.Drawing.Point(4, 3);
            this.offers_datagrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.offers_datagrid.MultiSelect = false;
            this.offers_datagrid.Name = "offers_datagrid";
            this.offers_datagrid.ReadOnly = true;
            this.offers_datagrid.RowHeadersWidth = 62;
            this.offers_datagrid.RowTemplate.Height = 33;
            this.offers_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.offers_datagrid.Size = new System.Drawing.Size(1249, 507);
            this.offers_datagrid.TabIndex = 0;
            this.offers_datagrid.UseWaitCursor = true;
            this.offers_datagrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.offers_datagrid_DataBindingComplete);
            this.offers_datagrid.SelectionChanged += new System.EventHandler(this.offers_datagrid_SelectionChanged);
            // 
            // AllOffers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 635);
            this.Controls.Add(this.all_users_main_layout);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AllOffers";
            this.Padding = new System.Windows.Forms.Padding(32, 26, 32, 26);
            this.Text = "AllOffers";
            this.Load += new System.EventHandler(this.AllOffers_Load);
            this.all_users_main_layout.ResumeLayout(false);
            this.all_users_panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.users_layout_content_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.offers_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel all_users_main_layout;
        private System.Windows.Forms.Panel all_users_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button offers_delete_button;
        private System.Windows.Forms.Button offers_edit_button;
        private System.Windows.Forms.Button offers_new_button;
        private System.Windows.Forms.Button offers_filter_button;
        private System.Windows.Forms.Panel users_layout_content_panel;
        private System.Windows.Forms.DataGridView offers_datagrid;
        private System.Windows.Forms.ComboBox filter_category_combobox;
    }
}