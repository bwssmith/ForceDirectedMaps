namespace Force_Directed_Maps
{
    partial class NodeInspector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReturnButton = new System.Windows.Forms.Button();
            this.ColourButton = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(0, 67);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(150, 30);
            this.ReturnButton.TabIndex = 5;
            this.ReturnButton.Text = "DONE";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // ColourButton
            // 
            this.ColourButton.Location = new System.Drawing.Point(120, 31);
            this.ColourButton.Name = "ColourButton";
            this.ColourButton.Size = new System.Drawing.Size(30, 30);
            this.ColourButton.TabIndex = 4;
            this.ColourButton.UseVisualStyleBackColor = true;
            this.ColourButton.Click += new System.EventHandler(this.ColourButton_Click);
            // 
            // NameBox
            // 
            this.NameBox.AcceptsReturn = true;
            this.NameBox.BackColor = System.Drawing.SystemColors.Control;
            this.NameBox.Location = new System.Drawing.Point(0, 3);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(150, 22);
            this.NameBox.TabIndex = 3;
            // 
            // NodeInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.ColourButton);
            this.Controls.Add(this.NameBox);
            this.Name = "NodeInspector";
            this.Size = new System.Drawing.Size(150, 105);
            this.Load += new System.EventHandler(this.NodeInspector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button ColourButton;
        public System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
