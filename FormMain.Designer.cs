namespace PersonnelApp
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.EmplButton = new System.Windows.Forms.Button();
            this.DepartmentsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Главное меню";
            // 
            // EmplButton
            // 
            this.EmplButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.EmplButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmplButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmplButton.Location = new System.Drawing.Point(0, 0);
            this.EmplButton.Name = "EmplButton";
            this.EmplButton.Size = new System.Drawing.Size(539, 90);
            this.EmplButton.TabIndex = 2;
            this.EmplButton.Text = "Сотрудники";
            this.EmplButton.UseVisualStyleBackColor = false;
            this.EmplButton.Click += new System.EventHandler(this.EmplButton_Click);
            // 
            // DepartmentsButton
            // 
            this.DepartmentsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DepartmentsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DepartmentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DepartmentsButton.Location = new System.Drawing.Point(0, 90);
            this.DepartmentsButton.Name = "DepartmentsButton";
            this.DepartmentsButton.Size = new System.Drawing.Size(539, 90);
            this.DepartmentsButton.TabIndex = 3;
            this.DepartmentsButton.Text = "Подразделения";
            this.DepartmentsButton.UseVisualStyleBackColor = false;
            this.DepartmentsButton.Click += new System.EventHandler(this.DepartmentsButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(0, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(539, 90);
            this.button1.TabIndex = 4;
            this.button1.Text = "Табели";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(0, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(539, 90);
            this.button2.TabIndex = 5;
            this.button2.Text = "Приказы";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.IndianRed;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(185, 496);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 96);
            this.button4.TabIndex = 6;
            this.button4.Text = "Выход";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // addUserButton
            // 
            this.addUserButton.BackColor = System.Drawing.SystemColors.Info;
            this.addUserButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUserButton.Location = new System.Drawing.Point(0, 360);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(539, 90);
            this.addUserButton.TabIndex = 7;
            this.addUserButton.Text = "Добавить пользователя";
            this.addUserButton.UseVisualStyleBackColor = false;
            this.addUserButton.Visible = false;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 604);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DepartmentsButton);
            this.Controls.Add(this.EmplButton);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EmplButton;
        private System.Windows.Forms.Button DepartmentsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button addUserButton;
    }
}