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
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblUnitsInStock;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.Label lblImagePath;

        private void InitializeComponent()
        {
            gridProducts = new DataGridView();
            txtName = new TextBox();
            txtDescription = new TextBox();
            txtPrice = new TextBox();
            txtUnitsInStock = new TextBox();
            txtCategoryID = new TextBox();
            txtImagePath = new TextBox();
            pictureBoxImage = new PictureBox();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnBack = new Button();
            btnSelectImage = new Button();
            lblName = new Label();
            lblDescription = new Label();
            lblPrice = new Label();
            lblUnitsInStock = new Label();
            lblCategoryID = new Label();
            lblImagePath = new Label();
            ((System.ComponentModel.ISupportInitialize)gridProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // gridProducts
            // 
            gridProducts.AllowUserToAddRows = false;
            gridProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridProducts.BackgroundColor = Color.White;
            gridProducts.BorderStyle = BorderStyle.None;
            gridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProducts.Location = new Point(27, 31);
            gridProducts.Margin = new Padding(4, 5, 4, 5);
            gridProducts.Name = "gridProducts";
            gridProducts.ReadOnly = true;
            gridProducts.RowHeadersVisible = false;
            gridProducts.RowHeadersWidth = 51;
            gridProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridProducts.Size = new Size(1133, 347);
            gridProducts.TabIndex = 0;
            gridProducts.SelectionChanged += GridProducts_SelectionChanged;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(167, 414);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(266, 30);
            txtName.TabIndex = 1;
            txtName.Enter += TextBox_Enter;
            txtName.Leave += TextBox_Leave;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(167, 460);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(266, 30);
            txtDescription.TabIndex = 2;
            txtDescription.Enter += TextBox_Enter;
            txtDescription.Leave += TextBox_Leave;
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Segoe UI", 10F);
            txtPrice.Location = new Point(167, 506);
            txtPrice.Margin = new Padding(4, 5, 4, 5);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(266, 30);
            txtPrice.TabIndex = 3;
            txtPrice.Enter += TextBox_Enter;
            txtPrice.Leave += TextBox_Leave;
            // 
            // txtUnitsInStock
            // 
            txtUnitsInStock.BorderStyle = BorderStyle.FixedSingle;
            txtUnitsInStock.Font = new Font("Segoe UI", 10F);
            txtUnitsInStock.Location = new Point(167, 553);
            txtUnitsInStock.Margin = new Padding(4, 5, 4, 5);
            txtUnitsInStock.Name = "txtUnitsInStock";
            txtUnitsInStock.Size = new Size(266, 30);
            txtUnitsInStock.TabIndex = 4;
            txtUnitsInStock.Enter += TextBox_Enter;
            txtUnitsInStock.Leave += TextBox_Leave;
            // 
            // txtCategoryID
            // 
            txtCategoryID.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryID.Font = new Font("Segoe UI", 10F);
            txtCategoryID.Location = new Point(167, 599);
            txtCategoryID.Margin = new Padding(4, 5, 4, 5);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.Size = new Size(266, 30);
            txtCategoryID.TabIndex = 5;
            txtCategoryID.Enter += TextBox_Enter;
            txtCategoryID.Leave += TextBox_Leave;
            // 
            // txtImagePath
            // 
            txtImagePath.BorderStyle = BorderStyle.FixedSingle;
            txtImagePath.Font = new Font("Segoe UI", 10F);
            txtImagePath.Location = new Point(167, 645);
            txtImagePath.Margin = new Padding(4, 5, 4, 5);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(266, 30);
            txtImagePath.TabIndex = 6;
            txtImagePath.Enter += TextBox_Enter;
            txtImagePath.Leave += TextBox_Leave;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImage.Location = new Point(541, 414);
            pictureBoxImage.Margin = new Padding(4, 5, 4, 5);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(266, 307);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxImage.TabIndex = 7;
            pictureBoxImage.TabStop = false;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(0, 123, 255);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 10F);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(27, 788);
            btnCreate.Margin = new Padding(4, 5, 4, 5);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(133, 54);
            btnCreate.TabIndex = 8;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(40, 167, 69);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(173, 788);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(133, 54);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(320, 788);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(133, 54);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(467, 788);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(133, 54);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Black;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1060, 798);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 35);
            btnBack.TabIndex = 10;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // btnSelectImage
            // 
            btnSelectImage.BackColor = Color.RosyBrown;
            btnSelectImage.FlatAppearance.BorderSize = 0;
            btnSelectImage.FlatStyle = FlatStyle.Flat;
            btnSelectImage.Font = new Font("Segoe UI", 10F);
            btnSelectImage.ForeColor = Color.White;
            btnSelectImage.Location = new Point(674, 731);
            btnSelectImage.Margin = new Padding(4, 5, 4, 5);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(133, 54);
            btnSelectImage.TabIndex = 12;
            btnSelectImage.Text = "Select Image";
            btnSelectImage.UseVisualStyleBackColor = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F);
            lblName.Location = new Point(34, 414);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(60, 23);
            lblName.TabIndex = 13;
            lblName.Text = "Name:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.Location = new Point(34, 460);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 23);
            lblDescription.TabIndex = 14;
            lblDescription.Text = "Description:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F);
            lblPrice.Location = new Point(34, 506);
            lblPrice.Margin = new Padding(4, 0, 4, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(51, 23);
            lblPrice.TabIndex = 15;
            lblPrice.Text = "Price:";
            // 
            // lblUnitsInStock
            // 
            lblUnitsInStock.AutoSize = true;
            lblUnitsInStock.Font = new Font("Segoe UI", 10F);
            lblUnitsInStock.Location = new Point(34, 553);
            lblUnitsInStock.Margin = new Padding(4, 0, 4, 0);
            lblUnitsInStock.Name = "lblUnitsInStock";
            lblUnitsInStock.Size = new Size(118, 23);
            lblUnitsInStock.TabIndex = 16;
            lblUnitsInStock.Text = "Units In Stock:";
            // 
            // lblCategoryID
            // 
            lblCategoryID.AutoSize = true;
            lblCategoryID.Font = new Font("Segoe UI", 10F);
            lblCategoryID.Location = new Point(34, 599);
            lblCategoryID.Margin = new Padding(4, 0, 4, 0);
            lblCategoryID.Name = "lblCategoryID";
            lblCategoryID.Size = new Size(105, 23);
            lblCategoryID.TabIndex = 17;
            lblCategoryID.Text = "Category ID:";
            // 
            // lblImagePath
            // 
            lblImagePath.AutoSize = true;
            lblImagePath.Font = new Font("Segoe UI", 10F);
            lblImagePath.Location = new Point(34, 645);
            lblImagePath.Margin = new Padding(4, 0, 4, 0);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(101, 23);
            lblImagePath.TabIndex = 18;
            lblImagePath.Text = "Image Path:";
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1200, 923);
            Controls.Add(btnBack);
            Controls.Add(lblImagePath);
            Controls.Add(lblCategoryID);
            Controls.Add(lblUnitsInStock);
            Controls.Add(lblPrice);
            Controls.Add(lblDescription);
            Controls.Add(lblName);
            Controls.Add(btnSelectImage);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(pictureBoxImage);
            Controls.Add(txtImagePath);
            Controls.Add(txtCategoryID);
            Controls.Add(txtUnitsInStock);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(gridProducts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "ProductForm";
            Text = "Product Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Center form

            ((System.ComponentModel.ISupportInitialize)gridProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
