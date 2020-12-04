using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace api.models.Database
{
    public class SurveyDBObj
    {
        public List<Survey> allSurveys{get; set;}

        public SurveyDBObj(){
            GetNewConnection();
        }

        public void GetNewConnection(){
            List<Survey> temp = new List<Survey>();

            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM CreatedSurveys";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                temp.Add(new Survey(){SurveyID = rdr.GetInt32(0), NumQuestions = rdr.GetInt32(1), SurveyQuestions = rdr.GetString(2)});
            }

            allSurveys = temp;
        }

        public List<Survey> GetAllSurveys(){
            return allSurveys;
        }

        public void UpdateSurveyTable(List<Survey> newSurveyTable){
            string cs = @"URI=file:C:\Users\ndiro\source\repos\Tuscaloosa_Accounting_Project\api\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "DROP TABLE IF EXISTS CreatedSurveys";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE CreatedSurveys(SurveyID INT PRIMARY KEY, NumQuestions INT, SurveyQuestions TEXT)";
            cmd.ExecuteNonQuery();

            foreach(Survey survey in newSurveyTable){
                cmd.CommandText = @"INSERT INTO CreatedSurveys(SurveyID, NumQuestions, SurveyQuestions) VALUES(@SurveyID, @NumQuestions, @SurveyQuestions)";
                cmd.Parameters.AddWithValue("@SurveyID", survey.SurveyID);
                cmd.Parameters.AddWithValue("@NumQuestions", survey.NumQuestions);
                cmd.Parameters.AddWithValue("@SurveyQuestions", survey.SurveyQuestions);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            GetNewConnection();
        }

        public void AddSurvey(Survey survey){
            allSurveys.Add(survey);
            UpdateSurveyTable(allSurveys);
        }
    }
}