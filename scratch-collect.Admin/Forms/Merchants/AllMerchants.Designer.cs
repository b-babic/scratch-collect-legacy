namespace scratch_collect.Admin.Forms.Merchants
{
    partial class AllMerchants
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
            this.merchants_country_filter = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.merchants_delete_button = new System.Windows.Forms.Button();
            this.merchants_edit_button = new System.Windows.Forms.Button();
            this.merchants_new_button = new System.Windows.Forms.Button();
            this.merchants_text_filter = new System.Windows.Forms.TextBox();
            this.merchants_filter_button = new System.Windows.Forms.Button();
            this.users_layout_content_panel = new System.Windows.Forms.Panel();
            this.merchants_datagrid = new System.Windows.Forms.DataGridView();
            this.all_users_main_layout.SuspendLayout();
            this.all_users_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.users_layout_content_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.merchants_datagrid)).BeginInit();
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
            this.all_users_main_layout.Location = new System.Drawing.Point(40, 40);
            this.all_users_main_layout.Name = "all_users_main_layout";
            this.all_users_main_layout.RowCount = 2;
            this.all_users_main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.40351F));
            this.all_users_main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.59649F));
            this.all_users_main_layout.Size = new System.Drawing.Size(1576, 912);
            this.all_users_main_layout.TabIndex = 1;
            // 
            // all_users_panel
            // 
            this.all_users_panel.Controls.Add(this.merchants_country_filter);
            this.all_users_panel.Controls.Add(this.panel2);
            this.all_users_panel.Controls.Add(this.panel3);
            this.all_users_panel.Controls.Add(this.merchants_text_filter);
            this.all_users_panel.Controls.Add(this.merchants_filter_button);
            this.all_users_panel.Location = new System.Drawing.Point(3, 3);
            this.all_users_panel.Name = "all_users_panel";
            this.all_users_panel.Size = new System.Drawing.Size(1570, 98);
            this.all_users_panel.TabIndex = 2;
            // 
            // merchants_country_filter
            // 
            this.merchants_country_filter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.merchants_country_filter.Location = new System.Drawing.Point(309, 31);
            this.merchants_country_filter.Name = "merchants_country_filter";
            this.merchants_country_filter.Size = new System.Drawing.Size(242, 39);
            this.merchants_country_filter.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(1081, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 60);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.merchants_delete_button);
            this.panel3.Controls.Add(this.merchants_edit_button);
            this.panel3.Controls.Add(this.merchants_new_button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1117, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 98);
            this.panel3.TabIndex = 3;
            // 
            // merchants_delete_button
            // 
            this.merchants_delete_button.BackColor = System.Drawing.Color.Brown;
            this.merchants_delete_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.merchants_delete_button.ForeColor = System.Drawing.Color.LightCoral;
            this.merchants_delete_button.Location = new System.Drawing.Point(40, 26);
            this.merchants_delete_button.Name = "merchants_delete_button";
            this.merchants_delete_button.Size = new System.Drawing.Size(112, 49);
            this.merchants_delete_button.TabIndex = 6;
            this.merchants_delete_button.Text = "Delete";
            this.merchants_delete_button.UseVisualStyleBackColor = false;
            this.merchants_delete_button.Click += new System.EventHandler(this.merchants_delete_button_Click);
            // 
            // merchants_edit_button
            // 
            this.merchants_edit_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.merchants_edit_button.Location = new System.Drawing.Point(187, 26);
            this.merchants_edit_button.Name = "merchants_edit_button";
            this.merchants_edit_button.Size = new System.Drawing.Size(112, 49);
            this.merchants_edit_button.TabIndex = 5;
            this.merchants_edit_button.Text = "Edit";
            this.merchants_edit_button.UseVisualStyleBackColor = true;
            this.merchants_edit_button.Click += new System.EventHandler(this.merchants_edit_button_Click);
            // 
            // merchants_new_button
            // 
            this.merchants_new_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.merchants_new_button.Location = new System.Drawing.Point(327, 26);
            this.merchants_new_button.Name = "merchants_new_button";
            this.merchants_new_button.Size = new System.Drawing.Size(112, 49);
            this.merchants_new_button.TabIndex = 4;
            this.merchants_new_button.Text = "New";
            this.merchants_new_button.UseVisualStyleBackColor = true;
            this.merchants_new_button.Click += new System.EventHandler(this.merchants_new_button_Click);
            // 
            // merchants_text_filter
            // 
            this.merchants_text_filter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.merchants_text_filter.Location = new System.Drawing.Point(33, 31);
            this.merchants_text_filter.Name = "merchants_text_filter";
            this.merchants_text_filter.Size = new System.Drawing.Size(242, 39);
            this.merchants_text_filter.TabIndex = 2;
            // 
            // merchants_filter_button
            // 
            this.merchants_filter_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.merchants_filter_button.Location = new System.Drawing.Point(619, 26);
            this.merchants_filter_button.Name = "merchants_filter_button";
            this.merchants_filter_button.Size = new System.Drawing.Size(112, 49);
            this.merchants_filter_button.TabIndex = 1;
            this.merchants_filter_button.Text = "Filter";
            this.merchants_filter_button.UseVisualStyleBackColor = true;
            this.merchants_filter_button.Click += new System.EventHandler(this.merchants_filter_button_Click);
            // 
            // users_layout_content_panel
            // 
            this.users_layout_content_panel.Controls.Add(this.merchants_datagrid);
            this.users_layout_content_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_layout_content_panel.Location = new System.Drawing.Point(3, 107);
            this.users_layout_content_panel.Name = "users_layout_content_panel";
            this.users_layout_content_panel.Padding = new System.Windows.Forms.Padding(5);
            this.users_layout_content_panel.Size = new System.Drawing.Size(1570, 802);
            this.users_layout_content_panel.TabIndex = 3;
            // 
            // merchants_datagrid
            // 
            this.merchants_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.merchants_datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.merchants_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.merchants_datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.merchants_datagrid.Location = new System.Drawing.Point(5, 5);
            this.merchants_datagrid.MultiSelect = false;
            this.merchants_datagrid.Name = "merchants_datagrid";
            this.merchants_datagrid.ReadOnly = true;
            this.merchants_datagrid.RowHeadersWidth = 62;
            this.merchants_datagrid.RowTemplate.Height = 33;
            this.merchants_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.merchants_datagrid.Size = new System.Drawing.Size(1560, 792);
            this.merchants_datagrid.TabIndex = 0;
            this.merchants_datagrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.merchants_datagrid_DataBindingComplete);
            this.merchants_datagrid.SelectionChanged += new System.EventHandler(this.merchants_datagrid_SelectionChanged);
            // 
            // AllMerchants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 992);
            this.Controls.Add(this.all_users_main_layout);
            this.Name = "AllMerchants";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Text = "AllMerchants";
            this.Load += new System.EventHandler(this.AllMerchants_Load);
            this.all_users_main_layout.ResumeLayout(false);
            this.all_users_panel.ResumeLayout(false);
            this.all_users_panel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.users_layout_content_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.merchants_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel all_users_main_layout;
        private System.Windows.Forms.Panel all_users_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button merchants_delete_button;
        private System.Windows.Forms.Button merchants_edit_button;
        private System.Windows.Forms.Button merchants_new_button;
        private System.Windows.Forms.TextBox merchants_text_filter;
        private System.Windows.Forms.Button merchants_filter_button;
        private System.Windows.Forms.Panel users_layout_content_panel;
        private System.Windows.Forms.DataGridView merchants_datagrid;
        private System.Windows.Forms.TextBox merchants_country_filter;
    }
}