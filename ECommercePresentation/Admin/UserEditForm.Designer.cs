namespace ECommercePresentation
{
    partial class UserEditForm
    {
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelMain;

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            cmbRole = new ComboBox();
            chkActive = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelMain = new Panel();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(20, 20);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(260, 30);
            txtUsername.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(20, 60);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(260, 30);
            txtEmail.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(20, 100);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(260, 30);
            txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(20, 140);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(260, 30);
            txtLastName.TabIndex = 3;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.Location = new Point(20, 180);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(260, 31);
            cmbRole.TabIndex = 4;
            // 
            // chkActive
            // 
            chkActive.Font = new Font("Segoe UI", 10F);
            chkActive.Location = new Point(20, 220);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(104, 24);
            chkActive.TabIndex = 5;
            chkActive.Text = "Active";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(3, 105, 161);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 260);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(130, 260);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(txtUsername);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(txtFirstName);
            panelMain.Controls.Add(txtLastName);
            panelMain.Controls.Add(cmbRole);
            panelMain.Controls.Add(chkActive);
            panelMain.Controls.Add(btnSave);
            panelMain.Controls.Add(btnCancel);
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(300, 320);
            panelMain.TabIndex = 0;
            // 
            // UserEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 320);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit User";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }
    }
}