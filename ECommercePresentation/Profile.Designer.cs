namespace ECommercePresentation
{
    partial class Profile
    {
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelPersonalInfo;
        private System.Windows.Forms.Label lblPersonalInfoHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Panel panelPasswordChange;
        private System.Windows.Forms.Label lblPasswordChangeHeader;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChangePassword;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelContent = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            panelPersonalInfo = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            Password = new System.Windows.Forms.Label();
            lblPersonalInfoHeader = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblFirstName = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            lblLastName = new System.Windows.Forms.Label();
            txtLastName = new System.Windows.Forms.TextBox();
            panelPasswordChange = new System.Windows.Forms.Panel();
            lblPasswordChangeHeader = new System.Windows.Forms.Label();
            lblOldPassword = new System.Windows.Forms.Label();
            txtOldPassword = new System.Windows.Forms.TextBox();
            lblNewPassword = new System.Windows.Forms.Label();
            txtNewPassword = new System.Windows.Forms.TextBox();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnChangePassword = new System.Windows.Forms.Button();
            errorProvider = new System.Windows.Forms.ErrorProvider(components);
            panelContent.SuspendLayout();
            panelPersonalInfo.SuspendLayout();
            panelPasswordChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            panelContent.Controls.Add(label3);
            panelContent.Controls.Add(panelPersonalInfo);
            panelContent.Controls.Add(panelPasswordChange);
            panelContent.Controls.Add(btnSave);
            panelContent.Controls.Add(btnChangePassword);
            panelContent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            panelContent.Location = new System.Drawing.Point(0, -1);
            panelContent.Name = "panelContent";
            panelContent.Padding = new System.Windows.Forms.Padding(20);
            panelContent.Size = new System.Drawing.Size(881, 759);
            panelContent.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.ForeColor = System.Drawing.Color.DodgerBlue;
            label3.Location = new System.Drawing.Point(23, 391);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(135, 20);
            label3.TabIndex = 11;
            label3.Text = "Change Password ?";
            label3.Click += this.label3_Click;
            // 
            // panelPersonalInfo
            // 
            panelPersonalInfo.BackColor = System.Drawing.Color.White;
            panelPersonalInfo.Controls.Add(label2);
            panelPersonalInfo.Controls.Add(Password);
            panelPersonalInfo.Controls.Add(lblPersonalInfoHeader);
            panelPersonalInfo.Controls.Add(txtPassword);
            panelPersonalInfo.Controls.Add(lblUsername);
            panelPersonalInfo.Controls.Add(txtUsername);
            panelPersonalInfo.Controls.Add(lblEmail);
            panelPersonalInfo.Controls.Add(txtEmail);
            panelPersonalInfo.Controls.Add(lblFirstName);
            panelPersonalInfo.Controls.Add(txtFirstName);
            panelPersonalInfo.Controls.Add(lblLastName);
            panelPersonalInfo.Controls.Add(txtLastName);
            panelPersonalInfo.Location = new System.Drawing.Point(20, 20);
            panelPersonalInfo.Name = "panelPersonalInfo";
            panelPersonalInfo.Padding = new System.Windows.Forms.Padding(15);
            panelPersonalInfo.Size = new System.Drawing.Size(560, 285);
            panelPersonalInfo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.ForeColor = System.Drawing.Color.IndianRed;
            label2.Location = new System.Drawing.Point(150, 234);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(278, 20);
            label2.TabIndex = 10;
            label2.Text = "Enter Your Password To Confirm Changes";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new System.Drawing.Font("Segoe UI", 9F);
            Password.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            Password.Location = new System.Drawing.Point(15, 197);
            Password.Name = "Password";
            Password.Size = new System.Drawing.Size(73, 20);
            Password.TabIndex = 8;
            Password.Text = "Password:";
            // 
            // lblPersonalInfoHeader
            // 
            lblPersonalInfoHeader.AutoSize = true;
            lblPersonalInfoHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblPersonalInfoHeader.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblPersonalInfoHeader.Location = new System.Drawing.Point(15, 15);
            lblPersonalInfoHeader.Name = "lblPersonalInfoHeader";
            lblPersonalInfoHeader.Size = new System.Drawing.Size(201, 25);
            lblPersonalInfoHeader.TabIndex = 0;
            lblPersonalInfoHeader.Text = "Personal Information";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(150, 194);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(380, 27);
            txtPassword.TabIndex = 9;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblUsername.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            lblUsername.Location = new System.Drawing.Point(15, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(78, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(150, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(380, 27);
            txtUsername.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblEmail.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            lblEmail.Location = new System.Drawing.Point(15, 85);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(49, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(150, 82);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(380, 27);
            txtEmail.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFirstName.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            lblFirstName.Location = new System.Drawing.Point(15, 120);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new System.Drawing.Size(83, 20);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(150, 117);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(380, 27);
            txtFirstName.TabIndex = 2;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblLastName.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            lblLastName.Location = new System.Drawing.Point(15, 155);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new System.Drawing.Size(82, 20);
            lblLastName.TabIndex = 4;
            lblLastName.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(150, 152);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(380, 27);
            txtLastName.TabIndex = 3;
            // 
            // panelPasswordChange
            // 
            panelPasswordChange.BackColor = System.Drawing.Color.White;
            panelPasswordChange.Controls.Add(lblPasswordChangeHeader);
            panelPasswordChange.Controls.Add(lblOldPassword);
            panelPasswordChange.Controls.Add(txtOldPassword);
            panelPasswordChange.Controls.Add(lblNewPassword);
            panelPasswordChange.Controls.Add(txtNewPassword);
            panelPasswordChange.Controls.Add(lblConfirmPassword);
            panelPasswordChange.Controls.Add(txtConfirmPassword);
            panelPasswordChange.Location = new System.Drawing.Point(20, 440);
            panelPasswordChange.Name = "panelPasswordChange";
            panelPasswordChange.Padding = new System.Windows.Forms.Padding(15);
            panelPasswordChange.Size = new System.Drawing.Size(560, 190);
            panelPasswordChange.TabIndex = 3;
            panelPasswordChange.Visible = false;
            // 
            // lblPasswordChangeHeader
            // 
            lblPasswordChangeHeader.AutoSize = true;
            lblPasswordChangeHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblPasswordChangeHeader.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblPasswordChangeHeader.Location = new System.Drawing.Point(15, 15);
            lblPasswordChangeHeader.Name = "lblPasswordChangeHeader";
            lblPasswordChangeHeader.Size = new System.Drawing.Size(169, 25);
            lblPasswordChangeHeader.TabIndex = 0;
            lblPasswordChangeHeader.Text = "Change Password";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOldPassword.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            lblOldPassword.Location = new System.Drawing.Point(15, 50);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new System.Drawing.Size(101, 20);
            lblOldPassword.TabIndex = 1;
            lblOldPassword.Text = "Old Password:";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new System.Drawing.Point(150, 47);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.Size = new System.Drawing.Size(380, 27);
            txtOldPassword.TabIndex = 5;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            lblNewPassword.Location = new System.Drawing.Point(15, 85);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new System.Drawing.Size(107, 20);
            lblNewPassword.TabIndex = 6;
            lblNewPassword.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new System.Drawing.Point(150, 82);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new System.Drawing.Size(380, 27);
            txtNewPassword.TabIndex = 6;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            lblConfirmPassword.Location = new System.Drawing.Point(15, 120);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(130, 20);
            lblConfirmPassword.TabIndex = 7;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new System.Drawing.Point(150, 117);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new System.Drawing.Size(380, 27);
            txtConfirmPassword.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnSave.Location = new System.Drawing.Point(20, 324);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(133, 54);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnChangePassword.Location = new System.Drawing.Point(20, 655);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new System.Drawing.Size(166, 54);
            btnChangePassword.TabIndex = 9;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Visible = false;
            btnChangePassword.Click += BtnChangePassword_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // Profile
            // 
            ClientSize = new System.Drawing.Size(893, 770);
            Controls.Add(panelContent);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Profile";
            Text = "Profile Management";
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelPersonalInfo.ResumeLayout(false);
            panelPersonalInfo.PerformLayout();
            panelPasswordChange.ResumeLayout(false);
            panelPasswordChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        private Label Password;
        private TextBox txtPassword;
        private Label label3;
        private Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.ComponentModel.IContainer components;
    }
}