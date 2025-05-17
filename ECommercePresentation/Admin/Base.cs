using ECommerceApplication.Contracts;
using ECommerceApplication.PasswordHasherService;
using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services.ProductService;
using ECommerceApplication.Services.UserServices;
using ECommerceDTOs;
using Microsoft.Extensions.DependencyInjection;
using Shared.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECommerceApplication.Services.AuthServices;
using ECommercePresentation.AuthForms;

namespace ECommercePresentation
{
    public partial class Base : Form
    {
        private readonly IOrderService _orderService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICartItemService _cartItemService;
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthService _authService;
        private readonly IOrderDetailService _orderDetailService;

        private Panel dashboardPanel;
        private FlowLayoutPanel summaryCardsPanel;

        public Base(IOrderService orderService, ICategoryService categoryService, IProductService productService,
                    ICartItemService cartItemService, IUserService userService, IPasswordHasher passwordHasher,
                    IOrderDetailService orderDetailService, IAuthService authService)
        {
            InitializeComponent();

            _orderService = orderService;
            _categoryService = categoryService;
            _productService = productService;
            _orderDetailService = orderDetailService;
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _cartItemService = cartItemService;
            _userService = userService;
            _passwordHasher = passwordHasher;

            // Set welcome label text with username
            UpdateWelcomeLabel();

            LoadProductsAsync();
            ShowDashboardPanel(null, null); // Default to dashboard
        }

        private async void UpdateWelcomeLabel()
        {
            try
            {
                if (SessionManager.IsAuthenticated)
                {
                    int userId = SessionManager.UserId;
                    var user = await _userService.GetUserByIdAsync(userId);
                    welcomeLabel.Text = $"Welcome {user?.Username ?? "User"}";
                }
                else
                {
                    welcomeLabel.Text = "Welcome Guest";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching username: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                welcomeLabel.Text = "Welcome Guest";
            }
        }

        private async void LoadProductsAsync()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                productPanelContainer.Controls.Clear();
                foreach (var product in products)
                {
                    var card = new ProductCard();
                    Image productImage = null;
                    try
                    {
                        // Load image from file path if ImagePath is provided
                        if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                        {
                            productImage = Image.FromFile(product.ImagePath);
                        }
                        else
                        {
                            productImage = Properties.Resources.logo;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image for product {product.Name}: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        productImage = Properties.Resources.logo;
                    }

                    card.UpdateCard(
                        product.ProductID,
                        product.Name,
                        product.Description?.Length > 50 ? product.Description.Substring(0, 50) + "..." : product.Description ?? "No description available",
                        product.Price,
                        productImage
                    );
                    card.AddToCartClicked += Card_AddToCartClicked;
                    productPanelContainer.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Card_AddToCartClicked(object sender, int productId)
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
        }

        private void CategoriesButton_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new CategoryForm(_categoryService, _productService));
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new OrderForm(_orderService));
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new ProductForm(_productService, _categoryService));
        }

        private void CartItemButton_Click(object sender, EventArgs e)
        {
            var cartItemForm = new CartItemForm(_cartItemService, _orderService, _orderDetailService);
            cartItemForm.Show();
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAuthenticated)
            {
                MessageBox.Show("User not logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = SessionManager.UserId;
            var profileForm = new Profile(_userService, _passwordHasher, _authService);
            profileForm.LoadUserProfile(userId);
            LoadFormInPanel(profileForm);
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm(_userService);
            LoadFormInPanel(userForm);
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            SessionManager.ClearSession();
            var loginForm = new LoginForm(_authService);
            loginForm.Show();
            this.Hide();
        }

        private void ShowDashboardPanel(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(dashboardPanel);
        }

        private void LoadFormInPanel(Form form)
        {
            contentPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }
    }
}