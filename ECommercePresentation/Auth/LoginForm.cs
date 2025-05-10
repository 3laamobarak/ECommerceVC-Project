using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.ProductService;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class LoginForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICartItemService _cartItemService;
        private PictureBox pictureBox;
        private Panel panelInputs;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;

        public LoginForm()
        {
         
            InitializeComponent();
        }
        //public LoginForm(IUserService userService, IProductService productService, ICategoryService categoryService, ICartItemService cartItemService)
        //{
        //    _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        //    _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        //    _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        //    _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
        //    InitializeComponent();
        //}

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            //{
            //    MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //try
            //{
            //    var user = await _userService.AuthenticateAsync(txtUsername.Text, txtPassword.Text);
            //    if (user == null)
            //    {
            //        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    if (!user.IsActive)
            //    {
            //        MessageBox.Show("Your account is deactivated. Please contact an admin.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    // Navigate to BaseForm
            //    var baseForm = new BaseForm(_productService, _categoryService, _cartItemService, _userService);
            //    baseForm.FormClosed += (s, args) => this.Close();
            //    baseForm.Show();
            //    this.Hide();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            registerForm.Show();
        }
    }
}