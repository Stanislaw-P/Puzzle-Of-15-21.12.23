namespace Puzzle_Of_15
{
    partial class FormMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDigit = new System.Windows.Forms.Button();
            this.buttonIron = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(96, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберете режим игры";
            // 
            // buttonDigit
            // 
            this.buttonDigit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDigit.Location = new System.Drawing.Point(214, 110);
            this.buttonDigit.Name = "buttonDigit";
            this.buttonDigit.Size = new System.Drawing.Size(130, 50);
            this.buttonDigit.TabIndex = 1;
            this.buttonDigit.Text = "Цифры";
            this.buttonDigit.UseVisualStyleBackColor = true;
            this.buttonDigit.Click += new System.EventHandler(this.buttonDigit_Click);
            // 
            // buttonIron
            // 
            this.buttonIron.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonIron.Location = new System.Drawing.Point(214, 189);
            this.buttonIron.Name = "buttonIron";
            this.buttonIron.Size = new System.Drawing.Size(130, 50);
            this.buttonIron.TabIndex = 2;
            this.buttonIron.Text = "Ирон";
            this.buttonIron.UseVisualStyleBackColor = true;
            this.buttonIron.Click += new System.EventHandler(this.buttonIron_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 353);
            this.Controls.Add(this.buttonIron);
            this.Controls.Add(this.buttonDigit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(565, 400);
            this.Name = "FormMenu";
            this.Text = "Пятнашки";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDigit;
        private System.Windows.Forms.Button buttonIron;
    }
}

