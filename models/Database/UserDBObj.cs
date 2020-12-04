using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace api.models.Database
{
    public class UserDBObj
    {
        public List<User> GetAllUsers(){
            List<User> temp = new List<User>();

            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM User";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                temp.Add(new User(){UserID = rdr.GetInt32(0), UserName = rdr.GetString(1), UserType = rdr.GetString(2), UserFName = rdr.GetString(4), UserLName = rdr.GetString(5), TeamID = rdr.GetInt32(6)});
            }

            return temp;
        }

        public void UpdateUserTable(List<User> newUserTable){
            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "DROP TABLE IF EXISTS User";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE User(UserID INT PRIMARY KEY, UserName TEXT, UserType TEXT, isHidden BOOLEAN, UserFName TEXT, UserLName TEXT, TeamID INT)";
            cmd.ExecuteNonQuery();

            foreach(User user in newUserTable){
                    cmd.CommandText = @"INSERT INTO User(UserID, UserName, UserType, isHidden, UserFName, UserLName, TeamID) VALUES(@UserID, @UserName, @UserType, @isHidden, @UserFName, @UserLName, @TeamID)";
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@UserType", user.UserType);
                    cmd.Parameters.AddWithValue("@isHidden", false);
                    cmd.Parameters.AddWithValue("@UserFName", user.UserFName);
                    cmd.Parameters.AddWithValue("@UserLName", user.UserLName);
                    cmd.Parameters.AddWithValue("@TeamID", user.TeamID);
                /*else if (user.UserType == "Manager"){
                    cmd.CommandText = @"INSERT INTO User(UserID, UserName, UserType, isHidden, UserFName, UserLName, TeamID) VALUES(@UserID, @UserName, @UserType, @isHidden, @UserFName, @UserLName, @TeamID)";
                    cmd.Parameters.AddWithValue("@UserID", user.MgrID);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@UserType", user.UserType);
                    cmd.Parameters.AddWithValue("@isHidden", 0);
                    cmd.Parameters.AddWithValue("@UserFName", user.UserFName);
                    cmd.Parameters.AddWithValue("@UserLName", user.UserLName);
                    cmd.Parameters.AddWithValue("@TeamID", user.TeamID);
                }
                else if (user.UserType == "Partner"){
                    cmd.CommandText = @"INSERT INTO User(UserID, UserName, UserType, isHidden, UserFName, UserLName, TeamID) VALUES(@UserID, @UserName, @UserType, @isHidden, @UserFName, @UserLName, @TeamID)";
                    cmd.Parameters.AddWithValue("@UserID", user.PartnerID);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@UserType", user.UserType);
                    cmd.Parameters.AddWithValue("@isHidden", 0);
                    cmd.Parameters.AddWithValue("@UserFName", user.UserFName);
                    cmd.Parameters.AddWithValue("@UserLName", user.UserLName);
                    cmd.Parameters.AddWithValue("@TeamID", -1);
                }*/
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}