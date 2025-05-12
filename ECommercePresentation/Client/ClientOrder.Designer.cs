namespace ECommercePresentation
{
    partial class ClientOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            gridOrders = new DataGridView();
            productListPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)gridOrders).BeginInit();
            SuspendLayout();
            // 
            // gridOrders
            // 
            gridOrders.AllowUserToAddRows = false;
            gridOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridOrders.BackgroundColor = Color.White;
            gridOrders.BorderStyle = BorderStyle.None;
            gridOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOrders.Location = new Point(27, 31);
            gridOrders.Margin = new Padding(4, 5, 4, 5);
            gridOrders.Name = "gridOrders";
            gridOrders.ReadOnly = true;
            gridOrders.RowHeadersVisible = false;
            gridOrders.RowHeadersWidth = 51;
            gridOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOrders.Size = new Size(1133, 300); // Reduced height to make space for product list
            gridOrders.TabIndex = 0;
            gridOrders.SelectionChanged += GridOrders_SelectionChanged;
            // 
            // productListPanel
            // 
            productListPanel.AutoScroll = true;
            productListPanel.BackColor = Color.FromArgb(248, 249, 250);
            productListPanel.Location = new Point(27, 350);
            productListPanel.Name = "productListPanel";
            productListPanel.Size = new Size(1133, 550);
            productListPanel.TabIndex = 1;
            // 
            // ClientOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1200, 923);
            Controls.Add(productListPanel);
            Controls.Add(gridOrders);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "ClientOrder";
            Text = "Client Order Management";
            ((System.ComponentModel.ISupportInitialize)gridOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView gridOrders;
        private System.Windows.Forms.FlowLayoutPanel productListPanel;
    }
}