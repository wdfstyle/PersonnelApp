namespace PersonnelApp
{
    partial class FormTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.textbox = new System.Windows.Forms.RichTextBox();
            this.startPicker = new System.Windows.Forms.DateTimePicker();
            this.endPicker = new System.Windows.Forms.DateTimePicker();
            this.textbox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(785, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(12, 12);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(339, 856);
            this.textbox.TabIndex = 1;
            this.textbox.Text = "";
            // 
            // startPicker
            // 
            this.startPicker.Location = new System.Drawing.Point(785, 61);
            this.startPicker.Name = "startPicker";
            this.startPicker.Size = new System.Drawing.Size(200, 20);
            this.startPicker.TabIndex = 2;
            this.startPicker.Value = new System.DateTime(2023, 12, 4, 0, 0, 0, 0);
            // 
            // endPicker
            // 
            this.endPicker.Location = new System.Drawing.Point(785, 98);
            this.endPicker.Name = "endPicker";
            this.endPicker.Size = new System.Drawing.Size(200, 20);
            this.endPicker.TabIndex = 3;
            this.endPicker.Value = new System.DateTime(2023, 12, 10, 0, 0, 0, 0);
            // 
            // textbox2
            // 
            this.textbox2.Location = new System.Drawing.Point(395, 12);
            this.textbox2.Name = "textbox2";
            this.textbox2.Size = new System.Drawing.Size(339, 856);
            this.textbox2.TabIndex = 4;
            this.textbox2.Text = "";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1691, 880);
            this.Controls.Add(this.textbox2);
            this.Controls.Add(this.endPicker);
            this.Controls.Add(this.startPicker);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.button1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox textbox;
        private System.Windows.Forms.DateTimePicker startPicker;
        private System.Windows.Forms.DateTimePicker endPicker;
        private System.Windows.Forms.RichTextBox textbox2;
    }
}