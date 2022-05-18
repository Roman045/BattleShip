using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace ServerForum
{
    class Database
    {
        static SqlConnection sqlConnection;
        public static void Connect_DB()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="D:\Обучение\Операционные системы\coursework\Server\Database.mdf";Integrated Security=True
            sqlConnection.Open();
        }
        public static void Count_win(string name)
        {
            SqlCommand command = new SqlCommand(
                $"UPDATE [Personal_Data] SET UserCountWin=UserCountWin+1 WHERE UserName='" + name + "'",
                sqlConnection);
            command.ExecuteNonQuery();
        }
        public static void Count_lose(string name)
        {
            SqlCommand command = new SqlCommand(
                $"UPDATE [Personal_Data] SET UserCountLose=UserCountLose+1 WHERE UserName='" + name + "'",
                sqlConnection);
            command.ExecuteNonQuery();
        }
        public static string Get_Game(string name)
        {
            string res;
            int t = 0;
            SqlCommand command = new SqlCommand(
                $"SELECT UserCountWin FROM [Personal_Data] WHERE UserName='" + name + "'",
                sqlConnection);
            if (command.ExecuteScalar() != null)
                t = (int)command.ExecuteScalar();
            res = t.ToString() + '|';
            command = new SqlCommand(
                $"SELECT UserCountLose FROM [Personal_Data] WHERE UserName='" + name + "'",
                sqlConnection);
            if (command.ExecuteScalar() != null)
                t = (int)command.ExecuteScalar();
            res += t.ToString();
            return res;
        }
        public static int Exist_UserName(string name)
        {
            SqlCommand command = new SqlCommand(
                $"SELECT Id FROM [Personal_Data] GROUP BY Id,UserName HAVING UserName='" + name + "'",
                sqlConnection);
            if (command.ExecuteScalar() == null) return -1;
            else return (int)command.ExecuteScalar();
        }
        public static int Exist_UserPassword(int id, string password)
        {
            SqlCommand command = new SqlCommand(
                $"SELECT Id FROM [Personal_Data] GROUP BY Id,UserPassword HAVING UserPassword='" + password + "' AND Id='" + id + "'",
                sqlConnection);
            if (command.ExecuteScalar() == null) return -1;
            else return (int)command.ExecuteScalar();
        }
        public static int Online_User(string name)
        {
            SqlCommand command = new SqlCommand(
               $"SELECT UserOnline FROM [Personal_Data] WHERE UserName='" + name + "'",
               sqlConnection);
            if (command.ExecuteScalar() == null) return -1;
            else return (int)command.ExecuteScalar();
        }
        public static void Add_UserData(string name, string password)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT [Personal_Data] (UserName,UserPassword,UserOnline,UserCountWin,UserCountLose) VALUES (@UserName,@UserPassword,@UserOnline" +
                $",@UserCountWin,@UserCountLose)",
                sqlConnection);
            command.Parameters.AddWithValue("@UserName", name);
            command.Parameters.AddWithValue("@UserPassword", password);
            command.Parameters.AddWithValue("@UserOnline", "0");
            command.Parameters.AddWithValue("@UserCountWin", 0);
            command.Parameters.AddWithValue("@UserCountLose", 0);

            command.ExecuteNonQuery();
        }
        public static void Online_User(string name,int c)
        {
            SqlCommand command = new SqlCommand(
               $"UPDATE [Personal_Data] SET UserOnline='"+ c +"' WHERE UserName='" + name + "'",
               sqlConnection);
            command.ExecuteNonQuery();
        }
        public static void Online_User()
        {
            SqlCommand command = new SqlCommand(
               $"UPDATE [Personal_Data] SET UserOnline='" + 0 + "'",
               sqlConnection);
            command.ExecuteNonQuery();
        }
        public static void Delete_UserData(string name)
        {
            SqlCommand command = new SqlCommand(
               $"DELETE FROM [Personal_Data] WHERE UserName='" + name + "'",
               sqlConnection);
            command.ExecuteNonQuery();
        }
        public static void Add_message(string name, string msg)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT [History_Messages] (UserName,Message) VALUES (@UserName,@Message)",
                sqlConnection);
            command.Parameters.AddWithValue("@UserName", name);
            command.Parameters.AddWithValue("@Message", msg);
            command.ExecuteNonQuery();
        }

        public static void Get_messages()
        {
            SqlDataReader dataReader = null;
            try
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM [History_Messages]", sqlConnection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ChatController.message newMessage = new ChatController.message(Convert.ToString(dataReader["UserName"]), Convert.ToString(dataReader["Message"]));
                    ChatController.Chat.Add(newMessage);
                }
            }
            catch (Exception ex){ Console.WriteLine(ex.Message); }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)                
                    dataReader.Close();                
            }
        }
    }
}
