namespace GUI;

partial class Principal
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
        button1 = new Button();
        button2 = new Button();
        label1 = new Label();
        listBox1 = new ListBox();
        label2 = new Label();
        textBox1 = new TextBox();
        label3 = new Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(265, 328);
        button1.Name = "button1";
        button1.Size = new Size(265, 110);
        button1.TabIndex = 0;
        button1.Text = "Iniciar Juego";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(586, 214);
        button2.Name = "button2";
        button2.Size = new Size(190, 37);
        button2.TabIndex = 1;
        button2.Text = "Cambiar palabra";
        button2.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
        label1.Location = new Point(190, 21);
        label1.Name = "label1";
        label1.Size = new Size(434, 30);
        label1.TabIndex = 2;
        label1.Text = "Juego de Fabricio Porras Morera";
        label1.Click += label1_Click;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new Point(565, 99);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(232, 109);
        listBox1.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Elephant", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
        label2.ForeColor = Color.Gold;
        label2.Location = new Point(598, 69);
        label2.Name = "label2";
        label2.Size = new Size(190, 27);
        label2.TabIndex = 4;
        label2.Text = "Lista de palabras";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(12, 99);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(189, 122);
        textBox1.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Elephant", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
        label3.ForeColor = Color.Gold;
        label3.Location = new Point(34, 69);
        label3.Name = "label3";
        label3.Size = new Size(146, 27);
        label3.TabIndex = 6;
        label3.Text = "Intrucciones";
        label3.Click += label3_Click;
        // 
        // Principal
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LimeGreen;
        ClientSize = new Size(800, 450);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(listBox1);
        Controls.Add(label1);
        Controls.Add(button2);
        Controls.Add(button1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Principal";
        Text = "Sopa de letras";
        Load += Principal_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Button button2;
    private Label label1;
    private ListBox listBox1;
    private Label label2;
    private TextBox textBox1;
    private Label label3;
}