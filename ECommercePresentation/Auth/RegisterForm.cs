using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class RegisterForm : Form
    {
        private PictureBox pictureBox;
        private Panel panelInputs;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Button btnBack;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            //// Validate inputs
            //if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
            //    string.IsNullOrWhiteSpace(txtEmail.Text) ||
            //    string.IsNullOrWhiteSpace(txtFirstName.Text) ||
            //    string.IsNullOrWhiteSpace(txtLastName.Text) ||
            //    string.IsNullOrWhiteSpace(txtPassword.Text) ||
            //    string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            //{
            //    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            //{
            //    MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (txtPassword.Text != txtConfirmPassword.Text)
            //{
            //    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //var user = new ECommerceDTOs.User
            //{
            //    Username = txtUsername.Text,
            //    Email = txtEmail.Text,
            //    FirstName = txtFirstName.Text,
            //    LastName = txtLastName.Text,
            //    Password = txtPassword.Text, // Mock: plain text; production: hash
            //    Role = "Client",
            //    IsActive = true,
            //    DateCreated = DateTime.Now,
            //    LastLoginDate = null
            //};

            //try
            //{
            //    bool success = await _userService.RegisterAsync(user);
            //    if (!success)
            //    {
            //        MessageBox.Show("Username or email already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    MessageBox.Show("Registration successful! Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    var loginForm = new LoginForm(_userService, new MockProductService(), new MockCategoryService(), new MockCartItemService());
            //    loginForm.FormClosed += (s, args) => this.Close();
            //    loginForm.Show();
            //    this.Hide();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            //var loginForm = new LoginForm(_userService, new MockProductService(), new MockCategoryService(), new MockCartItemService());
            var loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
            this.Hide();
        }
    }
}