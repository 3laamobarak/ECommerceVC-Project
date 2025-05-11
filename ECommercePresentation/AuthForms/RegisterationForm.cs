using ECommerceApplication.Services.AuthServices;
using ECommerceDTOs;
using System;
using System.Windows.Forms;

namespace ECommercePresentation.AuthForms
{
    public partial class RegistrationForm : Form
    {
        private readonly IAuthService _authService;

        public RegistrationForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var userDto = new RegisterUserDto
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Username = txtUsername.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                ConfirmPassword = txtConfirmPassword.Text
            };

            RegistrationResultDTO result = await _authService.RegisterAsync(userDto);

            if (!result.Success)
            {
                ShowValidationErrors(result);
            }
            else
            {
                errorProvider.Clear();
                MessageBox.Show("Registration successful! Please log in.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void ShowValidationErrors(RegistrationResultDTO result)
        {
            errorProvider.Clear();

            if (result.Errors == null || result.Errors.Count == 0)
                return;

            foreach (var error in result.Errors)
            {
                string fieldName = error.Key.ToLower();
                string combinedError = string.Join("\n", error.Value);

                switch (fieldName)
                {
                    case "firstname":
                        errorProvider.SetError(txtFirstName, combinedError);
                        break;
                    case "lastname":
                        errorProvider.SetError(txtLastName, combinedError);
                        break;
                    case "username":
                        errorProvider.SetError(txtUsername, combinedError);
                        break;
                    case "email":
                        errorProvider.SetError(txtEmail, combinedError);
                        break;
                    case "password":
                        errorProvider.SetError(txtPassword, combinedError);
                        break;
                    case "confirmpassword":
                        errorProvider.SetError(txtConfirmPassword, combinedError);
                        break;
                    default:
                        MessageBox.Show($"Unhandled error field: {fieldName}", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}