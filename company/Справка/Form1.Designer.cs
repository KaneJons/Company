namespace ПЗ_06.Справка
{
    partial class Настройка_паролей
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Настройка_паролей));
            this.Пользователь = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Пользователь
            // 
            this.Пользователь.AutoSize = true;
            this.Пользователь.Location = new System.Drawing.Point(26, 29);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(107, 20);
            this.Пользователь.TabIndex = 0;
            this.Пользователь.Text = "Пользователь";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Новый пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Подтверждение\r\nнового пароля:\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(163, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 27);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(163, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(303, 27);
            this.textBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(163, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(303, 28);
            this.comboBox1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.comboBox1, "Выберите из списка");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Изменить пароль";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Настройка_паролей
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 246);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Пользователь);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Настройка_паролей";
            this.Text = "Настройка паролей";
            this.Load += new System.EventHandler(this.Настройка_паролей_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Пользователь;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Button button1;
        private ToolTip toolTip1;
    }
}