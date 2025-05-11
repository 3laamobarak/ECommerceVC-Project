using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECommercePresentation
{
    partial class ProductCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private PictureBox pictureBox;
        private Label nameLabel;
        private Label descLabel;
        private Label priceLabel;
        private Button addToCartButton;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.Size = new Size(200, 300);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(5);

            // PictureBox for product image
            pictureBox = new PictureBox
            {
                Size = new Size(190, 150),
                Location = new Point(5, 5),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(pictureBox);

            // Label for product name
            nameLabel = new Label
            {
                Text = "Product Name",
                Location = new Point(5, 160),
                Size = new Size(190, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            this.Controls.Add(nameLabel);

            // Label for description
            descLabel = new Label
            {
                Text = "Description",
                Location = new Point(5, 185),
                Size = new Size(190, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8F)
            };
            this.Controls.Add(descLabel);

            // Label for price
            priceLabel = new Label
            {
                Text = "$0.00",
                Location = new Point(5, 230),
                Size = new Size(190, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            this.Controls.Add(priceLabel);

            // Add to Cart button
            addToCartButton = new Button
            {
                Text = "Add to Cart",
                Location = new Point(5, 255),
                Size = new Size(190, 35),
                BackColor = Color.FromArgb(3, 105, 161),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            addToCartButton.Click += (s, e) => AddToCartClicked?.Invoke(this, ProductId);
            this.Controls.Add(addToCartButton);
        }

        #endregion
    }
}