namespace scratch_collect.Admin.Forms
{
    partial class EditOffer
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
            this.table_layout_main = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.new__section_groupbox = new System.Windows.Forms.GroupBox();
            this.quantity_input = new System.Windows.Forms.NumericUpDown();
            this.price_combobox = new System.Windows.Forms.ComboBox();
            this.description_label = new System.Windows.Forms.Label();
            this.description_input = new System.Windows.Forms.RichTextBox();
            this.quantity_label = new System.Windows.Forms.Label();
            this.validation_label = new System.Windows.Forms.Label();
            this.edit_offer_button = new System.Windows.Forms.Button();
            this.category_combobox = new System.Windows.Forms.ComboBox();
            this.category_label = new System.Windows.Forms.Label();
            this.title_input = new System.Windows.Forms.TextBox();
            this.title_label = new System.Windows.Forms.Label();
            this.price_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.go_back_button = new System.Windows.Forms.Button();
            this.logo_title = new System.Windows.Forms.Label();
            this.edit_offer_error_provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.table_layout_main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.new__section_groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_input)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edit_offer_error_provider)).BeginInit();
            this.SuspendLayout();
            // 
            // table_layout_main
            // 
            this.table_layout_main.ColumnCount = 1;
            this.table_layout_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_layout_main.Controls.Add(this.panel1, 0, 1);
            this.table_layout_main.Controls.Add(this.panel2, 0, 0);
            this.table_layout_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_main.Location = new System.Drawing.Point(32, 26);
            this.table_layout_main.Margin = new System.Windows.Forms.Padding(2);
            this.table_layout_main.Name = "table_layout_main";
            this.table_layout_main.RowCount = 2;
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.971554F));
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.02845F));
            this.table_layout_main.Size = new System.Drawing.Size(1262, 584);
            this.table_layout_main.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.new__section_groupbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 528);
            this.panel1.TabIndex = 3;
            // 
            // new__section_groupbox
            // 
            this.new__section_groupbox.Controls.Add(this.quantity_input);
            this.new__section_groupbox.Controls.Add(this.price_combobox);
            this.new__section_groupbox.Controls.Add(this.description_label);
            this.new__section_groupbox.Controls.Add(this.description_input);
            this.new__section_groupbox.Controls.Add(this.quantity_label);
            this.new__section_groupbox.Controls.Add(this.validation_label);
            this.new__section_groupbox.Controls.Add(this.edit_offer_button);
            this.new__section_groupbox.Controls.Add(this.category_combobox);
            this.new__section_groupbox.Controls.Add(this.category_label);
            this.new__section_groupbox.Controls.Add(this.title_input);
            this.new__section_groupbox.Controls.Add(this.title_label);
            this.new__section_groupbox.Controls.Add(this.price_label);
            this.new__section_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new__section_groupbox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.new__section_groupbox.Location = new System.Drawing.Point(0, 0);
            this.new__section_groupbox.Margin = new System.Windows.Forms.Padding(2);
            this.new__section_groupbox.Name = "new__section_groupbox";
            this.new__section_groupbox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.new__section_groupbox.Size = new System.Drawing.Size(1258, 528);
            this.new__section_groupbox.TabIndex = 2;
            this.new__section_groupbox.TabStop = false;
            this.new__section_groupbox.Text = "Edit offer";
            // 
            // quantity_input
            // 
            this.quantity_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.quantity_input.Location = new System.Drawing.Point(708, 168);
            this.quantity_input.Margin = new System.Windows.Forms.Padding(2);
            this.quantity_input.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.quantity_input.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity_input.Name = "quantity_input";
            this.quantity_input.Size = new System.Drawing.Size(283, 39);
            this.quantity_input.TabIndex = 24;
            this.quantity_input.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // price_combobox
            // 
            this.price_combobox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.price_combobox.FormattingEnabled = true;
            this.price_combobox.Location = new System.Drawing.Point(708, 74);
            this.price_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.price_combobox.Name = "price_combobox";
            this.price_combobox.Size = new System.Drawing.Size(284, 39);
            this.price_combobox.TabIndex = 23;
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.description_label.Location = new System.Drawing.Point(32, 136);
            this.description_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(135, 32);
            this.description_label.TabIndex = 22;
            this.description_label.Text = "Description";
            // 
            // description_input
            // 
            this.description_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.description_input.Location = new System.Drawing.Point(30, 167);
            this.description_input.Margin = new System.Windows.Forms.Padding(2);
            this.description_input.Name = "description_input";
            this.description_input.Size = new System.Drawing.Size(444, 209);
            this.description_input.TabIndex = 21;
            this.description_input.Text = "";
            // 
            // quantity_label
            // 
            this.quantity_label.AutoSize = true;
            this.quantity_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.quantity_label.Location = new System.Drawing.Point(710, 136);
            this.quantity_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quantity_label.Name = "quantity_label";
            this.quantity_label.Size = new System.Drawing.Size(106, 32);
            this.quantity_label.TabIndex = 19;
            this.quantity_label.Text = "Quantity";
            // 
            // validation_label
            // 
            this.validation_label.AutoSize = true;
            this.validation_label.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.validation_label.ForeColor = System.Drawing.Color.IndianRed;
            this.validation_label.Location = new System.Drawing.Point(710, 322);
            this.validation_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.validation_label.Name = "validation_label";
            this.validation_label.Size = new System.Drawing.Size(71, 30);
            this.validation_label.TabIndex = 18;
            this.validation_label.Text = "label1";
            // 
            // edit_offer_button
            // 
            this.edit_offer_button.BackColor = System.Drawing.Color.OliveDrab;
            this.edit_offer_button.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.edit_offer_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.edit_offer_button.Location = new System.Drawing.Point(708, 407);
            this.edit_offer_button.Margin = new System.Windows.Forms.Padding(2);
            this.edit_offer_button.Name = "edit_offer_button";
            this.edit_offer_button.Size = new System.Drawing.Size(210, 35);
            this.edit_offer_button.TabIndex = 17;
            this.edit_offer_button.Text = "Edit offer";
            this.edit_offer_button.UseVisualStyleBackColor = false;
            this.edit_offer_button.Click += new System.EventHandler(this.edit_offer_button_Click);
            // 
            // category_combobox
            // 
            this.category_combobox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.category_combobox.FormattingEnabled = true;
            this.category_combobox.Location = new System.Drawing.Point(708, 248);
            this.category_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.category_combobox.Name = "category_combobox";
            this.category_combobox.Size = new System.Drawing.Size(284, 39);
            this.category_combobox.TabIndex = 13;
            // 
            // category_label
            // 
            this.category_label.AutoSize = true;
            this.category_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.category_label.Location = new System.Drawing.Point(710, 223);
            this.category_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.category_label.Name = "category_label";
            this.category_label.Size = new System.Drawing.Size(110, 32);
            this.category_label.TabIndex = 12;
            this.category_label.Text = "Category";
            // 
            // title_input
            // 
            this.title_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.title_input.Location = new System.Drawing.Point(30, 74);
            this.title_input.Margin = new System.Windows.Forms.Padding(2);
            this.title_input.Name = "title_input";
            this.title_input.Size = new System.Drawing.Size(444, 39);
            this.title_input.TabIndex = 7;
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.title_label.Location = new System.Drawing.Point(32, 49);
            this.title_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(60, 32);
            this.title_label.TabIndex = 6;
            this.title_label.Text = "Title";
            // 
            // price_label
            // 
            this.price_label.AutoSize = true;
            this.price_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.price_label.Location = new System.Drawing.Point(710, 49);
            this.price_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.price_label.Name = "price_label";
            this.price_label.Size = new System.Drawing.Size(65, 32);
            this.price_label.TabIndex = 4;
            this.price_label.Text = "Price";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.go_back_button);
            this.panel2.Controls.Add(this.logo_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1258, 48);
            this.panel2.TabIndex = 4;
            // 
            // go_back_button
            // 
            this.go_back_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.go_back_button.Image = global::scratch_collect.Admin.Properties.Resources.undo;
            this.go_back_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.go_back_button.Location = new System.Drawing.Point(0, 0);
            this.go_back_button.Margin = new System.Windows.Forms.Padding(2);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(116, 48);
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
            this.logo_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.logo_title.ForeColor = System.Drawing.SystemColors.InfoText;
            this.logo_title.Location = new System.Drawing.Point(1021, 0);
            this.logo_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.logo_title.Name = "logo_title";
            this.logo_title.Size = new System.Drawing.Size(237, 37);
            this.logo_title.TabIndex = 3;
            this.logo_title.Text = "Scratch && Collect";
            this.logo_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edit_offer_error_provider
            // 
            this.edit_offer_error_provider.ContainerControl = this;
            // 
            // EditOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 636);
            this.Controls.Add(this.table_layout_main);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditOffer";
            this.Padding = new System.Windows.Forms.Padding(32, 26, 32, 26);
            this.Text = "EditOffer";
            this.table_layout_main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.new__section_groupbox.ResumeLayout(false);
            this.new__section_groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_input)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edit_offer_error_provider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_layout_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox new__section_groupbox;
        private System.Windows.Forms.NumericUpDown quantity_input;
        private System.Windows.Forms.ComboBox price_combobox;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.RichTextBox description_input;
        private System.Windows.Forms.Label quantity_label;
        private System.Windows.Forms.Label validation_label;
        private System.Windows.Forms.Button edit_offer_button;
        private System.Windows.Forms.ComboBox category_combobox;
        private System.Windows.Forms.Label category_label;
        private System.Windows.Forms.TextBox title_input;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label price_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button go_back_button;
        private System.Windows.Forms.Label logo_title;
        private System.Windows.Forms.ErrorProvider edit_offer_error_provider;
    }
}