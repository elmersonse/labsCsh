namespace lab5
{
    partial class Form1
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
            this.task1 = new System.Windows.Forms.Button();
            this.task2 = new System.Windows.Forms.Button();
            this.exitb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // task1
            // 
            this.task1.Location = new System.Drawing.Point(16, 20);
            this.task1.Name = "task1";
            this.task1.Size = new System.Drawing.Size(350, 50);
            this.task1.TabIndex = 0;
            this.task1.Text = "Task 1";
            this.task1.UseVisualStyleBackColor = true;
            this.task1.Click += new System.EventHandler(this.task1_Click);
            // 
            // task2
            // 
            this.task2.Location = new System.Drawing.Point(16, 100);
            this.task2.Name = "task2";
            this.task2.Size = new System.Drawing.Size(350, 50);
            this.task2.TabIndex = 1;
            this.task2.Text = "Task 2";
            this.task2.UseVisualStyleBackColor = true;
            this.task2.Click += new System.EventHandler(this.task2_Click);
            // 
            // exitb
            // 
            this.exitb.Location = new System.Drawing.Point(16, 180);
            this.exitb.Name = "exitb";
            this.exitb.Size = new System.Drawing.Size(350, 50);
            this.exitb.TabIndex = 2;
            this.exitb.Text = "Exit";
            this.exitb.UseVisualStyleBackColor = true;
            this.exitb.Click += new System.EventHandler(this.exitb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.Controls.Add(this.exitb);
            this.Controls.Add(this.task2);
            this.Controls.Add(this.task1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button task2;
        private System.Windows.Forms.Button exitb;

        private System.Windows.Forms.Button task1;

        #endregion
    }
}