namespace Force_Directed_Maps
{
    partial class Confirmation
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
            this.LeftBut = new System.Windows.Forms.Button();
            this.RightBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // LeftBut
            // 
            this.LeftBut.Location = new System.Drawing.Point(12, 68);
            this.LeftBut.Name = "LeftBut";
            this.LeftBut.Size = new System.Drawing.Size(102, 30);
            this.LeftBut.TabIndex = 1;
            this.LeftBut.Text = "button1";
            this.LeftBut.UseVisualStyleBackColor = true;
            this.LeftBut.Click += new System.EventHandler(this.LeftBut_Click);
            // 
            // RightBut
            // 
            this.RightBut.Location = new System.Drawing.Point(124, 68);
            this.RightBut.Name = "RightBut";
            this.RightBut.Size = new System.Drawing.Size(102, 30);
            this.RightBut.TabIndex = 2;
            this.RightBut.Text = "button2";
            this.RightBut.UseVisualStyleBackColor = true;
            this.RightBut.Click += new System.EventHandler(this.RightBut_Click);
            // 
            // Confirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 109);
            this.Controls.Add(this.RightBut);
            this.Controls.Add(this.LeftBut);
            this.Controls.Add(this.label1);
            this.Name = "Confirmation";
            this.Text = "Confirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LeftBut;
        private System.Windows.Forms.Button RightBut;
    }
}