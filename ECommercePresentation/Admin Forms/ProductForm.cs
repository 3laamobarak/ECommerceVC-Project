using ECommerceApplication.Services.ProductService;
using ECommerceDTOs;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class ProductForm : Form
    {
        private readonly IProductService _productService;
        private int? _selectedProductId;

        public ProductForm(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            InitializeComponent();

            // Initialize DataGridView columns and styling
            gridProducts.Columns.Clear();
            gridProducts.Columns.Add("ProductID", "Product ID");
            gridProducts.Columns.Add("Name", "Name");
            gridProducts.Columns.Add("Description", "Description");
            gridProducts.Columns.Add("Price", "Price");
            gridProducts.Columns.Add("UnitsInStock", "Units In Stock");
            gridProducts.Columns.Add("CategoryID", "Category ID");

            // Apply Bootstrap-like styling to DataGridView
            gridProducts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 123, 255), // Bootstrap primary
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            gridProducts.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9),
                SelectionBackColor = Color.FromArgb(108, 117, 125), // Bootstrap secondary
                SelectionForeColor = Color.White
            };

            LoadProductsAsync();
        }

        private async void LoadProductsAsync()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                gridProducts.Rows.Clear();
                foreach (var product in products)
                {
                    gridProducts.Rows.Add(
                        product.ProductID,
                        product.Name,
                        product.Description,
                        product.Price.ToString("C"),
                        product.UnitsInStock,
                        product.CategoryID
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count > 0)
            {
                var selectedRow = gridProducts.SelectedRows[0];
                _selectedProductId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtDescription.Text = selectedRow.Cells["Description"].Value.ToString();
                txtPrice.Text = decimal.Parse(selectedRow.Cells["Price"].Value.ToString().Replace("$", "")).ToString("F2");
                txtUnitsInStock.Text = selectedRow.Cells["UnitsInStock"].Value.ToString();
                txtCategoryID.Text = selectedRow.Cells["CategoryID"].Value.ToString();
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new ProductDto
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    CategoryID = int.Parse(txtCategoryID.Text)
                };
                await _productService.CreateProductAsync(product);
                MessageBox.Show("Product created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadProductsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedProductId.HasValue)
                {
                    MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = new ProductDto
                {
                    ProductID = _selectedProductId.Value,
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    CategoryID = int.Parse(txtCategoryID.Text)
                };
                await _productService.UpdateProductAsync(_selectedProductId.Value, product);
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadProductsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedProductId.HasValue)
                {
                    MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _productService.DeleteProductAsync(_selectedProductId.Value);
                MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadProductsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Close form to return to BaseForm
            this.Close();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
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
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtUnitsInStock.Clear();
            txtCategoryID.Clear();
            _selectedProductId = null;
            gridProducts.ClearSelection();
        }
    }
}