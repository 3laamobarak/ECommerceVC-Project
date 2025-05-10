using ECommerceApplication.Services.CategoryService;
using EcommercModels;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ECommercePresentation
{
    public partial class CategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private int? _selectedCategoryId;
        private Category? _selectedCategory;

        public CategoryForm(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            InitializeComponent();

            // Initialize DataGridView columns and styling
            gridCategories.Columns.Clear();
            gridCategories.Columns.Add("CategoryID", "Category ID");
            gridCategories.Columns.Add("Name", "Name");
            gridCategories.Columns.Add("Description", "Description");

            // Apply Bootstrap-like styling to DataGridView
            gridCategories.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 123, 255), // Bootstrap primary
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            gridCategories.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9),
                SelectionBackColor = Color.FromArgb(108, 117, 125), // Bootstrap secondary
                SelectionForeColor = Color.White
            };

            LoadCategoriesAsync();
        }

        private async void LoadCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                gridCategories.Rows.Clear();
                foreach (var category in categories)
                {
                    gridCategories.Rows.Add(
                        category.CategoryID,
                        category.Name,
                        category.Description
                    );
                }
                if (!categories.Any())
                {
                    MessageBox.Show("No categories found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GridCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (gridCategories.SelectedRows.Count > 0)
            {
                var selectedRow = gridCategories.SelectedRows[0];
                _selectedCategoryId = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);
                _selectedCategory = await _categoryService.GetByIdAsync(_selectedCategoryId.Value); txtName.Text = selectedRow.Cells["Name"].Value?.ToString();
                txtDescription.Text = selectedRow.Cells["Description"].Value?.ToString();
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                var category = new Category
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text
                };

                var createdCategory = await _categoryService.AddAsync(category);
                MessageBox.Show("Category created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadCategoriesAsync();
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
                if (!ValidateInputs()) return;

                var category = await _categoryService.GetByIdAsync(_selectedCategoryId.Value);
                if (category == null)
                {
                    MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                category.Name = txtName.Text;
                category.Description = txtDescription.Text;

                var updatedCategory = await _categoryService.UpdateAsync(category);
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadCategoriesAsync();
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

                var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await _categoryService.DeleteAsync(_selectedCategoryId.Value);
                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadCategoriesAsync();
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

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Length > 100)
            {
                MessageBox.Show("Please enter a valid Name (1-100 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtName.Clear();
            txtDescription.Clear();
            _selectedCategoryId = null;
            gridCategories.ClearSelection();
        }
    }
}