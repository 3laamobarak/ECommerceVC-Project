using System.ComponentModel;

namespace ECommercePresentation;

partial class Base
{
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
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1000, 700);
        this.Text = "Base";

        // Navigation Bar
        Panel navBar = new Panel
        {
            Location = new Point(0, 0),
            Size = new Size(1000, 60),
            BackColor = Color.LightGray
        };

        Button homeButton = new Button
        {
            Text = "Home",
            Location = new Point(10, 15),
            Size = new Size(80, 30),
            BackColor = Color.White,
            ForeColor = Color.Black,
            FlatStyle = FlatStyle.Flat
        };
        homeButton.FlatAppearance.BorderSize = 0;

        Button logoutButton = new Button
        {
            Text = "Logout",
            Location = new Point(900, 15),
            Size = new Size(80, 30),
            BackColor = Color.Crimson,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        logoutButton.FlatAppearance.BorderSize = 0;

        navBar.Controls.Add(homeButton);
        navBar.Controls.Add(logoutButton);
        // add category section
        Button categoryButton = new Button
        {
            Text = "Categories",
            Location = new Point(100, 15),
            Size = new Size(80, 30),
            BackColor = Color.White,
            ForeColor = Color.Black,
            FlatStyle = FlatStyle.Flat
        };
        categoryButton.FlatAppearance.BorderSize = 0;
        navBar.Controls.Add(categoryButton);
        // how to make it refer to the category form
        categoryButton.Click += (sender, e) =>
        {
            // Open the CategoryForm
            Form1 categoryForm = new Form1();
            categoryForm.Show();
        };

        // Content Panel
        Panel contentPanel = new Panel
        {
            Location = new Point(0, 60),
            Size = new Size(1000, 640),
            BackColor = Color.White
        };

        // Add controls to the form
        this.Controls.Add(navBar);
        this.Controls.Add(contentPanel);
    }
    #endregion
}