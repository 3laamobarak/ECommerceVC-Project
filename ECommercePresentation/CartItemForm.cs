using ECommerceApplication.Services.CartItemService;
using ECommerceDTOs;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class CartItemForm : Form
    {
        private readonly ICartItemService _cartItemService;
        private int? _selectedCartItemId;

        public CartItemForm(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            InitializeComponent();

            // Initialize DataGridView columns and styling
            gridCartItems.Columns.Clear();
            gridCartItems.Columns.Add("CartItemID", "Cart Item ID");
            gridCartItems.Columns.Add("UserID", "User ID");
            gridCartItems.Columns.Add("ProductID", "Product ID");
            gridCartItems.Columns.Add("Quantity", "Quantity");
            gridCartItems.Columns.Add("DateAdded", "Date Added");

            gridCartItems.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            gridCartItems.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9),
                SelectionBackColor = Color.FromArgb(108, 117, 125),
                SelectionForeColor = Color.White
            };

            LoadCartItemsAsync();
        }

        private async void LoadCartItemsAsync()
        {
            try
            {
                var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(1); // Example UserID
                gridCartItems.Rows.Clear();
                foreach (var item in cartItems)
                {
                    gridCartItems.Rows.Add(
                        item.CartItemID,
                        item.UserID,
                        item.ProductID,
                        item.Quantity,
                        item.DateAdded.ToString("g")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridCartItems_SelectionChanged(object sender, EventArgs e)
        {
            if (gridCartItems.SelectedRows.Count > 0)
            {
                var selectedRow = gridCartItems.SelectedRows[0];
                _selectedCartItemId = Convert.ToInt32(selectedRow.Cells["CartItemID"].Value);
                txtUserID.Text = selectedRow.Cells["UserID"].Value.ToString();
                txtProductID.Text = selectedRow.Cells["ProductID"].Value.ToString();
                txtQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var cartItem = new CartItemDto
                {
                    UserID = int.Parse(txtUserID.Text),
                    ProductID = int.Parse(txtProductID.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    DateAdded = DateTime.Now
                };
                await _cartItemService.AddCartItemAsync(cartItem);
                MessageBox.Show("Cart item created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadCartItemsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating cart item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedCartItemId.HasValue)
                {
                    MessageBox.Show("Please select a cart item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cartItem = new CartItemDto
                {
                    CartItemID = _selectedCartItemId.Value,
                    UserID = int.Parse(txtUserID.Text),
                    ProductID = int.Parse(txtProductID.Text),
                    Quantity = int.Parse(txtQuantity.Text)
                };
                await _cartItemService.UpdateCartItemAsync(_selectedCartItemId.Value, cartItem);
                MessageBox.Show("Cart item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadCartItemsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating cart item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedCartItemId.HasValue)
                {
                    MessageBox.Show("Please select a cart item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _cartItemService.RemoveCartItemAsync(_selectedCartItemId.Value);
                MessageBox.Show("Cart item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadCartItemsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting cart item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtUserID.Clear();
            txtProductID.Clear();
            txtQuantity.Clear();
            _selectedCartItemId = null;
            gridCartItems.ClearSelection();
        }
    }
}