using ECommerceApplication.Services.UserServices;
using ECommerceDTOs;
using ECommerceModels.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECommerceApplication.Contracts;

namespace ECommercePresentation
{
    public partial class UserForm : Form
    {
        private readonly IUserService _userService;
        private List<UserDto> _allUsers;

        public UserForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            LoadUsersAsync();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridViewClients.AutoGenerateColumns = false;
            dataGridViewAdmins.AutoGenerateColumns = false;
            // Ensure columns are editable where needed
            dataGridViewClients.Columns["colRoleClients"].ReadOnly = false;
            dataGridViewClients.Columns["colActiveClients"].ReadOnly = false;
            dataGridViewAdmins.Columns["colRoleAdmins"].ReadOnly = false;
            dataGridViewAdmins.Columns["colActiveAdmins"].ReadOnly = false;
            // Set edit mode to commit on Enter
            dataGridViewClients.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewAdmins.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private async void LoadUsersAsync()
        {
            try
            {
                _allUsers = (await _userService.GetAllUsersAsync()).ToList();
                PopulateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataGridView()
        {
            dataGridViewClients.Rows.Clear();
            dataGridViewAdmins.Rows.Clear();

            var clients = _allUsers.Where(u => u.Role == UserRole.Client);
            foreach (var user in clients)
            {
                int rowIndex = dataGridViewClients.Rows.Add(
                    user.Username,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.Role.ToString(),
                    user.IsActive == IsActive.Active ? "True" : "False",
                    user.DateCreated.ToString("yyyy-MM-dd"),
                    user.LastLoginDate?.ToString("yyyy-MM-dd") ?? "N/A",
                    "Edit",
                    "Delete"
                );
                dataGridViewClients.Rows[rowIndex].Tag = user.UserID;
            }

            var admins = _allUsers.Where(u => u.Role == UserRole.Admin || u.Role == UserRole.SuperAdmin);
            foreach (var user in admins)
            {
                int rowIndex = dataGridViewAdmins.Rows.Add(
                    user.Username,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.Role.ToString(),
                    user.IsActive == IsActive.Active ? "True" : "False",
                    user.DateCreated.ToString("yyyy-MM-dd"),
                    user.LastLoginDate?.ToString("yyyy-MM-dd") ?? "N/A",
                    "Edit",
                    "Delete"
                );
                dataGridViewAdmins.Rows[rowIndex].Tag = user.UserID;
            }
        }

        private async void DataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            int userId = (int)dataGridViewClients.Rows[e.RowIndex].Tag;
            var user = _allUsers.FirstOrDefault(u => u.UserID == userId);

            if (e.ColumnIndex == dataGridViewClients.Columns["colEditClients"].Index)
            {
                await HandleEdit(userId, user);
            }
            else if (e.ColumnIndex == dataGridViewClients.Columns["colDeleteClients"].Index)
            {
                await HandleDelete(userId);
            }
        }

        private async void DataGridViewAdmins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            int userId = (int)dataGridViewAdmins.Rows[e.RowIndex].Tag;
            var user = _allUsers.FirstOrDefault(u => u.UserID == userId);

            if (e.ColumnIndex == dataGridViewAdmins.Columns["colEditAdmins"].Index)
            {
                await HandleEdit(userId, user);
            }
            else if (e.ColumnIndex == dataGridViewAdmins.Columns["colDeleteAdmins"].Index)
            {
                await HandleDelete(userId);
            }
        }

        private async void DataGridViewClients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || (e.ColumnIndex != dataGridViewClients.Columns["colRoleClients"].Index &&
                e.ColumnIndex != dataGridViewClients.Columns["colActiveClients"].Index)) return;

            int userId = (int)dataGridViewClients.Rows[e.RowIndex].Tag;
            await SaveCellChanges(userId, e.ColumnIndex, dataGridViewClients);
        }

        private async void DataGridViewAdmins_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || (e.ColumnIndex != dataGridViewAdmins.Columns["colRoleAdmins"].Index &&
                e.ColumnIndex != dataGridViewAdmins.Columns["colActiveAdmins"].Index)) return;

            int userId = (int)dataGridViewAdmins.Rows[e.RowIndex].Tag;
            await SaveCellChanges(userId, e.ColumnIndex, dataGridViewAdmins);
        }

        private async Task SaveCellChanges(int userId, int columnIndex, DataGridView dataGridView)
        {
            var user = _allUsers.FirstOrDefault(u => u.UserID == userId);
            if (user == null) return;

            var rows = dataGridView.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Tag == userId).ToList();
            if (!rows.Any())
            {
                MessageBox.Show($"No row found for user ID {userId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var row = rows.First();
            var rowIndex = row.Index;
            var cellValue = row.Cells[columnIndex].Value;

            if (cellValue == null)
            {
                MessageBox.Show($"Cell value at column {columnIndex} is null for user ID {userId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateUserResultDTO result = null;
            if (columnIndex == dataGridView.Columns["colRoleClients"].Index || columnIndex == dataGridView.Columns["colRoleAdmins"].Index)
            {
                var newRole = (UserRole)Enum.Parse(typeof(UserRole), cellValue.ToString());
                result = await _userService.ChangeRoleAsync(userId, newRole);
            }
            else if (columnIndex == dataGridView.Columns["colActiveClients"].Index || columnIndex == dataGridView.Columns["colActiveAdmins"].Index)
            {
                var isActive = cellValue.ToString() == "True" ? IsActive.Active : IsActive.Inactive;
                var updatedUser = new UserDto
                {
                    IsActive = isActive,
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role,
                    LastLoginDate = user.LastLoginDate
                };
                result = await _userService.UpdateUserWithoutPasswordAsync(userId, updatedUser);
            }

            if (result?.Success == true)
            {
                MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsersAsync();
            }
            else if (result != null)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadUsersAsync(); // Revert changes
            }
        }

        private async Task HandleEdit(int userId, UserDto user)
        {
            if (user == null) return;

            using (var editForm = new UserEditForm(user, _userService))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Assuming UserEditForm updates the user object; refresh the grid
                    var result = new UpdateUserResultDTO { Success = true, Message = "User updated successfully." };
                    MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsersAsync();
                }
            }
        }

        private async Task HandleDelete(int userId)
        {
            var confirm = MessageBox.Show("Are you sure you want to deactivate this user?", "Confirm Deactivate",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                var result = await _userService.DeactivateUserAsync(userId); // Using Deactivate since Delete isn't available
                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsersAsync();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}