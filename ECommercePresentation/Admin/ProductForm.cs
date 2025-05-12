using ECommerceApplication.Services.ProductService;
using ECommerceApplication.Services.CategoryService;
using ECommerceDTOs;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ECommercePresentation
{
    public partial class ProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private int? _selectedProductId;
        private Dictionary<string, int> _categoryNameToIdMap;
        private string _selectedImagePath;
        private readonly string _imageFolder = Path.Combine(Application.StartupPath, "Images", "Products");

        public ProductForm(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _categoryNameToIdMap = new Dictionary<string, int>();
            InitializeComponent();
            InitializeDataGridViewColumns(); // Ensure columns are set up before loading data
            Directory.CreateDirectory(_imageFolder); // Ensure image folder exists
            LoadCategoriesAsync().ContinueWith(_ => LoadProductsAsync(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void InitializeDataGridViewColumns()
        {
            if (gridProducts.Columns.Count == 0)
            {
                gridProducts.Columns.Clear();
                gridProducts.Columns.Add("ProductID", "Product ID");
                gridProducts.Columns.Add("Name", "Name");
                gridProducts.Columns.Add("Description", "Description");
                gridProducts.Columns.Add("Price", "Price");
                gridProducts.Columns.Add("UnitsInStock", "Units In Stock");
                gridProducts.Columns.Add("CategoryName", "Category Name");
                gridProducts.Columns.Add("ImagePath", "Image");
                gridProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

                // Apply styling
                gridProducts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(52, 58, 64),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                };
                gridProducts.DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10),
                    SelectionBackColor = Color.FromArgb(108, 117, 125),
                    SelectionForeColor = Color.White
                };
            }
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                cmbCategory.Items.Clear();
                _categoryNameToIdMap.Clear();
                var categories = await _categoryService.GetAllCategoriesAsync();
                if (categories == null || !categories.Any())
                {
                    MessageBox.Show("No categories available. Please add categories first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    return;
                }

                foreach (var category in categories)
                {
                    _categoryNameToIdMap[category.Name] = category.CategoryID;
                    cmbCategory.Items.Add(category.Name);
                }
                cmbCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private async void LoadProductsAsync()
        {
            try
            {
                gridProducts.SelectionChanged -= GridProducts_SelectionChanged;

                var products = await _productService.GetAllProductsAsync();
                if (products == null)
                {
                    MessageBox.Show("No products retrieved from the service.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                gridProducts.Rows.Clear();
                foreach (var product in products)
                {
                    var categoryName = _categoryNameToIdMap.FirstOrDefault(x => x.Value == product.CategoryID).Key ?? "Unknown";
                    gridProducts.Rows.Add(
                        product.ProductID,
                        product.Name,
                        product.Description,
                        product.Price.ToString("C"),
                        product.UnitsInStock,
                        categoryName,
                        product.ImagePath
                    );
                }

                gridProducts.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridProducts.SelectionChanged += GridProducts_SelectionChanged;
            }
        }

        private void GridProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count == 0 || gridProducts.CurrentRow == null)
            {
                return;
            }

            var selectedRow = gridProducts.SelectedRows[0];
            if (selectedRow.Cells["ProductID"].Value == null)
            {
                return;
            }

            try
            {
                _selectedProductId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                txtName.Text = selectedRow.Cells["Name"].Value?.ToString() ?? "";
                txtDescription.Text = selectedRow.Cells["Description"].Value?.ToString() ?? "";
                txtPrice.Text = decimal.TryParse(selectedRow.Cells["Price"].Value?.ToString()?.Replace("$", ""), out var price)
                    ? price.ToString("F2")
                    : "";
                txtUnitsInStock.Text = selectedRow.Cells["UnitsInStock"].Value?.ToString() ?? "";
                cmbCategory.SelectedItem = selectedRow.Cells["CategoryName"].Value?.ToString();

                var imagePath = selectedRow.Cells["ImagePath"].Value?.ToString();
                _selectedImagePath = imagePath;
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(Path.Combine(_imageFolder, Path.GetFileName(imagePath))))
                {
                    picProductImage.Image = Image.FromFile(Path.Combine(_imageFolder, Path.GetFileName(imagePath)));
                }
                else
                {
                    picProductImage.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearInputs();
            }
        }

        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                    openFileDialog.Title = "Select Product Image";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        picProductImage.Image = Image.FromFile(openFileDialog.FileName);
                        _selectedImagePath = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs(out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string savedImagePath = SaveImage();

                var product = new ProductDto
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    CategoryID = _categoryNameToIdMap[cmbCategory.SelectedItem.ToString()],
                    ImagePath = savedImagePath
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

                if (!ValidateInputs(out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string savedImagePath = SaveImage();

                var product = new ProductDto
                {
                    ProductID = _selectedProductId.Value,
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    CategoryID = _categoryNameToIdMap[cmbCategory.SelectedItem.ToString()],
                    ImagePath = savedImagePath
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

                var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await _productService.DeleteProductAsync(_selectedProductId.Value);
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadProductsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private bool ValidateInputs(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorMessage = "Product name is required.";
                return false;
            }

            if (txtName.Text.Trim().Length > 100)
            {
                errorMessage = "Product name cannot exceed 100 characters.";
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out var price) || price <= 0)
            {
                errorMessage = "Please enter a valid price greater than 0.";
                return false;
            }

            if (!int.TryParse(txtUnitsInStock.Text, out var units) || units < 0)
            {
                errorMessage = "Please enter a valid number for units in stock (0 or greater).";
                return false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                errorMessage = "Please select a category.";
                return false;
            }

            if (txtDescription.Text.Trim().Length > 500)
            {
                errorMessage = "Description cannot exceed 500 characters.";
                return false;
            }

            return true;
        }

        private string SaveImage()
        {
            if (string.IsNullOrEmpty(_selectedImagePath) || !File.Exists(_selectedImagePath))
            {
                return null;
            }

            try
            {
                string fileName = $"product_{DateTime.Now.Ticks}_{Path.GetFileName(_selectedImagePath)}";
                string destinationPath = Path.Combine(_imageFolder, fileName);
                File.Copy(_selectedImagePath, destinationPath, true);
                return Path.Combine("Images", "Products", fileName).Replace("\\", "/");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void ClearInputs()
        {
            try
            {
                gridProducts.SelectionChanged -= GridProducts_SelectionChanged;

                txtName.Clear();
                txtDescription.Clear();
                txtPrice.Clear();
                txtUnitsInStock.Clear();
                cmbCategory.SelectedIndex = -1;
                picProductImage.Image = null;
                _selectedImagePath = null;
                _selectedProductId = null;
                gridProducts.ClearSelection();
            }
            finally
            {
                gridProducts.SelectionChanged += GridProducts_SelectionChanged;
            }
        }
    }
}