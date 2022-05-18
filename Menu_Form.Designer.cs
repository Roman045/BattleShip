
namespace coursework
{
    partial class Menu_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_error = new System.Windows.Forms.Label();
            this.label_Registration = new System.Windows.Forms.Label();
            this.button_enterChat = new System.Windows.Forms.Button();
            this.tB_userPassword = new System.Windows.Forms.TextBox();
            this.tB_userName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Добро пожаловать в BattleShip!!!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::coursework.Properties.Resources.Ship;
            this.pictureBox1.Location = new System.Drawing.Point(32, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 204);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(58, 351);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(57, 13);
            this.label_error.TabIndex = 22;
            this.label_error.Text = "label_Error";
            // 
            // label_Registration
            // 
            this.label_Registration.AutoSize = true;
            this.label_Registration.Location = new System.Drawing.Point(129, 432);
            this.label_Registration.Name = "label_Registration";
            this.label_Registration.Size = new System.Drawing.Size(72, 13);
            this.label_Registration.TabIndex = 21;
            this.label_Registration.Text = "Регистрация";
            this.label_Registration.Click += new System.EventHandler(this.label_Registration_Click);
            // 
            // button_enterChat
            // 
            this.button_enterChat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_enterChat.Location = new System.Drawing.Point(89, 381);
            this.button_enterChat.Name = "button_enterChat";
            this.button_enterChat.Size = new System.Drawing.Size(150, 31);
            this.button_enterChat.TabIndex = 20;
            this.button_enterChat.Text = "Войти";
            this.button_enterChat.UseVisualStyleBackColor = true;
            this.button_enterChat.Click += new System.EventHandler(this.button_enterChat_Click);
            // 
            // tB_userPassword
            // 
            this.tB_userPassword.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tB_userPassword.Location = new System.Drawing.Point(89, 313);
            this.tB_userPassword.Name = "tB_userPassword";
            this.tB_userPassword.Size = new System.Drawing.Size(150, 20);
            this.tB_userPassword.TabIndex = 19;
            this.tB_userPassword.Text = "Пароль";
            // 
            // tB_userName
            // 
            this.tB_userName.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tB_userName.Location = new System.Drawing.Point(89, 277);
            this.tB_userName.Name = "tB_userName";
            this.tB_userName.Size = new System.Drawing.Size(150, 20);
            this.tB_userName.TabIndex = 18;
            this.tB_userName.Text = "Логин";
            // 
            // Menu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(334, 461);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.label_Registration);
            this.Controls.Add(this.button_enterChat);
            this.Controls.Add(this.tB_userPassword);
            this.Controls.Add(this.tB_userName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label_Registration;
        private System.Windows.Forms.Button button_enterChat;
        private System.Windows.Forms.TextBox tB_userPassword;
        private System.Windows.Forms.TextBox tB_userName;
    }
}