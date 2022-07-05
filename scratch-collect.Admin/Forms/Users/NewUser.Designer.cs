namespace scratch_collect.Admin.Forms.Users
{
    partial class NewUserForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.validation_label = new System.Windows.Forms.Label();
            this.create_user_button = new System.Windows.Forms.Button();
            this.user_photo_preview = new System.Windows.Forms.PictureBox();
            this.upload_profile_image_button = new System.Windows.Forms.Button();
            this.user_photo_label = new System.Windows.Forms.Label();
            this.role_combobox = new System.Windows.Forms.ComboBox();
            this.role_label = new System.Windows.Forms.Label();
            this.password_input = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.username_input = new System.Windows.Forms.TextBox();
            this.email_input = new System.Windows.Forms.TextBox();
            this.email_label = new System.Windows.Forms.Label();
            this.address_input = new System.Windows.Forms.TextBox();
            this.address_label = new System.Windows.Forms.Label();
            this.last_name_input = new System.Windows.Forms.TextBox();
            this.last_name_label = new System.Windows.Forms.Label();
            this.first_name_label = new System.Windows.Forms.Label();
            this.first_name_input = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.go_back_button = new System.Windows.Forms.Button();
            this.logo_title = new System.Windows.Forms.Label();
            this.new_user_error_provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.table_layout_main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_photo_preview)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.new_user_error_provider)).BeginInit();
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
            this.table_layout_main.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 528);
            this.panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.validation_label);
            this.groupBox1.Controls.Add(this.create_user_button);
            this.groupBox1.Controls.Add(this.user_photo_preview);
            this.groupBox1.Controls.Add(this.upload_profile_image_button);
            this.groupBox1.Controls.Add(this.user_photo_label);
            this.groupBox1.Controls.Add(this.role_combobox);
            this.groupBox1.Controls.Add(this.role_label);
            this.groupBox1.Controls.Add(this.password_input);
            this.groupBox1.Controls.Add(this.password_label);
            this.groupBox1.Controls.Add(this.username_label);
            this.groupBox1.Controls.Add(this.username_input);
            this.groupBox1.Controls.Add(this.email_input);
            this.groupBox1.Controls.Add(this.email_label);
            this.groupBox1.Controls.Add(this.address_input);
            this.groupBox1.Controls.Add(this.address_label);
            this.groupBox1.Controls.Add(this.last_name_input);
            this.groupBox1.Controls.Add(this.last_name_label);
            this.groupBox1.Controls.Add(this.first_name_label);
            this.groupBox1.Controls.Add(this.first_name_input);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1258, 528);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create new user";
            // 
            // validation_label
            // 
            this.validation_label.AutoSize = true;
            this.validation_label.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.validation_label.ForeColor = System.Drawing.Color.IndianRed;
            this.validation_label.Location = new System.Drawing.Point(788, 371);
            this.validation_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.validation_label.Name = "validation_label";
            this.validation_label.Size = new System.Drawing.Size(71, 30);
            this.validation_label.TabIndex = 18;
            this.validation_label.Text = "label1";
            // 
            // create_user_button
            // 
            this.create_user_button.BackColor = System.Drawing.Color.OliveDrab;
            this.create_user_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.create_user_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.create_user_button.Location = new System.Drawing.Point(793, 433);
            this.create_user_button.Margin = new System.Windows.Forms.Padding(2);
            this.create_user_button.Name = "create_user_button";
            this.create_user_button.Size = new System.Drawing.Size(210, 48);
            this.create_user_button.TabIndex = 17;
            this.create_user_button.Text = "Create user";
            this.create_user_button.UseVisualStyleBackColor = false;
            this.create_user_button.Click += new System.EventHandler(this.create_user_button_Click);
            // 
            // user_photo_preview
            // 
            this.user_photo_preview.Image = global::scratch_collect.Admin.Properties.Resources.account;
            this.user_photo_preview.Location = new System.Drawing.Point(793, 64);
            this.user_photo_preview.Margin = new System.Windows.Forms.Padding(2);
            this.user_photo_preview.Name = "user_photo_preview";
            this.user_photo_preview.Size = new System.Drawing.Size(414, 193);
            this.user_photo_preview.TabIndex = 16;
            this.user_photo_preview.TabStop = false;
            // 
            // upload_profile_image_button
            // 
            this.upload_profile_image_button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.upload_profile_image_button.Location = new System.Drawing.Point(793, 276);
            this.upload_profile_image_button.Margin = new System.Windows.Forms.Padding(2);
            this.upload_profile_image_button.Name = "upload_profile_image_button";
            this.upload_profile_image_button.Size = new System.Drawing.Size(181, 41);
            this.upload_profile_image_button.TabIndex = 15;
            this.upload_profile_image_button.Text = "Upload image";
            this.upload_profile_image_button.UseVisualStyleBackColor = true;
            this.upload_profile_image_button.Click += new System.EventHandler(this.upload_profile_image_button_Click);
            // 
            // user_photo_label
            // 
            this.user_photo_label.AutoSize = true;
            this.user_photo_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.user_photo_label.Location = new System.Drawing.Point(793, 28);
            this.user_photo_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.user_photo_label.Name = "user_photo_label";
            this.user_photo_label.Size = new System.Drawing.Size(155, 32);
            this.user_photo_label.TabIndex = 14;
            this.user_photo_label.Text = "Profile image";
            // 
            // role_combobox
            // 
            this.role_combobox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.role_combobox.FormattingEnabled = true;
            this.role_combobox.Location = new System.Drawing.Point(29, 255);
            this.role_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.role_combobox.Name = "role_combobox";
            this.role_combobox.Size = new System.Drawing.Size(525, 39);
            this.role_combobox.TabIndex = 13;
            this.role_combobox.Text = "Select";
            // 
            // role_label
            // 
            this.role_label.AutoSize = true;
            this.role_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.role_label.Location = new System.Drawing.Point(29, 223);
            this.role_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.role_label.Name = "role_label";
            this.role_label.Size = new System.Drawing.Size(138, 32);
            this.role_label.TabIndex = 12;
            this.role_label.Text = "System role";
            // 
            // password_input
            // 
            this.password_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.new_user_error_provider.SetIconPadding(this.password_input, 4);
            this.password_input.Location = new System.Drawing.Point(319, 83);
            this.password_input.Margin = new System.Windows.Forms.Padding(2);
            this.password_input.Name = "password_input";
            this.password_input.Size = new System.Drawing.Size(234, 39);
            this.password_input.TabIndex = 11;
            this.password_input.UseSystemPasswordChar = true;
            this.password_input.Validating += new System.ComponentModel.CancelEventHandler(this.password_input_Validating);
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.password_label.Location = new System.Drawing.Point(319, 57);
            this.password_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(111, 32);
            this.password_label.TabIndex = 10;
            this.password_label.Text = "Password";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.username_label.Location = new System.Drawing.Point(29, 57);
            this.username_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(121, 32);
            this.username_label.TabIndex = 9;
            this.username_label.Text = "Username";
            // 
            // username_input
            // 
            this.username_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.new_user_error_provider.SetIconPadding(this.username_input, 4);
            this.username_input.Location = new System.Drawing.Point(36, 83);
            this.username_input.Margin = new System.Windows.Forms.Padding(2);
            this.username_input.Name = "username_input";
            this.username_input.Size = new System.Drawing.Size(234, 39);
            this.username_input.TabIndex = 8;
            this.username_input.Validating += new System.ComponentModel.CancelEventHandler(this.username_input_Validating);
            // 
            // email_input
            // 
            this.email_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.new_user_error_provider.SetIconPadding(this.email_input, 4);
            this.email_input.Location = new System.Drawing.Point(29, 164);
            this.email_input.Margin = new System.Windows.Forms.Padding(2);
            this.email_input.Name = "email_input";
            this.email_input.Size = new System.Drawing.Size(525, 39);
            this.email_input.TabIndex = 7;
            this.email_input.Validating += new System.ComponentModel.CancelEventHandler(this.email_input_Validating);
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.email_label.Location = new System.Drawing.Point(30, 130);
            this.email_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(71, 32);
            this.email_label.TabIndex = 6;
            this.email_label.Text = "Email";
            // 
            // address_input
            // 
            this.address_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.new_user_error_provider.SetIconPadding(this.address_input, 4);
            this.address_input.Location = new System.Drawing.Point(29, 446);
            this.address_input.Margin = new System.Windows.Forms.Padding(2);
            this.address_input.Name = "address_input";
            this.address_input.Size = new System.Drawing.Size(525, 39);
            this.address_input.TabIndex = 5;
            this.address_input.Validating += new System.ComponentModel.CancelEventHandler(this.address_input_Validating);
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.address_label.Location = new System.Drawing.Point(29, 412);
            this.address_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(98, 32);
            this.address_label.TabIndex = 4;
            this.address_label.Text = "Address";
            // 
            // last_name_input
            // 
            this.last_name_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.new_user_error_provider.SetIconPadding(this.last_name_input, 4);
            this.last_name_input.Location = new System.Drawing.Point(307, 362);
            this.last_name_input.Margin = new System.Windows.Forms.Padding(2);
            this.last_name_input.Name = "last_name_input";
            this.last_name_input.Size = new System.Drawing.Size(246, 39);
            this.last_name_input.TabIndex = 3;
            this.last_name_input.Validating += new System.ComponentModel.CancelEventHandler(this.last_name_input_Validating);
            // 
            // last_name_label
            // 
            this.last_name_label.AutoSize = true;
            this.last_name_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.last_name_label.Location = new System.Drawing.Point(307, 330);
            this.last_name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.last_name_label.Name = "last_name_label";
            this.last_name_label.Size = new System.Drawing.Size(126, 32);
            this.last_name_label.TabIndex = 2;
            this.last_name_label.Text = "Last Name";
            // 
            // first_name_label
            // 
            this.first_name_label.AutoSize = true;
            this.first_name_label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.first_name_label.Location = new System.Drawing.Point(29, 330);
            this.first_name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.first_name_label.Name = "first_name_label";
            this.first_name_label.Size = new System.Drawing.Size(129, 32);
            this.first_name_label.TabIndex = 1;
            this.first_name_label.Text = "First Name";
            // 
            // first_name_input
            // 
            this.first_name_input.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.new_user_error_provider.SetIconPadding(this.first_name_input, 4);
            this.first_name_input.Location = new System.Drawing.Point(29, 362);
            this.first_name_input.Margin = new System.Windows.Forms.Padding(2);
            this.first_name_input.Name = "first_name_input";
            this.first_name_input.Size = new System.Drawing.Size(234, 39);
            this.first_name_input.TabIndex = 0;
            this.first_name_input.Validating += new System.ComponentModel.CancelEventHandler(this.first_name_input_Validating);
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
            // new_user_error_provider
            // 
            this.new_user_error_provider.ContainerControl = this;
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 636);
            this.Controls.Add(this.table_layout_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewUserForm";
            this.Padding = new System.Windows.Forms.Padding(32, 26, 32, 26);
            this.Text = "New User";
            this.table_layout_main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_photo_preview)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.new_user_error_provider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_layout_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button go_back_button;
        private System.Windows.Forms.Label logo_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox first_name_input;
        private System.Windows.Forms.TextBox last_name_input;
        private System.Windows.Forms.Label last_name_label;
        private System.Windows.Forms.Label first_name_label;
        private System.Windows.Forms.TextBox password_input;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.TextBox username_input;
        private System.Windows.Forms.TextBox email_input;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.TextBox address_input;
        private System.Windows.Forms.Label address_label;
        private System.Windows.Forms.Label user_photo_label;
        private System.Windows.Forms.ComboBox role_combobox;
        private System.Windows.Forms.Label role_label;
        private System.Windows.Forms.Button upload_profile_image_button;
        private System.Windows.Forms.PictureBox user_photo_preview;
        private System.Windows.Forms.Button create_user_button;
        private System.Windows.Forms.ErrorProvider new_user_error_provider;
        private System.Windows.Forms.Label validation_label;
    }
}