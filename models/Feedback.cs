using System;

namespace api.models
{
    public class Feedback : ICalculateFeedback
    {
        public int DestinationID{get; set;}
        public double ScoreTotal{get; set;}
        public int NumQuestions{get; set;}
        public String ReviewMessage{get; set;}
        public String EditTracking{get; set;}
        public double FinalScore{get; set;}

        public Feedback(){
            FinalScore = CalculateScore();
        }

        public double CalculateScore()
        {
            return ScoreTotal / NumQuestions;
        }
    }
}