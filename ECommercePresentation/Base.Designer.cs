namespace ECommercePresentation
{
    partial class Base
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel navBar;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.PictureBox userProfile;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button shoppingCart;
        private System.Windows.Forms.FlowLayoutPanel productPanel;

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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // contentPanel
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(177, 59);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1070, 570);
            this.contentPanel.TabIndex = 0;
            this.contentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.contentPanel_Paint);

            // Add FlowLayoutPanel for products
            productPanel = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new System.Windows.Forms.Padding(10)
            };
            contentPanel.Controls.Add(productPanel);

            // Navigation Panel
            System.Windows.Forms.Panel navPanel = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.SystemColors.ButtonFace,
                Dock = System.Windows.Forms.DockStyle.Left,
                Width = 177
            };

            // Logo
            System.Windows.Forms.PictureBox logo = new System.Windows.Forms.PictureBox
            {
                Image = Properties.Resources.logo1, // Replace with your logo path
                Size = new System.Drawing.Size(177, 59),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            };
            navPanel.Controls.Add(logo);

            // Navigation Buttons
            navPanel.Controls.Add(CreateNavButton("Products", new System.Drawing.Point(0, 125), ProductButton_Click));
            navPanel.Controls.Add(CreateNavButton("Categories", new System.Drawing.Point(0, 181), CategoriesButton_Click));
            navPanel.Controls.Add(CreateNavButton("Cart", new System.Drawing.Point(0, 243), CartItemButton_Click));
            navPanel.Controls.Add(CreateNavButton("Order", new System.Drawing.Point(0, 319), OrderButton_Click));
            navPanel.Controls.Add(CreateNavButton("Profile", new System.Drawing.Point(0, 432), ProfileButton_Click));
            navPanel.Controls.Add(CreateNavButton("Users", new System.Drawing.Point(0, 375), BtnUsers_Click));
            navPanel.Controls.Add(CreateNavButton("Setting", new System.Drawing.Point(0, 506), null));
            navPanel.Controls.Add(CreateNavButton("Logout", new System.Drawing.Point(0, 603), LogOutButton_Click));

            // Search Panel
            System.Windows.Forms.Panel searchPanel = new System.Windows.Forms.Panel
            {
                Dock = System.Windows.Forms.DockStyle.Top,
                Size = new System.Drawing.Size(1070, 59)
            };

            searchBox = new System.Windows.Forms.TextBox
            {
                Location = new System.Drawing.Point(78, 12),
                Size = new System.Drawing.Size(417, 27)
            };
            searchPanel.Controls.Add(searchBox);

            searchButton = new System.Windows.Forms.Button
            {
                Text = "Search",
                Location = new System.Drawing.Point(500, 12),
                Size = new System.Drawing.Size(77, 27)
            };
            searchPanel.Controls.Add(searchButton);

            // Footer Panel
            footerPanel = new System.Windows.Forms.Panel
            {
                Dock = System.Windows.Forms.DockStyle.Bottom,
                Height = 30,
                BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
            };

            System.Windows.Forms.Label footerLabel = new System.Windows.Forms.Label
            {
                Text = "© 2023 Your Brand. All rights reserved.",
                ForeColor = System.Drawing.Color.White,
                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };
            footerPanel.Controls.Add(footerLabel);

            // Main Form
            this.ClientSize = new System.Drawing.Size(1247, 659);
            this.Controls.Add(contentPanel);
            this.Controls.Add(searchPanel);
            this.Controls.Add(navPanel);
            this.Controls.Add(footerPanel);
            this.Name = "Base";
            this.Text = "E-Commerce Application";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button CreateNavButton(string text, System.Drawing.Point location, EventHandler clickEvent)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button
            {
                Text = text,
                Location = location,
                Size = new System.Drawing.Size(177, 35),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Century Gothic", 10.2F),
                ForeColor = System.Drawing.SystemColors.ControlDarkDark,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            if (clickEvent != null)
            {
                button.Click += clickEvent;
            }
            return button;
        }
    }
}