namespace Force_Directed_Maps
{
    partial class CreateNewPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewPage));
            this.label1 = new System.Windows.Forms.Label();
            this.CustomChartButton = new System.Windows.Forms.Button();
            this.PresetPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose a type of graph to make:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CustomChartButton
            // 
            this.CustomChartButton.BackColor = System.Drawing.Color.LightGray;
            this.CustomChartButton.Location = new System.Drawing.Point(10, 370);
            this.CustomChartButton.Name = "CustomChartButton";
            this.CustomChartButton.Size = new System.Drawing.Size(500, 100);
            this.CustomChartButton.TabIndex = 2;
            this.CustomChartButton.Text = "Custom chart";
            this.CustomChartButton.UseVisualStyleBackColor = false;
            this.CustomChartButton.Click += new System.EventHandler(this.CustomChartButton_Click);
            // 
            // PresetPanel
            // 
            this.PresetPanel.Location = new System.Drawing.Point(12, 70);
            this.PresetPanel.Name = "PresetPanel";
            this.PresetPanel.Size = new System.Drawing.Size(500, 100);
            this.PresetPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Presets";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "User charts";
            // 
            // UserPanel
            // 
            this.UserPanel.Location = new System.Drawing.Point(12, 220);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(500, 100);
            this.UserPanel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Create a new type of chart";
            // 
            // CreateNewPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(525, 484);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UserPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PresetPanel);
            this.Controls.Add(this.CustomChartButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateNewPage";
            this.Text = "Title Page";
            this.Load += new System.EventHandler(this.CreateNewPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CustomChartButton;
        private System.Windows.Forms.Panel PresetPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Label label4;
    }
}