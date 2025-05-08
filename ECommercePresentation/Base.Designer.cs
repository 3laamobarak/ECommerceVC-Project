using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECommercePresentation
{
    partial class Base
    {
        private Panel navBar;
        private Panel contentPanel;
        private Panel footerPanel;
        private PictureBox logo;
        private TextBox searchBox;
        private Button searchButton;
        private PictureBox userProfile;
        private Label userName;
        private Button shoppingCart;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Header panel
            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(45, 45, 48),
                Padding = new Padding(20, 0, 20, 0)
            };

            // Logo
            Label logo = new Label
            {
                Text = "Your Brand",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(10, 10)
            };

            // Navigation links
            Button homeBtn = CreateNavButton("Home", new Point(100, 20));
            Button aboutBtn = CreateNavButton("About", new Point(160, 20));
            Button shopBtn = CreateNavButton("Shop", new Point(220, 20));

            // Cart button
            Button cartBtn = CreateNavButton("Cart", new Point(740, 20));

            // Add controls to header
            header.Controls.Add(logo);
            header.Controls.Add(homeBtn);
            header.Controls.Add(aboutBtn);
            header.Controls.Add(shopBtn);
            header.Controls.Add(cartBtn);

            this.Controls.Add(header);
        }

        private Button CreateNavButton(string text, Point location)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Size = new Size(60, 30),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F)
            };
        }

        private void InitializeProductGrid()
        {
            // Product grid panel
            TableLayoutPanel productGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                Padding = new Padding(20, 20, 20, 20)
            };

            // Create product cards
            for (int i = 0; i < 8; i++)
            {
                ProductCard card = new ProductCard();
                productGrid.Controls.Add(card, i % 2, i / 2);
            }

            this.Controls.Add(productGrid);
        }

        private void InitializeFooter()
        {
            // Footer panel
            Panel footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.FromArgb(45, 45, 48)
            };

            // Footer label
            Label footerLabel = new Label
            {
                Text = "© 2023 Your Brand. All rights reserved.",
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F)
            };

            footer.Controls.Add(footerLabel);
            this.Controls.Add(footer);
        }
    }

    public class ProductCard : PictureBox
    {
        public ProductCard()
        {
            this.Size = new Size(350, 300);
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.TabStop = false;

            // Add product details
            Panel productDetails = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            Label price = new Label
            {
                Text = "$50.00",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Dock = DockStyle.Bottom
            };

            Label productName = new Label
            {
                Text = "Fancy Product",
                Font = new Font("Segoe UI", 12F),
                Dock = DockStyle.Bottom
            };

            Label stars = new Label
            {
                Text = "*****",
                Dock = DockStyle.Bottom
            };

            Button addToCart = new Button
            {
                Text = "Add to Cart",
                Dock = DockStyle.Bottom,
                Size = new Size(100, 25)
            };

            productDetails.Controls.Add(price);
            productDetails.Controls.Add(productName);
            productDetails.Controls.Add(stars);
            productDetails.Controls.Add(addToCart);

            this.Controls.Add(productDetails);
        }
        #endregion

        private Button CreateCategoryButton(string text, string imagePath, Point location)
        {
            Button button = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(180, 180),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Image = System.Drawing.Image.FromFile(imagePath),
                ImageAlign = ContentAlignment.TopCenter,
                TextAlign = ContentAlignment.BottomCenter,
                Padding = new Padding(10)
            };

            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.LightGray;

            return button;
        }

        private Button CreateStyledButton(string text, Point location, Color backColor)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Size = new Size(80, 30),
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                FlatAppearance = { BorderSize = 0 }
            };
        }

        private void AddHoverEffect(Button button, Color hoverColor)
        {
            button.MouseEnter += (sender, e) =>
            {
                button.BackColor = hoverColor;
            };
            button.MouseLeave += (sender, e) =>
            {
                button.BackColor = Color.FromArgb(28, 151, 234);
            };
        }
    }
}