using System;
using System.Collections.Generic;

namespace api.models
{
    public class Manager
    {
        public int MgrID{get; set;}
        public int TeamID{get; set;}
        public ICalculateFeedback feedbackBehavior;
        public IRank rankBehavior;
        public IAdmin adminBehavior;
    }
}