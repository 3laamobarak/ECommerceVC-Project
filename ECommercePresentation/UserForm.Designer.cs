namespace ECommercePresentation
{
    partial class UserForm
    {
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabAdmins;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.DataGridView dataGridViewAdmins;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsernameClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmailClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstNameClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastNameClients;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRoleClients;
        private System.Windows.Forms.DataGridViewComboBoxColumn colActiveClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastLoginClients;
        private System.Windows.Forms.DataGridViewButtonColumn colEditClients;
        private System.Windows.Forms.DataGridViewButtonColumn colDeleteClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsernameAdmins;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmailAdmins;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstNameAdmins;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastNameAdmins;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRoleAdmins;
        private System.Windows.Forms.DataGridViewComboBoxColumn colActiveAdmins;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedAdmins;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastLoginAdmins;
        private System.Windows.Forms.DataGridViewButtonColumn colEditAdmins;
        private System.Windows.Forms.DataGridViewButtonColumn colDeleteAdmins;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelMain;

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.tabAdmins = new System.Windows.Forms.TabPage();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.colUsernameClients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmailClients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstNameClients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastNameClients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleClients = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colActiveClients = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCreatedClients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastLoginClients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditClients = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDeleteClients = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewAdmins = new System.Windows.Forms.DataGridView();
            this.colUsernameAdmins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmailAdmins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstNameAdmins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastNameAdmins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleAdmins = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colActiveAdmins = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCreatedAdmins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastLoginAdmins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditAdmins = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDeleteAdmins = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();

            // tabControl
            this.tabControl.Controls.Add(this.tabClients);
            this.tabControl.Controls.Add(this.tabAdmins);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Size = new System.Drawing.Size(1170, 600);
            this.tabControl.TabIndex = 0;

            // tabClients
            this.tabClients.Location = new System.Drawing.Point(4, 29);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(1162, 567);
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Clients";
            this.tabClients.UseVisualStyleBackColor = true;
            this.tabClients.Controls.Add(this.dataGridViewClients);

            // tabAdmins
            this.tabAdmins.Location = new System.Drawing.Point(4, 29);
            this.tabAdmins.Name = "tabAdmins";
            this.tabAdmins.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmins.Size = new System.Drawing.Size(1162, 567);
            this.tabAdmins.TabIndex = 1;
            this.tabAdmins.Text = "Admins";
            this.tabAdmins.UseVisualStyleBackColor = true;
            this.tabAdmins.Controls.Add(this.dataGridViewAdmins);

            // dataGridViewClients
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colUsernameClients, colEmailClients, colFirstNameClients, colLastNameClients, colRoleClients,
                colActiveClients, colCreatedClients, colLastLoginClients, colEditClients, colDeleteClients});
            this.dataGridViewClients.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewClients.Size = new System.Drawing.Size(1150, 550);
            this.dataGridViewClients.TabIndex = 0;
            this.dataGridViewClients.AllowUserToAddRows = false; // Remove extra line
            this.dataGridViewClients.CellContentClick += new DataGridViewCellEventHandler(DataGridViewClients_CellContentClick);
            this.dataGridViewClients.CellValueChanged += new DataGridViewCellEventHandler(DataGridViewClients_CellValueChanged);
            this.dataGridViewClients.EditMode = DataGridViewEditMode.EditOnEnter;

            // dataGridViewAdmins
            this.dataGridViewAdmins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdmins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colUsernameAdmins, colEmailAdmins, colFirstNameAdmins, colLastNameAdmins, colRoleAdmins,
                colActiveAdmins, colCreatedAdmins, colLastLoginAdmins, colEditAdmins, colDeleteAdmins});
            this.dataGridViewAdmins.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewAdmins.Size = new System.Drawing.Size(1150, 550);
            this.dataGridViewAdmins.TabIndex = 0;
            this.dataGridViewAdmins.AllowUserToAddRows = false; // Remove extra line
            this.dataGridViewAdmins.CellContentClick += new DataGridViewCellEventHandler(DataGridViewAdmins_CellContentClick);
            this.dataGridViewAdmins.CellValueChanged += new DataGridViewCellEventHandler(DataGridViewAdmins_CellValueChanged);
            this.dataGridViewAdmins.EditMode = DataGridViewEditMode.EditOnEnter;

            // Column Headers for Clients
            this.colUsernameClients.HeaderText = "Username";
            this.colUsernameClients.Name = "colUsernameClients";
            this.colUsernameClients.Width = 100;
            this.colEmailClients.HeaderText = "Email";
            this.colEmailClients.Name = "colEmailClients";
            this.colEmailClients.Width = 150;
            this.colFirstNameClients.HeaderText = "First Name";
            this.colFirstNameClients.Name = "colFirstNameClients";
            this.colFirstNameClients.Width = 100;
            this.colLastNameClients.HeaderText = "Last Name";
            this.colLastNameClients.Name = "colLastNameClients";
            this.colLastNameClients.Width = 100;
            this.colRoleClients.HeaderText = "Role";
            this.colRoleClients.Name = "colRoleClients";
            this.colRoleClients.Width = 80;
            this.colRoleClients.Items.AddRange(new object[] { "Client", "Admin", "SuperAdmin" });
            this.colActiveClients.HeaderText = "Active";
            this.colActiveClients.Name = "colActiveClients";
            this.colActiveClients.Width = 60;
            this.colActiveClients.Items.AddRange(new object[] { "True", "False" });
            this.colCreatedClients.HeaderText = "Created";
            this.colCreatedClients.Name = "colCreatedClients";
            this.colCreatedClients.Width = 120;
            this.colCreatedClients.ReadOnly = true;
            this.colLastLoginClients.HeaderText = "Last Login";
            this.colLastLoginClients.Name = "colLastLoginClients";
            this.colLastLoginClients.Width = 120;
            this.colLastLoginClients.ReadOnly = true;
            this.colEditClients.HeaderText = "Edit";
            this.colEditClients.Name = "colEditClients";
            this.colEditClients.Width = 80;
            this.colEditClients.Text = "Edit";
            this.colDeleteClients.HeaderText = "Delete";
            this.colDeleteClients.Name = "colDeleteClients";
            this.colDeleteClients.Width = 80;
            this.colDeleteClients.Text = "Delete";

            // Column Headers for Admins
            this.colUsernameAdmins.HeaderText = "Username";
            this.colUsernameAdmins.Name = "colUsernameAdmins";
            this.colUsernameAdmins.Width = 100;
            this.colEmailAdmins.HeaderText = "Email";
            this.colEmailAdmins.Name = "colEmailAdmins";
            this.colEmailAdmins.Width = 150;
            this.colFirstNameAdmins.HeaderText = "First Name";
            this.colFirstNameAdmins.Name = "colFirstNameAdmins";
            this.colFirstNameAdmins.Width = 100;
            this.colLastNameAdmins.HeaderText = "Last Name";
            this.colLastNameAdmins.Name = "colLastNameAdmins";
            this.colLastNameAdmins.Width = 100;
            this.colRoleAdmins.HeaderText = "Role";
            this.colRoleAdmins.Name = "colRoleAdmins";
            this.colRoleAdmins.Width = 80;
            this.colRoleAdmins.Items.AddRange(new object[] { "Client", "Admin", "SuperAdmin" });
            this.colActiveAdmins.HeaderText = "Active";
            this.colActiveAdmins.Name = "colActiveAdmins";
            this.colActiveAdmins.Width = 60;
            this.colActiveAdmins.Items.AddRange(new object[] { "True", "False" });
            this.colCreatedAdmins.HeaderText = "Created";
            this.colCreatedAdmins.Name = "colCreatedAdmins";
            this.colCreatedAdmins.Width = 120;
            this.colCreatedAdmins.ReadOnly = true;
            this.colLastLoginAdmins.HeaderText = "Last Login";
            this.colLastLoginAdmins.Name = "colLastLoginAdmins";
            this.colLastLoginAdmins.Width = 120;
            this.colLastLoginAdmins.ReadOnly = true;
            this.colEditAdmins.HeaderText = "Edit";
            this.colEditAdmins.Name = "colEditAdmins";
            this.colEditAdmins.Width = 80;
            this.colEditAdmins.Text = "Edit";
            this.colDeleteAdmins.HeaderText = "Delete";
            this.colDeleteAdmins.Name = "colDeleteAdmins";
            this.colDeleteAdmins.Width = 80;
            this.colDeleteAdmins.Text = "Delete";

            // btnBack
            this.btnBack.Text = "Back";
            this.btnBack.Location = new System.Drawing.Point(10, 620);
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.BackColor = Color.FromArgb(3, 105, 161);
            this.btnBack.ForeColor = Color.White;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnBack.Click += new EventHandler(BtnBack_Click);

            // panelMain
            this.panelMain.BackColor = Color.White;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Size = new System.Drawing.Size(1190, 680);
            this.panelMain.Controls.Add(this.tabControl);
            this.panelMain.Controls.Add(this.btnBack);

            // UserForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 680);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.Text = "User Management";
            this.tabControl.ResumeLayout(false);
            this.tabClients.ResumeLayout(false);
            this.tabAdmins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmins)).EndInit();
            this.ResumeLayout(false);
        }
    }
}