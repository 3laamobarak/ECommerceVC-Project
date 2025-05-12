namespace ECommercePresentation
{
    partial class CartItemForm
    {
        private System.Windows.Forms.DataGridView gridCartItems;
        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMakeOrder; // New button
        private System.Windows.Forms.Label lblQuantity;

        private void InitializeComponent()
        {
            this.gridCartItems = new System.Windows.Forms.DataGridView();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnMakeOrder = new System.Windows.Forms.Button(); // New button
            this.lblQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridCartItems)).BeginInit();
            this.SuspendLayout();

            // txtSearchUser
            this.txtSearchUser.Location = new System.Drawing.Point(20, 20);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Size = new System.Drawing.Size(300, 25);
            this.txtSearchUser.TabIndex = 0;
            this.txtSearchUser.TextChanged += new System.EventHandler(this.TxtSearchUser_TextChanged);

            // gridCartItems
            this.gridCartItems.BackgroundColor = System.Drawing.Color.White;
            this.gridCartItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCartItems.Location = new System.Drawing.Point(20, 60);
            this.gridCartItems.Name = "gridCartItems";
            this.gridCartItems.ReadOnly = true;
            this.gridCartItems.RowHeadersVisible = false;
            this.gridCartItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCartItems.Size = new System.Drawing.Size(850, 250);
            this.gridCartItems.TabIndex = 1;
            this.gridCartItems.SelectionChanged += new System.EventHandler(this.GridCartItems_SelectionChanged);

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(120, 340);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 25);
            this.txtQuantity.TabIndex = 3;

            // btnCreate
            this.btnCreate.Location = new System.Drawing.Point(20, 390);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 35);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(130, 390);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(240, 390);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(350, 390);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // btnMakeOrder
            this.btnMakeOrder.Location = new System.Drawing.Point(460, 390);
            this.btnMakeOrder.Name = "btnMakeOrder";
            this.btnMakeOrder.Size = new System.Drawing.Size(100, 35);
            this.btnMakeOrder.TabIndex = 8;
            this.btnMakeOrder.Text = "Make Order";
            this.btnMakeOrder.UseVisualStyleBackColor = true;
            this.btnMakeOrder.Click += new System.EventHandler(this.BtnMakeOrder_Click);

            // lblQuantity
            this.lblQuantity.Location = new System.Drawing.Point(20, 340);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 25);
            this.lblQuantity.Text = "Quantity:";

            // CartItemForm
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.gridCartItems);
            this.Controls.Add(this.txtSearchUser);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMakeOrder); // Add the new button
            this.Controls.Add(this.lblQuantity);
            this.Text = "Cart Item Management";
            ((System.ComponentModel.ISupportInitialize)(this.gridCartItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}