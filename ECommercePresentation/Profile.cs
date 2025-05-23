using ECommerceApplication.Services.UserServices;
using ECommerceApplication.PasswordHasherService;
using ECommerceDTOs;
using ECommerceModels.Enums;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECommerceApplication.Contracts;
using ECommerceApplication.Services.AuthServices;

namespace ECommercePresentation
{
    public partial class Profile : Form
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IPasswordHasher _passwordHasher;
        private int _userId;

        public Profile(IUserService userService, IPasswordHasher passwordHasher, IAuthService authService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            InitializeComponent();

            // Form Styling
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Style Panels
            panelContent.BackColor = Color.FromArgb(245, 247, 250);

            panelPersonalInfo.BackColor = Color.White;
            panelPersonalInfo.BorderStyle = BorderStyle.None;
            panelPersonalInfo.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panelPersonalInfo.ClientRectangle,
                    Color.FromArgb(209, 213, 219), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 213, 219), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 213, 219), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 213, 219), 1, ButtonBorderStyle.Solid);
            };

            panelPasswordChange.BackColor = Color.White;
            panelPasswordChange.BorderStyle = BorderStyle.None;
            panelPasswordChange.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panelPasswordChange.ClientRectangle,
                    Color.FromArgb(209, 213, 219), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 213, 219), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 213, 219), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 213, 219), 1, ButtonBorderStyle.Solid);
            };

            // Style Labels


            lblPersonalInfoHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPersonalInfoHeader.ForeColor = Color.FromArgb(31, 41, 55);

            lblPasswordChangeHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPasswordChangeHeader.ForeColor = Color.FromArgb(31, 41, 55);

            foreach (Control ctrl in panelPersonalInfo.Controls)
            {
                if (ctrl is Label lbl && lbl != lblPersonalInfoHeader)
                {
                    lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    lbl.ForeColor = Color.FromArgb(75, 85, 99);
                }
            }

            foreach (Control ctrl in panelPasswordChange.Controls)
            {
                if (ctrl is Label lbl && lbl != lblPasswordChangeHeader)
                {
                    lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    lbl.ForeColor = Color.FromArgb(75, 85, 99);
                }
            }

            // Style Text Boxes
            foreach (Control panel in new[] { panelPersonalInfo, panelPasswordChange })
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is TextBox tb)
                    {
                        tb.BackColor = Color.FromArgb(249, 250, 251);
                        tb.BorderStyle = BorderStyle.None;
                        tb.Font = new Font("Segoe UI", 9F);
                        tb.Padding = new Padding(5);
                        tb.Tag = tb.BackColor; // Store original color
                        tb.Enter += (s, e) => ((TextBox)s).BackColor = Color.FromArgb(243, 244, 246);
                        tb.Leave += (s, e) => ((TextBox)s).BackColor = (Color)((TextBox)s).Tag;
                        tb.Paint += (s, e) =>
                        {
                            var tbx = (TextBox)s;
                            using (var pen = new Pen(Color.FromArgb(209, 213, 219), 1))
                            {
                                e.Graphics.DrawRectangle(pen, 0, 0, tbx.Width - 1, tbx.Height - 1);
                            }
                        };
                    }
                }
            }




            // Style Buttons
            btnSave.BackColor = Color.FromArgb(3, 105, 161);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.Tag = btnSave.BackColor;
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(2, 88, 135);
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = (Color)btnSave.Tag;

            btnChangePassword.BackColor = Color.FromArgb(16, 185, 129);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangePassword.Tag = btnChangePassword.BackColor;
            btnChangePassword.MouseEnter += (s, e) => btnChangePassword.BackColor = Color.FromArgb(13, 148, 103);
            btnChangePassword.MouseLeave += (s, e) => btnChangePassword.BackColor = (Color)btnChangePassword.Tag;
        }

        public void LoadUserProfile(int userId)
        {
            _userId = userId;
            LoadUserDetailsAsync();
        }

        private async void LoadUserDetailsAsync()
        {
            try
            {
                var userDetails = await _userService.GetUserDetailsAsync(_userId);
                txtUsername.Text = userDetails.Username;
                txtEmail.Text = userDetails.Email;
                txtFirstName.Text = userDetails.FirstName;
                txtLastName.Text = userDetails.LastName;
                //    cbStatus.SelectedIndex = userDetails.IsActive == IsActive.Active ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // if (!ValidateInputs()) return;


            var updatedUser = new UpdateUserDTO
            {
                Username = txtUsername.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                UserId = _userId,
                Password = txtPassword.Text.Trim(),
                //    IsActive = cbStatus.SelectedIndex == 0 ? IsActive.Active : IsActive.Inactive
            };
            ValidationResultDTO result = await _authService.UpdateUserAsync(updatedUser);

            if (!result.Success)
            {
                ShowValidationErrors(result);
            }
            else
            {
                errorProvider.Clear();
                MessageBox.Show("Registration successful! Please log in.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private async void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (!ValidatePasswordInputs()) return;

            try
            {
                var result = await _authService.ChangePasswordAsync(_userId, txtOldPassword.Text, txtNewPassword.Text);
                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOldPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                    panelPasswordChange.Visible = !panelPasswordChange.Visible;
                    btnChangePassword.Visible = !btnChangePassword.Visible;
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("All personal information fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Old password is required for updates.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidatePasswordInputs()
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text) || string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("All password fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("New password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

            panelPasswordChange.Visible = !panelPasswordChange.Visible;
            btnChangePassword.Visible = !btnChangePassword.Visible;
        }
        private void ShowValidationErrors(ValidationResultDTO result)
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


    }
}