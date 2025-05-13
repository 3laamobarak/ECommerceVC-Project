using ECommercePresentation.Client;

namespace ECommercePresentation.Client
{
    partial class ProductDetailForm
    {
        private System.Windows.Forms.PictureBox picMainImage;
        private System.Windows.Forms.Label lblBrandAndName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Label lblDeliveryInfo;

        private void InitializeComponent()
        {
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Text = "Product Detail";
            this.BackColor = System.Drawing.Color.White;

            // Main Layout: Split into 2 columns (60% left, 40% right)
            System.Windows.Forms.TableLayoutPanel tblMain = new System.Windows.Forms.TableLayoutPanel
            {
                Size = new System.Drawing.Size(1000, 700),
                Location = new System.Drawing.Point(0, 0),
                ColumnCount = 2,
                RowCount = 1,
                ColumnStyles = { new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F), new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F) },
                RowStyles = { new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F) }
            };

            // Left Section: Product Image
            System.Windows.Forms.Panel pnlImageSection = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(600, 700),
                BackColor = System.Drawing.Color.FromArgb(245, 245, 245)
            };

            picMainImage = new System.Windows.Forms.PictureBox
            {
                Size = new System.Drawing.Size(400, 400),
                Location = new System.Drawing.Point(100, 150),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
                // Image will be set in LoadProductDetails
            };
            pnlImageSection.Controls.Add(picMainImage);

            // Right Section: Product Info
            System.Windows.Forms.Panel pnlProductInfo = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(400, 700),
                Padding = new System.Windows.Forms.Padding(20)
            };

            // Brand and Name
            lblBrandAndName = new System.Windows.Forms.Label
            {
                Text = "Loading...",
                Location = new System.Drawing.Point(10, 50),
                Size = new System.Drawing.Size(360, 30),
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black
            };
            pnlProductInfo.Controls.Add(lblBrandAndName);

            // Price
            lblPrice = new System.Windows.Forms.Label
            {
                Text = "$0.00",
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(360, 40),
                Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black
            };
            pnlProductInfo.Controls.Add(lblPrice);

            // Add to Cart Button
            btnAddToCart = new System.Windows.Forms.Button
            {
                Text = "Add to cart",
                Location = new System.Drawing.Point(10, 500),
                Size = new System.Drawing.Size(320, 50),
                BackColor = System.Drawing.Color.FromArgb(40, 167, 69),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            btnAddToCart.Click += new System.EventHandler(this.BtnAddToCart_Click);
            pnlProductInfo.Controls.Add(btnAddToCart);

            // Delivery Info
            lblDeliveryInfo = new System.Windows.Forms.Label
            {
                Text = "Loading delivery info...",
                Location = new System.Drawing.Point(10, 570),
                Size = new System.Drawing.Size(360, 20),
                Font = new System.Drawing.Font("Segoe UI", 10F),
                ForeColor = System.Drawing.Color.Black
            };
            pnlProductInfo.Controls.Add(lblDeliveryInfo);

            // Add sections to the main layout
            tblMain.Controls.Add(pnlImageSection, 0, 0);
            tblMain.Controls.Add(pnlProductInfo, 1, 0);

            this.Controls.Add(tblMain);
        }
        
    }
}