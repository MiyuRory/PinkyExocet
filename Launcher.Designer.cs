namespace PinkyExocet;

partial class Launcher
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
        label1 = new Label();
        label2 = new Label();
        txtUser = new TextBox();
        txtPass = new TextBox();
        flagDobleFactor = new CheckBox();
        btnStart = new Button();
        txtListas = new RichTextBox();
        label3 = new Label();
        txtUsersToBlock = new RichTextBox();
        label4 = new Label();
        btnDetener = new Button();
        fotito = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)fotito).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Padding = new Padding(10);
        label1.Size = new Size(70, 35);
        label1.TabIndex = 0;
        label1.Text = "Usuario:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 44);
        label2.Name = "label2";
        label2.Padding = new Padding(10);
        label2.Size = new Size(80, 35);
        label2.TabIndex = 1;
        label2.Text = "Password:";
        // 
        // txtUser
        // 
        txtUser.Location = new Point(97, 16);
        txtUser.Name = "txtUser";
        txtUser.Size = new Size(272, 23);
        txtUser.TabIndex = 2;
        // 
        // txtPass
        // 
        txtPass.Location = new Point(98, 50);
        txtPass.Name = "txtPass";
        txtPass.PasswordChar = '*';
        txtPass.Size = new Size(272, 23);
        txtPass.TabIndex = 3;
        // 
        // flagDobleFactor
        // 
        flagDobleFactor.AutoSize = true;
        flagDobleFactor.Location = new Point(97, 88);
        flagDobleFactor.Name = "flagDobleFactor";
        flagDobleFactor.Size = new Size(91, 19);
        flagDobleFactor.TabIndex = 4;
        flagDobleFactor.Text = "Doble factor";
        flagDobleFactor.UseVisualStyleBackColor = true;
        // 
        // btnStart
        // 
        btnStart.Location = new Point(235, 88);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(135, 23);
        btnStart.TabIndex = 5;
        btnStart.Text = "Iniciar";
        btnStart.UseVisualStyleBackColor = true;
        btnStart.Click += btnStart_Click;
        // 
        // txtListas
        // 
        txtListas.Location = new Point(12, 129);
        txtListas.Name = "txtListas";
        txtListas.Size = new Size(358, 81);
        txtListas.TabIndex = 6;
        txtListas.Text = "https://raw.githubusercontent.com/pablofp92/Datasets/main/blocklist.json";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 213);
        label3.MaximumSize = new Size(350, 0);
        label3.Name = "label3";
        label3.Size = new Size(332, 30);
        label3.TabIndex = 7;
        label3.Text = "Aca pueden pegar listas como la de pablofp92, en ese mismo formato, separadas por saltos de línea.";
        // 
        // txtUsersToBlock
        // 
        txtUsersToBlock.Location = new Point(12, 267);
        txtUsersToBlock.Name = "txtUsersToBlock";
        txtUsersToBlock.Size = new Size(357, 67);
        txtUsersToBlock.TabIndex = 8;
        txtUsersToBlock.Text = "@DiegoMac227\n@MiltonFriedom5\n@AgustinLaje\n@Felii_N\n@javierlanari";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 337);
        label4.MaximumSize = new Size(350, 0);
        label4.Name = "label4";
        label4.Size = new Size(299, 15);
        label4.TabIndex = 9;
        label4.Text = "Aca pueden pegar arrobas separados por saltos de línea";
        // 
        // btnDetener
        // 
        btnDetener.Location = new Point(235, 88);
        btnDetener.Name = "btnDetener";
        btnDetener.Size = new Size(135, 23);
        btnDetener.TabIndex = 10;
        btnDetener.Text = "Detener";
        btnDetener.UseVisualStyleBackColor = true;
        btnDetener.Visible = false;
        btnDetener.Click += btnDetener_Click;
        // 
        // fotito
        // 
        fotito.Image = Properties.Resources.GKIVoRmWoAAeRXi;
        fotito.Location = new Point(122, 365);
        fotito.Name = "fotito";
        fotito.Size = new Size(126, 84);
        fotito.SizeMode = PictureBoxSizeMode.StretchImage;
        fotito.TabIndex = 11;
        fotito.TabStop = false;
        fotito.Click += fotito_Click;
        // 
        // Launcher
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(255, 192, 255);
        ClientSize = new Size(385, 453);
        Controls.Add(fotito);
        Controls.Add(btnDetener);
        Controls.Add(label4);
        Controls.Add(txtUsersToBlock);
        Controls.Add(label3);
        Controls.Add(txtListas);
        Controls.Add(btnStart);
        Controls.Add(flagDobleFactor);
        Controls.Add(txtPass);
        Controls.Add(txtUser);
        Controls.Add(label2);
        Controls.Add(label1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Launcher";
        Text = "PinkyExocet Launcher by @miyurory";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)fotito).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private TextBox txtUser;
    private TextBox txtPass;
    private CheckBox flagDobleFactor;
    private Button btnStart;
    private RichTextBox txtListas;
    private Label label3;
    private RichTextBox txtUsersToBlock;
    private Label label4;
    private Button btnDetener;
    private PictureBox fotito;
}