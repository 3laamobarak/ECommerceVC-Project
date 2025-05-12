namespace ECommercePresentation
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblUnitsInStock;
        private System.Windows.Forms.TextBox txtUnitsInStock;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolTip toolTip;

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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            gridProducts = new DataGridView();
            inputPanel = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblUnitsInStock = new Label();
            txtUnitsInStock = new TextBox();
            lblCategoryName = new Label();
            cmbCategory = new ComboBox();
            lblImagePath = new Label();
            picProductImage = new PictureBox();
            btnSelectImage = new Button();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            toolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)gridProducts).BeginInit();
            inputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(263, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product Management";
            // 
            // gridProducts
            // 
            gridProducts.AllowUserToAddRows = false;
            gridProducts.AllowUserToDeleteRows = false;
            gridProducts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gridProducts.BackgroundColor = Color.White;
            gridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProducts.EnableHeadersVisualStyles = false;
            gridProducts.Location = new Point(20, 60);
            gridProducts.Name = "gridProducts";
            gridProducts.ReadOnly = true;
            gridProducts.RowHeadersVisible = false;
            gridProducts.RowHeadersWidth = 51;
            gridProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridProducts.Size = new Size(904, 277);
            gridProducts.TabIndex = 1;
            gridProducts.SelectionChanged += GridProducts_SelectionChanged;
            // 
            // inputPanel
            // 
            inputPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inputPanel.BackColor = Color.White;
            inputPanel.Controls.Add(lblName);
            inputPanel.Controls.Add(txtName);
            inputPanel.Controls.Add(lblDescription);
            inputPanel.Controls.Add(txtDescription);
            inputPanel.Controls.Add(lblPrice);
            inputPanel.Controls.Add(txtPrice);
            inputPanel.Controls.Add(lblUnitsInStock);
            inputPanel.Controls.Add(txtUnitsInStock);
            inputPanel.Controls.Add(lblCategoryName);
            inputPanel.Controls.Add(cmbCategory);
            inputPanel.Controls.Add(lblImagePath);
            inputPanel.Controls.Add(picProductImage);
            inputPanel.Controls.Add(btnSelectImage);
            inputPanel.Controls.Add(btnCreate);
            inputPanel.Controls.Add(btnUpdate);
            inputPanel.Controls.Add(btnDelete);
            inputPanel.Controls.Add(btnClear);
            inputPanel.Location = new Point(20, 357);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(904, 495);
            inputPanel.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(33, 37, 41);
            lblName.Location = new Point(20, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(57, 23);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(20, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 30);
            txtName.TabIndex = 3;
            toolTip.SetToolTip(txtName, "Enter the product name");
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescription.ForeColor = Color.FromArgb(33, 37, 41);
            lblDescription.Location = new Point(20, 75);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 23);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(20, 100);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(300, 30);
            txtDescription.TabIndex = 5;
            toolTip.SetToolTip(txtDescription, "Enter the product description (optional)");
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(33, 37, 41);
            lblPrice.Location = new Point(20, 145);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 23);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Segoe UI", 10F);
            txtPrice.Location = new Point(20, 170);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(150, 30);
            txtPrice.TabIndex = 7;
            toolTip.SetToolTip(txtPrice, "Enter the product price");
            // 
            // lblUnitsInStock
            // 
            lblUnitsInStock.AutoSize = true;
            lblUnitsInStock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnitsInStock.ForeColor = Color.FromArgb(33, 37, 41);
            lblUnitsInStock.Location = new Point(190, 145);
            lblUnitsInStock.Name = "lblUnitsInStock";
            lblUnitsInStock.Size = new Size(121, 23);
            lblUnitsInStock.TabIndex = 8;
            lblUnitsInStock.Text = "Units In Stock";
            // 
            // txtUnitsInStock
            // 
            txtUnitsInStock.BorderStyle = BorderStyle.FixedSingle;
            txtUnitsInStock.Font = new Font("Segoe UI", 10F);
            txtUnitsInStock.Location = new Point(190, 170);
            txtUnitsInStock.Name = "txtUnitsInStock";
            txtUnitsInStock.Size = new Size(150, 30);
            txtUnitsInStock.TabIndex = 9;
            toolTip.SetToolTip(txtUnitsInStock, "Enter the stock quantity");
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategoryName.ForeColor = Color.FromArgb(33, 37, 41);
            lblCategoryName.Location = new Point(20, 215);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(136, 23);
            lblCategoryName.TabIndex = 10;
            lblCategoryName.Text = "Category Name";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.Location = new Point(20, 240);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(300, 31);
            cmbCategory.TabIndex = 11;
            // 
            // lblImagePath
            // 
            lblImagePath.AutoSize = true;
            lblImagePath.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblImagePath.ForeColor = Color.FromArgb(33, 37, 41);
            lblImagePath.Location = new Point(437, 10);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(101, 23);
            lblImagePath.TabIndex = 12;
            lblImagePath.Text = "Image Path";
            // 
            // picProductImage
            // 
            picProductImage.BackColor = Color.FromArgb(245, 245, 245);
            picProductImage.Location = new Point(437, 35);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(200, 200);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 13;
            picProductImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.BackColor = Color.FromArgb(153, 102, 51);
            btnSelectImage.FlatAppearance.BorderSize = 0;
            btnSelectImage.FlatStyle = FlatStyle.Flat;
            btnSelectImage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSelectImage.ForeColor = Color.White;
            btnSelectImage.Location = new Point(437, 240);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(200, 40);
            btnSelectImage.TabIndex = 14;
            btnSelectImage.Text = "Select Image";
            toolTip.SetToolTip(btnSelectImage, "Select an image for the product");
            btnSelectImage.UseVisualStyleBackColor = false;
            btnSelectImage.Click += BtnSelectImage_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(0, 123, 255);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(20, 350);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(133, 54);
            btnCreate.TabIndex = 15;
            btnCreate.Text = "Create";
            toolTip.SetToolTip(btnCreate, "Create a new product");
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(40, 167, 69);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(159, 350);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(133, 54);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "Update";
            toolTip.SetToolTip(btnUpdate, "Update the selected product");
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(298, 350);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(133, 54);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            toolTip.SetToolTip(btnDelete, "Delete the selected product");
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(437, 350);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(133, 54);
            btnClear.TabIndex = 18;
            btnClear.Text = "Clear";
            toolTip.SetToolTip(btnClear, "Clear all input fields");
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1026, 900);
            Controls.Add(inputPanel);
            Controls.Add(gridProducts);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ProductForm";
            Padding = new Padding(10);
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)gridProducts).EndInit();
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}