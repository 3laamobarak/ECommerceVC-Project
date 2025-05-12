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
            panelContent = new Panel();
            label3 = new Label();
            panelPersonalInfo = new Panel();
            label2 = new Label();
            label1 = new Label();
            lblPersonalInfoHeader = new Label();
            textBox1 = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            panelPasswordChange = new Panel();
            lblPasswordChangeHeader = new Label();
            lblOldPassword = new Label();
            txtOldPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnSave = new Button();
            btnChangePassword = new Button();
            panelContent.SuspendLayout();
            panelPersonalInfo.SuspendLayout();
            panelPasswordChange.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(245, 247, 250);
            panelContent.Controls.Add(label3);
            panelContent.Controls.Add(panelPersonalInfo);
            panelContent.Controls.Add(panelPasswordChange);
            panelContent.Controls.Add(btnSave);
            panelContent.Controls.Add(btnChangePassword);
            panelContent.ForeColor = SystemColors.ButtonHighlight;
            panelContent.Location = new Point(0, -1);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20);
            panelContent.Size = new Size(881, 759);
            panelContent.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = Color.DodgerBlue;
            label3.Location = new Point(20, 395);
            label3.Name = "label3";
            label3.Size = new Size(135, 20);
            label3.TabIndex = 11;
            label3.Text = "Change Password ?";
            // 
            // panelPersonalInfo
            // 
            panelPersonalInfo.BackColor = Color.White;
            panelPersonalInfo.Controls.Add(label2);
            panelPersonalInfo.Controls.Add(label1);
            panelPersonalInfo.Controls.Add(lblPersonalInfoHeader);
            panelPersonalInfo.Controls.Add(textBox1);
            panelPersonalInfo.Controls.Add(lblUsername);
            panelPersonalInfo.Controls.Add(txtUsername);
            panelPersonalInfo.Controls.Add(lblEmail);
            panelPersonalInfo.Controls.Add(txtEmail);
            panelPersonalInfo.Controls.Add(lblFirstName);
            panelPersonalInfo.Controls.Add(txtFirstName);
            panelPersonalInfo.Controls.Add(lblLastName);
            panelPersonalInfo.Controls.Add(txtLastName);
            panelPersonalInfo.Location = new Point(20, 20);
            panelPersonalInfo.Name = "panelPersonalInfo";
            panelPersonalInfo.Padding = new Padding(15);
            panelPersonalInfo.Size = new Size(560, 285);
            panelPersonalInfo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(150, 234);
            label2.Name = "label2";
            label2.Size = new Size(278, 20);
            label2.TabIndex = 10;
            label2.Text = "Enter Your Password To Confirm Changes";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.FromArgb(75, 85, 99);
            label1.Location = new Point(15, 197);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 8;
            label1.Text = "Password:";
            // 
            // lblPersonalInfoHeader
            // 
            lblPersonalInfoHeader.AutoSize = true;
            lblPersonalInfoHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPersonalInfoHeader.ForeColor = Color.FromArgb(31, 41, 55);
            lblPersonalInfoHeader.Location = new Point(15, 15);
            lblPersonalInfoHeader.Name = "lblPersonalInfoHeader";
            lblPersonalInfoHeader.Size = new Size(201, 25);
            lblPersonalInfoHeader.TabIndex = 0;
            lblPersonalInfoHeader.Text = "Personal Information";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(150, 194);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(380, 27);
            textBox1.TabIndex = 9;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.ForeColor = Color.FromArgb(75, 85, 99);
            lblUsername.Location = new Point(15, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(150, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(380, 27);
            txtUsername.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.FromArgb(75, 85, 99);
            lblEmail.Location = new Point(15, 85);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 82);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(380, 27);
            txtEmail.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9F);
            lblFirstName.ForeColor = Color.FromArgb(75, 85, 99);
            lblFirstName.Location = new Point(15, 120);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(83, 20);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(150, 117);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(380, 27);
            txtFirstName.TabIndex = 2;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9F);
            lblLastName.ForeColor = Color.FromArgb(75, 85, 99);
            lblLastName.Location = new Point(15, 155);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(82, 20);
            lblLastName.TabIndex = 4;
            lblLastName.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(150, 152);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(380, 27);
            txtLastName.TabIndex = 3;
            // 
            // panelPasswordChange
            // 
            panelPasswordChange.BackColor = Color.White;
            panelPasswordChange.Controls.Add(lblPasswordChangeHeader);
            panelPasswordChange.Controls.Add(lblOldPassword);
            panelPasswordChange.Controls.Add(txtOldPassword);
            panelPasswordChange.Controls.Add(lblNewPassword);
            panelPasswordChange.Controls.Add(txtNewPassword);
            panelPasswordChange.Controls.Add(lblConfirmPassword);
            panelPasswordChange.Controls.Add(txtConfirmPassword);
            panelPasswordChange.Location = new Point(20, 440);
            panelPasswordChange.Name = "panelPasswordChange";
            panelPasswordChange.Padding = new Padding(15);
            panelPasswordChange.Size = new Size(560, 190);
            panelPasswordChange.TabIndex = 3;
            // 
            // lblPasswordChangeHeader
            // 
            lblPasswordChangeHeader.AutoSize = true;
            lblPasswordChangeHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPasswordChangeHeader.ForeColor = Color.FromArgb(31, 41, 55);
            lblPasswordChangeHeader.Location = new Point(15, 15);
            lblPasswordChangeHeader.Name = "lblPasswordChangeHeader";
            lblPasswordChangeHeader.Size = new Size(169, 25);
            lblPasswordChangeHeader.TabIndex = 0;
            lblPasswordChangeHeader.Text = "Change Password";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new Font("Segoe UI", 9F);
            lblOldPassword.ForeColor = Color.FromArgb(75, 85, 99);
            lblOldPassword.Location = new Point(15, 50);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(101, 20);
            lblOldPassword.TabIndex = 1;
            lblOldPassword.Text = "Old Password:";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(150, 47);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.Size = new Size(380, 27);
            txtOldPassword.TabIndex = 5;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 9F);
            lblNewPassword.ForeColor = Color.FromArgb(75, 85, 99);
            lblNewPassword.Location = new Point(15, 85);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(107, 20);
            lblNewPassword.TabIndex = 6;
            lblNewPassword.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(150, 82);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(380, 27);
            txtNewPassword.TabIndex = 6;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F);
            lblConfirmPassword.ForeColor = Color.FromArgb(75, 85, 99);
            lblConfirmPassword.Location = new Point(15, 120);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 20);
            lblConfirmPassword.TabIndex = 7;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(150, 117);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(380, 27);
            txtConfirmPassword.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(40, 167, 69);
            btnSave.Location = new Point(20, 324);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 54);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(40, 167, 69);
            btnChangePassword.Location = new Point(20, 655);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(166, 54);
            btnChangePassword.TabIndex = 9;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += BtnChangePassword_Click;
            // 
            // Profile
            // 
            ClientSize = new Size(893, 770);
            Controls.Add(panelContent);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Profile";
            Text = "Profile Management";
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelPersonalInfo.ResumeLayout(false);
            panelPersonalInfo.PerformLayout();
            panelPasswordChange.ResumeLayout(false);
            panelPasswordChange.PerformLayout();
            ResumeLayout(false);
        }

        private Label label1;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
    }
}