using ECommerceApplication.Services.ProductService;
using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceDTOs;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using Shared.Helpers;
using System.Drawing.Drawing2D;
using ECommerceApplication.Contracts;
using ECommerceApplication.Services.AuthServices;
using ECommercePresentation.AuthForms;

namespace ECommercePresentation.Client
{
    public partial class ProductDashboardForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICartItemService _cartItemService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService; // Added for order navigation
        private readonly IOrderDetailService _orderDetailService; // Added for order details
        private readonly IUserService _userService; // Added for user data

        public ProductDashboardForm(
            IProductService productService,
            ICartItemService cartItemService,
            IOrderService orderService,
            IOrderDetailService orderDetailService,
            IAuthService authService,
            IUserService userService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(orderDetailService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            InitializeComponent();
            SetupNavigation();
            LoadProductsAsync();
            //UpdateWelcomeMessage();
        }

        // private void UpdateWelcomeMessage()
        // {
        //     if (SessionManager.IsAuthenticated)
        //     {
        //         // Assuming GetUserByIdAsync is async and returns UserDto
        //         Task.Run(async () =>
        //         {
        //             var user = await _userService.GetUserByIdAsync(SessionManager.UserId);
        //             string welcomeText = user != null ? $"Welcome, {user.FirstName} {user.LastName}" : "Welcome, Guest";
        //             lblWelcome.Invoke((MethodInvoker)(() => lblWelcome.Text = welcomeText));
        //         });
        //     }
        //     else
        //     {
        //         lblWelcome.Text = "Welcome, Guest";
        //     }
        // }

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
                            var clientOrderForm = new ClientOrder(_orderService, _orderDetailService, _userService);
                            clientOrderForm.ShowDialog();
                        }
                        else if (lbl.Text == "Cart")
                        {
                            var cartItemForm = new CartItemForm(_cartItemService, _orderService, _orderDetailService);
                            cartItemForm.ShowDialog();
                            
                        }
                        else if (lbl.Text == "Log Out")
                        {
                            SessionManager.ClearSession();
                            //UpdateWelcomeMessage();
                            MessageBox.Show("Logged out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var loginForm = new LoginForm(_authService);
                            loginForm.Show();
                            this.Hide(); // Hide the current form
                        }
                        else if (lbl.Text == "Store")
                        {
                            LoadProductsAsync(); // Reload products
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
                //sidebarPanel.Controls.Add(CreateSidebarButton("Cart Items", new Point(20, 300), CartItemButton_Click));
                // CartItemButton_Click 
                // Implement cart item navigation if needed
                var cartItemForm = new CartItemForm(_cartItemService, _orderService, _orderDetailService);
                cartItemForm.ShowDialog();
            };
        }

private async void LoadProductsAsync()
{
    try
    {
        var products = await _productService.GetAllProductsAsync();
        flowLayoutPanel.Controls.Clear();
        foreach (var product in products)
        {
            var card = new ProductCard();
            Image productImage = null;
            try
            {
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

            // Handle Add to Cart
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

            // Handle Card Click to Open ProductDetailForm
            card.CardClicked += (s, productId) =>
            {
                var productDetailForm = new ProductDetailForm(_cartItemService, _productService, productId);
                productDetailForm.ShowDialog();
            };

            flowLayoutPanel.Controls.Add(card);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
    }
}