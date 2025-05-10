using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.ProductService;
using ECommerceDTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class CategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private int? _selectedCategoryId;

        public CategoryForm(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            InitializeComponent();
            InitializeDataGridViewColumns(); // Ensure columns are set up before loading data
            LoadCategoriesAsync().ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    Invoke((Action)(() =>
                        MessageBox.Show("Failed to initialize categories: " + t.Exception.InnerException?.Message,
                            "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void InitializeDataGridViewColumns()
        {
            if (gridCategories.Columns.Count == 0)
            {
                gridCategories.Columns.Clear();
                gridCategories.Columns.Add("CategoryID", "Category ID");
                gridCategories.Columns.Add("Name", "Name");
                gridCategories.Columns.Add("Description", "Description");
                gridCategories.Columns.Add("ProductCount", "Product Count"); // Column for product count
                gridCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                // Detach event to prevent firing during load
                gridCategories.SelectionChanged -= GridCategories_SelectionChanged;

                var categories = await _categoryService.GetAllCategoriesAsync();
                if (categories == null)
                {
                    MessageBox.Show("No categories retrieved from the service.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                gridCategories.Rows.Clear();
                foreach (var category in categories)
                {
                    var products = await _productService.GetProductsByCategoryAsync(category.CategoryID);
                    int productCount = products?.Count() ?? 0;

                    gridCategories.Rows.Add(
                        category.CategoryID,
                        category.Name,
                        category.Description,
                        productCount
                    );
                }

                gridCategories.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridCategories.SelectionChanged += GridCategories_SelectionChanged;
            }
        }

        private void GridCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (gridCategories.SelectedRows.Count == 0 || gridCategories.CurrentRow == null)
            {
                return;
            }

            var selectedRow = gridCategories.SelectedRows[0];
            if (selectedRow.Cells["CategoryID"].Value == null)
            {
                return;
            }

            try
            {
                _selectedCategoryId = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);
                txtName.Text = selectedRow.Cells["Name"].Value?.ToString() ?? "";
                txtDescription.Text = selectedRow.Cells["Description"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing category selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearInputs();
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

                var categoryDto = new CategoryDto
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                var categories = await _categoryService.GetAllCategoriesAsync();
                if (categories?.Any(c => c.Name.Equals(categoryDto.Name, StringComparison.OrdinalIgnoreCase)) == true)
                {
                    MessageBox.Show("A category with this name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _categoryService.AddAsync(categoryDto);
                MessageBox.Show("Category created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                await LoadCategoriesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedCategoryId.HasValue)
                {
                    MessageBox.Show("Please select a category to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInputs(out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var categoryDto = new CategoryDto
                {
                    CategoryID = _selectedCategoryId.Value,
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                var categories = await _categoryService.GetAllCategoriesAsync();
                if (categories?.Any(c => c.Name.Equals(categoryDto.Name, StringComparison.OrdinalIgnoreCase) && c.CategoryID != categoryDto.CategoryID) == true)
                {
                    MessageBox.Show("A category with this name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _categoryService.UpdateAsync(categoryDto);
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                await LoadCategoriesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedCategoryId.HasValue)
                {
                    MessageBox.Show("Please select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var products = await _productService.GetProductsByCategoryAsync(_selectedCategoryId.Value);
                if (products != null && products.Any())
                {
                    MessageBox.Show($"Cannot delete this category because it is associated with {products.Count()} product(s). Please reassign or delete the products first.",
                        "Deletion Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var deleted = await _categoryService.DeleteAsync(_selectedCategoryId.Value);
                    if (deleted)
                    {
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        await LoadCategoriesAsync();
                    }
                    else
                    {
                        MessageBox.Show("Category not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private bool ValidateInputs(out string errorMessage)
        {
            errorMessage = string.Empty;
            var name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Category name is required.";
                return false;
            }

            if (name.Length > 100)
            {
                errorMessage = "Category name cannot exceed 100 characters.";
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z0-9\s\-&]+$"))
            {
                errorMessage = "Category name can only contain letters, numbers, spaces, hyphens, and ampersands.";
                return false;
            }

            var description = txtDescription.Text.Trim();
            if (description.Length > 500)
            {
                errorMessage = "Description cannot exceed 500 characters.";
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            try
            {
                gridCategories.SelectionChanged -= GridCategories_SelectionChanged;

                txtName.Clear();
                txtDescription.Clear();
                _selectedCategoryId = null;
                gridCategories.ClearSelection();
            }
            finally
            {
                gridCategories.SelectionChanged += GridCategories_SelectionChanged;
            }
        }
    }
}