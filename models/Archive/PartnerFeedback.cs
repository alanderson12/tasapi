using System;

namespace api.models
{
    public class PartnerFeedback : ICalculateFeedback
    {
        public int SourceID{get; set;}
        public int DestinationID{get; set;}
        public double ScoreTotal{get; set;}
        public int NumQuestions{get; set;}
        public String ReviewMessage{get; set;}
        public String EditTracking{get; set;}
        public double FinalScore{get; set;}
        
        public PartnerFeedback(){

        }

        public double CalculateScore()
        {
            return ScoreTotal / NumQuestions;
        }
    }
}