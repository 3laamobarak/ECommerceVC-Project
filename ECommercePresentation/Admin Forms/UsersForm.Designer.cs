namespace ECommercePresentation
{
    partial class UsersForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.tabAdmins = new System.Windows.Forms.TabPage();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.dgvAdmins = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmins)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabClients.SuspendLayout();
            this.tabAdmins.SuspendLayout();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.tabClients);
            this.tabControl.Controls.Add(this.tabAdmins);
            this.tabControl.Location = new System.Drawing.Point(20, 20);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(860, 500);
            this.tabControl.TabIndex = 0;

            // tabClients
            this.tabClients.Controls.Add(this.dgvClients);
            this.tabClients.Location = new System.Drawing.Point(4, 22);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(852, 474);
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Clients";
            this.tabClients.UseVisualStyleBackColor = true;

            // tabAdmins
            this.tabAdmins.Controls.Add(this.dgvAdmins);
            this.tabAdmins.Location = new System.Drawing.Point(4, 22);
            this.tabAdmins.Name = "tabAdmins";
            this.tabAdmins.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmins.Size = new System.Drawing.Size(852, 474);
            this.tabAdmins.TabIndex = 1;
            this.tabAdmins.Text = "Admins";
            this.tabAdmins.UseVisualStyleBackColor = true;

            // dgvClients
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(6, 6);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowTemplate.Height = 25;
            this.dgvClients.Size = new System.Drawing.Size(840, 462);
            this.dgvClients.TabIndex = 0;
            this.dgvClients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvClients_CellContentClick);
            // Columns
            var colUsername = new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Username", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colEmail = new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colFirstName = new DataGridViewTextBoxColumn { DataPropertyName = "FirstName", HeaderText = "First Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colLastName = new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = "Last Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colRole = new DataGridViewTextBoxColumn { DataPropertyName = "Role", HeaderText = "Role", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colIsActive = new DataGridViewCheckBoxColumn { DataPropertyName = "IsActive", HeaderText = "Active", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colDateCreated = new DataGridViewTextBoxColumn { DataPropertyName = "DateCreated", HeaderText = "Created", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colLastLogin = new DataGridViewTextBoxColumn { DataPropertyName = "LastLoginDate", HeaderText = "Last Login", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colActivate = new DataGridViewButtonColumn { Name = "Activate", HeaderText = "Activate", Text = "Activate", UseColumnTextForButtonValue = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 80 };
            var colDeactivate = new DataGridViewButtonColumn { Name = "Deactivate", HeaderText = "Deactivate", Text = "Deactivate", UseColumnTextForButtonValue = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 80 };
            var colChangeRole = new DataGridViewButtonColumn { Name = "ChangeRole", HeaderText = "Change Role", Text = "Change Role", UseColumnTextForButtonValue = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 80 };
            this.dgvClients.Columns.AddRange(new DataGridViewColumn[] { colUsername, colEmail, colFirstName, colLastName, colRole, colIsActive, colDateCreated, colLastLogin, colActivate, colDeactivate, colChangeRole });

            // dgvAdmins
            this.dgvAdmins.AllowUserToAddRows = false;
            this.dgvAdmins.AllowUserToDeleteRows = false;
            this.dgvAdmins.BackgroundColor = System.Drawing.Color.White;
            this.dgvAdmins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmins.Location = new System.Drawing.Point(6, 6);
            this.dgvAdmins.Name = "dgvAdmins";
            this.dgvAdmins.ReadOnly = true;
            this.dgvAdmins.RowTemplate.Height = 25;
            this.dgvAdmins.Size = new System.Drawing.Size(840, 462);
            this.dgvAdmins.TabIndex = 0;
            this.dgvAdmins.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdmins_CellContentClick);
            // Columns
            var colAdminUsername = new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Username", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colAdminEmail = new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colAdminFirstName = new DataGridViewTextBoxColumn { DataPropertyName = "FirstName", HeaderText = "First Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colAdminLastName = new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = "Last Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colAdminRole = new DataGridViewTextBoxColumn { DataPropertyName = "Role", HeaderText = "Role", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colAdminIsActive = new DataGridViewCheckBoxColumn { DataPropertyName = "IsActive", HeaderText = "Active", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colAdminDateCreated = new DataGridViewTextBoxColumn { DataPropertyName = "DateCreated", HeaderText = "Created", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colAdminLastLogin = new DataGridViewTextBoxColumn { DataPropertyName = "LastLoginDate", HeaderText = "Last Login", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colAdminActivate = new DataGridViewButtonColumn { Name = "Activate", HeaderText = "Activate", Text = "Activate", UseColumnTextForButtonValue = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 80 };
            var colAdminDeactivate = new DataGridViewButtonColumn { Name = "Deactivate", HeaderText = "Deactivate", Text = "Deactivate", UseColumnTextForButtonValue = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 80 };
            var colAdminChangeRole = new DataGridViewButtonColumn { Name = "ChangeRole", HeaderText = "Change Role", Text = "Change Role", UseColumnTextForButtonValue = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 80 };
            this.dgvAdmins.Columns.AddRange(new DataGridViewColumn[] { colAdminUsername, colAdminEmail, colAdminFirstName, colAdminLastName, colAdminRole, colAdminIsActive, colAdminDateCreated, colAdminLastLogin, colAdminActivate, colAdminDeactivate, colAdminChangeRole });

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(460, 560);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);

            // UsersForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UsersForm";
            this.Text = "User Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmins)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabClients.ResumeLayout(false);
            this.tabAdmins.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}