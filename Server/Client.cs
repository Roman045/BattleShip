using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace ServerForum
{
    class Client
    {
        private string _userName;
        private string _userPassword;
        private Socket _handler;
        private Thread _userThread;
        private Random rnd;
        public static List<OnlineName> ListName = new List<OnlineName>();
        Server.field temp;
        public struct OnlineName
        {
            public int number;
            public string name;
            public OnlineName(int n, string UserName)
            {
                name = UserName;
                number = n;
            }
        }
        public Client(Socket socket)
        {
            _handler = socket;
            _userThread = new Thread(listner);
            _userThread.IsBackground = true;
            _userThread.Start();
        }
        public string UserName
        {
            get { return _userName; }
        }
        public Socket UserHandler
        {
            get { return _handler; }
        }
        private void listner()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytesRec = _handler.Receive(buffer);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                    handleCommand(data);
                }
                catch { Server.EndClient(this); return; }
            }
        }
        public void End()
        {
            try
            {
                _handler.Close();
                try
                {
                    _userThread.Abort();
                }
                catch { }
            }
            catch (Exception exp) { Console.WriteLine("Error with end: {0}.", exp.Message); }
        }
        private void handleCommand(string data)
        {
            if (data.Contains("#gamewin"))
            {
                data = data.Remove(0, 8);
                Database.Count_win(_userName);
                Database.Count_lose(Server.Clients[int.Parse(data)]._userName);
                Send(Server.Clients[int.Parse(data)]._handler, "#gameover");
            }
            if (data.Contains("#gameover"))
            {
                data = data.Remove(0, 9);
                Database.Count_lose(_userName);
                Database.Count_win(Server.Clients[int.Parse(data)]._userName);
                Send(Server.Clients[int.Parse(data)]._handler, "#gamewin");
            }
            if (data.Contains("cancel"))
            {
                Server.q.Dequeue();
                return;
            }
            if (data.Contains("#motion"))
            {
                int x = int.Parse(data[7].ToString()), y = int.Parse(data[8].ToString()), m = int.Parse(data[9].ToString());
                data = data.Remove(0, 10);
                Send(Server.Clients[int.Parse(data)]._handler, "#motion" + m.ToString() + x.ToString() + y.ToString());
                return;
            }
            if (data.Contains("#ready"))
            {
                for (int i = 0; i < Server.Clients.Count; ++i)
                    if (_handler == Server.Clients[i]._handler)
                    {
                        temp.cl = i;
                        break;
                    }
                data = data.Remove(0, 6);
                temp.f = data;
                Server.q.Enqueue(temp);
                if (Server.q.Count == 2)
                {
                    rnd = new Random();
                    int r = rnd.Next(2);
                    temp = Server.q.Dequeue();
                    Send("#opp" + Server.Clients[temp.cl].UserName);
                    Send("#game" + temp.cl.ToString() + r.ToString() + temp.f);
                    int i = temp.cl;
                    temp = Server.q.Dequeue();
                    Send(Server.Clients[i]._handler, "#opp" + Server.Clients[temp.cl].UserName);
                    Send(Server.Clients[i]._handler, "#game" + temp.cl.ToString() + (1 - r).ToString() + temp.f);
                }
                return;
            }
            if (data.Contains("#userdelete"))
            {
                Console.WriteLine("User {0} has been deleted.", _userName);
                Database.Delete_UserData(_userName);
                _userName = "";
                _userPassword = "";
                return;
            }
            if (data.Contains("#userexit"))
            {
                Database.Online_User(_userName, 0);
                Console.WriteLine("User {0} has been disconnected.", _userName);
                _userName = "";
                _userPassword = "";
                return;
            }
            if (data.Contains("#setname"))
            {
                _userName = data.Split('&', '$')[1];
                _userPassword = data.Split('$')[1];
                int name_id = Database.Exist_UserName(_userName);
                if (name_id == -1)
                {
                    _userName = "";
                    _userPassword = "";
                    Send("#errorentry");
                    return;
                }
                else
                {
                    if (Database.Exist_UserPassword(name_id, _userPassword) == -1)
                    {
                        _userName = "";
                        _userPassword = "";
                        Send("#errorentry");
                        return;
                    }
                }
                if (Database.Online_User(_userName) == 1)
                {
                    _userName = "";
                    _userPassword = "";
                    Send("#errorentry");
                    return;
                }
                Database.Online_User(_userName, 1);
                Console.WriteLine("User {0} connected.", _userName);
                Send("#successentry" + Database.Get_Game(_userName));
                UpdateChat();
                return;
            }
            if (data.Contains("#newmsg"))
            {
                string message = data.Split('&')[1];
                ChatController.AddMessage(_userName, message);
                return;
            }
            if (data.Contains("#registration"))
            {
                _userName = data.Split('&', '$')[1];
                _userPassword = data.Split('$')[1];
                if (Database.Exist_UserName(_userName) == -1)
                {
                    Database.Add_UserData(_userName, _userPassword);
                    _userName = "";
                    _userPassword = "";
                    Send("#successreg");
                    return;
                }
                else
                {
                    _userName = "";
                    _userPassword = "";
                    Send("#errorreg");
                    return;
                }
            }
        }
        public void UpdateChat()
        {
            Send(ChatController.GetChat());
        }
        private void Send(Socket handler, string command)
        {
            try
            {
                int bytesSent = handler.Send(Encoding.UTF8.GetBytes(command));
            }
            catch (Exception exp) { Console.WriteLine("Error with send command: {0}.", exp.Message); Server.EndClient(this); }
        }
        public void Send(string command)
        {
            try
            {
                int bytesSent = _handler.Send(Encoding.UTF8.GetBytes(command));
            }
            catch (Exception exp) { Console.WriteLine("Error with send command: {0}.", exp.Message); Server.EndClient(this); }
        }
    }
}
