using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class UsersForm : Form
    {
        private TabControl tabControl;
        private TabPage tabClients;
        private TabPage tabAdmins;
        private DataGridView dgvClients;
        private DataGridView dgvAdmins;
        private Button btnBack;

        public UsersForm()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            //try
            //{
            //    // Mock data for testing
            //    var users = GetMockUsers();
            //    var clients = users.Where(u => u.Role == "Client").ToList();
            //    var admins = users.Where(u => u.Role == "Admin").ToList();

            //    // Bind to DataGridViews
            //    dgvClients.DataSource = clients;
            //    dgvAdmins.DataSource = admins;

            //    // Refresh button states
            //    UpdateButtonStates(dgvClients);
            //    UpdateButtonStates(dgvAdmins);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //private List<User> GetMockUsers()
        //{
        //    // Mock data
        //    return new List<User>
        //    {
        //        new User { UserID = 1, Username = "john_doe", Email = "john@example.com", FirstName = "John", LastName = "Doe", Role = "Client", IsActive = true, DateCreated = DateTime.Now.AddDays(-30), LastLoginDate = DateTime.Now.AddDays(-1) },
        //        new User { UserID = 2, Username = "jane_smith", Email = "jane@example.com", FirstName = "Jane", LastName = "Smith", Role = "Client", IsActive = false, DateCreated = DateTime.Now.AddDays(-20), LastLoginDate = null },
        //        new User { UserID = 3, Username = "bob_jones", Email = "bob@example.com", FirstName = "Bob", LastName = "Jones", Role = "Client", IsActive = true, DateCreated = DateTime.Now.AddDays(-15), LastLoginDate = DateTime.Now.AddDays(-2) },
        //        new User { UserID = 4, Username = "alice_brown", Email = "alice@example.com", FirstName = "Alice", LastName = "Brown", Role = "Client", IsActive = true, DateCreated = DateTime.Now.AddDays(-10), LastLoginDate = DateTime.Now.AddDays(-3) },
        //        new User { UserID = 5, Username = "charlie_davis", Email = "charlie@example.com", FirstName = "Charlie", LastName = "Davis", Role = "Client", IsActive = false, DateCreated = DateTime.Now.AddDays(-5), LastLoginDate = null },
        //        new User { UserID = 6, Username = "admin1", Email = "admin1@example.com", FirstName = "Admin", LastName = "One", Role = "Admin", IsActive = true, DateCreated = DateTime.Now.AddDays(-60), LastLoginDate = DateTime.Now.AddHours(-1) },
        //        new User { UserID = 7, Username = "admin2", Email = "admin2@example.com", FirstName = "Admin", LastName = "Two", Role = "Admin", IsActive = true, DateCreated = DateTime.Now.AddDays(-50), LastLoginDate = DateTime.Now.AddHours(-2) },
        //        new User { UserID = 8, Username = "admin3", Email = "admin3@example.com", FirstName = "Admin", LastName = "Three", Role = "Admin", IsActive = false, DateCreated = DateTime.Now.AddDays(-40), LastLoginDate = null }
        //    };
        //}

        private void UpdateButtonStates(DataGridView dgv)
        {
            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    var user = (User)row.DataBoundItem;
            //    var activateButton = (DataGridViewButtonCell)row.Cells["Activate"];
            //    var deactivateButton = (DataGridViewButtonCell)row.Cells["Deactivate"];
            //    var changeRoleButton = (DataGridViewButtonCell)row.Cells["ChangeRole"];
            //    activateButton.Value = user.IsActive ? "Activated" : "Activate";
            //    deactivateButton.Value = !user.IsActive ? "Deactivated" : "Deactivate";
            //    changeRoleButton.Value = user.Role == "Client" ? "To Admin" : "To Client";
            //}
        }

        private async void DgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            await HandleCellClick(dgvClients, dgvAdmins, e);
        }

        private async void DgvAdmins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            await HandleCellClick(dgvAdmins, dgvClients, e);
        }

        private async Task HandleCellClick(DataGridView currentDgv, DataGridView otherDgv, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //var user = (User)currentDgv.Rows[e.RowIndex].DataBoundItem;
            //try
            //{
            //    if (e.ColumnIndex == currentDgv.Columns["Activate"].Index && !user.IsActive)
            //    {
            //        // Simulate service call
            //        user.IsActive = true;
            //        MessageBox.Show($"User {user.Username} activated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else if (e.ColumnIndex == currentDgv.Columns["Deactivate"].Index && user.IsActive)
            //    {
            //        // Simulate service call
            //        user.IsActive = false;
            //        MessageBox.Show($"User {user.Username} deactivated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else if (e.ColumnIndex == currentDgv.Columns["ChangeRole"].Index)
            //    {
            //        // Simulate service call
            //        user.Role = user.Role == "Client" ? "Admin" : "Client";
            //        MessageBox.Show($"User {user.Username} role changed to {user.Role}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        // Refresh both grids
            //        var allUsers = GetMockUsers(); // Simulate full data fetch
            //        var clients = allUsers.Where(u => u.Role == "Client").ToList();
            //        var admins = allUsers.Where(u => u.Role == "Admin").ToList();
            //        dgvClients.DataSource = clients;
            //        dgvAdmins.DataSource = admins;
            //        UpdateButtonStates(dgvClients);
            //        UpdateButtonStates(dgvAdmins);
            //        return;
            //    }

            //    // Refresh current grid
            //    currentDgv.Refresh();
            //    UpdateButtonStates(currentDgv);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}