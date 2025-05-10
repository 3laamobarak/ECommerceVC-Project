namespace ECommercePresentation
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            sidebarPanel = new Panel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            btnUsers = new Button();
            btnCart = new Button();
            btnCategories = new Button();
            btnOrders = new Button();
            btnProducts = new Button();
            productPanel = new FlowLayoutPanel();
            LogOutBtn = new Button();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(233, 236, 239);
            sidebarPanel.Controls.Add(LogOutBtn);
            sidebarPanel.Controls.Add(button1);
            sidebarPanel.Controls.Add(pictureBox1);
            sidebarPanel.Controls.Add(btnUsers);
            sidebarPanel.Controls.Add(btnCart);
            sidebarPanel.Controls.Add(btnCategories);
            sidebarPanel.Controls.Add(btnOrders);
            sidebarPanel.Controls.Add(btnProducts);
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Margin = new Padding(4, 5, 4, 5);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(267, 923);
            sidebarPanel.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 123, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(27, 434);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(213, 54);
            button1.TabIndex = 6;
            button1.Text = "Profile";
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(27, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(204, 166);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.FromArgb(0, 123, 255);
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 10F);
            btnUsers.ForeColor = Color.White;
            btnUsers.Location = new Point(27, 644);
            btnUsers.Margin = new Padding(4, 5, 4, 5);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(213, 54);
            btnUsers.TabIndex = 4;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += BtnUsers_Click;
            // 
            // btnCart
            // 
            btnCart.BackColor = Color.FromArgb(0, 123, 255);
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Font = new Font("Segoe UI", 10F);
            btnCart.ForeColor = Color.White;
            btnCart.Location = new Point(27, 574);
            btnCart.Margin = new Padding(4, 5, 4, 5);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(213, 54);
            btnCart.TabIndex = 3;
            btnCart.Text = "Cart";
            btnCart.UseVisualStyleBackColor = false;
            btnCart.Click += BtnCart_Click;
            // 
            // btnCategories
            // 
            btnCategories.BackColor = Color.FromArgb(0, 123, 255);
            btnCategories.FlatAppearance.BorderSize = 0;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Segoe UI", 10F);
            btnCategories.ForeColor = Color.White;
            btnCategories.Location = new Point(27, 505);
            btnCategories.Margin = new Padding(4, 5, 4, 5);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(213, 54);
            btnCategories.TabIndex = 2;
            btnCategories.Text = "Categories";
            btnCategories.UseVisualStyleBackColor = false;
            btnCategories.Click += BtnCategories_Click;
            // 
            // btnOrders
            // 
            btnOrders.BackColor = Color.FromArgb(0, 123, 255);
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 10F);
            btnOrders.ForeColor = Color.White;
            btnOrders.Location = new Point(27, 436);
            btnOrders.Margin = new Padding(4, 5, 4, 5);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(213, 54);
            btnOrders.TabIndex = 1;
            btnOrders.Text = "Orders";
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += BtnOrders_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(0, 123, 255);
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 10F);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(27, 367);
            btnProducts.Margin = new Padding(4, 5, 4, 5);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(213, 54);
            btnProducts.TabIndex = 0;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += BtnProducts_Click;
            // 
            // productPanel
            // 
            productPanel.AutoScroll = true;
            productPanel.BackColor = Color.White;
            productPanel.Location = new Point(280, 31);
            productPanel.Margin = new Padding(4, 5, 4, 5);
            productPanel.Name = "productPanel";
            productPanel.Size = new Size(893, 862);
            productPanel.TabIndex = 5;
            // 
            // LogOutBtn
            // 
            LogOutBtn.BackColor = Color.Black;
            LogOutBtn.FlatAppearance.BorderSize = 0;
            LogOutBtn.FlatStyle = FlatStyle.Flat;
            LogOutBtn.Font = new Font("Segoe UI", 10F);
            LogOutBtn.ForeColor = Color.White;
            LogOutBtn.Location = new Point(55, 798);
            LogOutBtn.Margin = new Padding(4, 5, 4, 5);
            LogOutBtn.Name = "LogOutBtn";
            LogOutBtn.Size = new Size(154, 46);
            LogOutBtn.TabIndex = 7;
            LogOutBtn.Text = "Log Out";
            LogOutBtn.UseVisualStyleBackColor = false;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1200, 923);
            Controls.Add(productPanel);
            Controls.Add(sidebarPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "BaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "E-Commerce Dashboard";
            sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private PictureBox pictureBox1;
        private Button button1;
        private Button LogOutBtn;
    }
}