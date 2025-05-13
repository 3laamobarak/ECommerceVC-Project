using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services;
using ECommerceDTOs;
using ECommerceModels.Enums;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Helpers;
using System.Diagnostics;
using ECommerceApplication.Contracts;

namespace ECommercePresentation
{
    public partial class ClientOrder : Form
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUserService _userService;
        private int _selectedOrderId;

        public ClientOrder(IOrderService orderService, IOrderDetailService orderDetailService, IUserService userService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(orderDetailService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            InitializeComponent();

            // Initialize DataGridView columns and styling
            gridOrders.Columns.Clear();
            gridOrders.Columns.Add("OrderID", "Order Number");
            gridOrders.Columns.Add("Username", "Username");
            gridOrders.Columns.Add("Products", "Products Purchased");
            gridOrders.Columns.Add("OrderDate", "Order Date");
            gridOrders.Columns.Add("TotalAmount", "Total Amount");
            gridOrders.Columns.Add("Status", "Status");

            // Apply Bootstrap-like styling to DataGridView
            gridOrders.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            gridOrders.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9),
                SelectionBackColor = Color.FromArgb(108, 117, 125),
                SelectionForeColor = Color.White
            };

            LoadOrdersAsync();
        }

        private async void LoadOrdersAsync()
        {
            try
            {
                if (!SessionManager.IsAuthenticated)
                {
                    // UI update on UI thread
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show("Please log in to view orders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return;
                }

                Debug.WriteLine($"Loading orders for UserID: {SessionManager.UserId}");

                // Fetch data on background thread
                var orders = await _orderService.GetOrdersByUserIdAsync(SessionManager.UserId);
                Debug.WriteLine($"Retrieved {orders?.Count() ?? 0} orders");

                // Prepare data for UI
                var orderRows = new List<object[]>();
                foreach (var order in orders)
                {
                    var user = await _userService.GetUserByIdAsync(order.UserID);
                    string username = user?.Username ?? "Unknown";
                    Debug.WriteLine($"Order {order.OrderID}: Username = {username}");

                    var orderWithDetails = await _orderService.GetOrderWithDetailsAsync(order.OrderID);
                    string productNames = orderWithDetails.OrderDetails != null
                        ? string.Join(", ", orderWithDetails.OrderDetails.Select(od => od.Product?.Name ?? "Unknown"))
                        : "No Products";
                    Debug.WriteLine($"Order {order.OrderID}: Products = {productNames}");

                    orderRows.Add(new object[]
                    {
                        order.OrderID,
                        username,
                        productNames,
                        order.OrderDate.ToString("yyyy-MM-dd"),
                        order.TotalAmount.ToString("C"),
                        order.Status
                    });
                }

                // Update UI on UI thread
                this.Invoke((MethodInvoker)(() =>
                {
                    gridOrders.Rows.Clear();
                    foreach (var row in orderRows)
                    {
                        gridOrders.Rows.Add(row);
                    }
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading orders: {ex.Message}\nStackTrace: {ex.StackTrace}");
                this.Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void GridOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (gridOrders.SelectedRows.Count > 0)
            {
                var selectedRow = gridOrders.SelectedRows[0];
                _selectedOrderId = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                LoadProductList();
            }
        }

        private async void LoadProductList()
        {
            try
            {
                Debug.WriteLine($"Loading product list for OrderID: {_selectedOrderId}");
                var products = await _orderDetailService.GetOrderDetailsByOrderIdAsync(_selectedOrderId);

                // Update UI on UI thread
                this.Invoke((MethodInvoker)(() =>
                {
                    productListPanel.Controls.Clear();

                    if (products == null || !products.Any())
                    {
                        productListPanel.Controls.Add(new Label
                        {
                            Text = "No products found for this order.",
                            Font = new Font("Segoe UI", 10F),
                            AutoSize = true,
                            ForeColor = Color.Gray
                        });
                        return;
                    }

                    foreach (var product in products)
                    {
                        Panel productCard = new Panel
                        {
                            Size = new Size(300, 120),
                            BackColor = Color.White,
                            Padding = new Padding(10),
                            Margin = new Padding(10),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        string productName = product.Product?.Name ?? "Unknown Product";
                        decimal productPrice = product.Product?.Price ?? 0.00m;

                        Label lblName = new Label
                        {
                            Text = productName,
                            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                            Location = new Point(10, 10),
                            AutoSize = true
                        };
                        Label lblPrice = new Label
                        {
                            Text = $"Price: ${productPrice:F2}",
                            Font = new Font("Segoe UI", 9F),
                            Location = new Point(10, 40),
                            AutoSize = true
                        };
                        Label lblQuantity = new Label
                        {
                            Text = $"Quantity: {product.Quantity}",
                            Font = new Font("Segoe UI", 9F),
                            Location = new Point(10, 60),
                            AutoSize = true
                        };
                        Label lblTotal = new Label
                        {
                            Text = $"Total: ${(productPrice * product.Quantity):F2}",
                            Font = new Font("Segoe UI", 9F),
                            Location = new Point(10, 80),
                            AutoSize = true
                        };

                        productCard.Controls.AddRange(new Control[] { lblName, lblPrice, lblQuantity, lblTotal });
                        productListPanel.Controls.Add(productCard);
                    }
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading product list: {ex.Message}\nStackTrace: {ex.StackTrace}");
                this.Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show($"Error loading product list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }
    }
}