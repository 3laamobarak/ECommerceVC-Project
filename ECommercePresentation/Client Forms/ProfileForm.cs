using ECommerceDTOs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class ProfileForm : Form
    {

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;

        public ProfileForm()
        {
            InitializeComponent();

            // Set initial state
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
            btnSave.Enabled = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Placeholder for enabling edit mode
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Placeholder for saving changes
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.Fixed3D;
                textBox.BackColor = Color.FromArgb(235, 245, 255);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.BackColor = Color.White;
            }
        }
    }
}