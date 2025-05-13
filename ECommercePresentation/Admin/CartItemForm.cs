using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceDTOs;
using Shared.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;
using ECommerceModels.Enums;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
            LoadCartItemsAsync();
        }

        private async void LoadCartItemsAsync()
        {
            try
            {
                var userId = SessionManager.UserId;
                var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(userId);
                tblProducts.Controls.Clear();
                tblProducts.RowCount = 0;
                foreach (var item in cartItems)
                {
                    var pnlProduct = new Panel { Size = new Size(680, 80) };
                    var picProduct = new PictureBox
                    {
                        Size = new Size(80, 80),
                        Location = new Point(0, 0),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    if (!string.IsNullOrEmpty(item.Product?.ImagePath) && File.Exists(item.Product.ImagePath))
                    {
                        picProduct.Image = Image.FromFile(item.Product.ImagePath);
                    }
                    else
                    {
                        picProduct.Image = new Bitmap(80, 80);
                    }

                    var lblProduct = new Label
                    {
                        Text = item.Product?.Name ?? "Unknown Product",
                        Location = new Point(90, 10),
                        Size = new Size(300, 20)
                    };
                    var btnDec = new Button { Text = "-", Location = new Point(400, 20), Size = new Size(30, 30), Tag = item };
                    var lblQty = new Label { Text = item.Quantity.ToString(), Location = new Point(440, 20), Size = new Size(30, 30), Tag = item };
                    var btnInc = new Button { Text = "+", Location = new Point(480, 20), Size = new Size(30, 30), Tag = item };
                    var btnTrash = new Button { Text = "🗑", Location = new Point(520, 20), Size = new Size(30, 30), Tag = item.CartItemID };
                    var lblPrice = new Label
                    {
                        Text = $"${(item.Product?.Price ?? 0):F2}",
                        Location = new Point(560, 20),
                        Size = new Size(100, 30)
                    };

                    btnInc.Click += async (s, e) => await BtnInc_Click(s, e, item, lblQty);
                    btnDec.Click += async (s, e) => await BtnDec_Click(s, e, item, lblQty);
                    btnTrash.Click += async (s, e) => await BtnTrash_Click(s, e, item.CartItemID);

                    pnlProduct.Controls.Add(picProduct);
                    pnlProduct.Controls.Add(lblProduct);
                    pnlProduct.Controls.Add(btnDec);
                    pnlProduct.Controls.Add(lblQty);
                    pnlProduct.Controls.Add(btnInc);
                    pnlProduct.Controls.Add(btnTrash);
                    pnlProduct.Controls.Add(lblPrice);
                    tblProducts.Controls.Add(pnlProduct, 0, tblProducts.RowCount);
                    tblProducts.RowCount++;
                    tblProducts.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                UpdateOrderSummary(cartItems);
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
                tblProducts.Controls.Clear();
                tblProducts.RowCount = 0;
                foreach (var item in filteredItems)
                {
                    var pnlProduct = new Panel { Size = new Size(680, 80) };
                    var picProduct = new PictureBox
                    {
                        Size = new Size(80, 80),
                        Location = new Point(0, 0),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    if (!string.IsNullOrEmpty(item.Product?.ImagePath) && File.Exists(item.Product.ImagePath))
                    {
                        picProduct.Image = Image.FromFile(item.Product.ImagePath);
                    }
                    else
                    {
                        picProduct.Image = new Bitmap(80, 80);
                    }

                    var lblProduct = new Label
                    {
                        Text = item.Product?.Name ?? "Unknown Product",
                        Location = new Point(90, 10),
                        Size = new Size(300, 20)
                    };
                    var btnDec = new Button { Text = "-", Location = new Point(400, 20), Size = new Size(30, 30), Tag = item };
                    var lblQty = new Label { Text = item.Quantity.ToString(), Location = new Point(440, 20), Size = new Size(30, 30), Tag = item };
                    var btnInc = new Button { Text = "+", Location = new Point(480, 20), Size = new Size(30, 30), Tag = item };
                    var btnTrash = new Button { Text = "🗑", Location = new Point(520, 20), Size = new Size(30, 30), Tag = item.CartItemID };
                    var lblPrice = new Label
                    {
                        Text = $"${(item.Product?.Price ?? 0):F2}",
                        Location = new Point(560, 20),
                        Size = new Size(100, 30)
                    };

                    btnInc.Click += async (s, e) => await BtnInc_Click(s, e, item, lblQty);
                    btnDec.Click += async (s, e) => await BtnDec_Click(s, e, item, lblQty);
                    btnTrash.Click += async (s, e) => await BtnTrash_Click(s, e, item.CartItemID);

                    pnlProduct.Controls.Add(picProduct);
                    pnlProduct.Controls.Add(lblProduct);
                    pnlProduct.Controls.Add(btnDec);
                    pnlProduct.Controls.Add(lblQty);
                    pnlProduct.Controls.Add(btnInc);
                    pnlProduct.Controls.Add(btnTrash);
                    pnlProduct.Controls.Add(lblPrice);
                    tblProducts.Controls.Add(pnlProduct, 0, tblProducts.RowCount);
                    tblProducts.RowCount++;
                    tblProducts.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                UpdateOrderSummary(filteredItems.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(userId);

                if (!cartItems.Any())
                {
                    MessageBox.Show("Your cart is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                await _orderService.ChangeOrderStatusAsync(createdOrder.OrderID, OrderStatus.Pending);

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

        private async void BtnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SessionManager.IsAuthenticated)
                {
                    MessageBox.Show("Please log in to create an order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var userId = SessionManager.UserId;
                var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(userId);

                if (!cartItems.Any())
                {
                    MessageBox.Show("Your cart is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                await _orderService.ChangeOrderStatusAsync(createdOrder.OrderID, OrderStatus.Pending);

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

        private async Task BtnTrash_Click(object sender, EventArgs e, int cartItemId)
        {
            try
            {
                await _cartItemService.RemoveCartItemAsync(cartItemId);
                LoadCartItemsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting cart item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task BtnInc_Click(object sender, EventArgs e, CartItemDto cartItem, Label lblQty)
        {
            try
            {
                cartItem.Quantity++;
                await _cartItemService.UpdateCartItemAsync(cartItem.CartItemID, cartItem);
                lblQty.Text = cartItem.Quantity.ToString();
                var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(SessionManager.UserId);
                UpdateOrderSummary(cartItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error increasing quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task BtnDec_Click(object sender, EventArgs e, CartItemDto cartItem, Label lblQty)
        {
            try
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    await _cartItemService.UpdateCartItemAsync(cartItem.CartItemID, cartItem);
                    lblQty.Text = cartItem.Quantity.ToString();
                    var cartItems = await _cartItemService.GetCartItemsByUserIdAsync(SessionManager.UserId);
                    UpdateOrderSummary(cartItems);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decreasing quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderSummary(IEnumerable<CartItemDto> cartItems)
        {
            decimal subtotal = cartItems.Sum(ci => (ci.Product?.Price ?? 0) * ci.Quantity);
            decimal vat = subtotal * 0.05m; // 5% VAT as an example
            decimal total = subtotal + vat;

            lblSubtotalValue.Text = $"${subtotal:F2}";
            lblVATValue.Text = $"${vat:F2}";
            lblTotalValue.Text = $"${total:F2}";
        }

        private void ClearInputs()
        {
            txtQuantity.Clear();
            _selectedCartItemId = null;
        }
    }
}