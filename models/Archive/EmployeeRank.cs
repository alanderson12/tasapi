using System;

namespace api.models
{
    public class EmployeeRank : IRank
    {
        public int TeamID{get; set;}
        public int SourceID{get; set;}
        
        public void RankTeam()
        {
            throw new System.NotImplementedException();
        }
    }
}