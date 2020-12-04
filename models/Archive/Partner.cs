using System;
using System.Collections.Generic;

namespace api.models
{
    public class Partner : User
    {
        public int PartnerID{get; set;}
        public ICalculateFeedback feedbackBehavior;
        public IAdmin adminBehavior;
    }
}