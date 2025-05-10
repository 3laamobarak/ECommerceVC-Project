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
    public partial class OrderForm : Form
    {
        private readonly IOrderService _orderService;
        private int? _selectedOrderId;

        public OrderForm(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            InitializeComponent();

            // Initialize DataGridView columns and styling
            gridOrders.Columns.Clear();
            gridOrders.Columns.Add("OrderID", "Order ID");
            gridOrders.Columns.Add("UserID", "User ID");
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
                        order.UserID,
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
                txtUserId.Text = selectedRow.Cells["UserID"].Value.ToString();
                txtTotalAmount.Text = decimal.Parse(selectedRow.Cells["TotalAmount"].Value.ToString().Replace("$", "")).ToString("F2");
                cmbStatus.SelectedItem = selectedRow.Cells["Status"].Value.ToString();
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                var orderDto = new CreateOrderDto
                {
                    UserID = int.Parse(txtUserId.Text),

                };

                var createdOrder = await _orderService.CreateOrderAsync(orderDto);
                MessageBox.Show("Order created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedOrderId.HasValue)
                {
                    MessageBox.Show("Please select an order to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidateInputs()) return;

                var orderUpdateDto = new OrderUpdateDto
                {
                    TotalAmount = decimal.Parse(txtTotalAmount.Text),
                    Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), cmbStatus.SelectedItem.ToString())
                };

                var updatedOrder = await _orderService.UpdateOrderAsync(_selectedOrderId.Value, orderUpdateDto);
                MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedOrderId.HasValue)
                {
                    MessageBox.Show("Please select an order to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var deleted = await _orderService.DeleteOrderAsync(_selectedOrderId.Value);
                    if (deleted)
                    {
                        MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        LoadOrdersAsync();
                    }
                    else
                    {
                        MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private bool ValidateInputs()
        {
            if (!int.TryParse(txtUserId.Text, out int userId) || userId <= 0)
            {
                MessageBox.Show("Please enter a valid User ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount) || totalAmount < 0)
            {
                MessageBox.Show("Please enter a valid Total Amount (non-negative).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.Fixed3D;
                textBox.BackColor = Color.FromArgb(235, 245, 255);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.BackColor = Color.White;
            }
        }
        private void ClearInputs()
        {
            txtUserId.Clear();
            txtTotalAmount.Clear();
            cmbStatus.SelectedIndex = 0;
            _selectedOrderId = null;
            gridOrders.ClearSelection();
        }
    }
}