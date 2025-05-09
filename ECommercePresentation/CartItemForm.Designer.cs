namespace ECommercePresentation
{
    partial class CartItemForm
    {
        private System.Windows.Forms.DataGridView gridCartItems;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblQuantity;

        private void InitializeComponent()
        {
            this.gridCartItems = new System.Windows.Forms.DataGridView();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridCartItems)).BeginInit();
            this.SuspendLayout();

            // gridCartItems
            this.gridCartItems.BackgroundColor = System.Drawing.Color.White;
            this.gridCartItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCartItems.Location = new System.Drawing.Point(20, 20);
            this.gridCartItems.Name = "gridCartItems";
            this.gridCartItems.ReadOnly = true;
            this.gridCartItems.RowHeadersVisible = false;
            this.gridCartItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCartItems.Size = new System.Drawing.Size(850, 300);
            this.gridCartItems.TabIndex = 0;
            this.gridCartItems.SelectionChanged += new System.EventHandler(this.GridCartItems_SelectionChanged);

            // txtUserID
            this.txtUserID.Location = new System.Drawing.Point(120, 340);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(200, 25);
            this.txtUserID.TabIndex = 1;

            // txtProductID
            this.txtProductID.Location = new System.Drawing.Point(120, 370);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(200, 25);
            this.txtProductID.TabIndex = 2;

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(120, 400);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 25);
            this.txtQuantity.TabIndex = 3;

            // btnCreate
            this.btnCreate.Location = new System.Drawing.Point(20, 450);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 35);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(130, 450);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(240, 450);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(350, 450);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            this.lblUserID.Location = new System.Drawing.Point(20, 340);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(100, 25);
            this.lblUserID.Text = "User ID:";

            // lblProductID
            this.lblProductID.Location = new System.Drawing.Point(20, 370);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(100, 25);
            this.lblProductID.Text = "Product ID:";

            // lblQuantity
            this.lblQuantity.Location = new System.Drawing.Point(20, 400);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 25);
            this.lblQuantity.Text = "Quantity:";

            // CartItemForm
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.gridCartItems);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.lblQuantity);
            this.Text = "Cart Item Management";
            ((System.ComponentModel.ISupportInitialize)(this.gridCartItems)).EndInit();
            this.ResumeLayout(false);
        }
    }
}