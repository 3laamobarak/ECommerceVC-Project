using ECommerceApplication.Services.UserServices;
using ECommerceDTOs;
using ECommerceModels.Enums;
using System;
using System.Windows.Forms;
using ECommerceApplication.Contracts;

namespace ECommercePresentation
{
    public partial class UserEditForm : Form
    {
        private readonly UserDto _user;
        private readonly IUserService _userService;

        public UserEditForm(UserDto user, IUserService userService)
        {
            InitializeComponent();
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            LoadUserData();
            SetupEventHandlers();
        }

        private void LoadUserData()
        {
            txtUsername.Text = _user.Username;
            txtEmail.Text = _user.Email;
            txtFirstName.Text = _user.FirstName;
            txtLastName.Text = _user.LastName;
            cmbRole.Items.AddRange(Enum.GetNames(typeof(UserRole)));
            cmbRole.SelectedItem = _user.Role.ToString();
            chkActive.Checked = _user.IsActive == IsActive.Active;

            // Disable fields that shouldn't be edited directly (e.g., Created, LastLogin)
            txtUsername.Enabled = true;
            txtEmail.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            cmbRole.Enabled = true;
            chkActive.Enabled = true;
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var updatedUser = new UserDto
            {
                Username = txtUsername.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                LastLoginDate = _user.LastLoginDate, // Preserve existing login date
                Role = (UserRole)Enum.Parse(typeof(UserRole), cmbRole.SelectedItem.ToString()),
                IsActive = chkActive.Checked ? IsActive.Active : IsActive.Inactive
            };

            var result = await _userService.UpdateUserWithoutPasswordAsync(_user.UserID, updatedUser);
            if (result.Success)
            {
                _user.Username = updatedUser.Username;
                _user.Email = updatedUser.Email;
                _user.FirstName = updatedUser.FirstName;
                _user.LastName = updatedUser.LastName;
                _user.Role = updatedUser.Role;
                _user.IsActive = updatedUser.IsActive;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                cmbRole.SelectedItem == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
        }
    }
}