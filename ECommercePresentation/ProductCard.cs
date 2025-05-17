using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECommercePresentation
{
    public partial class ProductCard : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ProductId { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ItemName { get; set; } // Renamed from ProductName to avoid conflict

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal Price { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image ProductImage { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event EventHandler<int> AddToCartClicked;

        public event EventHandler<int> CardClicked;

        public ProductCard()
        {
            InitializeComponent();
            this.Click += (s, e) => CardClicked?.Invoke(this, ProductId);
            foreach (Control control in this.Controls)
            {
                if (control != addToCartButton)
                {
                    control.Click += (s, e) => CardClicked?.Invoke(this, ProductId);
                }
            }

            // Add hover effects
            this.MouseEnter += (s, e) => this.BackColor = Color.FromArgb(245, 245, 245);
            this.MouseLeave += (s, e) => this.BackColor = Color.White;
        }
        public void UpdateCard(int productId, string name, string description, decimal price, Image image)
        {
            ProductId = productId;
            ItemName = name;
            Description = description;
            Price = price;
            ProductImage = image;

            pictureBox.Image = image;
            nameLabel.Text = name;
            descLabel.Text = description;
            priceLabel.Text = $"${price:F2}";
        }
    }
}