namespace ECommercePresentation.AuthForms
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblBrandSubtitle;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBackToLogin;
        private System.Windows.Forms.ToolTip toolTip;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelLeft = new System.Windows.Forms.Panel();
            lblBrandSubtitle = new System.Windows.Forms.Label();
            lblBrandTitle = new System.Windows.Forms.Label();
            panelRight = new System.Windows.Forms.Panel();
            btnBackToLogin = new System.Windows.Forms.Button();
            btnRegister = new System.Windows.Forms.Button();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            lblPassword = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            txtLastName = new System.Windows.Forms.TextBox();
            lblLastName = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            lblFirstName = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            errorProvider = new System.Windows.Forms.ErrorProvider(components);
            toolTip = new System.Windows.Forms.ToolTip(components);
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            panelLeft.Controls.Add(lblBrandSubtitle);
            panelLeft.Controls.Add(lblBrandTitle);
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(300, 600);
            panelLeft.TabIndex = 0;
            // 
            // lblBrandSubtitle
            // 
            lblBrandSubtitle.AutoSize = true;
            lblBrandSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblBrandSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            lblBrandSubtitle.Location = new System.Drawing.Point(30, 190);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new System.Drawing.Size(215, 28);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "Shop Smart, Live Better";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblBrandTitle.ForeColor = System.Drawing.Color.White;
            lblBrandTitle.Location = new System.Drawing.Point(30, 150);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new System.Drawing.Size(208, 46);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "ECommerce";
            // 
            // panelRight
            // 
            panelRight.BackColor = System.Drawing.Color.White;
            panelRight.Controls.Add(btnBackToLogin);
            panelRight.Controls.Add(btnRegister);
            panelRight.Controls.Add(txtConfirmPassword);
            panelRight.Controls.Add(lblConfirmPassword);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(lblPassword);
            panelRight.Controls.Add(txtEmail);
            panelRight.Controls.Add(lblEmail);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(lblUsername);
            panelRight.Controls.Add(txtLastName);
            panelRight.Controls.Add(lblLastName);
            panelRight.Controls.Add(txtFirstName);
            panelRight.Controls.Add(lblFirstName);
            panelRight.Controls.Add(lblTitle);
            panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRight.Location = new System.Drawing.Point(300, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new System.Windows.Forms.Padding(40);
            panelRight.Size = new System.Drawing.Size(500, 600);
            panelRight.TabIndex = 1;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnBackToLogin.FlatAppearance.BorderSize = 0;
            btnBackToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBackToLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnBackToLogin.ForeColor = System.Drawing.Color.White;
            btnBackToLogin.Location = new System.Drawing.Point(250, 460);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new System.Drawing.Size(190, 40);
            btnBackToLogin.TabIndex = 14;
            btnBackToLogin.Text = "Back to Login";
            toolTip.SetToolTip(btnBackToLogin, "Return to the login page");
            btnBackToLogin.UseVisualStyleBackColor = false;
            btnBackToLogin.Click += btnBackToLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnRegister.ForeColor = System.Drawing.Color.White;
            btnRegister.Location = new System.Drawing.Point(40, 460);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(190, 40);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Register";
            toolTip.SetToolTip(btnRegister, "Create your account");
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new System.Drawing.Point(40, 415);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new System.Drawing.Size(400, 30);
            txtConfirmPassword.TabIndex = 12;
            toolTip.SetToolTip(txtConfirmPassword, "Re-enter your password to confirm");
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblConfirmPassword.Location = new System.Drawing.Point(40, 390);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(156, 23);
            lblConfirmPassword.TabIndex = 11;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPassword.Location = new System.Drawing.Point(40, 355);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(400, 30);
            txtPassword.TabIndex = 10;
            toolTip.SetToolTip(txtPassword, "Enter your password (minimum 8 characters)");
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblPassword.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblPassword.Location = new System.Drawing.Point(40, 330);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(85, 23);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEmail.Location = new System.Drawing.Point(40, 295);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(400, 30);
            txtEmail.TabIndex = 8;
            toolTip.SetToolTip(txtEmail, "Enter your email address");
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblEmail.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblEmail.Location = new System.Drawing.Point(40, 270);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(54, 23);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtUsername.Location = new System.Drawing.Point(40, 235);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(400, 30);
            txtUsername.TabIndex = 6;
            toolTip.SetToolTip(txtUsername, "Choose a unique username");
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblUsername.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblUsername.Location = new System.Drawing.Point(40, 210);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(89, 23);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Username";
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtLastName.Location = new System.Drawing.Point(40, 175);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(400, 30);
            txtLastName.TabIndex = 4;
            toolTip.SetToolTip(txtLastName, "Enter your last name");
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblLastName.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblLastName.Location = new System.Drawing.Point(40, 150);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new System.Drawing.Size(94, 23);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtFirstName.Location = new System.Drawing.Point(40, 115);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(400, 30);
            txtFirstName.TabIndex = 2;
            toolTip.SetToolTip(txtFirstName, "Enter your first name");
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblFirstName.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblFirstName.Location = new System.Drawing.Point(40, 90);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new System.Drawing.Size(97, 23);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblTitle.Location = new System.Drawing.Point(40, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(251, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create an Account";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(800, 600);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegistrationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Register - ECommerce";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }
    }
}