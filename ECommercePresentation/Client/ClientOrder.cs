using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceDTOs;
using ECommerceModels.Enums;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class ClientOrder : Form
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private int _selectedOrderId;

        public ClientOrder(IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(orderDetailService));
            InitializeComponent();

            // Initialize DataGridView columns and styling
            gridOrders.Columns.Clear();
            gridOrders.Columns.Add("OrderID", "Order ID");
            gridOrders.Columns.Add("OrderDate", "Order Date");
            gridOrders.Columns.Add("TotalAmount", "Total Amount");
            gridOrders.Columns.Add("Status", "Status");

            // Apply Bootstrap-like styling to DataGridView
            gridOrders.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 123, 255), // Bootstrap primary
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            gridOrders.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9),
                SelectionBackColor = Color.FromArgb(108, 117, 125), // Bootstrap secondary
                SelectionForeColor = Color.White
            };

            LoadOrdersAsync();
        }

        private async void LoadOrdersAsync()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                gridOrders.Rows.Clear();
                foreach (var order in orders)
                {
                    gridOrders.Rows.Add(
                        order.OrderID,
                        order.OrderDate.ToString("yyyy-MM-dd"),
                        order.TotalAmount.ToString("C"),
                        order.Status
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (gridOrders.SelectedRows.Count > 0)
            {
                var selectedRow = gridOrders.SelectedRows[0];
                _selectedOrderId = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                LoadProductList(); // Load products for the selected order
            }
        }

        private async void LoadProductList()
        {
            // Clear previous products
            productListPanel.Controls.Clear();

            try
            {
                var products = await _orderDetailService.GetOrderDetailsByOrderIdAsync(_selectedOrderId);

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
                        Size = new Size(300, 100),
                        BackColor = Color.White,
                        Padding = new Padding(10),
                        Margin = new Padding(10),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Null checking for product.Product
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

                    productCard.Controls.AddRange(new Control[] { lblName, lblPrice, lblQuantity });
                    productListPanel.Controls.Add(productCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}