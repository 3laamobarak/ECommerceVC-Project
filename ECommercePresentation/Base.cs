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

        public Base(IOrderService orderService, ICategoryService categoryService, IProductService productService, ICartItemService cartItemService, IUserService userService, IPasswordHasher passwordHasher)
        {
            InitializeComponent();
            _orderService = orderService;
            _categoryService = categoryService;
            _productService = productService;
            _cartItemService = cartItemService;
            _userService = userService;
            _passwordHasher = passwordHasher;
            LoadProductsAsync();
        }

        private async void LoadProductsAsync()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                productPanel.Controls.Clear();
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
                            productImage = Properties.Resources.logo; // Replace with default image if null
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image for product {product.Name}: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        productImage = Properties.Resources.logo; // Fallback to placeholder
                    }

                    card.UpdateCard(
                        product.ProductID,
                        product.Name,
                        product.Description?.Length > 50 ? product.Description.Substring(0, 50) + "..." : product.Description ?? "No description available",
                        product.Price,
                        productImage
                    );
                    card.AddToCartClicked += Card_AddToCartClicked;
                    productPanel.Controls.Add(card);
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
                var result = await _cartItemService.AddOrUpdateCartItemAsync(userId, productId, 1); // Increment by 1
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
            CategoryForm categoryForm = new CategoryForm(_categoryService, _productService);
            categoryForm.Show();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm(_orderService);
            orderForm.Show();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(_productService, _categoryService);
            productForm.Show();
        }

        private void CartItemButton_Click(object sender, EventArgs e)
        {
            var cartItemForm = Program.Resolve<CartItemForm>();
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
            var profileForm = new Profile(_userService, _passwordHasher);
            profileForm.LoadUserProfile(userId);
            profileForm.ShowDialog();
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm(_userService);
            userForm.ShowDialog();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            SessionManager.ClearSession();
            this.Close(); // Closes the form, redirect to login if needed
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }
    }
}