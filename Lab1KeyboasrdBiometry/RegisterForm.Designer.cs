using System.ComponentModel;

namespace Lab1KeyboasrdBiometry
{
    partial class RegisterForm
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
            this.comboBox_users = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Create = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.listBox_users = new System.Windows.Forms.ListBox();
            this.button_Enter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_users
            // 
            this.comboBox_users.FormattingEnabled = true;
            this.comboBox_users.Location = new System.Drawing.Point(25, 50);
            this.comboBox_users.Name = "comboBox_users";
            this.comboBox_users.Size = new System.Drawing.Size(250, 24);
            this.comboBox_users.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите своего пользователя";
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(25, 250);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(100, 25);
            this.button_Create.TabIndex = 2;
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(25, 150);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(200, 22);
            this.textBox_name.TabIndex = 3;
            this.textBox_name.Text = "Имя";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Создать нового пользователя";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(25, 200);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(200, 22);
            this.textBox_password.TabIndex = 5;
            this.textBox_password.Text = "Пароль";
            // 
            // listBox_users
            // 
            this.listBox_users.FormattingEnabled = true;
            this.listBox_users.ItemHeight = 16;
            this.listBox_users.Location = new System.Drawing.Point(300, 25);
            this.listBox_users.Name = "listBox_users";
            this.listBox_users.Size = new System.Drawing.Size(250, 244);
            this.listBox_users.TabIndex = 6;
            // 
            // button_Enter
            // 
            this.button_Enter.Location = new System.Drawing.Point(150, 250);
            this.button_Enter.Name = "button_Enter";
            this.button_Enter.Size = new System.Drawing.Size(100, 25);
            this.button_Enter.TabIndex = 7;
            this.button_Enter.Text = "Войти";
            this.button_Enter.UseVisualStyleBackColor = true;
            this.button_Enter.Click += new System.EventHandler(this.button_Enter_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 303);
            this.Controls.Add(this.button_Enter);
            this.Controls.Add(this.listBox_users);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_users);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.ListBox listBox_users;
        private System.Windows.Forms.Button button_Enter;

        private System.Windows.Forms.Button button_Create;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ComboBox comboBox_users;

        #endregion
    }
}