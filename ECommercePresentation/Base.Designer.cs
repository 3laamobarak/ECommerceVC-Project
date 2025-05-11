using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECommercePresentation
{
    partial class Base
    {
        private Panel navBar;
        private Panel contentPanel;
        private Panel footerPanel;
        private TextBox searchBox;
        private Button searchButton;
        private PictureBox userProfile;
        private Label userName;
        private Button shoppingCart;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(177, 59); // Adjust based on your layout
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1070, 570); // Adjust based on your layout
            this.contentPanel.TabIndex = 0;
            this.contentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.contentPanel_Paint);
            // 
            // Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Name = "Base";
            this.Text = "E-Commerce Application";
            this.ResumeLayout(false);

            // Navigation Panel
            Panel navPanel = new Panel
            {
                BackColor = SystemColors.ButtonFace,
                Dock = DockStyle.Left,
                Width = 177
            };

            // Logo
            PictureBox logo = new PictureBox
            {
                Image = Properties.Resources.logo1, // Replace with your logo path
                Size = new Size(177, 59),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            navPanel.Controls.Add(logo);

            // Navigation Buttons
            navPanel.Controls.Add(CreateNavButton("Products", new Point(0, 125), ProductButton_Click));
            navPanel.Controls.Add(CreateNavButton("Categories", new Point(0, 181), CategoriesButton_Click));
            navPanel.Controls.Add(CreateNavButton("Cart", new Point(0, 243), CartItemButton_Click));
            navPanel.Controls.Add(CreateNavButton("Order", new Point(0, 319), OrderButton_Click));
            navPanel.Controls.Add(CreateNavButton("Profile", new Point(0, 432), ProfileButton_Click));
            navPanel.Controls.Add(CreateNavButton("Users", new Point(0, 375), BtnUsers_Click));
            navPanel.Controls.Add(CreateNavButton("Setting", new Point(0, 506), null));
            navPanel.Controls.Add(CreateNavButton("Logout", new Point(0, 603),LogOutButton_Click));

            // Search Panel
            Panel searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Size = new Size(1070, 59)
            };

            searchBox = new TextBox
            {
                Location = new Point(78, 12),
                Size = new Size(417, 27)
            };
            searchPanel.Controls.Add(searchBox);

            searchButton = new Button
            {
                Text = "Search",
                Location = new Point(500, 12),
                Size = new Size(77, 27)
            };
            searchPanel.Controls.Add(searchButton);

            // Footer Panel
            footerPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.FromArgb(45, 45, 48)
            };

            Label footerLabel = new Label
            {
                Text = "© 2023 Your Brand. All rights reserved.",
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F)
            };
            footerPanel.Controls.Add(footerLabel);

            // Main Form
            this.ClientSize = new Size(1247, 659);
            this.Controls.Add(searchPanel);
            this.Controls.Add(navPanel);
            this.Controls.Add(footerPanel);
        }

        private Button CreateNavButton(string text, Point location, EventHandler clickEvent)
        {
            Button button = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(177, 35),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Century Gothic", 10.2F),
                ForeColor = SystemColors.ControlDarkDark,
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            if (clickEvent != null)
            {
                button.Click += clickEvent;
            }
            return button;
        }
        #endregion
    }
}