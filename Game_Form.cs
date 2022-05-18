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
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;


namespace coursework
{
    public partial class Game_Form : Form
    {
        private delegate void printer(string data);
        printer Printer;
        float ScreenW = 125, ScreenH = 125, devX, devY;
        public static ClientMenu_Form.field[,] f1;
        public static int[,] mask1;
        public static int win = 0, lose = 0;
        public Game_Form()
        {
            InitializeComponent();
            AnT_User.InitializeContexts();
            AnT_Opponent.InitializeContexts();
            Printer = new printer(print);
        }
        private void Game_Form_Load(object sender, EventArgs e)
        {
            devX = ScreenW / AnT_User.Width;
            devY = ScreenH / AnT_User.Height;            
            Ant_User_Load();
            Ant_Opponent_Load();
            if (Menu_Form.motion == 1)
            {
                label_motion.Text = "Ваш ход:";
                AnT_User.Enabled = false;
                AnT_Opponent.Enabled = true;
            }
            else
            {
                label_motion.Text = "Ход противника:";
                AnT_User.Enabled = true;
                AnT_Opponent.Enabled = false;
            }
        }
        private void Ant_User_Load()
        {
            AnT_User.MakeCurrent();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT_User.Width, AnT_User.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, ScreenW, 0, ScreenH);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Draw_Zone(AnT_User, ClientMenu_Form.f, ClientMenu_Form.mask);
        }
        private void Ant_Opponent_Load()
        {
            f1 = new ClientMenu_Form.field[10, 10];
            mask1 = new int[10, 10];
            int k = 0;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    mask1[i, j]  = 0;
                    f1[i, j].left.X = 10 + k * 11;
                    f1[i, j].right.X = f1[i, j].left.X + 11;
                    f1[i, j].left.Y = 104 - i * 11;
                    f1[i, j].right.Y = 115 - i * 11;
                    ++k;
                }
                k = 0;
            }
            AnT_Opponent.MakeCurrent();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT_Opponent.Width, AnT_Opponent.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, ScreenW, 0, ScreenH);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Draw_Zone(AnT_Opponent, f1, mask1);
        }
        private void print(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
        }     
        private Point Check_in_rect(double x, double y)
        {
            Point n = new Point(-1, -1);
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)
                    if (x > f1[i, j].left.X && x < f1[i, j].right.X && y > f1[i, j].left.Y && y < f1[i, j].right.Y)
                    {
                        n.X = i;
                        n.Y = j;
                        return n;
                    }
            return n;
        }
        public static void Cell(int[,] mask, Point p)
        {
            int[,] d = new int[8, 2] { { -1, 1 }, { -1, -1 }, { 1, -1 }, { 1, 1 }, { 1, 0 }, { 0, -1 }, { 0, 1 }, { -1, 0 } };
            int m = 0, h, dx, dy;
            int[,] a = new int[2, 2];
            mask[p.X, p.Y]  = 4;
            while (m != -1)
            {
                a[m, 0] = -1;
                a[m, 1] = -1;
                h = 0;
                for (int i = 0; i < 8; ++i)
                {
                    dx = p.X + d[i, 0];
                    dy = p.Y + d[i, 1];
                    if (dx >= 0 && dx < 10 && dy >= 0 && dy < 10)
                    {
                        if (mask[dx, dy]  == 0)
                            mask[dx, dy]  = 2;
                        if (mask[dx, dy] == 3) 
                        {
                            ++h;
                            mask[dx, dy]  = 4;
                            a[m, 0] = dx;
                            a[m, 1] = dy;
                            if (m < 1) ++m;
                        }
                    }
                }
                if (h == 0 || h == 1) --m;
                if (m > -1) 
                {
                    p.X = a[m, 0];
                    p.Y = a[m, 1];
                }                
            }
        }       
        public static int kill_ship(int[,] f, Point p)
        {
            int[,] d = new int[4, 2] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            int dx = -2, dy = -2, n = 0, k = 0;
            for (int i = 0; i < 4; ++i)
            {
                dx = p.X + d[i, 0];
                dy = p.Y + d[i, 1];
                if (dx >= 0 && dx < 10 && dy >= 0 && dy < 10 && f[dx, dy] == 1)
                {
                    k = 1;
                    ++n;
                    break;
                }
            }
            if (n == 0 && k == 0)
            {
                for (int i = 0; i < 4; ++i)
                {
                    dx = p.X + d[i, 0];
                    dy = p.Y + d[i, 1];
                    if (dx >= 0 && dx < 10 && dy >= 0 && dy < 10 && f[dx, dy] == 3)
                    {
                        if (d[i, 0] == 0)
                        {
                            dx = p.X;
                            dy = p.Y;
                            for (int j = 0; j < 4; ++j)
                            {
                                dy -= 1;
                                if (dy >= 0 && dy < 10 && (f[dx, dy] == 2 || f[dx, dy] == 0))
                                    break;
                            }
                            for (int j = 0; j < 4; ++j)
                            {
                                dy += 1;
                                if (dy >= 0 && dy < 10 && f[dx, dy] == 1)
                                {
                                    ++n;
                                    break;
                                }
                            }
                        }
                        if (d[i, 1] == 0)
                        {
                            dx = p.X;
                            dy = p.Y;
                            for (int j = 0; j < 4; ++j)
                            {
                                dx -= 1;
                                if (dx >= 0 && dx < 10 && (f[dx, dy] == 2 || f[dx, dy] == 0))
                                    break;
                            }
                            for (int j = 0; j < 4; ++j)
                            {
                                dx += 1;
                                if (dx >= 0 && dx < 10 && f[dx, dy] == 1)
                                {
                                    ++n;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
            }

            if (n > 0)
                return 1;
            else
                return 0;
        }
        private void AnT_Opponent_MouseDown(object sender, MouseEventArgs e)
        {
            Point r = Check_in_rect(devX * e.X, ScreenH - devY * e.Y);
            if (mask1[r.X, r.Y]  == 0)
            {
                if (Menu_Form.op_f[r.X, r.Y] == 1)  
                {
                    mask1[r.X, r.Y]  = 3;
                    Menu_Form.op_f[r.X, r.Y] = 3;
                    if (kill_ship(Menu_Form.op_f, r) == 0)
                    {                        
                        ++win;
                        Cell(mask1, r);
                    }                        
                }
                else
                {
                    mask1[r.X, r.Y]  = 2;
                    if (Menu_Form.motion == 1)
                        Menu_Form.motion = 0;
                    AnT_User.Enabled = true;
                    AnT_Opponent.Enabled = false;
                    label_motion.Text = "Ход противника";                    
                }
                send("#motion" + r.X.ToString() + r.Y.ToString() + Menu_Form.motion + Menu_Form.handler.ToString());
                Draw_Zone(AnT_Opponent, f1,mask1);
                Draw_Zone(AnT_User, ClientMenu_Form.f, ClientMenu_Form.mask) ;
                if (win == 10)                
                    this.Close();                
            }                         
        }
        private void button_give_up_Click(object sender, EventArgs e)
        {
            lose = 10;
            this.Close();
        }
        private void Game_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (lose == 10)
            {
                ClientMenu_Form f2 = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
                f2.label_lose.Text = (int.Parse(f2.label_lose.Text) + 1).ToString();
                send("#gameover" + Menu_Form.handler.ToString());
                MessageBox.Show("Игрок " + f2.label_userName.Text + " проиграл!!!");
            }
            if (win == 10)
            {
                ClientMenu_Form f2 = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
                f2.label_win.Text = (int.Parse(f2.label_win.Text) + 1).ToString();
                send("#gamewin" + Menu_Form.handler.ToString());
                MessageBox.Show("Игрок " + f2.label_userName.Text + " выиграл!!!");
            }
            win = 0;
            lose = 0;
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)
                {
                    Menu_Form.op_f[i, j] = 0;
                    if (ClientMenu_Form.mask[i, j]  == 4)
                        ClientMenu_Form.mask[i, j]  = 1;
                    if (ClientMenu_Form.mask[i, j]  == 2)
                        ClientMenu_Form.mask[i, j]  = 0;
                }
            Menu_Form.motion = -1;
            ClientMenu_Form ifrm = (ClientMenu_Form)Application.OpenForms["ClientMenu_Form"];
            ifrm.timer.Start();
            ifrm.Show();
        }
        public void Draw_Zone(SimpleOpenGlControl AnT, ClientMenu_Form.field[,] f , int[,] mask)
        {
            AnT.MakeCurrent();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            char ch = 'A';
            for (float i = 10; i <= 120; i += 11)
            {
                Gl.glColor3d(0, 0, 0);
                string str = ch.ToString();
                if (i < 115) PrintText2D(i + 4, 118, str);
                ++ch;
                Gl.glColor3d(0.258, 0.517, 0.827);
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex2f(i, 5);
                Gl.glVertex2f(i, 115);
                Gl.glEnd();
            }
            ch = '1';
            for (float i = 115; i >= 5; i -= 11)
            {
                Gl.glColor3d(0, 0, 0);
                if (ch <= '9')
                {
                    string str = ch.ToString();
                    PrintText2D(3, i - 7, str);
                    ++ch;
                }
                else if (i > 10) PrintText2D(2, i - 7, "10");
                Gl.glColor3d(0.258, 0.517, 0.827);
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex2f(10, i);
                Gl.glVertex2f(120, i);
                Gl.glEnd();
            }
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)               
                    switch (mask[i, j])
                        {                            
                            case 1: 
                            {
                                Gl.glColor3d(0, 0, 1);                                
                                Gl.glRectd(f[i, j].left.X, f[i, j].left.Y, f[i, j].right.X, f[i, j].right.Y); 
                                break;
                            }
                            case 2: 
                            { 
                                Gl.glColor3d(0, 0, 0);
                                Gl.glPointSize(5);
                                Gl.glEnable(Gl.GL_POINT_SMOOTH);                                
                                Gl.glBegin(Gl.GL_POINTS);
                                Gl.glVertex2d(f[i, j].left.X + 5.5, f[i, j].left.Y + 5.5);
                                Gl.glEnd();
                                Gl.glDisable(Gl.GL_POINT_SMOOTH);
                                break; 
                            }
                            case 3:
                            {
                                
                                Gl.glColor3d(0, 0, 1);
                                Gl.glRectd(f[i, j].left.X, f[i, j].left.Y, f[i, j].right.X, f[i, j].right.Y);
                                Gl.glColor3d(0.75, 0, 0);
                                Gl.glLineWidth(3);
                                Gl.glBegin(Gl.GL_LINES);
                                Gl.glVertex2d(f[i, j].left.X, f[i, j].left.Y);
                                Gl.glVertex2d(f[i, j].right.X, f[i, j].right.Y);
                                Gl.glVertex2d(f[i, j].left.X, f[i, j].right.Y);
                                Gl.glVertex2d(f[i, j].right.X, f[i, j].left.Y);
                                Gl.glEnd();
                                Gl.glLineWidth(1);
                                break;
                            }
                        case 4:
                            {
                                Gl.glColor3d(0, 0, 1);
                                Gl.glRectd(f[i, j].left.X, f[i, j].left.Y, f[i, j].right.X, f[i, j].right.Y);
                                Gl.glColor3d(0.75, 0, 0);
                                Gl.glLineWidth(3);
                                Gl.glBegin(Gl.GL_LINES);
                                Gl.glVertex2d(f[i, j].left.X, f[i, j].left.Y);
                                Gl.glVertex2d(f[i, j].right.X, f[i, j].right.Y);
                                Gl.glVertex2d(f[i, j].left.X, f[i, j].right.Y);
                                Gl.glVertex2d(f[i, j].right.X, f[i, j].left.Y);
                                Gl.glEnd();
                                Gl.glLineWidth(1);
                                break;
                            }
                    }                
            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }
        public void PrintText2D(double x, double y, string text)
        {
            Gl.glRasterPos2d(x, y);
            foreach (char char_for_draw in text)
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_12, char_for_draw);
        }
        private void send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                Menu_Form._serverSocket.Send(buffer);
            }
            catch { MessageBox.Show("Связь с сервером прервалась..."); Menu_Form._serverSocket.Shutdown(SocketShutdown.Both); Menu_Form._serverSocket.Close(); print("Связь с сервером прервалась..."); }
        }
    }
}
