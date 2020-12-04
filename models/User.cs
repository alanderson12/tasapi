using System.Security.AccessControl;
using System.Runtime.CompilerServices;
using System.Data.Common;
using System;
using System.Collections.Generic;
using api.models.Database;

namespace api.models
{
    public class User
    {
        public int UserID{get;set;}
        public String UserFName{get; set;}
        public String UserLName{get; set;}
        public String UserName{get; set;}
        public String UserType{get; set;}
        public int TeamID{get;set;}

        public bool VerifyUser(){ 
            UserDBObj db = new UserDBObj();
            List<User> myUsers = db.GetAllUsers();

            foreach(User user in myUsers){
                if(user.UserName == this.UserName && user.UserType == this.UserType){
                    return true;
                }
            }
            return false;
        }

    }
}