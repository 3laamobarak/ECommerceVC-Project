namespace ECommercePresentation;

partial class CategoryForm
{
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
        label1 = new Label();
        Save = new Button();
        Cancel = new Button();
        textBox1 = new TextBox();
        label2 = new Label();
        textBox2 = new TextBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(61, 103);
        label1.Name = "label1";
        label1.Size = new Size(136, 25);
        label1.TabIndex = 0;
        label1.Text = "Category Name";
        label1.Click += label1_Click;
        // 
        // Save
        // 
        Save.BackColor = SystemColors.MenuHighlight;
        Save.ForeColor = SystemColors.ButtonHighlight;
        Save.Location = new Point(350, 293);
        Save.Name = "Save";
        Save.Size = new Size(112, 48);
        Save.TabIndex = 1;
        Save.Text = "Save";
        Save.UseVisualStyleBackColor = false;
        //Save.Click += btnSave_Click;
        // 
        // Cancel
        // 
        Cancel.BackColor = SystemColors.ControlLight;
        Cancel.ForeColor = SystemColors.MenuHighlight;
        Cancel.Location = new Point(542, 293);
        Cancel.Name = "Cancel";
        Cancel.Size = new Size(112, 48);
        Cancel.TabIndex = 2;
        Cancel.Text = "Cancel";
        Cancel.UseVisualStyleBackColor = false;
        //Cancel.Click += btnCancel_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(275, 100);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(501, 31);
        textBox1.TabIndex = 3;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(61, 202);
        label2.Name = "label2";
        label2.Size = new Size(184, 25);
        label2.TabIndex = 4;
        label2.Text = "Category Description ";
        // 
        // textBox2
        // 
        textBox2.Location = new Point(275, 196);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(501, 31);
        textBox2.TabIndex = 5;
        // 
        // EntityCategory
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.GradientActiveCaption;
        ClientSize = new Size(849, 450);
        Controls.Add(textBox2);
        Controls.Add(label2);
        Controls.Add(textBox1);
        Controls.Add(Cancel);
        Controls.Add(Save);
        Controls.Add(label1);
        ForeColor = SystemColors.Highlight;
        Name = "EntityCategory";
        Text = "EntityCategory";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Button Save;
    private Button Cancel;
    private TextBox textBox1;
    private Label label2;
    private TextBox textBox2;
}