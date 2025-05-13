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
        private Dictionary<int, bool> _pendingChanges; // Track rows with pending changes

        public UserForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            _pendingChanges = new Dictionary<int, bool>();
            LoadUsersAsync();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridViewClients.AutoGenerateColumns = false;
            dataGridViewAdmins.AutoGenerateColumns = false;
            dataGridViewClients.Columns["colUsernameClients"].ReadOnly = true;
            dataGridViewClients.Columns["colEmailClients"].ReadOnly = true;
            dataGridViewClients.Columns["colFirstNameClients"].ReadOnly = true;
            dataGridViewClients.Columns["colLastNameClients"].ReadOnly = true;
            dataGridViewClients.Columns["colRoleClients"].ReadOnly = false;
            dataGridViewClients.Columns["colActiveClients"].ReadOnly = false;
            dataGridViewClients.Columns["colCreatedClients"].ReadOnly = true;
            dataGridViewClients.Columns["colLastLoginClients"].ReadOnly = true;
            dataGridViewAdmins.Columns["colUsernameAdmins"].ReadOnly = true;
            dataGridViewAdmins.Columns["colEmailAdmins"].ReadOnly = true;
            dataGridViewAdmins.Columns["colFirstNameAdmins"].ReadOnly = true;
            dataGridViewAdmins.Columns["colLastNameAdmins"].ReadOnly = true;
            dataGridViewAdmins.Columns["colRoleAdmins"].ReadOnly = false;
            dataGridViewAdmins.Columns["colActiveAdmins"].ReadOnly = false;
            dataGridViewAdmins.Columns["colCreatedAdmins"].ReadOnly = true;
            dataGridViewAdmins.Columns["colLastLoginAdmins"].ReadOnly = true;
            dataGridViewClients.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewAdmins.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private async void LoadUsersAsync()
        {
            try
            {
                _allUsers = (await _userService.GetAllUsersAsync()).ToList();
                _pendingChanges.Clear();
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
                int rowIndex = dataGridViewClients.Rows.Add(user.Username, user.Email, user.FirstName, user.LastName, user.Role.ToString(), user.IsActive == IsActive.Active ? "True" : "False", user.DateCreated.ToString("yyyy-MM-dd"), user.LastLoginDate?.ToString("yyyy-MM-dd") ?? "N/A", "Save Changes");
                dataGridViewClients.Rows[rowIndex].Tag = user.UserID;
            }
            var admins = _allUsers.Where(u => u.Role == UserRole.Admin || u.Role == UserRole.SuperAdmin);
            foreach (var user in admins)
            {
                int rowIndex = dataGridViewAdmins.Rows.Add(user.Username, user.Email, user.FirstName, user.LastName, user.Role.ToString(), user.IsActive == IsActive.Active ? "True" : "False", user.DateCreated.ToString("yyyy-MM-dd"), user.LastLoginDate?.ToString("yyyy-MM-dd") ?? "N/A", "Save Changes");
                dataGridViewAdmins.Rows[rowIndex].Tag = user.UserID;
            }
        }

        private async void DataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == dataGridViewClients.Columns["colSaveChangesClients"].Index)
            {
                int userId = (int)dataGridViewClients.Rows[e.RowIndex].Tag;
                if (_pendingChanges.ContainsKey(userId) && _pendingChanges[userId])
                    await SaveRowChanges(userId, dataGridViewClients, e.RowIndex);
            }
        }

        private async void DataGridViewAdmins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == dataGridViewAdmins.Columns["colSaveChangesAdmins"].Index)
            {
                int userId = (int)dataGridViewAdmins.Rows[e.RowIndex].Tag;
                if (_pendingChanges.ContainsKey(userId) && _pendingChanges[userId])
                    await SaveRowChanges(userId, dataGridViewAdmins, e.RowIndex);
            }
        }

        private async void DataGridViewClients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || (e.ColumnIndex != dataGridViewClients.Columns["colRoleClients"].Index && e.ColumnIndex != dataGridViewClients.Columns["colActiveClients"].Index)) return;
            int userId = (int)dataGridViewClients.Rows[e.RowIndex].Tag;
            _pendingChanges[userId] = true;
        }

        private async void DataGridViewAdmins_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || (e.ColumnIndex != dataGridViewAdmins.Columns["colRoleAdmins"].Index && e.ColumnIndex != dataGridViewAdmins.Columns["colActiveAdmins"].Index)) return;
            int userId = (int)dataGridViewAdmins.Rows[e.RowIndex].Tag;
            _pendingChanges[userId] = true;
        }

        private async Task SaveRowChanges(int userId, DataGridView dataGridView, int rowIndex)
        {
            var user = _allUsers.FirstOrDefault(u => u.UserID == userId);
            if (user == null)
            {
                MessageBox.Show($"User with ID {userId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var row = dataGridView.Rows[rowIndex];
            bool changesMade = false;
            UpdateUserResultDTO result = null;
            var roleCellValue = row.Cells[dataGridView.Columns["colRoleClients"]?.Index ?? dataGridView.Columns["colRoleAdmins"].Index].Value;
            if (roleCellValue != null && roleCellValue.ToString() != user.Role.ToString())
            {
                var newRole = (UserRole)Enum.Parse(typeof(UserRole), roleCellValue.ToString());
                result = await _userService.ChangeRoleAsync(userId, newRole);
                if (result?.Success == true)
                    changesMade = true;
                else
                {
                    MessageBox.Show(result?.Message ?? "Error updating role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadUsersAsync();
                    return;
                }
            }
            var activeCellValue = row.Cells[dataGridView.Columns["colActiveClients"]?.Index ?? dataGridView.Columns["colActiveAdmins"].Index].Value;
            if (activeCellValue != null)
            {
                var isActive = activeCellValue.ToString() == "True" ? IsActive.Active : IsActive.Inactive;
                if (isActive != user.IsActive)
                {
                    result = isActive == IsActive.Active ? await _userService.ActivateUserAsync(userId) : await _userService.DeactivateUserAsync(userId);
                    if (result?.Success == true)
                        changesMade = true;
                    else
                    {
                        MessageBox.Show(result?.Message ?? "Error updating active status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadUsersAsync();
                        return;
                    }
                }
            }
            if (changesMade)
            {
                MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _pendingChanges.Remove(userId);
                LoadUsersAsync();
            }
            else
                MessageBox.Show("No changes to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}