using MySql.Data.MySqlClient;
using System;

namespace api.models
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "sql9.freemysqlhosting.net";
            user = "sql9380318";
            database = "sql9380318";
            port = "3306";
            password = "Ugwl7TFVfi";

            string cs = "server="+server+";user="+user+";database="+database+";port="+port+";password="+password+";";
            connection = new MySqlConnection(cs);
        }

        public bool OpenConnection()
        {
            try{
                connection.Open();
                return true;
            }
            catch(MySqlException ex){
                if(ex.Number == 0){
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Cannot Connect");
                } else {
                    if(ex.Number == 1045){
                        Console.WriteLine("Invalid username/password");
                    }
                }
            }

            return false;
        }

        public bool CloseConnection(){
            try{
                connection.Close();
                return true;
            }
            catch(MySqlException ex){
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public MySqlConnection GetConnection(){
            return connection;
        }
    }
}