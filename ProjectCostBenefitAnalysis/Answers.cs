//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectCostBenefitAnalysis
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answers
    {
        public int AnswersId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> QuestionsId { get; set; }
        public string Answer { get; set; }
    
        public virtual ProjectDetails ProjectDetails { get; set; }
        public virtual Questions Questions { get; set; }
        public virtual StandartUsers StandartUsers { get; set; }
    }
}
