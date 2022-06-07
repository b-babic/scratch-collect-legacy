namespace scratch_collect.Desktop.Controls
{
    partial class VoucherPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vouchers_datagrid)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.usersDataGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.usersDataGrid.Location = new System.Drawing.Point(3, 23);
            this.usersDataGrid.MultiSelect = false;
            this.usersDataGrid.Name = "usersDataGrid";
            this.usersDataGrid.ReadOnly = true;
            this.usersDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.usersDataGrid.RowHeadersWidth = 62;
            this.usersDataGrid.RowTemplate.Height = 33;
            this.usersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDataGrid.Size = new System.Drawing.Size(194, 74);
            this.usersDataGrid.StandardTab = true;
            this.usersDataGrid.TabIndex = 0;
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
            this.panel1.Size = new System.Drawing.Size(194, 121);
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
            this.panel2.Location = new System.Drawing.Point(-259, 0);
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.vouchers_datagrid, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5657F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.4343F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1556, 723);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.vouchers_datagrid.Location = new System.Drawing.Point(3, 130);
            this.vouchers_datagrid.MultiSelect = false;
            this.vouchers_datagrid.Name = "vouchers_datagrid";
            this.vouchers_datagrid.ReadOnly = true;
            this.vouchers_datagrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.vouchers_datagrid.RowHeadersWidth = 62;
            this.vouchers_datagrid.RowTemplate.Height = 33;
            this.vouchers_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vouchers_datagrid.Size = new System.Drawing.Size(1550, 590);
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
            this.panel4.Size = new System.Drawing.Size(1550, 121);
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
            this.panel6.Location = new System.Drawing.Point(1097, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(453, 121);
            this.panel6.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(186, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 49);
            this.button2.TabIndex = 5;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(327, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 49);
            this.button3.TabIndex = 4;
            this.button3.Text = "New";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(307, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Filter by username...";
            this.textBox1.Size = new System.Drawing.Size(242, 39);
            this.textBox1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(598, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 49);
            this.button4.TabIndex = 1;
            this.button4.Text = "Filter";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(34, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Filter by email...";
            this.textBox2.Size = new System.Drawing.Size(242, 39);
            this.textBox2.TabIndex = 0;
            // 
            // VoucherPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "VoucherPage";
            this.Size = new System.Drawing.Size(1556, 723);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vouchers_datagrid)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView usersDataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button delete_user_button;
        private System.Windows.Forms.Button edit_user_button;
        private System.Windows.Forms.Button new_user_button;
        private System.Windows.Forms.TextBox filter_users_username;
        private System.Windows.Forms.Button filter_users_button;
        private System.Windows.Forms.TextBox filter_users_email;
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
    }
}
