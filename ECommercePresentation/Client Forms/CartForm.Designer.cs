namespace ECommercePresentation
{
    partial class CartForm
    {
        private System.Windows.Forms.DataGridView gridCart;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblTotalAmount;

        private void InitializeComponent()
        {
            this.gridCart = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).BeginInit();
            this.SuspendLayout();

            // gridCart
            this.gridCart.AllowUserToAddRows = false;
            this.gridCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCart.BackgroundColor = System.Drawing.Color.White;
            this.gridCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCart.Location = new System.Drawing.Point(20, 20);
            this.gridCart.Name = "gridCart";
            this.gridCart.ReadOnly = true;
            this.gridCart.RowHeadersVisible = false;
            this.gridCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCart.Size = new System.Drawing.Size(650, 200);
            this.gridCart.TabIndex = 0;
            this.gridCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCart_CellClick);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(20, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnCheckout
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(130, 240);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(100, 35);
            this.btnCheckout.TabIndex = 2;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);

            // lblTotalAmount
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(240, 248);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(71, 19);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "Total: $0.00";

            // CartForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gridCart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CartForm";
            this.Text = "Shopping Cart";
            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).EndInit();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Center form
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}