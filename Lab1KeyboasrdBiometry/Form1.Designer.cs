namespace Lab1KeyboasrdBiometry
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
            this.tB_phrase2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tB_phrase1 = new System.Windows.Forms.TextBox();
            this.lblCollectedData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tB_phrase2
            // 
            this.tB_phrase2.Location = new System.Drawing.Point(25, 220);
            this.tB_phrase2.Multiline = true;
            this.tB_phrase2.Name = "tB_phrase2";
            this.tB_phrase2.Size = new System.Drawing.Size(500, 100);
            this.tB_phrase2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Проверочная фраза:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Съешь же этих мягких французских булок да выпей чаю!";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Проверочная фраза:";
            // 
            // tB_phrase1
            // 
            this.tB_phrase1.Location = new System.Drawing.Point(25, 100);
            this.tB_phrase1.Multiline = true;
            this.tB_phrase1.Name = "tB_phrase1";
            this.tB_phrase1.Size = new System.Drawing.Size(500, 50);
            this.tB_phrase1.TabIndex = 4;
            // 
            // lblCollectedData
            // 
            this.lblCollectedData.Location = new System.Drawing.Point(25, 350);
            this.lblCollectedData.Name = "lblCollectedData";
            this.lblCollectedData.Size = new System.Drawing.Size(500, 70);
            this.lblCollectedData.TabIndex = 5;
            this.lblCollectedData.Text = "Итоговые данные:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCollectedData);
            this.Controls.Add(this.tB_phrase1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tB_phrase2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_phrase1;
        private System.Windows.Forms.Label lblCollectedData;

        private System.Windows.Forms.TextBox tB_phrase2;

        #endregion
    }
}