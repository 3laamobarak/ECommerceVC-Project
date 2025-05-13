using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.ProductService;
using ECommerceDTOs;
using Shared.Helpers;
using System;
using System.Windows.Forms;

namespace ECommercePresentation.Client
{
    public partial class ProductDetailForm : Form
    {
        private readonly ICartItemService _cartItemService;
        private readonly IProductService _productService;
        private readonly int _productId;
        private ProductDto _product;

        public ProductDetailForm(ICartItemService cartItemService, IProductService productService, int productId)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _productId = productId;
            InitializeComponent();
            LoadProductDetails();
        }

        private async void LoadProductDetails()
        {
            try
            {
                _product = await _productService.GetProductByIdAsync(_productId);
                if (_product == null)
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Update UI with product details
                this.Text = $"Product Detail - {_product.Name}";
                lblBrandAndName.Text = _product.Name;
                lblPrice.Text = $"${_product.Price:F2}";
                lblDeliveryInfo.Text = _product.Price >= 30.0m ? "Free delivery" : "Delivery charges apply";

                // Load product image if available
                if (!string.IsNullOrEmpty(_product.ImagePath) && System.IO.File.Exists(_product.ImagePath))
                {
                    picMainImage.Image = System.Drawing.Image.FromFile(_product.ImagePath);
                }
                else
                {
                    // Use a placeholder image if the image path is invalid
                    picMainImage.Image = System.Drawing.Image.FromFile("placeholder.png"); // Ensure you have a placeholder image
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void BtnAddToCart_Click(object sender, EventArgs e)
        {
            await Card_AddToCartClicked(sender, _productId);
        }

        private async Task Card_AddToCartClicked(object sender, int productId)
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
    }
}