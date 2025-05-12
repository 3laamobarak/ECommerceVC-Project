
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ECommercePresentation.Client
{
    public partial class ProductDashboardForm : Form
    {
        private FlowLayoutPanel flowLayoutPanel;
        private Panel sidebar;
        private Panel topNavbar;
        private Label lblWelcome;
        private Label lblTitle;
        private Label lblCategory;
        private Button btnCart;
        private List<Product> products;

        public ProductDashboardForm()
        {
            InitializeComponent();
            InitializeData();
            SetupLayout();
            LoadProducts();
        }

        private void InitializeData()
        {
            products = new List<Product>
            {
                new Product { ProductID = 1, Name = "Color Mastery in Web Design", Description = "A Guide to Creating Visually Stunning Websites", Price = 49.00m, UnitsInStock = 66, Category = "Published", ImagePath = "color_mastery.jpg" },
                new Product { ProductID = 2, Name = "Speedy Design Solutions", Description = "Mastering the Art of Quick and Effective Design Systems", Price = 59.00m, UnitsInStock = 151, Category = "Published", ImagePath = "speedy_design.jpg" },
                new Product { ProductID = 3, Name = "Responsive Web Design Best Practices", Description = "Best Practices for Responsive Web Design", Price = 99.00m, UnitsInStock = 0, Category = "Draft", ImagePath = "responsive_web.jpg" },
                 new Product { ProductID = 4, Name = "Responsive Web Design Best Practices", Description = "Best Practices for Responsive Web Design", Price = 99.00m, UnitsInStock = 0, Category = "Draft", ImagePath = "responsive_web.jpg" },
                 new Product { ProductID = 5, Name = "Responsive Web Design Best Practices", Description = "Best Practices for Responsive Web Design", Price = 99.00m, UnitsInStock = 0, Category = "Draft", ImagePath = "responsive_web.jpg" }
            };
        }

        private void SetupLayout()
        {
            // Sidebar with padding and margins
            sidebar = new Panel
            {
                Size = new Size(200, this.ClientSize.Height),
                BackColor = Color.FromArgb(240, 242, 245),
                Location = new Point(0, 0),
                Padding = new Padding(15)
            };

            // Logo as "HYPER" text styled like a logo
            Label logo = new Label
            {
                Text = "HYPER",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 200),
                Location = new Point(15, 15),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 30)
            };
            logo.Paint += (s, e) =>
            {
                using (var brush = new LinearGradientBrush(logo.ClientRectangle, Color.FromArgb(0, 120, 200), Color.FromArgb(75, 0, 130), LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, logo.ClientRectangle);
                }
                TextRenderer.DrawText(e.Graphics, logo.Text, logo.Font, logo.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
            sidebar.Controls.Add(logo);

            // Sidebar navigation items with adjusted positions
            Label lblStore = new Label { Text = "Store", Font = new Font("Segoe UI", 12F), Location = new Point(15, 80), Margin = new Padding(5), Size = new Size(200, 40) };
            Label lblOrders = new Label { Text = "My Orders", Font = new Font("Segoe UI", 12F), Location = new Point(15, 110), Margin = new Padding(5) , Size = new Size(200,40) };
            Label lblCartNav = new Label { Text = "Cart", Font = new Font("Segoe UI", 12F), Location = new Point(15, 140), Margin = new Padding(20), Size = new Size(200, 60) };
            Label lblLogout = new Label { Text = "Log Out", Font = new Font("Segoe UI", 12F), Location = new Point(15, this.ClientSize.Height - 60), ForeColor = Color.FromArgb(220, 53, 69), Margin = new Padding(5), Size = new Size(200, 40) };

            sidebar.Controls.AddRange(new Control[] { lblStore, lblOrders, lblCartNav, lblLogout });
            this.Controls.Add(sidebar);

            // Top Navbar
            topNavbar = new Panel
            {
                Size = new Size(this.ClientSize.Width - sidebar.Width, 60),
                BackColor = Color.White,
                Location = new Point(sidebar.Width, 0)
            };
            lblWelcome = new Label
            {
                Text = "Welcome, Dominic Keller",
                Font = new Font("Segoe UI", 12F),
                AutoSize = true,
                Location = new Point((topNavbar.Width - 200) / 2, 20)
            };
            topNavbar.Controls.Add(lblWelcome);
            this.Controls.Add(topNavbar);

            // Main Content
            lblTitle = new Label
            {
                Text = "Products", // Explicitly set to "Products" to confirm
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(sidebar.Width + 20, 80),
                Size = new Size(200, 50),
                Margin = new Padding(0, 0, 0, 100) // Increased bottom margin to prevent cropping
            };
            this.Controls.Add(lblTitle);

            // Category Header
            lblCategory = new Label
            {
                Text = "Category",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(sidebar.Width + 20, 160),
                Size = new Size(200, 50),// Moved down to give more space
            };
            this.Controls.Add(lblCategory);

            // Cart Button
            btnCart = new Button
            {
                Text = "Cart",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                Size = new Size(100, 40),
                Location = new Point(this.ClientSize.Width - 150, 80)
            };
            this.Controls.Add(btnCart);

            // FlowLayoutPanel for Cards (adjusted position to avoid overlap)
            flowLayoutPanel = new FlowLayoutPanel
            {
                Location = new Point(sidebar.Width + 20, 200), // Moved down to avoid overlap
                Size = new Size(this.ClientSize.Width - sidebar.Width - 40, this.ClientSize.Height ), // Adjusted height
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = true
            };
            this.Controls.Add(flowLayoutPanel);
        }

        private void LoadProducts()
        {
            flowLayoutPanel.Controls.Clear();
            foreach (var product in products)
            {
                Panel card = CreateProductCard(product);
                flowLayoutPanel.Controls.Add(card);
            }
        }

        private Panel CreateProductCard(Product product)
        {
            Panel card = new Panel
            {
                Size = new Size(300, 550), // Kept at 500px as preferred
                BackColor = Color.White,
                Padding = new Padding(10),
                Margin = new Padding(10)
            };
            card.Paint += (s, e) => { using (var brush = new SolidBrush(Color.FromArgb(0, 0, 0, 20))) e.Graphics.FillRectangle(brush, card.ClientRectangle); };

            PictureBox image = new PictureBox
            {
                Size = new Size(200, 250),
                Location = new Point(50, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.LightGray
            };
            card.Controls.Add(image);

            Label status = new Label
            {
                Text = product.UnitsInStock > 0 ? "Avaliable" : "Out Of Stock",
                ForeColor = product.UnitsInStock > 0 ? Color.Green : Color.Red,
                Location = new Point(10, 270),
                Font = new Font("Segoe UI", 10F)
            };
            card.Controls.Add(status);

            Label name = new Label
            {
                Text = product.Name,
                Location = new Point(10, 300),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                MaximumSize = new Size(280, 0)
            };
            card.Controls.Add(name);

            Label description = new Label
            {
                Text = product.Description,
                Location = new Point(10, 330),
                Font = new Font("Segoe UI", 10F),
                AutoSize = true,
                MaximumSize = new Size(280, 0)
            };
            card.Controls.Add(description);

            Label price = new Label
            {
                Text = $"Price: ${product.Price:F2}",
                Location = new Point(10, 390), // Moved up from 450
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(200, 30),

            };
            Label DecreaseQuantity = new Label
            {
                Text = $"---",
                Location = new Point(90, 430), // Moved up from 450
                Font = new Font("Segoe UI", 10F),
                Size = new Size(30, 30),
            };
            Label QuantityInCart = new Label
            {
                Text = $"In Cart: {product.UnitsInStock}",
                Location = new Point(100, 430), // Moved up from 450
                Font = new Font("Segoe UI", 10F),
                Size = new Size(70, 20),

            };
            Label IncreaseQuantity = new Label
            {
                Text = $"+",
                Location = new Point(170, 430), // Moved up from 450
                Font = new Font("Segoe UI", 10F),
                Size = new Size(30, 30),
            };
            card.Controls.Add(price);
            card.Controls.Add(QuantityInCart);
            card.Controls.Add(IncreaseQuantity);
            card.Controls.Add(DecreaseQuantity);

            Button addToCart = new Button
            {
                Text = "Add To Cart",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                Size = new Size(270, 30), // 90% of 300px width
                Location = new Point(15, 480), // Moved up from 480
                FlatAppearance = { BorderSize = 0 }
            };
            card.Controls.Add(addToCart);

            card.Click += (s, e) => MessageBox.Show($"Selected: {product.Name}");
            return card;
        }

        private class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int UnitsInStock { get; set; }
            public string Category { get; set; }
            public string ImagePath { get; set; }
        }
    }
}