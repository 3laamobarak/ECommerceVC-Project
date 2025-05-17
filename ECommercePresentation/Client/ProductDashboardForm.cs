using ECommerceApplication.Services.ProductService;
using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services.CategoryService; // Added for category service
using ECommerceDTOs;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using Shared.Helpers;
using ECommerceApplication.Contracts;
using ECommerceApplication.Services.AuthServices;
using ECommercePresentation.AuthForms;
using ECommerceModels.Enums;
using ECommerceApplication.PasswordHasherService;

namespace ECommercePresentation.Client
{
    public partial class ProductDashboardForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICartItemService _cartItemService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ICategoryService _categoryService; // Added for category service

        public ProductDashboardForm(
            IProductService productService,
            ICartItemService cartItemService,
            IOrderService orderService,
            IOrderDetailService orderDetailService,
            IAuthService authService,
            IUserService userService,
            IPasswordHasher passwordHasher,
            ICategoryService categoryService // Added parameter
            )
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(orderDetailService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService)); // Initialize category service
            InitializeComponent();
            UpdateWelcomeLabel(); // Update welcome label with username
            SetupNavigation();
            LoadProductsAsync();
        }

        private async void UpdateWelcomeLabel()
        {
            try
            {
                if (SessionManager.IsAuthenticated)
                {
                    int userId = SessionManager.UserId;
                    var user = await _userService.GetUserByIdAsync(userId);
                    lblWelcome.Text = $"Welcome, {user?.Username ?? "User"}";
                }
                else
                {
                    lblWelcome.Text = "Welcome, Guest";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching username: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblWelcome.Text = "Welcome, Guest";
            }
        }

        private void SetupNavigation()
        {
            foreach (Control control in sidebar.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.Cursor = Cursors.Hand;
                    lbl.Click += (s, e) =>
                    {
                        if (lbl.Text == "My Orders")
                        {
                            if (!SessionManager.IsAuthenticated)
                            {
                                MessageBox.Show("Please log in to view orders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (SessionManager.Role == UserRole.Admin)
                            {
                                LoadOrderFormContent();
                            }
                            else
                            {
                                LoadClientOrderContent();
                            }
                        }
                        else if (lbl.Text == "Cart")
                        {
                            if (!SessionManager.IsAuthenticated)
                            {
                                MessageBox.Show("Please log in to view cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            LoadCartItemFormContent();
                        }
                        else if (lbl.Text == "Profile")
                        {
                            if (!SessionManager.IsAuthenticated)
                            {
                                MessageBox.Show("Please log in to view profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            int userId = SessionManager.UserId;
                            var profileForm = new Profile(_userService, _passwordHasher, _authService);
                            profileForm.LoadUserProfile(userId);
                            LoadProfileFormContent();
                        }
                        else if (lbl.Text == "Log Out")
                        {
                            SessionManager.ClearSession();
                            MessageBox.Show("Logged out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var loginForm = new LoginForm(_authService);
                            loginForm.Show();
                            this.Hide();
                        }
                        else if (lbl.Text == "Store")
                        {
                            LoadProductsAsync();
                        }
                    };
                }
            }

            btnCart.Click += (s, e) =>
            {
                if (!SessionManager.IsAuthenticated)
                {
                    MessageBox.Show("Please log in to view cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadCartItemFormContent();
            };
        }

        private async void LoadProductsAsync()
        {
            try
            {
                contentPanel.Controls.Clear();
                lblTitle.Visible = true;
                lblCategory.Visible = true;
                btnCart.Visible = true;

                var products = await _productService.GetAllProductsAsync();
                //MessageBox.Show($"Loaded {products.ToList().Count} products from database.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information); // Debug

                if (products.ToList().Count == 0)
                {
                    MessageBox.Show("No products found in the database.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int cardWidth = 200; // Assumed ProductCard width
                int cardHeight = 300; // Assumed ProductCard height
                int spacing = 20; // Space between cards
                int cardsPerRow = (contentPanel.Width - spacing) / (cardWidth + spacing);
                int x = spacing;
                int y = spacing;
                int currentRow = 0;

                foreach (var product in products)
                {
                    if (product.UnitsInStock == 0)
                    {
                        continue;
                    }
                    var card = new ProductCard();
                    Image productImage = null;
                    string categoryName = "Unknown";
                    try
                    {
                        // Load image
                        if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                        {
                            productImage = Image.FromFile(product.ImagePath);
                        }
                        else
                        {
                            productImage = Properties.Resources.logo;
                        }

                        // // Fetch category name
                        // if (product.CategoryId > 0) // Assuming CategoryId is a property in ProductDTO
                        // {
                        //     var category = await _categoryService.GetCategoryByIdAsync(product.CategoryId);
                        //     categoryName = category?.CategoryName ?? "Unknown";
                        // }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image or category for product {product.Name}: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        productImage = Properties.Resources.logo;
                        categoryName = "Unknown";
                    }


                    card.UpdateCard(
                        product.ProductID,
                        product.Name,
                        product.Description?.Length > 50 ? product.Description.Substring(0, 50) + "..." : product.Description ?? "No description available",
                        product.Price,
                        productImage
                    );

                    card.AddToCartClicked += async (s, productId) =>
                    {
                        if (!SessionManager.IsAuthenticated)
                        {
                            MessageBox.Show("Please log in to add items to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int userId = SessionManager.UserId;
                        try
                        {
                            var result = await _cartItemService.AddOrUpdateCartItemAsync(userId, productId, 1);
                            if (result != null)
                            {
                                MessageBox.Show($"Product {result.Product?.Name ?? "item"} added/updated in cart. Quantity: {result.Quantity}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to add/update product in cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error adding to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    card.CardClicked += (s, productId) =>
                    {
                        var productDetailForm = new ProductDetailForm(_cartItemService, _productService, productId); // Updated to pass _categoryService
                        productDetailForm.ShowDialog();
                    };

                    card.Size = new Size(cardWidth, cardHeight);
                    card.Location = new Point(x, y);
                    contentPanel.Controls.Add(card);

                    x += cardWidth + spacing;
                    if (x + cardWidth > contentPanel.Width)
                    {
                        x = spacing;
                        y += cardHeight + spacing;
                        currentRow++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClientOrderContent()
        {
            contentPanel.Controls.Clear();
            lblTitle.Visible = false;
            lblCategory.Visible = false;
            btnCart.Visible = false;

            var clientOrderForm = new ClientOrder(_orderService, _orderDetailService, _userService);
            clientOrderForm.TopLevel = false;
            clientOrderForm.FormBorderStyle = FormBorderStyle.None;
            clientOrderForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(clientOrderForm);
            clientOrderForm.Show();
        }

        private void LoadCartItemFormContent()
        {
            contentPanel.Controls.Clear();
            lblTitle.Visible = false;
            lblCategory.Visible = false;
            btnCart.Visible = false;

            var cartItemForm = new CartItemForm(_cartItemService, _orderService, _orderDetailService);
            cartItemForm.TopLevel = false;
            cartItemForm.FormBorderStyle = FormBorderStyle.None;
            cartItemForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(cartItemForm);
            cartItemForm.Show();
        }

        private void LoadProfileFormContent()
        {
            contentPanel.Controls.Clear();
            lblTitle.Visible = false;
            lblCategory.Visible = false;
            btnCart.Visible = false;

            var profile = new Profile(_userService, _passwordHasher, _authService);

            int userId = SessionManager.UserId;
            profile.LoadUserProfile(userId);

            profile.TopLevel = false;
            profile.FormBorderStyle = FormBorderStyle.None;
            profile.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(profile);
            profile.Show();
        }

        private void LoadOrderFormContent()
        {
            contentPanel.Controls.Clear();
            lblTitle.Visible = false;
            lblCategory.Visible = false;
            btnCart.Visible = false;

            var orderForm = new ClientOrder(_orderService, _orderDetailService, _userService);
            orderForm.TopLevel = false;
            orderForm.FormBorderStyle = FormBorderStyle.None;
            orderForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(orderForm);
            orderForm.Show();
        }
    }
}