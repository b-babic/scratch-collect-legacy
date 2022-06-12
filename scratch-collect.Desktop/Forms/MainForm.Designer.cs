namespace scratch_collect.Desktop.Forms
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
            this.table_layout_main.SuspendLayout();
            this.main_layout.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_layout_main
            // 
            this.table_layout_main.ColumnCount = 1;
            this.table_layout_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_layout_main.Controls.Add(this.logo_title, 0, 0);
            this.table_layout_main.Controls.Add(this.main_layout, 0, 1);
            this.table_layout_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_layout_main.Location = new System.Drawing.Point(40, 40);
            this.table_layout_main.Name = "table_layout_main";
            this.table_layout_main.RowCount = 2;
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.539474F));
            this.table_layout_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.46053F));
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
            this.logo_title.Size = new System.Drawing.Size(276, 86);
            this.logo_title.TabIndex = 2;
            this.logo_title.Text = "Scratch && Collect";
            this.logo_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // main_layout
            // 
            this.main_layout.ColumnCount = 1;
            this.main_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.main_layout.Controls.Add(this.toolStrip1, 0, 0);
            this.main_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_layout.Location = new System.Drawing.Point(3, 89);
            this.main_layout.Name = "main_layout";
            this.main_layout.RowCount = 2;
            this.main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666F));
            this.main_layout.Size = new System.Drawing.Size(1570, 820);
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
            this.toolStrip1.Size = new System.Drawing.Size(1570, 68);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // users_control_menu
            // 
            this.users_control_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.users_control_menu.Name = "users_control_menu";
            this.users_control_menu.Size = new System.Drawing.Size(55, 63);
            this.users_control_menu.Text = "Users";
            this.users_control_menu.ToolTipText = "Go to users page";
            this.users_control_menu.Click += new System.EventHandler(this.users_control_menu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 68);
            // 
            // vouchers_control_menu
            // 
            this.vouchers_control_menu.Name = "vouchers_control_menu";
            this.vouchers_control_menu.Size = new System.Drawing.Size(84, 63);
            this.vouchers_control_menu.Text = "Vouchers";
            this.vouchers_control_menu.ToolTipText = "Go to vouchers  page";
            this.vouchers_control_menu.Click += new System.EventHandler(this.vouchers_control_menu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 68);
            // 
            // merchants_control_menu
            // 
            this.merchants_control_menu.Name = "merchants_control_menu";
            this.merchants_control_menu.Size = new System.Drawing.Size(94, 63);
            this.merchants_control_menu.Text = "Merchants";
            this.merchants_control_menu.ToolTipText = "Go to merchants page";
            this.merchants_control_menu.Click += new System.EventHandler(this.merchants_control_menu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 68);
            // 
            // offers_control_menu
            // 
            this.offers_control_menu.Name = "offers_control_menu";
            this.offers_control_menu.Size = new System.Drawing.Size(61, 63);
            this.offers_control_menu.Text = "Offers";
            this.offers_control_menu.ToolTipText = "Go to offers page";
            this.offers_control_menu.Click += new System.EventHandler(this.offers_control_menu_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 68);
            // 
            // winnings_control_menu
            // 
            this.winnings_control_menu.Name = "winnings_control_menu";
            this.winnings_control_menu.Size = new System.Drawing.Size(86, 63);
            this.winnings_control_menu.Text = "Winnings";
            this.winnings_control_menu.ToolTipText = "Go to winnings page";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 992);
            this.Controls.Add(this.table_layout_main);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Text = "Homepage";
            this.table_layout_main.ResumeLayout(false);
            this.table_layout_main.PerformLayout();
            this.main_layout.ResumeLayout(false);
            this.main_layout.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
    }
}