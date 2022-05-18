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
    public partial class ClientMenu_Form : Form
    {
        private delegate void printer(string data);
        printer Printer;
        public struct field { public Point left, right; }
        float ScreenW = 125, ScreenH = 125, devX, devY;
        public static int[,] mask;
        public static field[,] f;
        int[] ship;

        public ClientMenu_Form()
        {
            InitializeComponent();
            //Glut.glutInit();
            AnT_User.InitializeContexts();
            Printer = new printer(print);
        }
        private void print(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
        }
        private void send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                Menu_Form._serverSocket.Send(buffer);
            } //Menu_Form._serverSocket.Shutdown(SocketShutdown.Both);
            catch { MessageBox.Show("Связь с сервером прервалась...");  Menu_Form._serverSocket.Close(); print("Связь с сервером прервалась..."); }
        }
        private void sendMessage()
        {
            try
            {
                string data = chat_msg.Text;
                if (string.IsNullOrEmpty(data)) return;
                chatBox.Clear();
                send("#newmsg&" + data);
                chat_msg.Text = string.Empty;
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }
        private void chat_send_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void chatBox_KeyDown(object sender, KeyEventArgs e)
        {
            sendMessage();
        }

        private void chat_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                sendMessage();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            chatBox.Clear();            
            this.Close();
        }

        private void ClientMenu_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            chatBox.Clear();
            Menu_Form ifrm = (Menu_Form)Application.OpenForms["Menu_Form"];
            send("#userexit");
            ifrm.Show();
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            send("#userdelete");            
            chatBox.Clear();
            Menu_Form ifrm = (Menu_Form)Application.OpenForms["Menu_Form"];
            ifrm.Show();
            this.Close();
        }
        private void rB_singledeck_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_singledeck.Checked) gB_Position.Enabled = false;
            else gB_Position.Enabled = true;            
        }
        private Point Check_in_rect(double x, double y)
        {
            Point n = new Point(-1, -1);
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)
                    if (x > f[i, j].left.X && x < f[i, j].right.X && y > f[i, j].left.Y && y < f[i, j].right.Y)
                    {
                        n.X = i;
                        n.Y = j;
                        return n;
                    }
            return n;
        }
        private int Check_cell(Point p)
        {
            if ((p.X > 9 || p.Y > 9) || mask[p.X, p.Y]  != 0) return 1;
            else
            {
                int[,] d = new int[8, 2] { { -1, 1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, -1 }, { -1, 0 } };
                int dx, dy;
                for (int i = 0; i < 8; ++i)
                {
                    dx = p.X + d[i, 0];
                    dy = p.Y + d[i, 1];
                    if (dx >= 0 && dx < 10 && dy >= 0 && dy < 10 && mask[dx, dy] != 0)
                        return 1;
                }
            }
            return 0;
        }
        private void init_field(field[,] f)
        {
            button_cancel.Enabled = false;
            button_ready.Enabled = false;
            int k = 0;
            for (int i = 0; i < 4; ++i)
                ship[i] = 0;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    mask[i, j]  = 0;
                    f[i, j].left.X = 10 + k * 11;
                    f[i, j].right.X = f[i, j].left.X + 11;
                    f[i, j].left.Y = 104 - i * 11;
                    f[i, j].right.Y = 115 - i * 11;
                    ++k;
                }
                k = 0;
            }
        }
        private void label_reset_Click(object sender, EventArgs e)
        {
            init_field(f);
            rB_singledeck.Checked = false;
            rB_doubledeck.Checked = false;
            rB_threedeck.Checked = false;
            rB_fourdeck.Checked = false;
            rB_singledeck.Enabled = true;
            rB_doubledeck.Enabled = true;
            rB_threedeck.Enabled = true;
            rB_fourdeck.Enabled = true;
            gB_Position.Enabled = true;
            gB_Rank.Enabled = true;
        }
        private void label_random_Click(object sender, EventArgs e)
        {
            init_field(f);
            Random rnd = new Random();
            int kx, ky;
            int b;
            Point p = new Point(-1, -1);
            for (int i = 3; i >= 0; --i)
                for (int j = 0; j <= 3 - i; ++j)
                    do
                    {
                        p.X = rnd.Next(0, 10) + 1;
                        p.Y = rnd.Next(0, 10) + 1;
                        kx = rnd.Next(0, 2);
                        if (kx == 1) ky = 0; else ky = 1;
                        b = 0;
                        for (int h = 0; h <= i; ++h)
                        {
                            Point temp = new Point();
                            temp.X = p.X + kx * h;
                            temp.Y = p.Y + ky * h;
                            if (Check_cell(temp) == 1)
                                b = 1;
                        }
                        if (b == 0)
                            for (int h = 0; h <= i; ++h)
                                mask[p.X + h * kx, p.Y + h * ky]  = 1;
                    } while (b == 1);
            button_ready.Enabled = true;
            gB_Position.Enabled = false;
            gB_Rank.Enabled = false;
            for (int i = 0; i < 4; ++i)
                ship[i] = 4 - i;
        }
        private void AnT_User_MouseDown(object sender, MouseEventArgs e)
        {
            Point r = Check_in_rect(devX * e.X, ScreenH - devY * e.Y);
            int b = 0;
            if (rB_singledeck.Checked == true && ship[0] < 4 && r.X != -1)
                if (Check_cell(r) == 0)
                {
                    ++ship[0];
                    if (ship[0] == 4) { rB_singledeck.Checked = false; rB_singledeck.Enabled = false; }
                    mask[r.X, r.Y]  = 1;
                }
            if (rB_doubledeck.Checked == true && ship[1] < 3 && r.X != -1 && (rB_Vertical.Checked == true || rB_Horizontal.Checked == true))
            {
                for (int i = 0; i <= 1; ++i)
                {
                    if (rB_Horizontal.Checked == true)
                    {
                        if (r.Y > 9 || Check_cell(r) != 0)
                        {
                            b = 1;
                            break;
                        }
                        r.Y += 1;
                    }
                    else if (rB_Vertical.Checked == true)
                    {
                        if (r.X > 9 || Check_cell(r) != 0)
                        {
                            b = 1;
                            break;
                        }
                        r.X += 1;
                    }
                }
                if (b == 0)
                {
                    r = Check_in_rect(devX * e.X, ScreenH - devY * e.Y);
                    for (int i = 0; i <= 1; ++i)
                    {
                        mask[r.X, r.Y]  = 1;
                        if (rB_Horizontal.Checked == true)
                            r.Y += 1;
                        else if (rB_Vertical.Checked == true)
                            r.X += 1;
                    }
                    ++ship[1];
                    if (ship[1] == 3) { rB_doubledeck.Checked = false; rB_doubledeck.Enabled = false; }
                }
            }
            if (rB_threedeck.Checked == true && ship[2] < 2 && r.X != -1 && (rB_Vertical.Checked == true || rB_Horizontal.Checked == true))
            {
                for (int i = 0; i <= 2; ++i)
                {
                    if (rB_Horizontal.Checked == true)
                    {
                        if (r.Y > 9 || Check_cell(r) != 0)
                        {
                            b = 1;
                            break;
                        }
                        r.Y += 1;
                    }
                    else if (rB_Vertical.Checked == true)
                    {
                        if (r.X > 9 || Check_cell(r) != 0)
                        {
                            b = 1;
                            break;
                        }
                        r.X += 1;
                    }
                }
                if (b == 0)
                {
                    r = Check_in_rect(devX * e.X, ScreenH - devY * e.Y);
                    for (int i = 0; i <= 2; ++i)
                    {
                        mask[r.X, r.Y]  = 1;
                        if (rB_Horizontal.Checked == true)
                            r.Y += 1;
                        else if (rB_Vertical.Checked == true)
                            r.X += 1;
                    }
                    ++ship[2];
                    if (ship[2] == 2) { rB_threedeck.Checked = false; rB_threedeck.Enabled = false; }
                }
            }
            if (rB_fourdeck.Checked == true && ship[3] < 1 && r.X != -1 && (rB_Vertical.Checked == true || rB_Horizontal.Checked == true))
            {
                for (int i = 0; i <= 3; ++i)
                {
                    if (rB_Horizontal.Checked == true)
                    {
                        if (r.Y > 9 || Check_cell(r) != 0)
                        {
                            b = 1;
                            break;
                        }
                        r.Y += 1;
                    }
                    else if (rB_Vertical.Checked == true)
                    {
                        if (r.X > 9 || Check_cell(r) != 0)
                        {
                            b = 1;
                            break;
                        }
                        r.X += 1;
                    }
                }
                if (b == 0)
                {
                    r = Check_in_rect(devX * e.X, ScreenH - devY * e.Y);
                    for (int i = 0; i <= 3; ++i)
                    {
                        mask[r.X, r.Y]  = 1;
                        if (rB_Horizontal.Checked == true)
                            r.Y += 1;
                        else if (rB_Vertical.Checked == true)
                            r.X += 1;
                    }
                    ++ship[3];
                    if (ship[3] == 1) { rB_fourdeck.Checked = false; rB_fourdeck.Enabled = false; }
                }
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Draw_Zone();
            int sum = 0;
            for (int i = 0; i < 4; ++i)
                sum += ship[i];
            if (sum == 10)
            {                
                button_ready.Enabled = true;
                gB_Position.Enabled = false;
                gB_Rank.Enabled = false;
                rB_singledeck.Enabled = true;
                rB_doubledeck.Enabled = true;
                rB_threedeck.Enabled = true;
                rB_fourdeck.Enabled = true;
            }
        }
        private void button_ready_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)
                    str += mask[i, j].ToString();
            send("#ready" + str);
            button_ready.Enabled = false;
            button_cancel.Enabled = true;
            label_random.Enabled = false;
            label_reset.Enabled = false;
            timer.Stop();
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            send("#cancel");
            button_ready.Enabled = true;
            button_cancel.Enabled = false;
            label_random.Enabled = true;
            label_reset.Enabled = true;
            timer.Start();
        }
        private void ClientMenu_Form_Load(object sender, EventArgs e)
        {
            devX = ScreenW / AnT_User.Width;
            devY = ScreenH / AnT_User.Height;
            f = new field[10, 10];
            mask = new int[10, 10];
            ship = new int[4];
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT_User.Width, AnT_User.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, ScreenW, 0, ScreenH);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            init_field(f);
            timer.Start();
        }
        private void Draw_Zone()
        {
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
                    if (mask[i, j]  == 1)
                    {
                        Gl.glColor3d(0, 0, 1);
                        Gl.glRectd(f[i, j].left.X, f[i, j].left.Y, f[i, j].right.X, f[i, j].right.Y);
                    }            
            Gl.glPopMatrix();
            Gl.glFlush();
            AnT_User.Invalidate();
        }
        private void PrintText2D(double x, double y, string text)
        {
            Gl.glRasterPos2d(x, y);
            foreach (char char_for_draw in text)
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_12, char_for_draw);
        }
    }
}