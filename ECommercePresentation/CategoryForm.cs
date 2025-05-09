using ECommerceApplication.Services.CategoryService;
using ECommerceDTOs;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class CategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private int? _selectedCategoryId;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (gridCategories.SelectedRows.Count > 0)
            {
                var selectedRow = gridCategories.SelectedRows[0];
                _selectedCategoryId = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtDescription.Text = selectedRow.Cells["Description"].Value.ToString();
            }
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                var categoryDto = new CategoryDto
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text
                };

                var createdCategory = await _categoryService.AddAsync(categoryDto);
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

                var categoryDto = new CategoryDto
                {
                    CategoryID = _selectedCategoryId.Value,
                    Name = txtName.Text,
                    Description = txtDescription.Text
                };

                var updatedCategory = await _categoryService.UpdateAsync(categoryDto);
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
                    var deleted = await _categoryService.DeleteAsync(_selectedCategoryId.Value);
                    if (deleted)
                    {
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        LoadCategoriesAsync();
                    }
                    else
                    {
                        MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a valid Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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