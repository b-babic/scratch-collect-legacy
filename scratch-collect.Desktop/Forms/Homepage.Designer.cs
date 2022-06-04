namespace scratch_collect.Desktop.Forms
{
    partial class Homepage
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
            this.tab_navigation_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.usersDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.delete_user_button = new System.Windows.Forms.Button();
            this.edit_user_button = new System.Windows.Forms.Button();
            this.new_user_button = new System.Windows.Forms.Button();
            this.filter_users_username = new System.Windows.Forms.TextBox();
            this.filter_users_button = new System.Windows.Forms.Button();
            this.filter_users_email = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.table_layout_main = new System.Windows.Forms.TableLayoutPanel();
            this.logo_title = new System.Windows.Forms.Label();
            this.tab_navigation_control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.table_layout_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_navigation_control
            // 
            this.tab_navigation_control.Controls.Add(this.tabPage1);
            this.tab_navigation_control.Controls.Add(this.tabPage2);
            this.tab_navigation_control.Controls.Add(this.tabPage3);
            this.tab_navigation_control.Controls.Add(this.tabPage4);
            this.tab_navigation_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_navigation_control.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tab_navigation_control.HotTrack = true;
            this.tab_navigation_control.Location = new System.Drawing.Point(3, 129);
            this.tab_navigation_control.Name = "tab_navigation_control";
            this.tab_navigation_control.SelectedIndex = 0;
            this.tab_navigation_control.Size = new System.Drawing.Size(1570, 780);
            this.tab_navigation_control.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tab_navigation_control.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 47);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1562, 729);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.usersDataGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5657F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.4343F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1556, 723);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // usersDataGrid
            // 
            this.usersDataGrid.AllowUserToAddRows = false;
            this.usersDataGrid.AllowUserToOrderColumns = true;
            this.usersDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.usersDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usersDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.usersDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.usersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersDataGrid.Location = new System.Drawing.Point(3, 130);
            this.usersDataGrid.MultiSelect = false;
            this.usersDataGrid.Name = "usersDataGrid";
            this.usersDataGrid.ReadOnly = true;
            this.usersDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.usersDataGrid.RowHeadersWidth = 62;
            this.usersDataGrid.RowTemplate.Height = 33;
            this.usersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDataGrid.Size = new System.Drawing.Size(1550, 590);
            this.usersDataGrid.StandardTab = true;
            this.usersDataGrid.TabIndex = 0;
            this.usersDataGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.usersDataGrid_DataBindingComplete);
            this.usersDataGrid.SelectionChanged += new System.EventHandler(this.usersDataGrid_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.filter_users_username);
            this.panel1.Controls.Add(this.filter_users_button);
            this.panel1.Controls.Add(this.filter_users_email);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1550, 121);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(1081, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 90);
            this.panel3.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.delete_user_button);
            this.panel2.Controls.Add(this.edit_user_button);
            this.panel2.Controls.Add(this.new_user_button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1097, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 121);
            this.panel2.TabIndex = 3;
            // 
            // delete_user_button
            // 
            this.delete_user_button.BackColor = System.Drawing.Color.Brown;
            this.delete_user_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.delete_user_button.ForeColor = System.Drawing.Color.LightCoral;
            this.delete_user_button.Location = new System.Drawing.Point(40, 35);
            this.delete_user_button.Name = "delete_user_button";
            this.delete_user_button.Size = new System.Drawing.Size(112, 49);
            this.delete_user_button.TabIndex = 6;
            this.delete_user_button.Text = "Delete";
            this.delete_user_button.UseVisualStyleBackColor = false;
            this.delete_user_button.Click += new System.EventHandler(this.delete_user_button_Click);
            // 
            // edit_user_button
            // 
            this.edit_user_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.edit_user_button.Location = new System.Drawing.Point(186, 35);
            this.edit_user_button.Name = "edit_user_button";
            this.edit_user_button.Size = new System.Drawing.Size(112, 49);
            this.edit_user_button.TabIndex = 5;
            this.edit_user_button.Text = "Edit";
            this.edit_user_button.UseVisualStyleBackColor = true;
            // 
            // new_user_button
            // 
            this.new_user_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.new_user_button.Location = new System.Drawing.Point(327, 35);
            this.new_user_button.Name = "new_user_button";
            this.new_user_button.Size = new System.Drawing.Size(112, 49);
            this.new_user_button.TabIndex = 4;
            this.new_user_button.Text = "New";
            this.new_user_button.UseVisualStyleBackColor = true;
            this.new_user_button.Click += new System.EventHandler(this.new_user_button_Click);
            // 
            // filter_users_username
            // 
            this.filter_users_username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filter_users_username.Location = new System.Drawing.Point(307, 36);
            this.filter_users_username.Name = "filter_users_username";
            this.filter_users_username.PlaceholderText = "Filter by username...";
            this.filter_users_username.Size = new System.Drawing.Size(242, 39);
            this.filter_users_username.TabIndex = 2;
            // 
            // filter_users_button
            // 
            this.filter_users_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filter_users_button.Location = new System.Drawing.Point(598, 36);
            this.filter_users_button.Name = "filter_users_button";
            this.filter_users_button.Size = new System.Drawing.Size(112, 49);
            this.filter_users_button.TabIndex = 1;
            this.filter_users_button.Text = "Filter";
            this.filter_users_button.UseVisualStyleBackColor = true;
            this.filter_users_button.Click += new System.EventHandler(this.filter_users_button_Click);
            // 
            // filter_users_email
            // 
            this.filter_users_email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filter_users_email.Location = new System.Drawing.Point(34, 36);
            this.filter_users_email.Name = "filter_users_email";
            this.filter_users_email.PlaceholderText = "Filter by email...";
            this.filter_users_email.Size = new System.Drawing.Size(242, 39);
            this.filter_users_email.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 47);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1562, 729);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 47);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1562, 729);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 47);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1562, 729);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // table_layout_main
            // 
            this.table_layout_main.ColumnCount = 1;
            this.table_layout_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_layout_main.Controls.Add(this.tab_navigation_control, 0, 1);
            this.table_layout_main.Controls.Add(this.logo_title, 0, 0);
            this.table_layout_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_main.Location = new System.Drawing.Point(40, 40);
            this.table_layout_main.Name = "table_layout_main";
            this.table_layout_main.RowCount = 2;
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86935F));
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.13065F));
            this.table_layout_main.Size = new System.Drawing.Size(1576, 912);
            this.table_layout_main.TabIndex = 2;
            // 
            // logo_title
            // 
            this.logo_title.AutoSize = true;
            this.logo_title.Dock = System.Windows.Forms.DockStyle.Right;
            this.logo_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logo_title.ForeColor = System.Drawing.SystemColors.InfoText;
            this.logo_title.Location = new System.Drawing.Point(1297, 0);
            this.logo_title.Name = "logo_title";
            this.logo_title.Size = new System.Drawing.Size(276, 126);
            this.logo_title.TabIndex = 2;
            this.logo_title.Text = "Scratch && Collect";
            this.logo_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 992);
            this.Controls.Add(this.table_layout_main);
            this.Name = "Homepage";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Text = "Homepage";
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.tab_navigation_control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.table_layout_main.ResumeLayout(false);
            this.table_layout_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_navigation_control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView usersDataGrid;
        private System.Windows.Forms.TableLayoutPanel table_layout_main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label logo_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button filter_users_button;
        private System.Windows.Forms.TextBox filter_users_email;
        private System.Windows.Forms.TextBox filter_users_username;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button delete_user_button;
        private System.Windows.Forms.Button edit_user_button;
        private System.Windows.Forms.Button new_user_button;
        private System.Windows.Forms.Panel panel3;
    }
}