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


namespace coursework
{
    public partial class Registration_Form : Form
    {
        private delegate void printer(string data);
        printer Printer;
        public Registration_Form()
        {
            InitializeComponent();
            Printer = new printer(print);
            label_error.Hide();
            label_error.MaximumSize = new Size(200, 0);           
        }
        private void send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                Menu_Form._serverSocket.Send(buffer);
            }
            catch { MessageBox.Show("Связь с сервером прервалась..."); Menu_Form._serverSocket.Close(); print("Связь с сервером прервалась..."); }
        }
        private void print(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
        }
        private void label_enterMenu_Click(object sender, EventArgs e)
        {
            Menu_Form.exb_reg = 1;
            Menu_Form ifrm = (Menu_Form)Application.OpenForms["Menu_Form"];
            ifrm.Show();
            this.Close();
    }

        private void Registration_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Menu_Form.exb_reg == 0) 
                Application.Exit();
        }

        private void button_Registration_Click(object sender, EventArgs e)
        {            
            if (tB_userName.Text == "" || tB_userPassword.Text == "" || tB_userPassword.Text != tB_userPassword_repeat.Text)
            {
                label_error.Text = "Ошибка!!! Заполните все поля!!!";
                label_error.Show();
            }
            else
                send("#registration&" + tB_userName.Text + "$" + tB_userPassword.Text);
        }

    }
}
