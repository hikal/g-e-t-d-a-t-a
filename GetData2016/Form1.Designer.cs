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
            this.btnGetXeHoiChoTot = new System.Windows.Forms.Button();
            this.txtFromPage = new System.Windows.Forms.TextBox();
            this.txtToPage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            // btnGetXeHoiChoTot
            // 
            this.btnGetXeHoiChoTot.Location = new System.Drawing.Point(33, 70);
            this.btnGetXeHoiChoTot.Name = "btnGetXeHoiChoTot";
            this.btnGetXeHoiChoTot.Size = new System.Drawing.Size(90, 23);
            this.btnGetXeHoiChoTot.TabIndex = 3;
            this.btnGetXeHoiChoTot.Text = "get x";
            this.btnGetXeHoiChoTot.UseVisualStyleBackColor = true;
            this.btnGetXeHoiChoTot.Click += new System.EventHandler(this.btnGetXeHoiChoTot_Click);
            // 
            // txtFromPage
            // 
            this.txtFromPage.Location = new System.Drawing.Point(142, 22);
            this.txtFromPage.Name = "txtFromPage";
            this.txtFromPage.Size = new System.Drawing.Size(100, 22);
            this.txtFromPage.TabIndex = 4;
            this.txtFromPage.Text = "1";
            // 
            // txtToPage
            // 
            this.txtToPage.Location = new System.Drawing.Point(325, 22);
            this.txtToPage.Name = "txtToPage";
            this.txtToPage.Size = new System.Drawing.Size(100, 22);
            this.txtToPage.TabIndex = 5;
            this.txtToPage.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "From page";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "To page";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 263);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToPage);
            this.Controls.Add(this.txtFromPage);
            this.Controls.Add(this.btnGetXeHoiChoTot);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvlMes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lvlMes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetXeHoiChoTot;
        private System.Windows.Forms.TextBox txtFromPage;
        private System.Windows.Forms.TextBox txtToPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

