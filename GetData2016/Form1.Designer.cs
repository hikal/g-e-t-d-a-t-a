namespace GetData2016
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
            this.lvlMes = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvlMes
            // 
            this.lvlMes.AutoSize = true;
            this.lvlMes.ForeColor = System.Drawing.Color.Red;
            this.lvlMes.Location = new System.Drawing.Point(193, 192);
            this.lvlMes.Name = "lvlMes";
            this.lvlMes.Size = new System.Drawing.Size(0, 17);
            this.lvlMes.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get detail company";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 263);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvlMes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lvlMes;
        private System.Windows.Forms.Button button1;
    }
}

