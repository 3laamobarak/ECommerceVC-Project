using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceDTOs;
using Shared.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECommerceModels.Enums;
using Microsoft.EntityFrameworkCore; // Add for ToListAsync

namespace ECommercePresentation
{
    public partial class CartItemForm : Form
    {
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private int? _selectedCartItemId;

        public CartItemForm(ICartItemService cartItemService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(orderDetailService));
            InitializeComponent();

            // Initialize DataGridView columns and styling
            gridCartItems.Columns.Clear();
            gridCartItems.Columns.Add("Username", "User");
            gridCartItems.Columns.Add("ProductName", "Product");
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
                var userId = SessionManager.UserId;
                var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(userId);
                gridCartItems.Rows.Clear();
                foreach (var item in cartItems)
                {
                    var rowIndex = gridCartItems.Rows.Add(
                        item.User?.Username ?? "Unknown",
                        item.Product?.Name ?? "Unknown",
                        item.Quantity,
                        item.DateAdded.ToString("g")
                    );
                    gridCartItems.Rows[rowIndex].Tag = item.CartItemID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void TxtSearchUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchUser.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadCartItemsAsync();
                    return;
                }

                var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(SessionManager.UserId);
                var filteredItems = cartItems.Where(ci => ci.User?.Username?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true);
                gridCartItems.Rows.Clear();
                foreach (var item in filteredItems)
                {
                    var rowIndex = gridCartItems.Rows.Add(
                        item.User?.Username ?? "Unknown",
                        item.Product?.Name ?? "Unknown",
                        item.Quantity,
                        item.DateAdded.ToString("g")
                    );
                    gridCartItems.Rows[rowIndex].Tag = item.CartItemID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridCartItems_SelectionChanged(object sender, EventArgs e)
        {
            if (gridCartItems.SelectedRows.Count > 0)
            {
                var selectedRow = gridCartItems.SelectedRows[0];
                _selectedCartItemId = (int?)selectedRow.Tag;
                txtQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var cartItem = new CartItemDto
                {
                    UserID = SessionManager.UserId,
                    ProductID = 1,
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

        private async void BtnMakeOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SessionManager.IsAuthenticated)
                {
                    MessageBox.Show("Please log in to create an order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var userId = SessionManager.UserId;
                // Materialize the cart items into a list to avoid open DataReader issues
                var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(userId);

                if (!cartItems.Any())
                {
                    MessageBox.Show("Your cart is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new order
                var orderDto = new CreateOrderDto { UserID = userId };
                var createdOrder = await _orderService.CreateOrderAsync(orderDto);
                if (createdOrder == null)
                {
                    MessageBox.Show("Failed to create order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                foreach (var cartItem in cartItems)
                {
                    var orderDetail = await _orderDetailService.CreateOrderwithuseridandproductidAsync(
                        createdOrder.OrderID,
                        cartItem.ProductID,
                        cartItem.Quantity
                    );
                    if (orderDetail == null)
                    {
                        MessageBox.Show($"Failed to create order detail for ProductID: {cartItem.ProductID}. Check product existence and stock.");
                    }
                }

                // Set order status
                await _orderService.ChangeOrderStatusAsync(createdOrder.OrderID, OrderStatus.Pending);

                // Clear cart items after successful order
                foreach (var cartItem in cartItems)
                {
                    await _cartItemService.RemoveCartItemAsync(cartItem.CartItemID);
                }

                MessageBox.Show($"Order created successfully with Order ID: {createdOrder.OrderID}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCartItemsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating order: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtQuantity.Clear();
            _selectedCartItemId = null;
            gridCartItems.ClearSelection();
        }
    }
}