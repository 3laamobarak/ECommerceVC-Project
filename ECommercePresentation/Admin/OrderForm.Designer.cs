namespace ECommercePresentation
{
    partial class OrderForm
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
            gridOrders = new DataGridView();
        //    txtUserId = new TextBox();
            txtUserName = new TextBox();
            txtTotalAmount = new TextBox();
            cmbStatus = new ComboBox();
        //    btnCreate = new Button();
            btnUpdate = new Button();
        //    btnDelete = new Button();
        //    btnClear = new Button();
        //    lblUserId = new Label();
        //    lblTotalAmount = new Label();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)gridOrders).BeginInit();
            SuspendLayout();

            // gridOrders
            gridOrders.AllowUserToAddRows = false;
            gridOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridOrders.BackgroundColor = Color.White;
            gridOrders.BorderStyle = BorderStyle.None;
            gridOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOrders.Location = new Point(27, 31);
            gridOrders.Margin = new Padding(4, 5, 4, 5);
            gridOrders.Name = "gridOrders";
            gridOrders.ReadOnly = true;
            gridOrders.RowHeadersVisible = false;
            gridOrders.RowHeadersWidth = 51;
            gridOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOrders.Size = new Size(1133, 462);
            gridOrders.TabIndex = 0;
            gridOrders.SelectionChanged += GridOrders_SelectionChanged;

            // txtUserId
            // txtUserId.BorderStyle = BorderStyle.FixedSingle;
            // txtUserId.Font = new Font("Segoe UI", 10F);
            // txtUserId.Location = new Point(160, 523);
            // txtUserId.Margin = new Padding(4, 5, 4, 5);
            // txtUserId.Name = "txtUserId";
            // txtUserId.Size = new Size(266, 30);
            // txtUserId.TabIndex = 1;
            
            // txtUserName
            // txtUserName.BorderStyle = BorderStyle.FixedSingle;
            // txtUserName.Font = new Font("Segoe UI", 10F);
            // txtUserName.Location = new Point(160, 523);
            // txtUserName.Margin = new Padding(4, 5, 4, 5);
            // txtUserName.Name = "txtUserName";
            // txtUserName.Size = new Size(266, 30);
            // txtUserName.TabIndex = 1;
            //
            // // txtTotalAmount
            // txtTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            // txtTotalAmount.Font = new Font("Segoe UI", 10F);
            // txtTotalAmount.Location = new Point(160, 569);
            // txtTotalAmount.Margin = new Padding(4, 5, 4, 5);
            // txtTotalAmount.Name = "txtTotalAmount";
            // txtTotalAmount.Size = new Size(266, 30);
            // txtTotalAmount.TabIndex = 2;

            // cmbStatus
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.Items.AddRange(new object[] { "Pending", "Approved", "Denied", "Shipped"});
            cmbStatus.Location = new Point(160, 615);
            cmbStatus.Margin = new Padding(4, 5, 4, 5);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(265, 31);
            cmbStatus.TabIndex = 3;

            // btnCreate
            // btnCreate.BackColor = Color.FromArgb(40, 167, 69);
            // btnCreate.FlatAppearance.BorderSize = 0;
            // btnCreate.FlatStyle = FlatStyle.Flat;
            // btnCreate.Font = new Font("Segoe UI", 10F);
            // btnCreate.ForeColor = Color.White;
            // btnCreate.Location = new Point(468, 687);
            // btnCreate.Margin = new Padding(4, 5, 4, 5);
            // btnCreate.Name = "btnCreate";
            // btnCreate.Size = new Size(133, 54);
            // btnCreate.TabIndex = 4;
            // btnCreate.Text = "Create";
            // btnCreate.UseVisualStyleBackColor = false;
            // btnCreate.Click += BtnCreate_Click;

            // btnUpdate
            btnUpdate.BackColor = Color.FromArgb(40, 167, 69);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(27, 687);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(133, 54);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;

            // btnDelete
            // btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            // btnDelete.FlatAppearance.BorderSize = 0;
            // btnDelete.FlatStyle = FlatStyle.Flat;
            // btnDelete.ForeColor = Color.White;
            // btnDelete.Location = new Point(174, 687);
            // btnDelete.Margin = new Padding(4, 5, 4, 5);
            // btnDelete.Name = "btnDelete";
            // btnDelete.Size = new Size(133, 54);
            // btnDelete.TabIndex = 6;
            // btnDelete.Text = "Delete";
            // btnDelete.UseVisualStyleBackColor = false;
            // btnDelete.Click += BtnDelete_Click;

            // btnClear
            // btnClear.BackColor = Color.FromArgb(108, 117, 125);
            // btnClear.FlatAppearance.BorderSize = 0;
            // btnClear.FlatStyle = FlatStyle.Flat;
            // btnClear.Font = new Font("Segoe UI", 10F);
            // btnClear.ForeColor = Color.White;
            // btnClear.Location = new Point(321, 687);
            // btnClear.Margin = new Padding(4, 5, 4, 5);
            // btnClear.Name = "btnClear";
            // btnClear.Size = new Size(133, 54);
            // btnClear.TabIndex = 7;
            // btnClear.Text = "Clear";
            // btnClear.UseVisualStyleBackColor = false;
            // btnClear.Click += BtnClear_Click;
            //
            // // lblUserId
            // lblUserId.AutoSize = true;
            // lblUserId.Font = new Font("Segoe UI", 10F);
            // lblUserId.Location = new Point(27, 523);
            // lblUserId.Margin = new Padding(4, 0, 4, 0);
            // lblUserId.Name = "lblUserId";
            // lblUserId.Size = new Size(70, 23);
            // lblUserId.TabIndex = 8;
            // lblUserId.Text = "User ID:";
            //
            // // lblTotalAmount
            // lblTotalAmount.AutoSize = true;
            // lblTotalAmount.Font = new Font("Segoe UI", 10F);
            // lblTotalAmount.Location = new Point(27, 569);
            // lblTotalAmount.Margin = new Padding(4, 0, 4, 0);
            // lblTotalAmount.Name = "lblTotalAmount";
            // lblTotalAmount.Size = new Size(117, 23);
            // lblTotalAmount.TabIndex = 9;
            // lblTotalAmount.Text = "Total Amount:";

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(27, 615);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 23);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status:";

            // OrderForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1200, 923);
            // Controls.Add(btnCreate);
            Controls.Add(lblStatus);
            // Controls.Add(lblTotalAmount);
            // Controls.Add(lblUserId);
            // Controls.Add(btnClear);
            // Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(cmbStatus);
            Controls.Add(txtTotalAmount);
            // Controls.Add(txtUserId);
            Controls.Add(txtUserName);
            Controls.Add(gridOrders);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "OrderForm";
            Text = "Order Management";
            ((System.ComponentModel.ISupportInitialize)gridOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView gridOrders;
        //private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.ComboBox cmbStatus;
        // private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        // private System.Windows.Forms.Button btnDelete;
        // private System.Windows.Forms.Button btnClear;
        // private System.Windows.Forms.Label lblUserId;
        // private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblStatus;
    }
}