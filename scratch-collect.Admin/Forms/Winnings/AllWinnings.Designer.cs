namespace scratch_collect.Admin.Forms
{
    partial class AllWinnings
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
            this.date_to_label = new System.Windows.Forms.Label();
            this.date_from_label = new System.Windows.Forms.Label();
            this.date_to_picker = new System.Windows.Forms.DateTimePicker();
            this.date_from_picker = new System.Windows.Forms.DateTimePicker();
            this.winnings_filter_button = new System.Windows.Forms.Button();
            this.users_layout_content_panel = new System.Windows.Forms.Panel();
            this.winnings_datagrid = new System.Windows.Forms.DataGridView();
            this.all_users_main_layout.SuspendLayout();
            this.all_users_panel.SuspendLayout();
            this.users_layout_content_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winnings_datagrid)).BeginInit();
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
            this.all_users_main_layout.TabIndex = 2;
            // 
            // all_users_panel
            // 
            this.all_users_panel.Controls.Add(this.date_to_label);
            this.all_users_panel.Controls.Add(this.date_from_label);
            this.all_users_panel.Controls.Add(this.date_to_picker);
            this.all_users_panel.Controls.Add(this.date_from_picker);
            this.all_users_panel.Controls.Add(this.winnings_filter_button);
            this.all_users_panel.Location = new System.Drawing.Point(3, 3);
            this.all_users_panel.Name = "all_users_panel";
            this.all_users_panel.Size = new System.Drawing.Size(1570, 98);
            this.all_users_panel.TabIndex = 2;
            // 
            // date_to_label
            // 
            this.date_to_label.AutoSize = true;
            this.date_to_label.Location = new System.Drawing.Point(451, 39);
            this.date_to_label.Name = "date_to_label";
            this.date_to_label.Size = new System.Drawing.Size(30, 25);
            this.date_to_label.TabIndex = 5;
            this.date_to_label.Text = "To";
            // 
            // date_from_label
            // 
            this.date_from_label.AutoSize = true;
            this.date_from_label.Location = new System.Drawing.Point(5, 39);
            this.date_from_label.Name = "date_from_label";
            this.date_from_label.Size = new System.Drawing.Size(54, 25);
            this.date_from_label.TabIndex = 4;
            this.date_from_label.Text = "From";
            // 
            // date_to_picker
            // 
            this.date_to_picker.Location = new System.Drawing.Point(508, 34);
            this.date_to_picker.Name = "date_to_picker";
            this.date_to_picker.Size = new System.Drawing.Size(300, 31);
            this.date_to_picker.TabIndex = 3;
            // 
            // date_from_picker
            // 
            this.date_from_picker.Location = new System.Drawing.Point(79, 34);
            this.date_from_picker.Name = "date_from_picker";
            this.date_from_picker.Size = new System.Drawing.Size(300, 31);
            this.date_from_picker.TabIndex = 2;
            // 
            // winnings_filter_button
            // 
            this.winnings_filter_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.winnings_filter_button.Location = new System.Drawing.Point(889, 25);
            this.winnings_filter_button.Name = "winnings_filter_button";
            this.winnings_filter_button.Size = new System.Drawing.Size(112, 49);
            this.winnings_filter_button.TabIndex = 1;
            this.winnings_filter_button.Text = "Filter";
            this.winnings_filter_button.UseVisualStyleBackColor = true;
            this.winnings_filter_button.Click += new System.EventHandler(this.winnings_filter_button_Click);
            // 
            // users_layout_content_panel
            // 
            this.users_layout_content_panel.Controls.Add(this.winnings_datagrid);
            this.users_layout_content_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_layout_content_panel.Location = new System.Drawing.Point(3, 107);
            this.users_layout_content_panel.Name = "users_layout_content_panel";
            this.users_layout_content_panel.Padding = new System.Windows.Forms.Padding(5);
            this.users_layout_content_panel.Size = new System.Drawing.Size(1570, 802);
            this.users_layout_content_panel.TabIndex = 3;
            // 
            // winnings_datagrid
            // 
            this.winnings_datagrid.AllowUserToAddRows = false;
            this.winnings_datagrid.AllowUserToDeleteRows = false;
            this.winnings_datagrid.AllowUserToResizeColumns = false;
            this.winnings_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.winnings_datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.winnings_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.winnings_datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winnings_datagrid.Location = new System.Drawing.Point(5, 5);
            this.winnings_datagrid.MultiSelect = false;
            this.winnings_datagrid.Name = "winnings_datagrid";
            this.winnings_datagrid.ReadOnly = true;
            this.winnings_datagrid.RowHeadersWidth = 62;
            this.winnings_datagrid.RowTemplate.Height = 33;
            this.winnings_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.winnings_datagrid.Size = new System.Drawing.Size(1560, 792);
            this.winnings_datagrid.TabIndex = 0;
            this.winnings_datagrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.winnings_datagrid_DataBindingComplete);
            // 
            // AllWinnings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 992);
            this.Controls.Add(this.all_users_main_layout);
            this.Name = "AllWinnings";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Text = "Latest Winnings";
            this.Load += new System.EventHandler(this.AllWinnings_Load);
            this.all_users_main_layout.ResumeLayout(false);
            this.all_users_panel.ResumeLayout(false);
            this.all_users_panel.PerformLayout();
            this.users_layout_content_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winnings_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel all_users_main_layout;
        private System.Windows.Forms.Panel all_users_panel;
        private System.Windows.Forms.Label date_to_label;
        private System.Windows.Forms.Label date_from_label;
        private System.Windows.Forms.DateTimePicker date_to_picker;
        private System.Windows.Forms.DateTimePicker date_from_picker;
        private System.Windows.Forms.Button winnings_filter_button;
        private System.Windows.Forms.Panel users_layout_content_panel;
        private System.Windows.Forms.DataGridView winnings_datagrid;
    }
}