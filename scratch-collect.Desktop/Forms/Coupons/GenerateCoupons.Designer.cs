namespace scratch_collect.Desktop.Forms.Coupons
{
    partial class GenerateCoupons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateCoupons));
            this.table_layout_main = new System.Windows.Forms.TableLayoutPanel();
            this.main_panel = new System.Windows.Forms.Panel();
            this.generate_coupons_groupbox = new System.Windows.Forms.GroupBox();
            this.coupons_generate_button = new System.Windows.Forms.Button();
            this.coupons_generate_numeric_input = new System.Windows.Forms.NumericUpDown();
            this.new_coupons_count_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.go_back_button = new System.Windows.Forms.Button();
            this.logo_title = new System.Windows.Forms.Label();
            this.table_layout_main.SuspendLayout();
            this.main_panel.SuspendLayout();
            this.generate_coupons_groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coupons_generate_numeric_input)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_layout_main
            // 
            this.table_layout_main.ColumnCount = 1;
            this.table_layout_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_layout_main.Controls.Add(this.main_panel, 0, 1);
            this.table_layout_main.Controls.Add(this.panel2, 0, 0);
            this.table_layout_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_main.Location = new System.Drawing.Point(40, 40);
            this.table_layout_main.Name = "table_layout_main";
            this.table_layout_main.RowCount = 2;
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.971554F));
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.02845F));
            this.table_layout_main.Size = new System.Drawing.Size(1576, 912);
            this.table_layout_main.TabIndex = 5;
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.generate_coupons_groupbox);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(3, 84);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1570, 825);
            this.main_panel.TabIndex = 3;
            // 
            // generate_coupons_groupbox
            // 
            this.generate_coupons_groupbox.Controls.Add(this.coupons_generate_button);
            this.generate_coupons_groupbox.Controls.Add(this.coupons_generate_numeric_input);
            this.generate_coupons_groupbox.Controls.Add(this.new_coupons_count_label);
            this.generate_coupons_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generate_coupons_groupbox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.generate_coupons_groupbox.Location = new System.Drawing.Point(0, 0);
            this.generate_coupons_groupbox.Name = "generate_coupons_groupbox";
            this.generate_coupons_groupbox.Size = new System.Drawing.Size(1570, 825);
            this.generate_coupons_groupbox.TabIndex = 0;
            this.generate_coupons_groupbox.TabStop = false;
            this.generate_coupons_groupbox.Text = "Generate coupons";
            // 
            // coupons_generate_button
            // 
            this.coupons_generate_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.coupons_generate_button.Location = new System.Drawing.Point(32, 335);
            this.coupons_generate_button.Name = "coupons_generate_button";
            this.coupons_generate_button.Size = new System.Drawing.Size(218, 63);
            this.coupons_generate_button.TabIndex = 3;
            this.coupons_generate_button.Text = "Generate";
            this.coupons_generate_button.UseVisualStyleBackColor = true;
            this.coupons_generate_button.Click += new System.EventHandler(this.coupons_generate_button_Click);
            // 
            // coupons_generate_numeric_input
            // 
            this.coupons_generate_numeric_input.Location = new System.Drawing.Point(32, 191);
            this.coupons_generate_numeric_input.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.coupons_generate_numeric_input.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.coupons_generate_numeric_input.Name = "coupons_generate_numeric_input";
            this.coupons_generate_numeric_input.Size = new System.Drawing.Size(218, 45);
            this.coupons_generate_numeric_input.TabIndex = 2;
            this.coupons_generate_numeric_input.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // new_coupons_count_label
            // 
            this.new_coupons_count_label.AutoSize = true;
            this.new_coupons_count_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.new_coupons_count_label.Location = new System.Drawing.Point(32, 142);
            this.new_coupons_count_label.Name = "new_coupons_count_label";
            this.new_coupons_count_label.Size = new System.Drawing.Size(231, 32);
            this.new_coupons_count_label.TabIndex = 0;
            this.new_coupons_count_label.Text = "Amount to generate";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.go_back_button);
            this.panel2.Controls.Add(this.logo_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1570, 75);
            this.panel2.TabIndex = 4;
            // 
            // go_back_button
            // 
            this.go_back_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.go_back_button.Image = ((System.Drawing.Image)(resources.GetObject("go_back_button.Image")));
            this.go_back_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.go_back_button.Location = new System.Drawing.Point(0, 0);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(145, 75);
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
            this.logo_title.Location = new System.Drawing.Point(1294, 0);
            this.logo_title.Name = "logo_title";
            this.logo_title.Size = new System.Drawing.Size(276, 45);
            this.logo_title.TabIndex = 3;
            this.logo_title.Text = "Scratch && Collect";
            this.logo_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GenerateCoupons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 992);
            this.Controls.Add(this.table_layout_main);
            this.Name = "GenerateCoupons";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Text = "GenerateCoupons";
            this.table_layout_main.ResumeLayout(false);
            this.main_panel.ResumeLayout(false);
            this.generate_coupons_groupbox.ResumeLayout(false);
            this.generate_coupons_groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coupons_generate_numeric_input)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_layout_main;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button go_back_button;
        private System.Windows.Forms.Label logo_title;
        private System.Windows.Forms.GroupBox generate_coupons_groupbox;
        private System.Windows.Forms.Button coupons_generate_button;
        private System.Windows.Forms.NumericUpDown coupons_generate_numeric_input;
        private System.Windows.Forms.Label new_coupons_count_label;
    }
}