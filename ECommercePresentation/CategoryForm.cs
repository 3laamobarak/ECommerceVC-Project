using ECommerceApplication.Services.CategoryService;

namespace ECommercePresentation;

public partial class CategoryForm : Base
{
    private readonly ICategoryService _categoryService;
    public CategoryForm(/*ICategoryService categoryService*/)
    {
        //_categoryService = categoryService;
        InitializeComponent();
        LoadCategories();
    }
    private async void LoadCategories()
    {
        try
        {
            var categories = await _categoryService.GetAllAsync();
            dataGridView1.Rows.Clear();

            foreach (var category in categories)
            {
                dataGridView1.Rows.Add(category.Name, category.Description, "Edit/Delete");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private async void button1_Click(object sender, EventArgs e) // Add New Category
    {
        var addForm = new AddEditCategoryForm(_categoryService);
        if (addForm.ShowDialog() == DialogResult.OK)
        {
            LoadCategories();
        }
    }
    private async void button2_Click(object sender, EventArgs e) // Edit Category
    {
        if (dataGridView1.SelectedRows.Count > 0)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var categoryName = selectedRow.Cells["Name"].Value.ToString();

            var category = await _categoryService.GetByNameAsync(categoryName);
            if (category != null)
            {
                var editForm = new AddEditCategoryForm(_categoryService, category);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a category to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    private async void button3_Click(object sender, EventArgs e) // Delete Category
    {
        if (dataGridView1.SelectedRows.Count > 0)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var categoryName = selectedRow.Cells["Name"].Value.ToString();

            var category = await _categoryService.GetByNameAsync(categoryName);
            if (category != null)
            {
                var confirmResult = MessageBox.Show($"Are you sure you want to delete the category '{category.Name}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    //await _categoryService.DeleteAsync(category.Id);
                    LoadCategories();
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}