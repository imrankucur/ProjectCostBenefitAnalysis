using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



namespace ProjectCostBenefitAnalysis
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities database = new ProjectCostBenefitAnalysisEntities();
        public void GetUserData()
        {



            if (Ddl_AllProjects.SelectedValue == "Please Select a Project")
            { }
            else
            {

                int a = Convert.ToInt32(Ddl_AllProjects.SelectedValue);
                var userdata = (from p in database.ProjectDetails
                                select new
                                {
                                    UserId = p.UserId,
                                    ProjectId = p.ProjectId,
                                    ProjectName = p.ProjectName,
                                    ProjectEstimatedStartDate = p.ProjectEstimatedStartDate,
                                    ProjectEstimatedCompleteDate = p.ProjectEstimatedCompletionDate,
                                    ProjectDescription = p.ProjectDescription,
                                    ExpectedBenefits = p.ExpectedBenefits,
                                    StakeholdersActors = p.StakeholdersActors,
                                    RelatedBusinessProcesses = p.RelatedBusinessProcesses,
                                    ProjectGoal = p.ProjectGoal,
                                }).Where(x => x.ProjectId == a);
                Grd_ViewUserData.DataSource = userdata.ToList();
                Grd_ViewUserData.DataBind();

                var userdata2 = (from p in database.Answers
                                 select new
                                 {
                                     UserId = p.UserId,
                                     ProjectId = p.ProjectId,
                                     Question = database.Questions.Where(x => x.QuestionsId == p.QuestionsId).Select(x => x.Question).FirstOrDefault(),
                                     Answer = p.Answer,
                                 }).Where(x => x.ProjectId == a);
                Grd_ViewUserAnswers.DataSource = userdata2.ToList();
                Grd_ViewUserAnswers.DataBind();

                var userdata3 = (from p in database.CostProfile
                                 select new
                                 {
                                     UserId = p.UserId,
                                     ProjectId = p.ProjectId,
                                     ProposedProduct = p.ProposedProduct,
                                     DateConducte = p.DateConducte,
                                     CompletedBy = p.CompletedBy,
                                     CostCategory = database.CostCategory.Where(x => x.CostCategoryId == p.CostCategoryId).Select(x => x.CostCategoryName).FirstOrDefault(),
                                     OpexCapex = p.OpexCapex,
                                     Year1 = p.Year1,
                                     Year2 = p.Year2,
                                     Year3 = p.Year3,
                                     Year4 = p.Year4,
                                     Year5 = p.Year5,
                                     Year6 = p.Year6,
                                     Year7 = p.Year7,
                                     Year8 = p.Year8,
                                     Year9 = p.Year9,
                                     Year10 = p.Year10,

                                 }).Where(x => x.ProjectId == a);
                Grd_ViewUserCostProfile.DataSource = userdata3.ToList();
                Grd_ViewUserCostProfile.DataBind();

                var userdata4 = (from p in database.BenefitsProfile
                                 select new
                                 {
                                     UserId = p.UserId,
                                     ProjectId = p.ProjectId,
                                     ProposedProduct = p.ProposedProduct,
                                     DateConducted = p.DateConducted,
                                     CompletedBy = p.CompletedBy,
                                     BenefitsCategoryId = database.BenefitsCategory.Where(x => x.BenefitsCategoryId == p.BenefitsCategoryId).Select(x => x.BenefitsCategoryName).FirstOrDefault(),

                                     Year1 = p.Year1,
                                     Year2 = p.Year2,
                                     Year3 = p.Year3,
                                     Year4 = p.Year4,
                                     Year5 = p.Year5,
                                     Year6 = p.Year6,
                                     Year7 = p.Year7,
                                     Year8 = p.Year8,
                                     Year9 = p.Year9,
                                     Year10 = p.Year10,
                                 }).Where(x => x.ProjectId == a);
                Grd_ViewUserBenefitsProfile.DataSource = userdata4.ToList();
                Grd_ViewUserBenefitsProfile.DataBind();
            }

        }
        public void PopulateGridView()
        {

            Grd_Questions.DataSource = database.Questions.Where(x => x.QuestionState == 1).Select(x => new { x.QuestionsId, x.Question }).ToList();
            Grd_Questions.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddl_AllUsers.Items.Insert(0, new ListItem("Please Select a User", "Please Select a User"));
                Ddl_AllProjects.Items.Insert(0, new ListItem("Please Select a Project", "Please Select a Project"));

                PopulateGridView();
                var allusers = database.StandartUsers.ToList();
                Ddl_AllUsers.DataTextField = "StandartUserUsername";
                Ddl_AllUsers.DataValueField = "UserId";
                Ddl_AllUsers.DataSource = allusers;
                Ddl_AllUsers.DataBind();
            }
            
        }

        protected void Btn_AddQuestion_Click(object sender, EventArgs e)
        {
            int number = database.Questions.Where(x => x.QuestionState == 1).Count();
            if (number >= 5)
            {
                Lbl_QuestionLimit.Text = "Maximum question limit reached/!";
            }
            else
            {
                Questions send = new Questions();
                send.Question = Txt_Question.Text;
                send.QuestionState = 1;
                database.Questions.Add(send);
                database.SaveChanges();
                Txt_Question.Text = "";
                PopulateGridView();
            }
        }
        protected void Grd_Questions_SelectedIndexChanged(object sender, EventArgs e)
        {

            int deleteQuestion = Convert.ToInt32(Grd_Questions.SelectedRow.Cells[1].Text);
            Questions deneme = new Questions();
            var status = database.Questions.Where(x => x.QuestionsId == deleteQuestion).FirstOrDefault();
            status.QuestionState = 0;
            //var flik = new Questions { QuestionsId = deleteQuestion };
            //database.Questions.Attach(flik);
            //database.Questions.Remove(flik);
            database.SaveChanges();
            PopulateGridView();

        }

        protected void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void Btn_GetUserData_Click(object sender, EventArgs e)
        {
            GetUserData();
        }

        protected void Ddl_AllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Ddl_AllUsers.SelectedValue == "Please Select a User")
            {
                Ddl_AllProjects.Enabled = false;
                Ddl_AllProjects.SelectedValue = "Please Select a Project";
            }
            else
            {
                Ddl_AllProjects.Items.Clear();
                Ddl_AllProjects.Items.Insert(0, new ListItem("Please Select a Project", "Please Select a Project"));
                Ddl_AllProjects.Enabled = true;
                int userId = Convert.ToInt32(Ddl_AllUsers.SelectedValue);
                var allprojects = database.ProjectDetails.Where(x => x.UserId == userId).ToList();
                Ddl_AllProjects.DataTextField = "ProjectName";
                Ddl_AllProjects.DataValueField = "ProjectId";
                Ddl_AllProjects.DataSource = allprojects;
                Ddl_AllProjects.DataBind();

            }
        }
        
    }
}