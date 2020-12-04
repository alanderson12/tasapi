using System;

namespace api.models
{
    public class EmployeeFeedback : ICalculateFeedback
    {
        public int DestinationID{get; set;}
        public double ScoreTotal{get; set;}
        public int NumQuestions{get; set;}
        public String ReviewMessage{get; set;}
        public String EditTracking{get; set;}
        public double FinalScore{get; set;}

        public EmployeeFeedback(){
            FinalScore = CalculateScore();
        }
        
        public double CalculateScore()
        {
            return ScoreTotal / NumQuestions;
        }
    }
}