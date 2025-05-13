namespace ECommercePresentation
{
    partial class CartItemForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCart = new System.Windows.Forms.Label();
            this.lblCheckout = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlProductList = new System.Windows.Forms.Panel();
            this.tblProducts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlOrderSummary = new System.Windows.Forms.Panel();
            this.lblOrderSummary = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.lblVATValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnMakeOrder = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.LightGray;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1000, 50);
            this.pnlHeader.Controls.Add(this.lblCart);
            this.pnlHeader.Controls.Add(this.lblCheckout);
            this.pnlHeader.Controls.Add(this.lblOrder);

            // lblCart
            this.lblCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCart.Location = new System.Drawing.Point(50, 10);
            this.lblCart.Size = new System.Drawing.Size(100, 25);
            this.lblCart.Text = "Cart";

            // lblCheckout
            this.lblCheckout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheckout.Location = new System.Drawing.Point(200, 10);
            this.lblCheckout.Size = new System.Drawing.Size(100, 25);
            this.lblCheckout.Text = "Checkout";

            // lblOrder
            this.lblOrder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrder.Location = new System.Drawing.Point(350, 10);
            this.lblOrder.Size = new System.Drawing.Size(100, 25);
            this.lblOrder.Text = "Order";

            // tblMain
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblMain.Location = new System.Drawing.Point(0, 50);
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.Size = new System.Drawing.Size(1000, 600);
            this.tblMain.Controls.Add(this.pnlProductList, 0, 0);
            this.tblMain.Controls.Add(this.pnlOrderSummary, 1, 0);

            // pnlProductList
            this.pnlProductList.AutoScroll = true;
            this.pnlProductList.Size = new System.Drawing.Size(700, 600);
            this.pnlProductList.Controls.Add(this.tblProducts);

            // tblProducts
            this.tblProducts.AutoSize = true;
            this.tblProducts.ColumnCount = 1;
            this.tblProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblProducts.Location = new System.Drawing.Point(10, 10);
            this.tblProducts.Size = new System.Drawing.Size(680, 500);
            this.tblProducts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

            // pnlOrderSummary
            this.pnlOrderSummary.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.pnlOrderSummary.Size = new System.Drawing.Size(300, 600);
            this.pnlOrderSummary.Controls.Add(this.lblOrderSummary);
            this.pnlOrderSummary.Controls.Add(this.lblSubtotal);
            this.pnlOrderSummary.Controls.Add(this.lblSubtotalValue);
            this.pnlOrderSummary.Controls.Add(this.lblVAT);
            this.pnlOrderSummary.Controls.Add(this.lblVATValue);
            this.pnlOrderSummary.Controls.Add(this.lblTotal);
            this.pnlOrderSummary.Controls.Add(this.lblTotalValue);
            this.pnlOrderSummary.Controls.Add(this.btnCheckout);

            // lblOrderSummary
            this.lblOrderSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderSummary.ForeColor = System.Drawing.Color.White;
            this.lblOrderSummary.Location = new System.Drawing.Point(10, 10);
            this.lblOrderSummary.Size = new System.Drawing.Size(150, 25);
            this.lblOrderSummary.Text = "Order Summary";

            // lblSubtotal
            this.lblSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblSubtotal.Location = new System.Drawing.Point(10, 50);
            this.lblSubtotal.Size = new System.Drawing.Size(100, 25);
            this.lblSubtotal.Text = "Subtotal";

            // lblSubtotalValue
            this.lblSubtotalValue.ForeColor = System.Drawing.Color.White;
            this.lblSubtotalValue.Location = new System.Drawing.Point(200, 50);
            this.lblSubtotalValue.Size = new System.Drawing.Size(90, 25);
            this.lblSubtotalValue.Text = "$0.00";

            // lblVAT
            this.lblVAT.ForeColor = System.Drawing.Color.White;
            this.lblVAT.Location = new System.Drawing.Point(10, 80);
            this.lblVAT.Size = new System.Drawing.Size(100, 25);
            this.lblVAT.Text = "V.A.T";

            // lblVATValue
            this.lblVATValue.ForeColor = System.Drawing.Color.White;
            this.lblVATValue.Location = new System.Drawing.Point(200, 80);
            this.lblVATValue.Size = new System.Drawing.Size(90, 25);
            this.lblVATValue.Text = "$0.00";

            // lblTotal
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(10, 140);
            this.lblTotal.Size = new System.Drawing.Size(100, 25);
            this.lblTotal.Text = "Total";

            // lblTotalValue
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalValue.Location = new System.Drawing.Point(200, 140);
            this.lblTotalValue.Size = new System.Drawing.Size(90, 25);
            this.lblTotalValue.Text = "$0.00";

            // btnCheckout
            this.btnCheckout.BackColor = System.Drawing.Color.Yellow;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.Location = new System.Drawing.Point(50, 500);
            this.btnCheckout.Size = new System.Drawing.Size(200, 50);
            this.btnCheckout.Text = "Proceed to Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);

            // lblHelp
            this.lblHelp.Location = new System.Drawing.Point(10, 660);
            this.lblHelp.Size = new System.Drawing.Size(300, 20);
            this.lblHelp.Text = "Need help? Check our help and support or contact us";

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.LightGray;
            this.btnBack.Location = new System.Drawing.Point(10, 620);
            this.btnBack.Size = new System.Drawing.Size(150, 30);
            this.btnBack.Text = "← Go back to shopping";
            this.btnBack.UseVisualStyleBackColor = false;

            // txtSearchUser
            this.txtSearchUser.Location = new System.Drawing.Point(20, 20);
            this.txtSearchUser.Size = new System.Drawing.Size(300, 25);
            this.txtSearchUser.TextChanged += new System.EventHandler(this.TxtSearchUser_TextChanged);

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(120, 340);
            this.txtQuantity.Size = new System.Drawing.Size(200, 25);

            // btnCreate
            this.btnCreate.Location = new System.Drawing.Point(20, 390);
            this.btnCreate.Size = new System.Drawing.Size(100, 35);
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(130, 390);
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(240, 390);
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(350, 390);
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // btnMakeOrder
            this.btnMakeOrder.Location = new System.Drawing.Point(460, 390);
            this.btnMakeOrder.Size = new System.Drawing.Size(100, 35);
            this.btnMakeOrder.Text = "Make Order";
            this.btnMakeOrder.UseVisualStyleBackColor = true;
            this.btnMakeOrder.Click += new System.EventHandler(this.BtnMakeOrder_Click);

            // lblQuantity
            this.lblQuantity.Location = new System.Drawing.Point(20, 340);
            this.lblQuantity.Size = new System.Drawing.Size(100, 25);
            this.lblQuantity.Text = "Quantity:";

            // CartItemForm
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtSearchUser);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMakeOrder);
            this.Controls.Add(this.lblQuantity);
            this.Text = "Cart Item Management";
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Label lblCheckout;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnlProductList;
        protected System.Windows.Forms.TableLayoutPanel tblProducts;
        private System.Windows.Forms.Panel pnlOrderSummary;
        protected System.Windows.Forms.Label lblOrderSummary;
        protected System.Windows.Forms.Label lblSubtotal;
        protected System.Windows.Forms.Label lblSubtotalValue;
        protected System.Windows.Forms.Label lblVAT;
        protected System.Windows.Forms.Label lblVATValue;
        protected System.Windows.Forms.Label lblTotal;
        protected System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMakeOrder;
        private System.Windows.Forms.Label lblQuantity;
    }
}