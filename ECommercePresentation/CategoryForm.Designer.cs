namespace ECommercePresentation;

partial class CategoryForm
{
    private System.ComponentModel.IContainer components = null;

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
            this.Text = "Category Management";
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.BackColor = Color.White;

            // Navigation Bar
            Panel navBar = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1000, 60),
                BackColor = Color.MidnightBlue,
                ForeColor = Color.White
            };

            // Navigation Buttons
            Button[] navButtons = new Button[]
            {
                new Button { Text = "Home", Location = new Point(10, 10) },
                new Button { Text = "Resume", Location = new Point(90, 10) },
                new Button { Text = "Projects", Location = new Point(170, 10) },
                new Button { Text = "Contact", Location = new Point(260, 10) },
                new Button { Text = "Logout", Location = new Point(350, 10) }
            };

            navBar.Controls.AddRange(navButtons);

            // Title Label
            Label titleLabel = new Label
            {
                Text = "Manage Categories",
                Location = new Point(20, 70),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                AutoSize = true
            };

            // Add Category Button
            Button addCategoryButton = new Button
            {
                Text = "Add Category",
                Location = new Point(900, 70),
                Size = new Size(80, 30),
                BackColor = Color.MidnightBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // DataGridView for Categories
            DataGridView categoryGridView = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(950, 500),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
//                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.SingleLine,
//                GridLinesBorderStyle = DataGridViewBorderStyle.None,
                RowHeadersVisible = false
            };

            categoryGridView.Columns.Add("colCategoryID", "CategoryID");
            categoryGridView.Columns.Add("colName", "Name");
            categoryGridView.Columns.Add("colDescription", "Description");
            categoryGridView.Columns.Add("colActions", "");

            // Add DataGridView buttons column
            DataGridViewButtonColumn actionsColumn = new DataGridViewButtonColumn
            {
                Name = "colActions",
                Text = "",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            categoryGridView.Columns.Add(actionsColumn);

            // Style DataGridView
            categoryGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            categoryGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            categoryGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Add controls to the form
            this.Controls.Add(navBar);
            this.Controls.Add(titleLabel);
            this.Controls.Add(addCategoryButton);
            this.Controls.Add(categoryGridView);
        }
}