namespace scratch_collect.Admin.Forms.Users
{
    partial class AllUsers
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.users_delete_button = new System.Windows.Forms.Button();
            this.users_edit_button = new System.Windows.Forms.Button();
            this.users_new_button = new System.Windows.Forms.Button();
            this.users_username_filter = new System.Windows.Forms.TextBox();
            this.users_filter_button = new System.Windows.Forms.Button();
            this.users_email_filter = new System.Windows.Forms.TextBox();
            this.users_layout_content_panel = new System.Windows.Forms.Panel();
            this.users_datagrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.vouchers_datagrid = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.all_users_main_layout.SuspendLayout();
            this.all_users_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.users_layout_content_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.users_datagrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vouchers_datagrid)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
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
            this.all_users_main_layout.Margin = new System.Windows.Forms.Padding(2);
            this.all_users_main_layout.Name = "all_users_main_layout";
            this.all_users_main_layout.RowCount = 2;
            this.all_users_main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.40351F));
            this.all_users_main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.59649F));
            this.all_users_main_layout.Size = new System.Drawing.Size(1261, 583);
            this.all_users_main_layout.TabIndex = 0;
            // 
            // all_users_panel
            // 
            this.all_users_panel.Controls.Add(this.label2);
            this.all_users_panel.Controls.Add(this.label1);
            this.all_users_panel.Controls.Add(this.panel2);
            this.all_users_panel.Controls.Add(this.panel3);
            this.all_users_panel.Controls.Add(this.users_username_filter);
            this.all_users_panel.Controls.Add(this.users_filter_button);
            this.all_users_panel.Controls.Add(this.users_email_filter);
            this.all_users_panel.Location = new System.Drawing.Point(2, 2);
            this.all_users_panel.Margin = new System.Windows.Forms.Padding(2);
            this.all_users_panel.Name = "all_users_panel";
            this.all_users_panel.Size = new System.Drawing.Size(1256, 62);
            this.all_users_panel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(865, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 38);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.users_delete_button);
            this.panel3.Controls.Add(this.users_edit_button);
            this.panel3.Controls.Add(this.users_new_button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(894, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 62);
            this.panel3.TabIndex = 3;
            // 
            // users_delete_button
            // 
            this.users_delete_button.BackColor = System.Drawing.Color.Brown;
            this.users_delete_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.users_delete_button.ForeColor = System.Drawing.Color.LightCoral;
            this.users_delete_button.Location = new System.Drawing.Point(32, 12);
            this.users_delete_button.Margin = new System.Windows.Forms.Padding(2);
            this.users_delete_button.Name = "users_delete_button";
            this.users_delete_button.Size = new System.Drawing.Size(90, 36);
            this.users_delete_button.TabIndex = 6;
            this.users_delete_button.Text = "Delete";
            this.users_delete_button.UseVisualStyleBackColor = false;
            this.users_delete_button.Click += new System.EventHandler(this.users_delete_button_Click);
            // 
            // users_edit_button
            // 
            this.users_edit_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.users_edit_button.Location = new System.Drawing.Point(147, 12);
            this.users_edit_button.Margin = new System.Windows.Forms.Padding(2);
            this.users_edit_button.Name = "users_edit_button";
            this.users_edit_button.Size = new System.Drawing.Size(90, 36);
            this.users_edit_button.TabIndex = 5;
            this.users_edit_button.Text = "Edit";
            this.users_edit_button.UseVisualStyleBackColor = true;
            this.users_edit_button.Click += new System.EventHandler(this.users_edit_button_Click);
            // 
            // users_new_button
            // 
            this.users_new_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.users_new_button.Location = new System.Drawing.Point(254, 11);
            this.users_new_button.Margin = new System.Windows.Forms.Padding(2);
            this.users_new_button.Name = "users_new_button";
            this.users_new_button.Size = new System.Drawing.Size(75, 35);
            this.users_new_button.TabIndex = 4;
            this.users_new_button.Text = "New";
            this.users_new_button.UseVisualStyleBackColor = true;
            this.users_new_button.Click += new System.EventHandler(this.users_new_button_Click);
            // 
            // users_username_filter
            // 
            this.users_username_filter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.users_username_filter.Location = new System.Drawing.Point(399, 15);
            this.users_username_filter.Margin = new System.Windows.Forms.Padding(2);
            this.users_username_filter.Name = "users_username_filter";
            this.users_username_filter.Size = new System.Drawing.Size(194, 34);
            this.users_username_filter.TabIndex = 2;
            // 
            // users_filter_button
            // 
            this.users_filter_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.users_filter_button.Location = new System.Drawing.Point(683, 15);
            this.users_filter_button.Margin = new System.Windows.Forms.Padding(2);
            this.users_filter_button.Name = "users_filter_button";
            this.users_filter_button.Size = new System.Drawing.Size(90, 35);
            this.users_filter_button.TabIndex = 1;
            this.users_filter_button.Text = "Filter";
            this.users_filter_button.UseVisualStyleBackColor = true;
            this.users_filter_button.Click += new System.EventHandler(this.users_filter_button_Click);
            // 
            // users_email_filter
            // 
            this.users_email_filter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.users_email_filter.Location = new System.Drawing.Point(77, 12);
            this.users_email_filter.Margin = new System.Windows.Forms.Padding(2);
            this.users_email_filter.Name = "users_email_filter";
            this.users_email_filter.Size = new System.Drawing.Size(194, 34);
            this.users_email_filter.TabIndex = 0;
            // 
            // users_layout_content_panel
            // 
            this.users_layout_content_panel.Controls.Add(this.users_datagrid);
            this.users_layout_content_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_layout_content_panel.Location = new System.Drawing.Point(2, 68);
            this.users_layout_content_panel.Margin = new System.Windows.Forms.Padding(2);
            this.users_layout_content_panel.Name = "users_layout_content_panel";
            this.users_layout_content_panel.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.users_layout_content_panel.Size = new System.Drawing.Size(1257, 513);
            this.users_layout_content_panel.TabIndex = 3;
            // 
            // users_datagrid
            // 
            this.users_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.users_datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.users_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.users_datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_datagrid.Location = new System.Drawing.Point(4, 3);
            this.users_datagrid.Margin = new System.Windows.Forms.Padding(2);
            this.users_datagrid.MultiSelect = false;
            this.users_datagrid.Name = "users_datagrid";
            this.users_datagrid.ReadOnly = true;
            this.users_datagrid.RowHeadersWidth = 62;
            this.users_datagrid.RowTemplate.Height = 33;
            this.users_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.users_datagrid.Size = new System.Drawing.Size(1249, 507);
            this.users_datagrid.TabIndex = 0;
            this.users_datagrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.users_datagrid_DataBindingComplete);
            this.users_datagrid.SelectionChanged += new System.EventHandler(this.users_datagrid_SelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.vouchers_datagrid, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // vouchers_datagrid
            // 
            this.vouchers_datagrid.AllowUserToAddRows = false;
            this.vouchers_datagrid.AllowUserToOrderColumns = true;
            this.vouchers_datagrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.vouchers_datagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vouchers_datagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.vouchers_datagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.vouchers_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vouchers_datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vouchers_datagrid.Location = new System.Drawing.Point(3, 23);
            this.vouchers_datagrid.MultiSelect = false;
            this.vouchers_datagrid.Name = "vouchers_datagrid";
            this.vouchers_datagrid.ReadOnly = true;
            this.vouchers_datagrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.vouchers_datagrid.RowHeadersWidth = 62;
            this.vouchers_datagrid.RowTemplate.Height = 33;
            this.vouchers_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vouchers_datagrid.Size = new System.Drawing.Size(194, 74);
            this.vouchers_datagrid.StandardTab = true;
            this.vouchers_datagrid.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 121);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Location = new System.Drawing.Point(1081, 18);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 90);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.button3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(-259, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(453, 121);
            this.panel6.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.ForeColor = System.Drawing.Color.LightCoral;
            this.button1.Location = new System.Drawing.Point(40, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button2.Location = new System.Drawing.Point(186, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 49);
            this.button2.TabIndex = 5;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button3.Location = new System.Drawing.Point(327, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 49);
            this.button3.TabIndex = 4;
            this.button3.Text = "New";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Location = new System.Drawing.Point(307, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 34);
            this.textBox1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button4.Location = new System.Drawing.Point(598, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 49);
            this.button4.TabIndex = 1;
            this.button4.Text = "Filter";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox2.Location = new System.Drawing.Point(34, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(242, 34);
            this.textBox2.TabIndex = 0;
            // 
            // AllUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 635);
            this.Controls.Add(this.all_users_main_layout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AllUsers";
            this.Padding = new System.Windows.Forms.Padding(32, 26, 32, 26);
            this.Text = "All Users";
            this.Load += new System.EventHandler(this.AllUsers_Load);
            this.all_users_main_layout.ResumeLayout(false);
            this.all_users_panel.ResumeLayout(false);
            this.all_users_panel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.users_layout_content_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.users_datagrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vouchers_datagrid)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel all_users_main_layout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView vouchers_datagrid;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel all_users_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button users_delete_button;
        private System.Windows.Forms.Button users_edit_button;
        private System.Windows.Forms.Button users_new_button;
        private System.Windows.Forms.TextBox users_username_filter;
        private System.Windows.Forms.Button users_filter_button;
        private System.Windows.Forms.TextBox users_email_filter;
        private System.Windows.Forms.Panel users_layout_content_panel;
        private System.Windows.Forms.DataGridView users_datagrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}