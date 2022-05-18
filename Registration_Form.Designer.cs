
namespace coursework
{
    partial class Registration_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration_Form));
            this.label_error = new System.Windows.Forms.Label();
            this.label_enterMenu = new System.Windows.Forms.Label();
            this.button_Registration = new System.Windows.Forms.Button();
            this.tB_userPassword_repeat = new System.Windows.Forms.TextBox();
            this.tB_userPassword = new System.Windows.Forms.TextBox();
            this.tB_userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(12, 194);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(57, 13);
            this.label_error.TabIndex = 23;
            this.label_error.Text = "label_Error";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_enterMenu
            // 
            this.label_enterMenu.AutoSize = true;
            this.label_enterMenu.Location = new System.Drawing.Point(77, 303);
            this.label_enterMenu.Name = "label_enterMenu";
            this.label_enterMenu.Size = new System.Drawing.Size(37, 13);
            this.label_enterMenu.TabIndex = 22;
            this.label_enterMenu.Text = "Войти";
            this.label_enterMenu.Click += new System.EventHandler(this.label_enterMenu_Click);
            // 
            // button_Registration
            // 
            this.button_Registration.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Registration.Location = new System.Drawing.Point(26, 232);
            this.button_Registration.Name = "button_Registration";
            this.button_Registration.Size = new System.Drawing.Size(150, 39);
            this.button_Registration.TabIndex = 21;
            this.button_Registration.Text = "Зарегистрироваться";
            this.button_Registration.UseVisualStyleBackColor = true;
            this.button_Registration.Click += new System.EventHandler(this.button_Registration_Click);
            // 
            // tB_userPassword_repeat
            // 
            this.tB_userPassword_repeat.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tB_userPassword_repeat.Location = new System.Drawing.Point(26, 154);
            this.tB_userPassword_repeat.Name = "tB_userPassword_repeat";
            this.tB_userPassword_repeat.Size = new System.Drawing.Size(150, 20);
            this.tB_userPassword_repeat.TabIndex = 20;
            this.tB_userPassword_repeat.Text = "Повторите пароль";
            // 
            // tB_userPassword
            // 
            this.tB_userPassword.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tB_userPassword.Location = new System.Drawing.Point(26, 115);
            this.tB_userPassword.Name = "tB_userPassword";
            this.tB_userPassword.Size = new System.Drawing.Size(150, 20);
            this.tB_userPassword.TabIndex = 19;
            this.tB_userPassword.Text = "Пароль";
            // 
            // tB_userName
            // 
            this.tB_userName.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tB_userName.Location = new System.Drawing.Point(26, 78);
            this.tB_userName.Name = "tB_userName";
            this.tB_userName.Size = new System.Drawing.Size(150, 20);
            this.tB_userName.TabIndex = 18;
            this.tB_userName.Text = "Логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(41, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Регистрация";
            // 
            // Registration_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(214, 331);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.label_enterMenu);
            this.Controls.Add(this.button_Registration);
            this.Controls.Add(this.tB_userPassword_repeat);
            this.Controls.Add(this.tB_userPassword);
            this.Controls.Add(this.tB_userName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registration_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registration_Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label_enterMenu;
        private System.Windows.Forms.Button button_Registration;
        private System.Windows.Forms.TextBox tB_userPassword_repeat;
        private System.Windows.Forms.TextBox tB_userPassword;
        private System.Windows.Forms.TextBox tB_userName;
        private System.Windows.Forms.Label label1;
    }
}