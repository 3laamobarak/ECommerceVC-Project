using System.Drawing.Drawing2D;

namespace ECommercePresentation.Client
{
    partial class ProductDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel topNavbar;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnCart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.Name = "ProductDashboardForm";
            this.Text = "E-Commerce Dashboard";

            // Sidebar
            this.sidebar = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(200, this.ClientSize.Height),
                BackColor = System.Drawing.Color.FromArgb(240, 242, 245),
                Location = new System.Drawing.Point(0, 0),
                Padding = new System.Windows.Forms.Padding(15)
            };

            // Logo
            var logo = new System.Windows.Forms.Label
            {
                Text = "HYPER",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(0, 120, 200),
                Location = new System.Drawing.Point(15, 15),
                AutoSize = true,
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 30)
            };
            logo.Paint += (s, e) =>
            {
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(logo.ClientRectangle, System.Drawing.Color.FromArgb(0, 120, 200), System.Drawing.Color.FromArgb(75, 0, 130), LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, logo.ClientRectangle);
                }
                System.Windows.Forms.TextRenderer.DrawText(e.Graphics, logo.Text, logo.Font, logo.ClientRectangle, System.Drawing.Color.White, System.Windows.Forms.TextFormatFlags.HorizontalCenter | System.Windows.Forms.TextFormatFlags.VerticalCenter);
            };
            this.sidebar.Controls.Add(logo);

            // Sidebar Navigation
            var lblStore = new System.Windows.Forms.Label { Text = "Store", Font = new System.Drawing.Font("Segoe UI", 12F), Location = new System.Drawing.Point(15, 80), Margin = new System.Windows.Forms.Padding(5), Size = new System.Drawing.Size(200, 40) };
            var lblOrders = new System.Windows.Forms.Label { Text = "My Orders", Font = new System.Drawing.Font("Segoe UI", 12F), Location = new System.Drawing.Point(15, 120), Margin = new System.Windows.Forms.Padding(5), Size = new System.Drawing.Size(200, 40) };
            var lblCartNav = new System.Windows.Forms.Label { Text = "Cart", Font = new System.Drawing.Font("Segoe UI", 12F), Location = new System.Drawing.Point(15, 160), Margin = new System.Windows.Forms.Padding(5), Size = new System.Drawing.Size(200, 40) };
            var lblProfile = new System.Windows.Forms.Label { Text = "Profile", Font = new System.Drawing.Font("Segoe UI", 12F), Location = new System.Drawing.Point(15, 200), Margin = new System.Windows.Forms.Padding(5), Size = new System.Drawing.Size(200, 40) };
            var lblLogout = new System.Windows.Forms.Label { Text = "Log Out", Font = new System.Drawing.Font("Segoe UI", 12F), Location = new System.Drawing.Point(15, this.ClientSize.Height - 60), ForeColor = System.Drawing.Color.FromArgb(220, 53, 69), Margin = new System.Windows.Forms.Padding(5), Size = new System.Drawing.Size(200, 40) };
            this.sidebar.Controls.AddRange(new System.Windows.Forms.Control[] { lblStore, lblOrders, lblCartNav, lblProfile, lblLogout });

            // Top Navbar
            this.topNavbar = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(this.ClientSize.Width - this.sidebar.Width, 60),
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(this.sidebar.Width, 0)
            };
            this.lblWelcome = new System.Windows.Forms.Label
            {
                Text = "Welcome, Guest", // Default to Guest
                Font = new System.Drawing.Font("Segoe UI", 12F),
                AutoSize = true,
                Location = new System.Drawing.Point((this.topNavbar.Width - 200) / 2, 20)
            };
            this.topNavbar.Controls.Add(this.lblWelcome);

            // Main Content
            this.lblTitle = new System.Windows.Forms.Label
            {
                Text = "Products",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(this.sidebar.Width + 20, 80),
                Size = new System.Drawing.Size(200, 50),
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 100)
            };

            this.lblCategory = new System.Windows.Forms.Label
            {
                Text = "Category",
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(this.sidebar.Width + 20, 160),
                Size = new System.Drawing.Size(200, 50)
            };

            // Cart Button
            this.btnCart = new System.Windows.Forms.Button
            {
                Text = "Cart",
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(59, 130, 246),
                ForeColor = System.Drawing.Color.White,
                Size = new System.Drawing.Size(100, 40),
                Location = new System.Drawing.Point(this.ClientSize.Width - 150, 80)
            };

            // Content Panel
            this.contentPanel = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(this.sidebar.Width + 20, 200),
                Size = new System.Drawing.Size(this.ClientSize.Width - this.sidebar.Width - 40, this.ClientSize.Height - 200),
                BackColor = System.Drawing.Color.Transparent,
                AutoScroll = true
            };

            // FlowLayoutPanel for Products
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = true
            };
            this.contentPanel.Controls.Add(this.flowLayoutPanel);

            // Add Controls
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.topNavbar);
            this.Controls.Add(this.sidebar);
        }
    }
}