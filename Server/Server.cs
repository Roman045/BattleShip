using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace ServerForum
{
    class Server
    {
        public struct field { public int cl; public string f; }
        public static Queue<field> q;
        public static Random rnd;
        public static List<Client> Clients = new List<Client>();
        public static void NewClient(Socket handle)
        {
            try
            {
                Client newClient = new Client(handle);
                Clients.Add(newClient);
                Console.WriteLine("New client connected: {0}", handle.RemoteEndPoint);
            }
            catch (Exception exp) { Console.WriteLine("Error with addNewClient: {0}.", exp.Message); }
        }
        public static void EndClient(Client client)
        {
            try
            {
                Database.Online_User(client.UserName, 0);
                Console.WriteLine("Client {0} has been disconnected.", client.UserHandler.RemoteEndPoint);
                client.End();
                Clients.Remove(client);                
            }
            catch (Exception exp) { Console.WriteLine("Error with endClient: {0}.", exp.Message); }
        }
        public static void UpdateAllChats()
        {
            try
            {
                int countUsers = Clients.Count;
                for (int i = 0; i < countUsers; ++i)                
                    Clients[i].UpdateChat();                
            }
            catch (Exception exp) { Console.WriteLine("Error with updateAllChats: {0}.", exp.Message); }
        }
    }
}
