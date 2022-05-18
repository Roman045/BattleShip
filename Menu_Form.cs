using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace coursework
{
    public partial class Menu_Form : Form
    {        
        private delegate void choice(string data);
        choice Choice;
        public static Socket _serverSocket;
        private Thread _clientThread;
        private const string _serverHost = "localhost";
        private const int _serverPort = 9933;
        public static int exb_reg = 0, motion = -1, handler;
        public string name_opp;
        public static int[,] op_f;        
        public static Point NCoords;
        public Menu_Form()
        {
            Glut.glutInit();
            InitializeComponent();
            Choice = new choice(print);
            connect();
            _clientThread = new Thread(listner);
            _clientThread.IsBackground = true;
            _clientThread.Start();
            label_error.Hide();
        }
        public void UpdateChat(string data)
        {
            //#updatechat&userName~data|username~data          
            ClientMenu_Form f2 = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
            if (f2 != null)
                f2.chatBox.Clear();
            string[] messages = data.Split('&')[1].Split('|');
            int countMessages = messages.Length;
            if (countMessages <= 0) return;
            for (int i = 0; i < countMessages; ++i)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    print(String.Format("[{0}]:{1}", messages[i].Split('~')[0], messages[i].Split('~')[1]));
                }
                catch { continue; }
            }
        }
        private void listner()
        {
            while (_serverSocket.Connected)
            {
                try
                {
                    byte[] buffer = new byte[8196];
                    int bytesRec = _serverSocket.Receive(buffer);                   
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                    if (data.Contains("#updatechat"))
                    {
                        UpdateChat(data);
                        continue;
                    }
                    print(data);
                }//_serverSocket.Shutdown(SocketShutdown.Both);
                catch { MessageBox.Show("Сервер недоступен!");  _serverSocket.Close(); print("Связь с сервером прервалась..."); }
            }
        }
        private void connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
                _serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Connect(ipEndPoint);
            }
            catch { MessageBox.Show("Сервер недоступен!"); _serverSocket.Close(); print("Сервер недоступен!"); }
        }
        private void print(string data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Choice, data);
                return;
            }
            if (data.Contains("#gameover"))
            {
                Game_Form f4 = (Game_Form)Application.OpenForms["Game_Form"];                
                ClientMenu_Form f2 = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
                f2.label_lose.Text = (int.Parse(f2.label_lose.Text) + 1).ToString();
                Game_Form.lose = 0;
                Game_Form.win = 0;
                MessageBox.Show("Игрок " + f2.label_userName.Text + " проиграл!!!");
                f4.Close();
                return;
            }
            if (data.Contains("#gamewin"))
            {                
                Game_Form f4 = (Game_Form)Application.OpenForms["Game_Form"];
                ClientMenu_Form f2 = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
                f2.label_win.Text = (int.Parse(f2.label_win.Text) + 1).ToString();
                MessageBox.Show("Игрок " + f2.label_userName.Text + " выиграл!!!");
                f4.Close();
                return;
            }
            if (data.Contains("#opp"))
            {
                data = data.Remove(0, 4);
                name_opp = data;
                motion = -2;
            }
            if (data.Contains("#game"))
            {
                handler = int.Parse(data[5].ToString());
                motion = int.Parse(data[6].ToString());
                data = data.Remove(0, 7);
                op_f = new int[10, 10];
                int k = 0;
                for (int i = 0; i < 10; ++i)
                    for (int j = 0; j < 10; ++j)
                    {
                        op_f[i, j] = int.Parse(data[k].ToString());
                        ++k;
                    }
                ClientMenu_Form f2 = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
                f2.label_random.Enabled = true;
                f2.label_reset.Enabled = true;
                f2.button_ready.Enabled = true;
                f2.button_cancel.Enabled = false;
                f2.Hide();
                Game_Form f4 = (Game_Form)Application.OpenForms["Game_Form"];
                f4 = new Game_Form();
                f4.label_opp.Text += name_opp;
                f4.label_user.Text = f2.label_userName.Text;
                f4.Show();
            }
            if (motion == -1)
            {
                ClientMenu_Form f2 = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
                if (f2 != null)                
                    if (f2.chatBox.Text.Length == 0)
                        f2.chatBox.AppendText(data);
                    else
                        f2.chatBox.AppendText(Environment.NewLine + data);                
            }            
            if (data.Contains("#motion"))
            {
                Game_Form f4 = (Game_Form)Application.OpenForms["Game_Form"];
                NCoords.X = int.Parse(data[8].ToString());
                NCoords.Y = int.Parse(data[9].ToString());
                motion = int.Parse(data[7].ToString());        
                if(motion == 0)
                {
                    ++motion;
                    f4.label_motion.Text = "Ваш ход:";
                    f4.AnT_User.Enabled = false;
                    f4.AnT_Opponent.Enabled = true;
                }                    
                else
                    f4.label_motion.Text = "Ход противника:";
                switch(ClientMenu_Form.mask[NCoords.X, NCoords.Y])
                {
                    case 0: 
                        ClientMenu_Form.mask[NCoords.X, NCoords.Y] = 2; 
                        break;
                    case 1:
                        {
                            ClientMenu_Form.mask[NCoords.X, NCoords.Y] = 3;
                            if (Game_Form.kill_ship(ClientMenu_Form.mask, NCoords) == 0)
                            {                                
                                ++Game_Form.lose;
                                Game_Form.Cell(ClientMenu_Form.mask, NCoords);
                            }
                            break;
                        }
                }
                f4.Draw_Zone(f4.AnT_User, ClientMenu_Form.f, ClientMenu_Form.mask);
                f4.Draw_Zone(f4.AnT_Opponent, Game_Form.f1, Game_Form.mask1);
            }            
            if (data.Contains("#successentry"))
            {
                label_error.Hide();
                Hide();                
                ClientMenu_Form f2 = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
                if (f2 == null)
                {
                    string words = "";
                    f2 = new ClientMenu_Form();
                    data = data.Remove(0, 13);
                    for (int i = 0; i < data.Length; ++i)                    
                        if(data[i] != '|')
                            words += data[i];
                        else
                        {
                            f2.label_win.Text = words;
                            words = "";
                        }                                                                   
                    f2.label_lose.Text = words;
                    f2.label_userName.Text = tB_userName.Text;
                    f2.label_userPassword.Text = tB_userPassword.Text;
                    tB_userName.Text = "Логин";
                    tB_userPassword.Text = "Пароль";
                    f2.Show();
                    return;
                }
            }
            switch (data)
            {                
                case "#errorentry":
                    label_error.Text = "Ошибка!!! Неверно введены Логин или Пароль!!!";
                    label_error.Show();
                    tB_userName.Text = "Логин";
                    tB_userPassword.Text = "Пароль";
                    break;
                case "#errorreg":
                    {
                        Registration_Form ifrm = (Registration_Form)Application.OpenForms["Registration_Form"];
                        ifrm.label_error.Text = "Ошибка!!! Неверно введены Логин или Пароль!!!";
                        tB_userName.Text = "Логин";
                        tB_userPassword.Text = "Пароль";
                        ifrm.label_error.Show();
                        break;
                    }
                case "#successreg":
                    {
                        exb_reg = 1;
                        Registration_Form ifrm = (Registration_Form)Application.OpenForms["Registration_Form"];
                        ifrm.label_error.Show();
                        ifrm.label_error.Text = "Регистрация прошла успешна!!!";
                        tB_userName.Text = "Логин";
                        tB_userPassword.Text = "Пароль";
                        ifrm.Close();
                        Show();
                        break;
                    }
            }
        }
        private void send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                _serverSocket.Send(buffer);
            }
            catch { MessageBox.Show("Связь с сервером прервалась..."); _serverSocket.Close(); print("Связь с сервером прервалась..."); }            
        }

        private void label_Registration_Click(object sender, EventArgs e)
        {
            Hide();
            Registration_Form f3 = (Registration_Form)Application.OpenForms["Registration_Form"];
            if (f3 == null)
            {
                f3 = new Registration_Form();
                f3.Show();
            }
        }
        private void button_enterChat_Click(object sender, EventArgs e)
        {
            if (tB_userName.Text == "" || tB_userPassword.Text == "")
            {
                label_error.Text = "Ошибка!!! Заполните все поля!!!";
                label_error.Show();
            }
            else
                send("#setname&" + tB_userName.Text + "$" + tB_userPassword.Text);          
        }
    }
}
