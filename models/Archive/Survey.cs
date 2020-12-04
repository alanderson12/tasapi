using System;

namespace api.models
{
    public class Survey
    {
        public int SurveyID{get; set;}
        public int NumQuestions{get; set;}
        public String SurveyQuestions{get; set;}
        
        public void DeleteSurvey(){

        }
    }
}