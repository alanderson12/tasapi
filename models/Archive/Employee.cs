using System;
using System.Collections.Generic;

namespace api.models
{
    public class Employee 
    {
        public int EmpID{get; set;}
        public int TeamID{get; set;}
        public bool isHidden{get; set;}
        public ICalculateFeedback feedbackBehavior;
        public IRank rankBehavior;

        public Employee(){
            feedbackBehavior = new EmployeeFeedback();
            rankBehavior = new EmployeeRank();
        }
    }
}