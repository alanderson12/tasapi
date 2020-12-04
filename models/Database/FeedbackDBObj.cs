using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace api.models.Database
{
    public class FeedbackDBObj
    {
        public List<Feedback> GetAllFeedback(int id){
            List<Feedback> temp = new List<Feedback>();

            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Feedback WHERE destinationID = " + id;
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                temp.Add(new Feedback(){DestinationID = rdr.GetInt32(0), ReviewMessage = rdr.GetString(1), 
                    NumQuestions = rdr.GetInt32(2), 
                    ScoreTotal = rdr.GetInt32(3), EditTracking = rdr.GetString(4), FinalScore = rdr.GetDouble(5)});
            }

            return temp;
        }

        public List<Feedback> GetAllFeedback(){
            List<Feedback> temp = new List<Feedback>();

            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Feedback";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                temp.Add(new Feedback(){DestinationID = rdr.GetInt32(0), ReviewMessage = rdr.GetString(1), NumQuestions = rdr.GetInt32(2), 
                    ScoreTotal = rdr.GetInt32(3), EditTracking = rdr.GetString(4), FinalScore = rdr.GetDouble(5)});
            }

            return temp;
        }

        public void PostFeedback(Feedback obj){
           string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            DateTime localDate = DateTime.Now;
            cmd.CommandText = @"INSERT INTO Feedback(DestinationID, Message, NumQuestions, ScoreTotal, LastEdit, FinalScore) 
                                VALUES(@DestinationID, @Message, @NumQuestions, @ScoreTotal, @LastEdit, @FinalScore)";
            cmd.Parameters.AddWithValue("@DestinationID", obj.DestinationID);
            cmd.Parameters.AddWithValue("@Message", obj.ReviewMessage);
            cmd.Parameters.AddWithValue("@NumQuestions", obj.NumQuestions);
            cmd.Parameters.AddWithValue("@ScoreTotal", obj.ScoreTotal);
            cmd.Parameters.AddWithValue("@LastEdit", localDate.ToString());
            cmd.Parameters.AddWithValue("@FinalScore", obj.FinalScore);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            //Console.WriteLine(obj.DestinationID + " " + obj.ReviewMessage + " " + obj.NumQuestions + " " + obj.FinalScore);
        }
    }
}