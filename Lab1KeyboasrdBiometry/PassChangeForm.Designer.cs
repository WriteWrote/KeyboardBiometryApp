using System.ComponentModel;

namespace Lab1KeyboasrdBiometry
{
    partial class PassChangeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.tb_OldPass = new System.Windows.Forms.TextBox();
            this.tb_NewPass = new System.Windows.Forms.TextBox();
            this.btn_ChangePass = new System.Windows.Forms.Button();
            this.tb_ConfirmNewPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_OldPass
            // 
            this.tb_OldPass.Location = new System.Drawing.Point(25, 25);
            this.tb_OldPass.Multiline = true;
            this.tb_OldPass.Name = "tb_OldPass";
            this.tb_OldPass.Size = new System.Drawing.Size(200, 30);
            this.tb_OldPass.TabIndex = 1;
            this.tb_OldPass.Text = "Старый пароль";
            // 
            // tb_NewPass
            // 
            this.tb_NewPass.Location = new System.Drawing.Point(25, 85);
            this.tb_NewPass.Multiline = true;
            this.tb_NewPass.Name = "tb_NewPass";
            this.tb_NewPass.Size = new System.Drawing.Size(200, 30);
            this.tb_NewPass.TabIndex = 3;
            this.tb_NewPass.Text = "Новый пароль";
            // 
            // btn_ChangePass
            // 
            this.btn_ChangePass.Location = new System.Drawing.Point(250, 145);
            this.btn_ChangePass.Name = "btn_ChangePass";
            this.btn_ChangePass.Size = new System.Drawing.Size(70, 30);
            this.btn_ChangePass.TabIndex = 2;
            this.btn_ChangePass.Text = "Задать";
            this.btn_ChangePass.UseVisualStyleBackColor = true;
            // 
            // tb_ConfirmNewPass
            // 
            this.tb_ConfirmNewPass.Location = new System.Drawing.Point(25, 145);
            this.tb_ConfirmNewPass.Multiline = true;
            this.tb_ConfirmNewPass.Name = "tb_ConfirmNewPass";
            this.tb_ConfirmNewPass.Size = new System.Drawing.Size(200, 30);
            this.tb_ConfirmNewPass.TabIndex = 4;
            this.tb_ConfirmNewPass.Text = "Повторите пароль";
            // 
            // PassChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 203);
            this.Controls.Add(this.tb_ConfirmNewPass);
            this.Controls.Add(this.tb_NewPass);
            this.Controls.Add(this.btn_ChangePass);
            this.Controls.Add(this.tb_OldPass);
            this.Name = "PassChangeForm";
            this.Text = "PassChangeForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox tb_NewPass;
        private System.Windows.Forms.Button btn_ChangePass;
        private System.Windows.Forms.TextBox tb_ConfirmNewPass;

        private System.Windows.Forms.TextBox tb_OldPass;

        #endregion
    }
}