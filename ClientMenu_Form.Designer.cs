
namespace coursework
{
    partial class ClientMenu_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMenu_Form));
            this.gB_Data_user = new System.Windows.Forms.GroupBox();
            this.label_lose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_win = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.label_userPassword = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_userName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gB_Chat = new System.Windows.Forms.GroupBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.chat_send = new System.Windows.Forms.Button();
            this.chat_msg = new System.Windows.Forms.TextBox();
            this.button_ready = new System.Windows.Forms.Button();
            this.AnT_User = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label_random = new System.Windows.Forms.Label();
            this.label_reset = new System.Windows.Forms.Label();
            this.gB_Rank = new System.Windows.Forms.GroupBox();
            this.rB_fourdeck = new System.Windows.Forms.RadioButton();
            this.rB_threedeck = new System.Windows.Forms.RadioButton();
            this.rB_doubledeck = new System.Windows.Forms.RadioButton();
            this.rB_singledeck = new System.Windows.Forms.RadioButton();
            this.gB_Position = new System.Windows.Forms.GroupBox();
            this.rB_Vertical = new System.Windows.Forms.RadioButton();
            this.rB_Horizontal = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button_cancel = new System.Windows.Forms.Button();
            this.gB_Data_user.SuspendLayout();
            this.gB_Chat.SuspendLayout();
            this.gB_Rank.SuspendLayout();
            this.gB_Position.SuspendLayout();
            this.SuspendLayout();
            // 
            // gB_Data_user
            // 
            this.gB_Data_user.Controls.Add(this.label_lose);
            this.gB_Data_user.Controls.Add(this.label1);
            this.gB_Data_user.Controls.Add(this.label_win);
            this.gB_Data_user.Controls.Add(this.label2);
            this.gB_Data_user.Controls.Add(this.button_Exit);
            this.gB_Data_user.Controls.Add(this.button_delete);
            this.gB_Data_user.Controls.Add(this.label_userPassword);
            this.gB_Data_user.Controls.Add(this.label4);
            this.gB_Data_user.Controls.Add(this.label_userName);
            this.gB_Data_user.Controls.Add(this.label3);
            this.gB_Data_user.Location = new System.Drawing.Point(3, 6);
            this.gB_Data_user.Name = "gB_Data_user";
            this.gB_Data_user.Size = new System.Drawing.Size(331, 108);
            this.gB_Data_user.TabIndex = 23;
            this.gB_Data_user.TabStop = false;
            this.gB_Data_user.Text = "Данные пользователя:";
            // 
            // label_lose
            // 
            this.label_lose.AutoSize = true;
            this.label_lose.Location = new System.Drawing.Point(183, 77);
            this.label_lose.Name = "label_lose";
            this.label_lose.Size = new System.Drawing.Size(14, 15);
            this.label_lose.TabIndex = 9;
            this.label_lose.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Поражения:";
            // 
            // label_win
            // 
            this.label_win.AutoSize = true;
            this.label_win.Location = new System.Drawing.Point(69, 77);
            this.label_win.Name = "label_win";
            this.label_win.Size = new System.Drawing.Size(14, 15);
            this.label_win.TabIndex = 7;
            this.label_win.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Победы:";
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(221, 71);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(87, 27);
            this.button_Exit.TabIndex = 5;
            this.button_Exit.Text = "Выход";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(212, 17);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(112, 44);
            this.button_delete.TabIndex = 4;
            this.button_delete.Text = "Удалить\r\nпользователя";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // label_userPassword
            // 
            this.label_userPassword.AutoSize = true;
            this.label_userPassword.Location = new System.Drawing.Point(69, 49);
            this.label_userPassword.Name = "label_userPassword";
            this.label_userPassword.Size = new System.Drawing.Size(51, 15);
            this.label_userPassword.TabIndex = 3;
            this.label_userPassword.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Пароль:";
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Location = new System.Drawing.Point(69, 23);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(118, 15);
            this.label_userName.TabIndex = 1;
            this.label_userName.Text = "Имя пользователя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Имя:";
            // 
            // gB_Chat
            // 
            this.gB_Chat.Controls.Add(this.chatBox);
            this.gB_Chat.Controls.Add(this.chat_send);
            this.gB_Chat.Controls.Add(this.chat_msg);
            this.gB_Chat.Location = new System.Drawing.Point(1, 124);
            this.gB_Chat.Name = "gB_Chat";
            this.gB_Chat.Size = new System.Drawing.Size(333, 247);
            this.gB_Chat.TabIndex = 21;
            this.gB_Chat.TabStop = false;
            this.gB_Chat.Text = "Чат:";
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(7, 21);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(319, 185);
            this.chatBox.TabIndex = 10;
            this.chatBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatBox_KeyDown);
            // 
            // chat_send
            // 
            this.chat_send.Location = new System.Drawing.Point(205, 212);
            this.chat_send.Name = "chat_send";
            this.chat_send.Size = new System.Drawing.Size(121, 27);
            this.chat_send.TabIndex = 12;
            this.chat_send.Text = "Отправить";
            this.chat_send.UseVisualStyleBackColor = true;
            this.chat_send.Click += new System.EventHandler(this.chat_send_Click);
            // 
            // chat_msg
            // 
            this.chat_msg.Location = new System.Drawing.Point(7, 215);
            this.chat_msg.Name = "chat_msg";
            this.chat_msg.Size = new System.Drawing.Size(191, 21);
            this.chat_msg.TabIndex = 11;
            this.chat_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chat_msg_KeyDown);
            // 
            // button_ready
            // 
            this.button_ready.Location = new System.Drawing.Point(340, 256);
            this.button_ready.Name = "button_ready";
            this.button_ready.Size = new System.Drawing.Size(143, 32);
            this.button_ready.TabIndex = 24;
            this.button_ready.Text = "Готов";
            this.button_ready.UseVisualStyleBackColor = true;
            this.button_ready.Click += new System.EventHandler(this.button_ready_Click);
            // 
            // AnT_User
            // 
            this.AnT_User.AccumBits = ((byte)(0));
            this.AnT_User.AutoCheckErrors = false;
            this.AnT_User.AutoFinish = false;
            this.AnT_User.AutoMakeCurrent = true;
            this.AnT_User.AutoSwapBuffers = true;
            this.AnT_User.BackColor = System.Drawing.Color.Black;
            this.AnT_User.ColorBits = ((byte)(32));
            this.AnT_User.DepthBits = ((byte)(16));
            this.AnT_User.Location = new System.Drawing.Point(495, 6);
            this.AnT_User.Name = "AnT_User";
            this.AnT_User.Size = new System.Drawing.Size(350, 350);
            this.AnT_User.StencilBits = ((byte)(0));
            this.AnT_User.TabIndex = 25;
            this.AnT_User.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnT_User_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(639, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Ваше поле:";
            // 
            // label_random
            // 
            this.label_random.AutoSize = true;
            this.label_random.Location = new System.Drawing.Point(349, 193);
            this.label_random.Name = "label_random";
            this.label_random.Size = new System.Drawing.Size(125, 15);
            this.label_random.TabIndex = 27;
            this.label_random.Text = "Случайным образом";
            this.label_random.Click += new System.EventHandler(this.label_random_Click);
            // 
            // label_reset
            // 
            this.label_reset.AutoSize = true;
            this.label_reset.Location = new System.Drawing.Point(357, 218);
            this.label_reset.Name = "label_reset";
            this.label_reset.Size = new System.Drawing.Size(100, 15);
            this.label_reset.TabIndex = 28;
            this.label_reset.Text = "С чистого листа";
            this.label_reset.Click += new System.EventHandler(this.label_reset_Click);
            // 
            // gB_Rank
            // 
            this.gB_Rank.Controls.Add(this.rB_fourdeck);
            this.gB_Rank.Controls.Add(this.rB_threedeck);
            this.gB_Rank.Controls.Add(this.rB_doubledeck);
            this.gB_Rank.Controls.Add(this.rB_singledeck);
            this.gB_Rank.Location = new System.Drawing.Point(340, 76);
            this.gB_Rank.Name = "gB_Rank";
            this.gB_Rank.Size = new System.Drawing.Size(143, 113);
            this.gB_Rank.TabIndex = 39;
            this.gB_Rank.TabStop = false;
            this.gB_Rank.Text = "Ранг:";
            // 
            // rB_fourdeck
            // 
            this.rB_fourdeck.AutoSize = true;
            this.rB_fourdeck.Location = new System.Drawing.Point(6, 86);
            this.rB_fourdeck.Name = "rB_fourdeck";
            this.rB_fourdeck.Size = new System.Drawing.Size(132, 19);
            this.rB_fourdeck.TabIndex = 3;
            this.rB_fourdeck.TabStop = true;
            this.rB_fourdeck.Text = "Четырёхпалубный";
            this.rB_fourdeck.UseVisualStyleBackColor = true;
            // 
            // rB_threedeck
            // 
            this.rB_threedeck.AutoSize = true;
            this.rB_threedeck.Location = new System.Drawing.Point(6, 63);
            this.rB_threedeck.Name = "rB_threedeck";
            this.rB_threedeck.Size = new System.Drawing.Size(108, 19);
            this.rB_threedeck.TabIndex = 2;
            this.rB_threedeck.TabStop = true;
            this.rB_threedeck.Text = "Трёхпалубный";
            this.rB_threedeck.UseVisualStyleBackColor = true;
            // 
            // rB_doubledeck
            // 
            this.rB_doubledeck.AutoSize = true;
            this.rB_doubledeck.Location = new System.Drawing.Point(6, 40);
            this.rB_doubledeck.Name = "rB_doubledeck";
            this.rB_doubledeck.Size = new System.Drawing.Size(108, 19);
            this.rB_doubledeck.TabIndex = 1;
            this.rB_doubledeck.TabStop = true;
            this.rB_doubledeck.Text = "Двухпалубный";
            this.rB_doubledeck.UseVisualStyleBackColor = true;
            // 
            // rB_singledeck
            // 
            this.rB_singledeck.AutoSize = true;
            this.rB_singledeck.Location = new System.Drawing.Point(6, 19);
            this.rB_singledeck.Name = "rB_singledeck";
            this.rB_singledeck.Size = new System.Drawing.Size(111, 19);
            this.rB_singledeck.TabIndex = 0;
            this.rB_singledeck.TabStop = true;
            this.rB_singledeck.Text = "Однопалубный";
            this.rB_singledeck.UseVisualStyleBackColor = true;
            this.rB_singledeck.CheckedChanged += new System.EventHandler(this.rB_singledeck_CheckedChanged);
            // 
            // gB_Position
            // 
            this.gB_Position.Controls.Add(this.rB_Vertical);
            this.gB_Position.Controls.Add(this.rB_Horizontal);
            this.gB_Position.Location = new System.Drawing.Point(340, 6);
            this.gB_Position.Name = "gB_Position";
            this.gB_Position.Size = new System.Drawing.Size(143, 64);
            this.gB_Position.TabIndex = 38;
            this.gB_Position.TabStop = false;
            this.gB_Position.Text = "Положение:";
            // 
            // rB_Vertical
            // 
            this.rB_Vertical.AutoSize = true;
            this.rB_Vertical.Location = new System.Drawing.Point(6, 42);
            this.rB_Vertical.Name = "rB_Vertical";
            this.rB_Vertical.Size = new System.Drawing.Size(102, 19);
            this.rB_Vertical.TabIndex = 1;
            this.rB_Vertical.TabStop = true;
            this.rB_Vertical.Text = "Вертикально";
            this.rB_Vertical.UseVisualStyleBackColor = true;
            // 
            // rB_Horizontal
            // 
            this.rB_Horizontal.AutoSize = true;
            this.rB_Horizontal.Location = new System.Drawing.Point(6, 19);
            this.rB_Horizontal.Name = "rB_Horizontal";
            this.rB_Horizontal.Size = new System.Drawing.Size(115, 19);
            this.rB_Horizontal.TabIndex = 0;
            this.rB_Horizontal.TabStop = true;
            this.rB_Horizontal.Text = "Горизонтально";
            this.rB_Horizontal.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(340, 294);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(143, 32);
            this.button_cancel.TabIndex = 40;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // ClientMenu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(855, 382);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.gB_Rank);
            this.Controls.Add(this.gB_Position);
            this.Controls.Add(this.label_reset);
            this.Controls.Add(this.label_random);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AnT_User);
            this.Controls.Add(this.button_ready);
            this.Controls.Add(this.gB_Data_user);
            this.Controls.Add(this.gB_Chat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientMenu_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BattleShip";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientMenu_Form_FormClosed);
            this.Load += new System.EventHandler(this.ClientMenu_Form_Load);
            this.gB_Data_user.ResumeLayout(false);
            this.gB_Data_user.PerformLayout();
            this.gB_Chat.ResumeLayout(false);
            this.gB_Chat.PerformLayout();
            this.gB_Rank.ResumeLayout(false);
            this.gB_Rank.PerformLayout();
            this.gB_Position.ResumeLayout(false);
            this.gB_Position.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gB_Data_user;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_delete;
        public System.Windows.Forms.Label label_userPassword;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gB_Chat;
        public System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.Button chat_send;
        private System.Windows.Forms.TextBox chat_msg;
        public System.Windows.Forms.Button button_ready;
        public System.Windows.Forms.Label label_lose;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label_win;
        private System.Windows.Forms.Label label2;
        private Tao.Platform.Windows.SimpleOpenGlControl AnT_User;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label_random;
        public System.Windows.Forms.Label label_reset;
        private System.Windows.Forms.GroupBox gB_Rank;
        private System.Windows.Forms.RadioButton rB_fourdeck;
        private System.Windows.Forms.RadioButton rB_threedeck;
        private System.Windows.Forms.RadioButton rB_doubledeck;
        private System.Windows.Forms.RadioButton rB_singledeck;
        private System.Windows.Forms.GroupBox gB_Position;
        private System.Windows.Forms.RadioButton rB_Vertical;
        private System.Windows.Forms.RadioButton rB_Horizontal;
        public System.Windows.Forms.Timer timer;
        public System.Windows.Forms.Button button_cancel;
    }
}