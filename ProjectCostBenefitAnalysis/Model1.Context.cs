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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectCostBenefitAnalysisEntities : DbContext
    {
        public ProjectCostBenefitAnalysisEntities()
            : base("name=ProjectCostBenefitAnalysisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminUsers> AdminUsers { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<BenefitsCategory> BenefitsCategory { get; set; }
        public virtual DbSet<BenefitsProfile> BenefitsProfile { get; set; }
        public virtual DbSet<CostCategory> CostCategory { get; set; }
        public virtual DbSet<CostProfile> CostProfile { get; set; }
        public virtual DbSet<ProjectDetails> ProjectDetails { get; set; }
        public virtual DbSet<ProjectGoals> ProjectGoals { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<StandartUsers> StandartUsers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
