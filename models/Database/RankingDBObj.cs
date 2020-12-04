using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace api.models.Database
{
    public class RankingDBObj
    {
        public List<Rank> GetAllRankings(int id){
            List<Rank> temp = new List<Rank>();

            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Rank WHERE DestinationID = " + id;
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                temp.Add(new Rank(){DestinationID = rdr.GetInt32(2), RankScore = rdr.GetInt32(1)});
            }

            return temp;
        }

        public List<Rank> GetAllRankings(){
            List<Rank> temp = new List<Rank>();

            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Rank";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                temp.Add(new Rank(){DestinationID = rdr.GetInt32(2), RankScore = rdr.GetInt32(1)});
            }

            return temp;
        }

        public void PostRank(Rank obj){
            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();
            Console.WriteLine(obj.RankScore);
            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO Rank(DestinationID, Ranking) VALUES(@DestinationID, @Ranking)";
            cmd.Parameters.AddWithValue("@DestinationID", obj.DestinationID);
            cmd.Parameters.AddWithValue("@Ranking", obj.RankScore);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}