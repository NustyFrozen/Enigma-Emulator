namespace Enigma_Simulator
{
    partial class Enigma
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
            keyboard1 = new Keyboard();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            keyboardLBL = new Label();
            LampBoardLBL = new Label();
            ReflectorLBL = new Label();
            PlugBoardLBL = new Label();
            SuspendLayout();
            // 
            // keyboard1
            // 
            keyboard1.BackColor = Color.FromArgb(64, 64, 64);
            keyboard1.Location = new Point(122, 195);
            keyboard1.Name = "keyboard1";
            keyboard1.Size = new Size(1064, 364);
            keyboard1.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1006, 87);
            button1.Name = "button1";
            button1.Size = new Size(116, 43);
            button1.TabIndex = 1;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(29, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(281, 74);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(64, 64, 64);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(451, 12);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(281, 74);
            textBox2.TabIndex = 3;
            // 
            // keyboardLBL
            // 
            keyboardLBL.AutoSize = true;
            keyboardLBL.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            keyboardLBL.ForeColor = Color.White;
            keyboardLBL.Location = new Point(442, 126);
            keyboardLBL.Name = "keyboardLBL";
            keyboardLBL.Size = new Size(88, 18);
            keyboardLBL.TabIndex = 4;
            keyboardLBL.Text = "Keyboard";
            // 
            // LampBoardLBL
            // 
            LampBoardLBL.AutoSize = true;
            LampBoardLBL.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LampBoardLBL.ForeColor = Color.White;
            LampBoardLBL.Location = new Point(701, 300);
            LampBoardLBL.Name = "LampBoardLBL";
            LampBoardLBL.Size = new Size(98, 18);
            LampBoardLBL.TabIndex = 5;
            LampBoardLBL.Text = "LampBoard";
            // 
            // ReflectorLBL
            // 
            ReflectorLBL.AutoSize = true;
            ReflectorLBL.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ReflectorLBL.ForeColor = Color.White;
            ReflectorLBL.Location = new Point(701, 135);
            ReflectorLBL.Name = "ReflectorLBL";
            ReflectorLBL.Size = new Size(158, 18);
            ReflectorLBL.TabIndex = 6;
            ReflectorLBL.Text = "Reflector Table";
            // 
            // PlugBoardLBL
            // 
            PlugBoardLBL.AutoSize = true;
            PlugBoardLBL.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PlugBoardLBL.ForeColor = Color.White;
            PlugBoardLBL.Location = new Point(666, 300);
            PlugBoardLBL.Name = "PlugBoardLBL";
            PlugBoardLBL.Size = new Size(158, 18);
            PlugBoardLBL.TabIndex = 7;
            PlugBoardLBL.Text = "PlugBoard Table";
            // 
            // Enigma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1491, 619);
            Controls.Add(PlugBoardLBL);
            Controls.Add(ReflectorLBL);
            Controls.Add(LampBoardLBL);
            Controls.Add(keyboardLBL);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(keyboard1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Enigma";
            StartPosition = FormStartPosition.Manual;
            Text = "Enigma";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Keyboard keyboard1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label keyboardLBL;
        private Label LampBoardLBL;
        private Label ReflectorLBL;
        private Label PlugBoardLBL;
    }
}