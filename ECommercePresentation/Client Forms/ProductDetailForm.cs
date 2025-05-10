using ECommerceApplication.Services.CartItemService;
using ECommerceDTOs;
using EcommercModels;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class ProductDetailForm : Form
    {
        private readonly ICartItemService _cartItemService;
        private readonly Product _product;

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnBack;

        public ProductDetailForm(ICartItemService cartItemService, Product product)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _product = product ?? throw new ArgumentNullException(nameof(product));
            InitializeComponent();
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            // Placeholder for adding product to cart
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Placeholder for returning to BaseForm
            this.Close();
        }
    }
}