namespace ECommercePresentation
{
    partial class Base
    {
        private System.ComponentModel.IContainer components = null;
        private Panel navBar;
        private Panel contentPanel;
        private Panel productPanelContainer;

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
            this.SuspendLayout();

            // Form settings
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.MinimizeBox = false; // Disable minimize button
            this.BackColor = ColorTranslator.FromHtml("#F5F7FB");
            this.Size = Screen.PrimaryScreen.WorkingArea.Size; // Full width and height, respecting taskbar
            this.Location = Screen.PrimaryScreen.WorkingArea.Location; // Position at top-left of working area

            // Left Sidebar
            Panel sidebarPanel = new Panel
            {
                BackColor = ColorTranslator.FromHtml("#2C3E50"),
                Dock = DockStyle.Left,
                Width = 220
            };

            // Logo
            Label logoLabel = new Label
            {
                Text = "HYPER",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            sidebarPanel.Controls.Add(logoLabel);

            // Navigation Section
            Label navLabel = new Label
            {
                Text = "NAVIGATION",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 70),
                AutoSize = true
            };
            sidebarPanel.Controls.Add(navLabel);

            // Sidebar Buttons
            Button dashboardButton = CreateSidebarButton("Dashboards", new Point(20, 100), new EventHandler(ShowDashboardPanel));
            dashboardButton.Controls.Add(new Label
            {
                Text = "3",
                ForeColor = Color.White,
                BackColor = Color.Green,
                Font = new Font("Segoe UI", 8F),
                Location = new Point(140, 5),
                Size = new Size(20, 20),
                TextAlign = ContentAlignment.MiddleCenter
            });
            sidebarPanel.Controls.Add(dashboardButton);
            sidebarPanel.Controls.Add(CreateSidebarButton("Products", new Point(20, 140), ProductButton_Click));
            sidebarPanel.Controls.Add(CreateSidebarButton("Categories", new Point(20, 180), CategoriesButton_Click));
            sidebarPanel.Controls.Add(CreateSidebarButton("Orders", new Point(20, 220), OrderButton_Click));
            sidebarPanel.Controls.Add(CreateSidebarButton("Users", new Point(20, 260), BtnUsers_Click));

            // Settings Section
            Label settingsLabel = new Label
            {
                Text = "SETTINGS",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 320),
                AutoSize = true
            };
            sidebarPanel.Controls.Add(settingsLabel);

            sidebarPanel.Controls.Add(CreateSidebarButton("Profile", new Point(20, 350), ProfileButton_Click));
            sidebarPanel.Controls.Add(CreateSidebarButton("Log Out", new Point(20, 390), LogOutButton_Click));

            // Top Bar
            Panel topBar = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Height = 60
            };

            Label welcomeLabel = new Label
            {
                Text = "Welcome, Dominic Keller",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            topBar.Controls.Add(welcomeLabel);

            // Main Content Panel
            contentPanel = new Panel
            {
                Location = new Point(220, 60),
                Size = new Size(this.ClientSize.Width - 220, this.ClientSize.Height - 60),
                BackColor = ColorTranslator.FromHtml("#F5F7FB")
            };

            // Dashboard Panel (Default View)
            dashboardPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#F5F7FB")
            };

            Label dashboardTitle = new Label
            {
                Text = "DASHBOARD",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            dashboardPanel.Controls.Add(dashboardTitle);

            DateTimePicker datePicker = new DateTimePicker
            {
                Location = new Point(contentPanel.Width - 220, 20),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 10F)
            };
            dashboardPanel.Controls.Add(datePicker);

            // Summary Cards Panel
            summaryCardsPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 70),
                Size = new Size(contentPanel.Width - 40, 200),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                BackColor = Color.White
            };

            Panel clientsCard = CreateSummaryCard("Clients", "36,254", "+5.27%", new Point(10, 20));
            Panel ordersCard = CreateSummaryCard("Orders", "5,543", "+1.08%", new Point(0, 0));
            Panel productsCard = CreateSummaryCard("Products", "$6,254", "-7.00%", new Point(0, 0));
            Panel categoriesCard = CreateSummaryCard("Categories", "+30.56%", "+4.87%", new Point(0, 0));
            summaryCardsPanel.Controls.Add(clientsCard);
            summaryCardsPanel.Controls.Add(ordersCard);
            summaryCardsPanel.Controls.Add(productsCard);
            summaryCardsPanel.Controls.Add(categoriesCard);
            dashboardPanel.Controls.Add(summaryCardsPanel);

            // Revenue Section
            Label revenueLabel = new Label
            {
                Text = "REVENUE",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 280),
                AutoSize = true
            };
            dashboardPanel.Controls.Add(revenueLabel);

            Label currentWeekLabel = new Label
            {
                Text = "Current Week: $58,254",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 310),
                AutoSize = true
            };
            dashboardPanel.Controls.Add(currentWeekLabel);

            Label previousWeekLabel = new Label
            {
                Text = "Previous Week: $69,524",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(220, 310),
                AutoSize = true
            };
            dashboardPanel.Controls.Add(previousWeekLabel);

            // Product Panel Container
            productPanelContainer = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            productPanelContainer.Controls.Add(new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(10)
            });

            contentPanel.Controls.Add(dashboardPanel);

            // Add controls to form
            this.Controls.Add(contentPanel);
            this.Controls.Add(topBar);
            this.Controls.Add(sidebarPanel);

            this.Name = "Base";
            this.Text = "E-Commerce Dashboard";
            this.ResumeLayout(false);
        }

        private Button CreateSidebarButton(string text, Point location, EventHandler clickEvent)
        {
            Button button = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(180, 30),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            button.MouseEnter += (s, e) => button.BackColor = ColorTranslator.FromHtml("#34495E");
            button.MouseLeave += (s, e) => button.BackColor = Color.Transparent;
            if (clickEvent != null)
            {
                button.Click += clickEvent;
            }
            return button;
        }

        private Button CreateIconButton(string text, Point location)
        {
            Button button = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(30, 30),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.Transparent,
                ForeColor = Color.Gray
            };
            button.FlatAppearance.BorderSize = 0;
            button.MouseEnter += (s, e) => button.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            button.MouseLeave += (s, e) => button.BackColor = Color.Transparent;
            return button;
        }

        private Panel CreateSummaryCard(string title, string value, string change, Point location)
        {
            Panel card = new Panel
            {
                Location = location,
                Size = new Size(220, 100),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Margin = new Padding(10)
            };
            card.MouseEnter += (s, e) => card.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 20),
                AutoSize = true
            };
            card.Controls.Add(titleLabel);

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(20, 40),
                AutoSize = true
            };
            card.Controls.Add(valueLabel);

            Label changeLabel = new Label
            {
                Text = change,
                Font = new Font("Segoe UI", 9F),
                ForeColor = change.StartsWith("+") ? Color.Green : Color.Red,
                Location = new Point(20, 70),
                AutoSize = true
            };
            card.Controls.Add(changeLabel);

            return card;
        }
    }
}