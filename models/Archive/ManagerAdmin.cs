using System;

namespace api.models
{
    public class ManagerAdmin : IAdmin
    {
        public int UserID{get; set;}
        public String UserName{get; set;}
        public String UserType{get; set;}

        public void AddUser()
        {
            throw new System.NotImplementedException();
        }
        public void GrantPermissions(int id)
        {
            throw new System.NotImplementedException();
        }
        public void RemoveUser(int id)
        {
            throw new System.NotImplementedException();
        }
        public void ViewUsers()
        {
            throw new System.NotImplementedException();
        }
        public Survey CreateSurvey(){
            return null;
        }
        public void SetSurvey(Survey value){

        }
    }
}