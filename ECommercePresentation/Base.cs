using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services.ProductService;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePresentation;

public partial class Base : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IOrderService _orderService;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly ICartItemService _cartItemService;

    public Base(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        _orderService = _serviceProvider.GetRequiredService<IOrderService>();
        _categoryService = _serviceProvider.GetRequiredService<ICategoryService>();
        _productService = _serviceProvider.GetRequiredService<IProductService>();
        _cartItemService = _serviceProvider.GetRequiredService<ICartItemService>();
    }
    private void CategoriesButton_Click(object sender, EventArgs e)
    {
        CategoryForm categoryForm = new CategoryForm(_categoryService, _productService);
        categoryForm.Show();
    }

    private void OrderButton_Click(object sender, EventArgs e)
    {
        OrderForm orderForm = new OrderForm(_orderService);
        orderForm.Show();
    }
    // product 
    private void ProductButton_Click(object sender, EventArgs e)
    {
        ProductForm productForm = new ProductForm(_productService, _categoryService);
        productForm.Show();
    }
    // cart item
    private void CartItemButton_Click(object sender, EventArgs e)
    {
        var cartItemForm = Program.Resolve<CartItemForm>();
        cartItemForm.Show();
    }
    
    private void contentPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void header_Paint(object sender, PaintEventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void button8_Click(object sender, EventArgs e)
    {

    }
}