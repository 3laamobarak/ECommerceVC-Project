namespace ECommercePresentation
{
    partial class ProductForm
    {
        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtUnitsInStock;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblUnitsInStock;
        private System.Windows.Forms.Label lblCategoryID;

        private void InitializeComponent()
        {
            this.gridProducts = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtUnitsInStock = new System.Windows.Forms.TextBox();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblUnitsInStock = new System.Windows.Forms.Label();
            this.lblCategoryID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            this.SuspendLayout();

            // gridProducts
            this.gridProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProducts.BackgroundColor = System.Drawing.Color.White;
            this.gridProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProducts.Location = new System.Drawing.Point(20, 20);
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.ReadOnly = true;
            this.gridProducts.RowHeadersVisible = false;
            this.gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProducts.Size = new System.Drawing.Size(850, 300);
            this.gridProducts.TabIndex = 0;
            this.gridProducts.SelectionChanged += new System.EventHandler(this.GridProducts_SelectionChanged);

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 340);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 25);
            this.txtName.TabIndex = 1;

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(120, 370);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 25);
            this.txtDescription.TabIndex = 2;

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(120, 400);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 25);
            this.txtPrice.TabIndex = 3;

            // txtUnitsInStock
            this.txtUnitsInStock.Location = new System.Drawing.Point(120, 430);
            this.txtUnitsInStock.Name = "txtUnitsInStock";
            this.txtUnitsInStock.Size = new System.Drawing.Size(200, 25);
            this.txtUnitsInStock.TabIndex = 4;

            // txtCategoryID
            this.txtCategoryID.Location = new System.Drawing.Point(120, 460);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(200, 25);
            this.txtCategoryID.TabIndex = 5;

            // btnCreate
            this.btnCreate.Location = new System.Drawing.Point(20, 500);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 35);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(130, 500);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(240, 500);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(350, 500);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // lblName
            this.lblName.Location = new System.Drawing.Point(20, 340);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 25);
            this.lblName.Text = "Name:";

            // lblDescription
            this.lblDescription.Location = new System.Drawing.Point(20, 370);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 25);
            this.lblDescription.Text = "Description:";

// lblPrice
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPrice.Location = new System.Drawing.Point(20, 400);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 25);
            this.lblPrice.Text = "Price:";
            this.Controls.Add(this.lblPrice);

// lblUnitsInStock
            this.lblUnitsInStock = new System.Windows.Forms.Label();
            this.lblUnitsInStock.Location = new System.Drawing.Point(20, 430);
            this.lblUnitsInStock.Name = "lblUnitsInStock";
            this.lblUnitsInStock.Size = new System.Drawing.Size(100, 25);
            this.lblUnitsInStock.Text = "Units In Stock:";
            this.Controls.Add(this.lblUnitsInStock);

// lblCategoryID
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.lblCategoryID.Location = new System.Drawing.Point(20, 460);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(100, 25);
            this.lblCategoryID.Text = "Category ID:";
            this.Controls.Add(this.lblCategoryID);
            
            // ProductForm
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.gridProducts);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtUnitsInStock);
            this.Controls.Add(this.txtCategoryID);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPrice); // Make sure this is added
            this.Controls.Add(this.lblUnitsInStock); // Make sure this is added
            this.Controls.Add(this.lblCategoryID); // Make sure this is added
            this.Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}