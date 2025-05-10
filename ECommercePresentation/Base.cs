using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services.ProductService;
using ECommerceDTOs;
using EcommercModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class BaseForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.FlowLayoutPanel productPanel;


        public BaseForm(IProductService productService, ICategoryService categoryService, ICartItemService cartItemService, IOrderService orderService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            InitializeComponent();
            PopulateProductPanel();
            // Handle form resize to adjust product row widths
            this.Resize += BaseForm_Resize;
        }

        private void BaseForm_Resize(object sender, EventArgs e)
        {
            // Update product row widths on resize
            foreach (Control control in productPanel.Controls)
            {
                if (control is Panel rowPanel && rowPanel.Controls.Count > 0 && rowPanel.Controls[0] is FlowLayoutPanel flowPanel)
                {
                    rowPanel.Width = productPanel.ClientSize.Width;
                    flowPanel.Width = Math.Max(productPanel.ClientSize.Width, flowPanel.Controls.Count * 220);
                }
            }
        }

        private void PopulateProductPanel()
        {
            // Mock categories and products
            var categories = new List<(string Name, List<Product> Products)>
            {
                ("Electronics", new List<Product>
                {
                    new Product { ProductID = 1, Name = "Smartphone", Description = "Latest model with 128GB storage and 5G.", Price = 699.99m, ImagePath = "smartphone.jpg" },
                    new Product { ProductID = 2, Name = "Laptop", Description = "High-performance laptop with 16GB RAM.", Price = 1299.99m, ImagePath = "laptop.jpg" },
                    new Product { ProductID = 3, Name = "Tablet", Description = "10-inch tablet with 64GB storage.", Price = 399.99m, ImagePath = "tablet.jpg" }
                }),
                ("Clothing", new List<Product>
                {
                    new Product { ProductID = 4, Name = "T-Shirt", Description = "Comfortable cotton t-shirt in various colors.", Price = 19.99m, ImagePath = "tshirt.jpg" },
                    new Product { ProductID = 5, Name = "Jeans", Description = "Slim-fit denim jeans for casual wear.", Price = 49.99m, ImagePath = "jeans.jpg" },
                    new Product { ProductID = 6, Name = "Jacket", Description = "Water-resistant jacket for outdoor use.", Price = 89.99m, ImagePath = "jacket.jpg" }
                }),
                ("Accessories", new List<Product>
                {
                    new Product { ProductID = 7, Name = "Headphones", Description = "Wireless noise-canceling headphones.", Price = 199.99m, ImagePath = "headphones.jpg" },
                    new Product { ProductID = 8, Name = "Watch", Description = "Smartwatch with fitness tracking.", Price = 249.99m, ImagePath = "watch.jpg" }
                }),
                ("Books", new List<Product>
                {
                    new Product { ProductID = 9, Name = "Novel", Description = "Bestselling fiction novel.", Price = 14.99m, ImagePath = "novel.jpg" },
                    new Product { ProductID = 10, Name = "Textbook", Description = "Comprehensive computer science textbook.", Price = 79.99m, ImagePath = "textbook.jpg" }
                })
            };

            foreach (var category in categories)
            {
                // Add category header in a centered panel
                var categoryPanel = new Panel
                {
                    Size = new Size(606, 30),
                    Margin = new Padding(32, 10, 32, 5)
                };
                var lblCategory = new Label
                {
                    Text = category.Name,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(10, 5)
                };
                categoryPanel.Controls.Add(lblCategory);
                productPanel.Controls.Add(categoryPanel);

                // Add products in a full-width panel with a nested FlowLayoutPanel
                var productRowPanel = new Panel
                {
                    Size = new Size(productPanel.ClientSize.Width, 300),
                    Margin = new Padding(0, 0, 0, 10)
                };
                var productFlowPanel = new FlowLayoutPanel
                {
                    Location = new Point(0, 0),
                    Size = new Size(productPanel.ClientSize.Width, 300),
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoScroll = false,
                    WrapContents = false
                };
                productFlowPanel.HorizontalScroll.Enabled = true;
                productFlowPanel.VerticalScroll.Enabled = false;

                // Set FlowLayoutPanel width to fit all products
                int productCount = category.Products.Count;
                productFlowPanel.Size = new Size(Math.Max(productPanel.ClientSize.Width, productCount * 220), 300);

                foreach (var product in category.Products)
                {
                    var card = new Panel
                    {
                        Size = new Size(200, 250),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10)
                    };

                    var pictureBox = new PictureBox
                    {
                        Location = new Point(25, 10),
                        Size = new Size(150, 100),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle
                        // Image = Image.FromFile(product.ImagePath) // Placeholder
                    };
                    card.Controls.Add(pictureBox);

                    var lblName = new Label
                    {
                        Text = product.Name,
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(10, 120)
                    };
                    card.Controls.Add(lblName);

                    var lblDescription = new Label
                    {
                        Text = product.Description.Length > 50 ? product.Description.Substring(0, 47) + "..." : product.Description,
                        Font = new Font("Segoe UI", 9F),
                        Size = new Size(180, 40),
                        Location = new Point(10, 140)
                    };
                    card.Controls.Add(lblDescription);

                    var lblPrice = new Label
                    {
                        Text = $"${product.Price:F2}",
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(10, 180)
                    };
                    card.Controls.Add(lblPrice);

                    var btnDetails = new Button
                    {
                        Text = "Details",
                        Font = new Font("Segoe UI", 9F),
                        BackColor = Color.FromArgb(0, 123, 255),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0 },
                        Size = new Size(90, 30),
                        Location = new Point(10, 210),
                        Tag = product
                    };
                    btnDetails.Click += BtnDetails_Click;
                    card.Controls.Add(btnDetails);

                    var btnAddToCart = new Button
                    {
                        Text = "Add to Cart",
                        Font = new Font("Segoe UI", 9F),
                        BackColor = Color.FromArgb(0, 123, 255),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0 },
                        Size = new Size(90, 30),
                        Location = new Point(100, 210)
                    };
                    btnAddToCart.Click += BtnAddToCart_Click;
                    card.Controls.Add(btnAddToCart);

                    productFlowPanel.Controls.Add(card);
                }

                productRowPanel.Controls.Add(productFlowPanel);
                productPanel.Controls.Add(productRowPanel);
            }
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(_productService);
            productForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            productForm.Show();
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm(_orderService);
            orderForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            orderForm.Show();
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm(_categoryService);
            categoryForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            categoryForm.Show();
        }

        private void BtnCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm(_cartItemService);
            cartForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            cartForm.Show();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm();
            profileForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            profileForm.Show();
        }
        private void BtnUsers_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            usersForm.Show();
        }
        private void BtnDetails_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Product product)
            {
                ProductDetailForm detailForm = new ProductDetailForm(_cartItemService, product);
                detailForm.FormClosed += (s, args) => this.Show();
                this.Hide();
                detailForm.Show();
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            // Placeholder
        }
    }
}