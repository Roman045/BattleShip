
namespace coursework
{
    partial class Game_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game_Form));
            this.label_user = new System.Windows.Forms.Label();
            this.button_give_up = new System.Windows.Forms.Button();
            this.label_opp = new System.Windows.Forms.Label();
            this.AnT_Opponent = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.label_motion = new System.Windows.Forms.Label();
            this.AnT_User = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(156, 392);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(64, 13);
            this.label_user.TabIndex = 28;
            this.label_user.Text = "Ваше поле:";
            // 
            // button_give_up
            // 
            this.button_give_up.Location = new System.Drawing.Point(702, 415);
            this.button_give_up.Name = "button_give_up";
            this.button_give_up.Size = new System.Drawing.Size(75, 23);
            this.button_give_up.TabIndex = 29;
            this.button_give_up.Text = "Сдаться";
            this.button_give_up.UseVisualStyleBackColor = true;
            this.button_give_up.Click += new System.EventHandler(this.button_give_up_Click);
            // 
            // label_opp
            // 
            this.label_opp.AutoSize = true;
            this.label_opp.Location = new System.Drawing.Point(541, 392);
            this.label_opp.Name = "label_opp";
            this.label_opp.Size = new System.Drawing.Size(101, 13);
            this.label_opp.TabIndex = 31;
            this.label_opp.Text = "Поле противника: ";
            // 
            // AnT_Opponent
            // 
            this.AnT_Opponent.AccumBits = ((byte)(0));
            this.AnT_Opponent.AutoCheckErrors = false;
            this.AnT_Opponent.AutoFinish = false;
            this.AnT_Opponent.AutoMakeCurrent = true;
            this.AnT_Opponent.AutoSwapBuffers = true;
            this.AnT_Opponent.BackColor = System.Drawing.Color.Black;
            this.AnT_Opponent.ColorBits = ((byte)(32));
            this.AnT_Opponent.DepthBits = ((byte)(16));
            this.AnT_Opponent.Location = new System.Drawing.Point(397, 38);
            this.AnT_Opponent.Name = "AnT_Opponent";
            this.AnT_Opponent.Size = new System.Drawing.Size(350, 350);
            this.AnT_Opponent.StencilBits = ((byte)(0));
            this.AnT_Opponent.TabIndex = 30;
            this.AnT_Opponent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnT_Opponent_MouseDown);
            // 
            // label_motion
            // 
            this.label_motion.AutoSize = true;
            this.label_motion.Location = new System.Drawing.Point(355, 9);
            this.label_motion.Name = "label_motion";
            this.label_motion.Size = new System.Drawing.Size(51, 13);
            this.label_motion.TabIndex = 32;
            this.label_motion.Text = "Ваш ход:";
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
            this.AnT_User.Location = new System.Drawing.Point(12, 38);
            this.AnT_User.Name = "AnT_User";
            this.AnT_User.Size = new System.Drawing.Size(350, 350);
            this.AnT_User.StencilBits = ((byte)(0));
            this.AnT_User.TabIndex = 27;
            // 
            // Game_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.label_motion);
            this.Controls.Add(this.label_opp);
            this.Controls.Add(this.AnT_Opponent);
            this.Controls.Add(this.button_give_up);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.AnT_User);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_Form_FormClosed);
            this.Load += new System.EventHandler(this.Game_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Button button_give_up;
        public System.Windows.Forms.Label label_opp;
        public Tao.Platform.Windows.SimpleOpenGlControl AnT_Opponent;
        public System.Windows.Forms.Label label_motion;
        public Tao.Platform.Windows.SimpleOpenGlControl AnT_User;
    }
}