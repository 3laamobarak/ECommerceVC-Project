namespace ECommercePresentation
{
    partial class Profile
    {
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelPersonalInfo;
        private System.Windows.Forms.Label lblPersonalInfoHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cbStatus;
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelPersonalInfo = new System.Windows.Forms.Panel();
            this.lblPersonalInfoHeader = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.panelPasswordChange = new System.Windows.Forms.Panel();
            this.lblPasswordChangeHeader = new System.Windows.Forms.Label();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelPersonalInfo.SuspendLayout();
            this.panelPasswordChange.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(3, 105, 161);
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 60);
            this.panelHeader.TabIndex = 0;

            // lblHeader
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(180, 25);
            this.lblHeader.Text = "Profile Management";

            // panelContent
            this.panelContent.BackColor = Color.FromArgb(245, 247, 250);
            this.panelContent.Controls.Add(this.panelPersonalInfo);
            this.panelContent.Controls.Add(this.panelPasswordChange);
            this.panelContent.Controls.Add(this.btnSave);
            this.panelContent.Controls.Add(this.btnChangePassword);
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(600, 500);
            this.panelContent.TabIndex = 1;
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);

            // panelPersonalInfo
            this.panelPersonalInfo.BackColor = Color.White;
            this.panelPersonalInfo.Controls.Add(this.lblPersonalInfoHeader);
            this.panelPersonalInfo.Controls.Add(this.lblUsername);
            this.panelPersonalInfo.Controls.Add(this.txtUsername);
            this.panelPersonalInfo.Controls.Add(this.lblEmail);
            this.panelPersonalInfo.Controls.Add(this.txtEmail);
            this.panelPersonalInfo.Controls.Add(this.lblFirstName);
            this.panelPersonalInfo.Controls.Add(this.txtFirstName);
            this.panelPersonalInfo.Controls.Add(this.lblLastName);
            this.panelPersonalInfo.Controls.Add(this.txtLastName);
            this.panelPersonalInfo.Controls.Add(this.lblStatus);
            this.panelPersonalInfo.Controls.Add(this.cbStatus);
            this.panelPersonalInfo.Location = new System.Drawing.Point(20, 20);
            this.panelPersonalInfo.Name = "panelPersonalInfo";
            this.panelPersonalInfo.Size = new System.Drawing.Size(560, 220);
            this.panelPersonalInfo.TabIndex = 2;
            this.panelPersonalInfo.Padding = new System.Windows.Forms.Padding(15);

            // lblPersonalInfoHeader
            this.lblPersonalInfoHeader.AutoSize = true;
            this.lblPersonalInfoHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPersonalInfoHeader.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblPersonalInfoHeader.Location = new System.Drawing.Point(15, 15);
            this.lblPersonalInfoHeader.Name = "lblPersonalInfoHeader";
            this.lblPersonalInfoHeader.Size = new System.Drawing.Size(150, 20);
            this.lblPersonalInfoHeader.Text = "Personal Information";

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblUsername.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblUsername.Location = new System.Drawing.Point(15, 50);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(70, 15);
            this.lblUsername.Text = "Username:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(150, 47);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(380, 23);
            this.txtUsername.TabIndex = 0;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblEmail.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblEmail.Location = new System.Drawing.Point(15, 85);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(40, 15);
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(150, 82);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(380, 23);
            this.txtEmail.TabIndex = 1;

            // lblFirstName
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblFirstName.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblFirstName.Location = new System.Drawing.Point(15, 120);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(70, 15);
            this.lblFirstName.Text = "First Name:";

            // txtFirstName
            this.txtFirstName.Location = new System.Drawing.Point(150, 117);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(380, 23);
            this.txtFirstName.TabIndex = 2;

            // lblLastName
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblLastName.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblLastName.Location = new System.Drawing.Point(15, 155);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(70, 15);
            this.lblLastName.Text = "Last Name:";

            // txtLastName
            this.txtLastName.Location = new System.Drawing.Point(150, 152);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(380, 23);
            this.txtLastName.TabIndex = 3;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblStatus.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblStatus.Location = new System.Drawing.Point(15, 190);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.Text = "Status:";

            // cbStatus
            this.cbStatus.Location = new System.Drawing.Point(150, 187);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(150, 23);
            this.cbStatus.TabIndex = 4;
            this.cbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // panelPasswordChange
            this.panelPasswordChange.BackColor = Color.White;
            this.panelPasswordChange.Controls.Add(this.lblPasswordChangeHeader);
            this.panelPasswordChange.Controls.Add(this.lblOldPassword);
            this.panelPasswordChange.Controls.Add(this.txtOldPassword);
            this.panelPasswordChange.Controls.Add(this.lblNewPassword);
            this.panelPasswordChange.Controls.Add(this.txtNewPassword);
            this.panelPasswordChange.Controls.Add(this.lblConfirmPassword);
            this.panelPasswordChange.Controls.Add(this.txtConfirmPassword);
            this.panelPasswordChange.Location = new System.Drawing.Point(20, 250);
            this.panelPasswordChange.Name = "panelPasswordChange";
            this.panelPasswordChange.Size = new System.Drawing.Size(560, 190);
            this.panelPasswordChange.TabIndex = 3;
            this.panelPasswordChange.Padding = new System.Windows.Forms.Padding(15);

            // lblPasswordChangeHeader
            this.lblPasswordChangeHeader.AutoSize = true;
            this.lblPasswordChangeHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPasswordChangeHeader.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblPasswordChangeHeader.Location = new System.Drawing.Point(15, 15);
            this.lblPasswordChangeHeader.Name = "lblPasswordChangeHeader";
            this.lblPasswordChangeHeader.Size = new System.Drawing.Size(150, 20);
            this.lblPasswordChangeHeader.Text = "Change Password";

            // lblOldPassword
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblOldPassword.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblOldPassword.Location = new System.Drawing.Point(15, 50);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(90, 15);
            this.lblOldPassword.Text = "Old Password:";

            // txtOldPassword
            this.txtOldPassword.Location = new System.Drawing.Point(150, 47);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(380, 23);
            this.txtOldPassword.TabIndex = 5;
            this.txtOldPassword.PasswordChar = '*';

            // lblNewPassword
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblNewPassword.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblNewPassword.Location = new System.Drawing.Point(15, 85);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(95, 15);
            this.lblNewPassword.Text = "New Password:";

            // txtNewPassword
            this.txtNewPassword.Location = new System.Drawing.Point(150, 82);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(380, 23);
            this.txtNewPassword.TabIndex = 6;
            this.txtNewPassword.PasswordChar = '*';

            // lblConfirmPassword
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblConfirmPassword.ForeColor = Color.FromArgb(75, 85, 99);
            this.lblConfirmPassword.Location = new System.Drawing.Point(15, 120);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(110, 15);
            this.lblConfirmPassword.Text = "Confirm Password:";

            // txtConfirmPassword
            this.txtConfirmPassword.Location = new System.Drawing.Point(150, 117);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(380, 23);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.PasswordChar = '*';

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(350, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // btnChangePassword
            this.btnChangePassword.Location = new System.Drawing.Point(460, 460);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(120, 35);
            this.btnChangePassword.TabIndex = 9;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);

            // ProfileForm
            this.ClientSize = new System.Drawing.Size(600, 560);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Profile Management";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelPersonalInfo.ResumeLayout(false);
            this.panelPersonalInfo.PerformLayout();
            this.panelPasswordChange.ResumeLayout(false);
            this.panelPasswordChange.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}