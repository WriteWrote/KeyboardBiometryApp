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
            this.btnSubmitPhrase1 = new System.Windows.Forms.Button();
            this.btnSubmitPhrase2 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
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
            this.tB_phrase1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_phrase1_KeyDown);
            this.tB_phrase1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_phrase1_KeyUp);
            // 
            // lblCollectedData
            // 
            this.lblCollectedData.Location = new System.Drawing.Point(25, 350);
            this.lblCollectedData.Name = "lblCollectedData";
            this.lblCollectedData.Size = new System.Drawing.Size(500, 70);
            this.lblCollectedData.TabIndex = 5;
            this.lblCollectedData.Text = "Итоговые данные:";
            // 
            // btnSubmitPhrase1
            // 
            this.btnSubmitPhrase1.Location = new System.Drawing.Point(550, 100);
            this.btnSubmitPhrase1.Name = "btnSubmitPhrase1";
            this.btnSubmitPhrase1.Size = new System.Drawing.Size(100, 50);
            this.btnSubmitPhrase1.TabIndex = 6;
            this.btnSubmitPhrase1.Text = "Submit";
            this.btnSubmitPhrase1.UseVisualStyleBackColor = true;
            this.btnSubmitPhrase1.Click += new System.EventHandler(this.btnSubmitPhrase1_Click);
            // 
            // btnSubmitPhrase2
            // 
            this.btnSubmitPhrase2.Location = new System.Drawing.Point(550, 220);
            this.btnSubmitPhrase2.Name = "btnSubmitPhrase2";
            this.btnSubmitPhrase2.Size = new System.Drawing.Size(100, 50);
            this.btnSubmitPhrase2.TabIndex = 7;
            this.btnSubmitPhrase2.Text = "Submit";
            this.btnSubmitPhrase2.UseVisualStyleBackColor = true;
            this.btnSubmitPhrase2.Click += new System.EventHandler(this.btnSubmitPhrase2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSubmitPhrase2);
            this.Controls.Add(this.btnSubmitPhrase1);
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

        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        private System.Windows.Forms.Button btnSubmitPhrase1;
        private System.Windows.Forms.Button btnSubmitPhrase2;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_phrase1;
        private System.Windows.Forms.Label lblCollectedData;

        private System.Windows.Forms.TextBox tB_phrase2;

        #endregion
    }
}