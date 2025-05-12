using ECommerceApplication.Services.AuthServices;
using ECommerceDTOs;
using System;
using System.Windows.Forms;
using ECommerceModels.Enums;
using ECommercePresentation.Client;
using Shared.Helpers;

namespace ECommercePresentation.AuthForms
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;

        public LoginForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = await _authService.LoginAsync(new LoginDto
            {
                UsernameOrEmail = txtUsername.Text,
                Password = txtPassword.Text
            });

            if (result.Success)
            {
                MessageBox.Show("Login successful!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Store session (uncomment if SessionManager is implemented)
                // SessionManager.SetSession(result.User);

                this.Hide();
                // session manager
                if(SessionManager.Role == UserRole.Admin || SessionManager.Role == UserRole.SuperAdmin)
                {
                    var baseForm = Program.Resolve<Base>();
                    baseForm.FormClosed += (s, args) => this.Close();
                    baseForm.Show();
                }
                else if(SessionManager.Role == UserRole.Client)
                {
                    var clientOrder = Program.Resolve<ProductDashboardForm>();
                    clientOrder.FormClosed += (s, args) => this.Close();
                    clientOrder.Show();
                } 
            }
            else
            {
                MessageBox.Show(result.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = Program.Resolve<RegistrationForm>();
            registerForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            registerForm.Show();
        }
    }
}