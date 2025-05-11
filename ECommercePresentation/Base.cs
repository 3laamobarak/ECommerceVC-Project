using ECommerceApplication.PasswordHasherService;
using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services.ProductService;
using ECommerceApplication.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;
using Shared.Helpers;

namespace ECommercePresentation;

public partial class Base : Form
{
    private readonly IOrderService _orderService;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly ICartItemService _cartItemService;
    private readonly IUserService _userService;
    private readonly IPasswordHasher _passwordHasher;

    public Base(IOrderService orderService, ICategoryService categoryService, IProductService productService, ICartItemService cartItemService, IUserService userService
        ,IPasswordHasher passwordHasher )
    {
        InitializeComponent();
        _orderService = orderService;
        _categoryService = categoryService;
        _productService = productService;
        _cartItemService = cartItemService;
        _userService = userService;
        _passwordHasher = passwordHasher;
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

    private void ProductButton_Click(object sender, EventArgs e)
    {
        ProductForm productForm = new ProductForm(_productService, _categoryService);
        productForm.Show();
    }

    private void CartItemButton_Click(object sender, EventArgs e)
    {
        var cartItemForm = Program.Resolve<CartItemForm>();
        cartItemForm.Show();
    }
    private void ProfileButton_Click(object sender, EventArgs e)
    {
        // Check if a user is logged in using SessionManager
        if (!SessionManager.IsAuthenticated)
        {
            MessageBox.Show("User not logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int userId = SessionManager.UserId;
        var profileForm = new Profile(_userService, _passwordHasher);
        profileForm.LoadUserProfile(userId);
        profileForm.ShowDialog();
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