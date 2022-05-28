namespace scratch_collect.Desktop
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.email_label = new System.Windows.Forms.Label();
            this.email_input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.signin_button = new System.Windows.Forms.Button();
            this.password_label = new System.Windows.Forms.Label();
            this.password_input = new System.Windows.Forms.TextBox();
            this.signin_error_provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.validation_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.signin_error_provider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // email_label
            // 
            this.email_label.AccessibleDescription = "Email";
            this.email_label.AccessibleName = "Email";
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.email_label.Location = new System.Drawing.Point(653, 304);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(83, 38);
            this.email_label.TabIndex = 0;
            this.email_label.Text = "Email";
            // 
            // email_input
            // 
            this.email_input.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.signin_error_provider.SetIconPadding(this.email_input, 4);
            this.email_input.Location = new System.Drawing.Point(662, 345);
            this.email_input.Name = "email_input";
            this.email_input.PlaceholderText = "mail@example.com";
            this.email_input.Size = new System.Drawing.Size(377, 45);
            this.email_input.TabIndex = 1;
            this.email_input.Validating += new System.ComponentModel.CancelEventHandler(this.email_input_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(671, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 2;
            // 
            // signin_button
            // 
            this.signin_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.signin_button.Location = new System.Drawing.Point(653, 686);
            this.signin_button.Name = "signin_button";
            this.signin_button.Size = new System.Drawing.Size(386, 98);
            this.signin_button.TabIndex = 4;
            this.signin_button.Text = "Signin";
            this.signin_button.UseVisualStyleBackColor = true;
            this.signin_button.Click += new System.EventHandler(this.signin_button_Click);
            // 
            // password_label
            // 
            this.password_label.AccessibleDescription = "Email";
            this.password_label.AccessibleName = "Email";
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.password_label.Location = new System.Drawing.Point(653, 452);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(132, 38);
            this.password_label.TabIndex = 5;
            this.password_label.Text = "Password";
            // 
            // password_input
            // 
            this.password_input.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.signin_error_provider.SetIconPadding(this.password_input, 4);
            this.password_input.Location = new System.Drawing.Point(662, 493);
            this.password_input.Name = "password_input";
            this.password_input.PasswordChar = '*';
            this.password_input.PlaceholderText = "******";
            this.password_input.Size = new System.Drawing.Size(377, 45);
            this.password_input.TabIndex = 2;
            this.password_input.UseSystemPasswordChar = true;
            this.password_input.Validating += new System.ComponentModel.CancelEventHandler(this.password_input_Validating);
            // 
            // signin_error_provider
            // 
            this.signin_error_provider.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::scratch_collect.Desktop.Properties.Resources.logo;
            this.pictureBox1.Image = global::scratch_collect.Desktop.Properties.Resources.logo;
            this.pictureBox1.InitialImage = global::scratch_collect.Desktop.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(662, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // validation_label
            // 
            this.validation_label.AutoSize = true;
            this.validation_label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.validation_label.ForeColor = System.Drawing.Color.IndianRed;
            this.validation_label.Location = new System.Drawing.Point(655, 646);
            this.validation_label.Name = "validation_label";
            this.validation_label.Size = new System.Drawing.Size(71, 30);
            this.validation_label.TabIndex = 8;
            this.validation_label.Text = "label1";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1837, 1093);
            this.Controls.Add(this.validation_label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.password_input);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.signin_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.email_input);
            this.Controls.Add(this.email_label);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(24, 65);
            this.Name = "LoginForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.signin_error_provider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.TextBox email_input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button signin_button;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox password_input;
        private System.Windows.Forms.ErrorProvider signin_error_provider;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label validation_label;
    }
}

