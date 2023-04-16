namespace GUI
{
    partial class Juego
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Juego));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 4;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ImeMode = ImeMode.Off;
            dataGridView1.Location = new Point(25, 81);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 4;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.ShowCellErrors = false;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.ShowRowErrors = false;
            dataGridView1.Size = new Size(703, 376);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Click += Color_click;
            dataGridView1.DoubleClick += RegresarColor_Doclick;
            // 
            // button1
            // 
            button1.Location = new Point(749, 432);
            button1.Name = "button1";
            button1.Size = new Size(137, 54);
            button1.TabIndex = 1;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.HorizontalScrollbar = true;
            checkedListBox1.ImeMode = ImeMode.NoControl;
            checkedListBox1.Location = new Point(749, 46);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.SelectionMode = SelectionMode.None;
            checkedListBox1.Size = new Size(137, 274);
            checkedListBox1.TabIndex = 2;
            checkedListBox1.TabStop = false;
            checkedListBox1.UseTabStops = false;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LimeGreen;
            label1.Font = new Font("Elephant", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(734, 16);
            label1.Name = "label1";
            label1.Size = new Size(161, 27);
            label1.TabIndex = 3;
            label1.Text = "Lista palabras";
            // 
            // button2
            // 
            button2.Location = new Point(749, 358);
            button2.Name = "button2";
            button2.Size = new Size(137, 54);
            button2.TabIndex = 4;
            button2.Text = "Resolver todo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(154, 26);
            label2.Name = "label2";
            label2.Size = new Size(418, 30);
            label2.TabIndex = 5;
            label2.Text = "Hora de jugar la sopa de letras";
            // 
            // Juego
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LimeGreen;
            ClientSize = new Size(898, 498);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Off;
            MaximizeBox = false;
            Name = "Juego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sopa de letras";
            Load += Juego_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private CheckedListBox checkedListBox1;
        private Label label1;
        private Button button2;
        private Label label2;
    }
}