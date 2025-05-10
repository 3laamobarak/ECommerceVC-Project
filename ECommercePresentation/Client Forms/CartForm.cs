using ECommerceApplication.Services.CartItemService;
using ECommerceDTOs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class CartForm : Form
    {
        private readonly ICartItemService _cartItemService;

     

        public CartForm(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            InitializeComponent();

            // Initialize DataGridView columns and styling
            gridCart.Columns.Clear();

            // Product Name column
            gridCart.Columns.Add("ProductName", "Product Name");

            // Quantity column (includes -/+ buttons in cell)
            var quantityColumn = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Quantity",
                ReadOnly = true // Quantity edited via buttons
            };
            gridCart.Columns.Add(quantityColumn);

            // Unit Price column
            gridCart.Columns.Add("UnitPrice", "Unit Price");

            // Total Price column
            gridCart.Columns.Add("TotalPrice", "Total Price");

            // Styling for DataGridView
            gridCart.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            gridCart.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9),
                SelectionBackColor = Color.FromArgb(108, 117, 125),
                SelectionForeColor = Color.White
            };
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Placeholder for delete logic
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            // Placeholder for checkout logic
        }

        private void GridCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder for handling -/+ button clicks
        }
    }
}