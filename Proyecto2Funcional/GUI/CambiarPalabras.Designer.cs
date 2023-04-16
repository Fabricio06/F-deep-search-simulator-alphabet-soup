namespace GUI
{
    partial class CambiarPalabras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarPalabras));
            label1 = new Label();
            checkedListBox1 = new CheckedListBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LimeGreen;
            label1.Font = new Font("Elephant", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(27, 92);
            label1.Name = "label1";
            label1.Size = new Size(339, 27);
            label1.TabIndex = 4;
            label1.Text = "Seleccione la palabra a cambiar";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.HorizontalScrollbar = true;
            checkedListBox1.ImeMode = ImeMode.NoControl;
            checkedListBox1.Location = new Point(69, 147);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(253, 274);
            checkedListBox1.TabIndex = 5;
            checkedListBox1.TabStop = false;
            checkedListBox1.UseTabStops = false;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(651, 384);
            button1.Name = "button1";
            button1.Size = new Size(137, 54);
            button1.TabIndex = 6;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(584, 195);
            button2.Name = "button2";
            button2.Size = new Size(137, 54);
            button2.TabIndex = 7;
            button2.Text = "Cambiar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(107, 24);
            label2.Name = "label2";
            label2.Size = new Size(594, 30);
            label2.TabIndex = 8;
            label2.Text = "Cambiar palabras de la lista predeterminada";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(541, 147);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(231, 42);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LimeGreen;
            label3.Font = new Font("Elephant", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(518, 92);
            label3.Name = "label3";
            label3.Size = new Size(270, 27);
            label3.TabIndex = 10;
            label3.Text = "Escriba la nueva palabra";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(584, 122);
            label4.Name = "label4";
            label4.Size = new Size(139, 15);
            label4.TabIndex = 11;
            label4.Text = "Mayuscula y sin espacios";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(129, 122);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 12;
            label5.Text = "Seleccione solo uno";
            // 
            // CambiarPalabras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LimeGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkedListBox1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CambiarPalabras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambiar palabras sopa de letras";
            Load += CambiarPalabras_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckedListBox checkedListBox1;
        private Button button1;
        private Button button2;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}