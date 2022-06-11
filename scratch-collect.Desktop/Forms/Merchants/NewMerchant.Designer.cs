﻿namespace scratch_collect.Desktop.Forms.Merchants
{
    partial class NewMerchant
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMerchant));
            this.table_layout_main = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.telephone_input = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.validation_label = new System.Windows.Forms.Label();
            this.create_merchant_button = new System.Windows.Forms.Button();
            this.country_combobox = new System.Windows.Forms.ComboBox();
            this.role_label = new System.Windows.Forms.Label();
            this.name_input = new System.Windows.Forms.TextBox();
            this.email_label = new System.Windows.Forms.Label();
            this.address_input = new System.Windows.Forms.TextBox();
            this.address_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.go_back_button = new System.Windows.Forms.Button();
            this.logo_title = new System.Windows.Forms.Label();
            this.new_merchant_error_provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.table_layout_main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.new_merchant_error_provider)).BeginInit();
            this.SuspendLayout();
            // 
            // table_layout_main
            // 
            this.table_layout_main.ColumnCount = 1;
            this.table_layout_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_layout_main.Controls.Add(this.panel1, 0, 1);
            this.table_layout_main.Controls.Add(this.panel2, 0, 0);
            this.table_layout_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_main.Location = new System.Drawing.Point(40, 40);
            this.table_layout_main.Name = "table_layout_main";
            this.table_layout_main.RowCount = 2;
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.971554F));
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.02845F));
            this.table_layout_main.Size = new System.Drawing.Size(1578, 914);
            this.table_layout_main.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1572, 826);
            this.panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.telephone_input);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.validation_label);
            this.groupBox1.Controls.Add(this.create_merchant_button);
            this.groupBox1.Controls.Add(this.country_combobox);
            this.groupBox1.Controls.Add(this.role_label);
            this.groupBox1.Controls.Add(this.name_input);
            this.groupBox1.Controls.Add(this.email_label);
            this.groupBox1.Controls.Add(this.address_input);
            this.groupBox1.Controls.Add(this.address_label);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1572, 826);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create new merchant";
            // 
            // telephone_input
            // 
            this.telephone_input.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.telephone_input.Location = new System.Drawing.Point(38, 381);
            this.telephone_input.Mask = "(999) 000-0000";
            this.telephone_input.Name = "telephone_input";
            this.telephone_input.Size = new System.Drawing.Size(655, 45);
            this.telephone_input.TabIndex = 20;
            this.telephone_input.Validating += new System.ComponentModel.CancelEventHandler(this.telephone_input_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 38);
            this.label1.TabIndex = 19;
            this.label1.Text = "Telephone";
            // 
            // validation_label
            // 
            this.validation_label.AutoSize = true;
            this.validation_label.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.validation_label.ForeColor = System.Drawing.Color.IndianRed;
            this.validation_label.Location = new System.Drawing.Point(46, 634);
            this.validation_label.Name = "validation_label";
            this.validation_label.Size = new System.Drawing.Size(83, 36);
            this.validation_label.TabIndex = 18;
            this.validation_label.Text = "label1";
            // 
            // create_merchant_button
            // 
            this.create_merchant_button.BackColor = System.Drawing.Color.OliveDrab;
            this.create_merchant_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.create_merchant_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.create_merchant_button.Location = new System.Drawing.Point(49, 740);
            this.create_merchant_button.Name = "create_merchant_button";
            this.create_merchant_button.Size = new System.Drawing.Size(263, 55);
            this.create_merchant_button.TabIndex = 17;
            this.create_merchant_button.Text = "Create Merchant";
            this.create_merchant_button.UseVisualStyleBackColor = false;
            this.create_merchant_button.Click += new System.EventHandler(this.create_merchant_button_Click);
            // 
            // country_combobox
            // 
            this.country_combobox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.country_combobox.FormattingEnabled = true;
            this.country_combobox.Location = new System.Drawing.Point(38, 529);
            this.country_combobox.Name = "country_combobox";
            this.country_combobox.Size = new System.Drawing.Size(655, 46);
            this.country_combobox.TabIndex = 13;
            this.country_combobox.Text = "Select";
            // 
            // role_label
            // 
            this.role_label.AutoSize = true;
            this.role_label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.role_label.Location = new System.Drawing.Point(38, 473);
            this.role_label.Name = "role_label";
            this.role_label.Size = new System.Drawing.Size(115, 38);
            this.role_label.TabIndex = 12;
            this.role_label.Text = "Country";
            // 
            // name_input
            // 
            this.name_input.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name_input.Location = new System.Drawing.Point(38, 126);
            this.name_input.Name = "name_input";
            this.name_input.PlaceholderText = "Name";
            this.name_input.Size = new System.Drawing.Size(655, 45);
            this.name_input.TabIndex = 7;
            this.name_input.Validating += new System.ComponentModel.CancelEventHandler(this.name_input_Validating);
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.email_label.Location = new System.Drawing.Point(38, 85);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(91, 38);
            this.email_label.TabIndex = 6;
            this.email_label.Text = "Name";
            // 
            // address_input
            // 
            this.address_input.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.address_input.Location = new System.Drawing.Point(38, 249);
            this.address_input.Name = "address_input";
            this.address_input.PlaceholderText = "Address";
            this.address_input.Size = new System.Drawing.Size(655, 45);
            this.address_input.TabIndex = 5;
            this.address_input.Validating += new System.ComponentModel.CancelEventHandler(this.address_input_Validating);
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.address_label.Location = new System.Drawing.Point(38, 208);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(116, 38);
            this.address_label.TabIndex = 4;
            this.address_label.Text = "Address";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.go_back_button);
            this.panel2.Controls.Add(this.logo_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1572, 76);
            this.panel2.TabIndex = 4;
            // 
            // go_back_button
            // 
            this.go_back_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.go_back_button.Image = ((System.Drawing.Image)(resources.GetObject("go_back_button.Image")));
            this.go_back_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.go_back_button.Location = new System.Drawing.Point(0, 0);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(145, 76);
            this.go_back_button.TabIndex = 4;
            this.go_back_button.Text = "Go Back";
            this.go_back_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.go_back_button.UseVisualStyleBackColor = true;
            this.go_back_button.Click += new System.EventHandler(this.go_back_button_Click);
            // 
            // logo_title
            // 
            this.logo_title.AutoSize = true;
            this.logo_title.Dock = System.Windows.Forms.DockStyle.Right;
            this.logo_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logo_title.ForeColor = System.Drawing.SystemColors.InfoText;
            this.logo_title.Location = new System.Drawing.Point(1296, 0);
            this.logo_title.Name = "logo_title";
            this.logo_title.Size = new System.Drawing.Size(276, 45);
            this.logo_title.TabIndex = 3;
            this.logo_title.Text = "Scratch && Collect";
            this.logo_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // new_merchant_error_provider
            // 
            this.new_merchant_error_provider.ContainerControl = this;
            // 
            // NewMerchant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1658, 994);
            this.Controls.Add(this.table_layout_main);
            this.Name = "NewMerchant";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Text = "Add New Merchant";
            this.table_layout_main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.new_merchant_error_provider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_layout_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label validation_label;
        private System.Windows.Forms.Button create_merchant_button;
        private System.Windows.Forms.ComboBox country_combobox;
        private System.Windows.Forms.Label role_label;
        private System.Windows.Forms.TextBox name_input;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.TextBox address_input;
        private System.Windows.Forms.Label address_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button go_back_button;
        private System.Windows.Forms.Label logo_title;
        private System.Windows.Forms.MaskedTextBox telephone_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider new_merchant_error_provider;
    }
}