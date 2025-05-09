using ECommerceApplication.Services.CategoryService;
using ECommerceDTOs;

namespace ECommercePresentation;

public partial class AddEditCategoryForm : Form
{
    private readonly ICategoryService _categoryService;
    private readonly CategoryDto _category;

    public AddEditCategoryForm(ICategoryService categoryService, CategoryDto? category = null)
    {
        _categoryService = categoryService;
        _category = category;
        InitializeComponent();
        if (_category != null)
        {
            // textBoxName.Text = _category.Name;
            // textBoxDescription.Text = _category.Description;
        }
        // private async void button3_Click(object sender, EventArgs e) // Delete Category
        // {
        //     if (dataGridView1.SelectedRows.Count > 0)
        //     {
        //         var selectedRow = dataGridView1.SelectedRows[0];
        //         var categoryName = selectedRow.Cells["Name"].Value.ToString();
        //
        //         var category = await _categoryService.GetByNameAsync(categoryName);
        //         if (category != null)
        //         {
        //             var confirmResult = MessageBox.Show($"Are you sure you want to delete the category '{category.Name}'?",
        //                 "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //
        //             if (confirmResult == DialogResult.Yes)
        //             {
        //                 await _categoryService.DeleteAsync(category.Id);
        //                 LoadCategories();
        //             }
        //         }
        //     }
        //     else
        //     {
        //         MessageBox.Show("Please select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //     }
    }
}