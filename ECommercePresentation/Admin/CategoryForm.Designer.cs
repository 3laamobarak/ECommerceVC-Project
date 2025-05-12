namespace ECommercePresentation
{
    partial class CategoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolTip toolTip;

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
            components = new System.ComponentModel.Container();
            toolTip = new ToolTip(components);
            flowLayoutPanelButtons = new FlowLayoutPanel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtName = new TextBox();
            lblName = new Label();
            gridCategories = new DataGridView();
            tableLayoutPanel = new TableLayoutPanel();
            flowLayoutPanelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCategories).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.Controls.Add(btnCreate);
            flowLayoutPanelButtons.Controls.Add(btnUpdate);
            flowLayoutPanelButtons.Controls.Add(btnDelete);
            flowLayoutPanelButtons.Controls.Add(btnClear);
            flowLayoutPanelButtons.Location = new Point(172, 667);
            flowLayoutPanelButtons.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new Size(564, 64);
            flowLayoutPanelButtons.TabIndex = 5;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(52, 58, 64);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(427, 5);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(133, 54);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            toolTip.SetToolTip(btnClear, "Clear all input fields and selection");
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(286, 5);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(133, 54);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            toolTip.SetToolTip(btnDelete, "Delete the selected category (cannot delete if products are associated)");
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(40, 167, 69);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(145, 5);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(133, 54);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            toolTip.SetToolTip(btnUpdate, "Update the selected category");
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(0, 123, 255);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(4, 5);
            btnCreate.Margin = new Padding(4, 5, 4, 5);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(133, 54);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Create";
            toolTip.SetToolTip(btnCreate, "Create a new category");
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += BtnCreate_Click;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(172, 602);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(399, 30);
            txtDescription.TabIndex = 4;
            toolTip.SetToolTip(txtDescription, "Enter an optional description for the category (max 500 characters)");
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescription.Location = new Point(17, 597);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(107, 23);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(172, 540);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(399, 30);
            txtName.TabIndex = 2;
            toolTip.SetToolTip(txtName, "Enter the category name (letters, numbers, spaces, hyphens, ampersands only)");
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.Location = new Point(17, 535);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(62, 23);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // gridCategories
            // 
            gridCategories.AllowUserToAddRows = false;
            gridCategories.BackgroundColor = Color.White;
            gridCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel.SetColumnSpan(gridCategories, 2);
            gridCategories.GridColor = Color.FromArgb(233, 236, 239);
            gridCategories.Location = new Point(17, 20);
            gridCategories.Margin = new Padding(4, 5, 4, 5);
            gridCategories.Name = "gridCategories";
            gridCategories.ReadOnly = true;
            gridCategories.RowHeadersVisible = false;
            gridCategories.RowHeadersWidth = 51;
            gridCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCategories.Size = new Size(1133, 462);
            gridCategories.TabIndex = 0;
            toolTip.SetToolTip(gridCategories, "Select a category to edit or delete");
            gridCategories.SelectionChanged += GridCategories_SelectionChanged;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5017424F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.49826F));
            tableLayoutPanel.Controls.Add(gridCategories, 0, 0);
            tableLayoutPanel.Controls.Add(lblName, 0, 1);
            tableLayoutPanel.Controls.Add(txtName, 1, 1);
            tableLayoutPanel.Controls.Add(lblDescription, 0, 2);
            tableLayoutPanel.Controls.Add(txtDescription, 1, 2);
            tableLayoutPanel.Controls.Add(flowLayoutPanelButtons, 1, 3);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(13, 15);
            tableLayoutPanel.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(13, 15, 13, 15);
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 216F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1174, 893);
            tableLayoutPanel.TabIndex = 0;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1200, 923);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "CategoryForm";
            Padding = new Padding(13, 15, 13, 15);
            Text = "Category Management";
            flowLayoutPanelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridCategories).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtName;
        private Label lblName;
        private DataGridView gridCategories;
        private TableLayoutPanel tableLayoutPanel;
    }
}