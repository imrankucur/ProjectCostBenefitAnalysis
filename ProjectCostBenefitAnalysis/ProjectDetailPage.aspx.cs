using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
 

namespace ProjectCostBenefitAnalysis
{
    public partial class ProjectDetailPage : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities db = new ProjectCostBenefitAnalysisEntities();

        public int getProjectId()
        {
            int projectId = db.ProjectDetails.Where(x => x.ProjectName == Txt_ProjectName.Text).Select(x => x.ProjectId).FirstOrDefault();
            return (projectId);
        }
        public void PopulateDDL()
        {
            if (!IsPostBack)
            {
                var goals = db.ProjectGoals.ToList();
                Ddl_ProjectGoals.DataTextField = "GoalNames";
                Ddl_ProjectGoals.DataValueField = "GoalId";
                Ddl_ProjectGoals.DataSource = goals;
                Ddl_ProjectGoals.DataBind();
            }

        }
        public void SendData()
        {
            int a = db.ProjectGoals.Where(x => x.GoalNames == Ddl_ProjectGoals.SelectedItem.Text).Select(x => x.GoalId).FirstOrDefault();
            ProjectDetails send = new ProjectDetails();
            send.ProjectName = Txt_ProjectName.Text;
            send.ProjectEstimatedStartDate = Convert.ToDateTime(Txt_ProjectEstimatedStartDate.Text);
            send.ProjectEstimatedCompletionDate = Convert.ToDateTime(Txt_ProjectEstimatedCompletionDate.Text);
            send.ProjectDescription = Txt_ProjectDescription.Text;
            send.ProjectGoal = a;
            send.ExpectedBenefits = Txt_ExpectedBenefits.Text;
            send.StakeholdersActors = Txt_StakeHoldersActors.Text;
            send.RelatedBusinessProcesses = Txt_RelatedBusinessProcesses.Text;
            send.UserId = Convert.ToInt32(Request.QueryString["userId"]);
            db.ProjectDetails.Add(send);
            db.SaveChanges();

            Response.Redirect("ProjectDetailPage.aspx?userId=" + Request.QueryString["userId"] + "&ProjectId=" + getProjectId());
            
        }

        public void UpdateData(int b)
        {
            int a = db.ProjectGoals.Where(x => x.GoalNames == Ddl_ProjectGoals.SelectedItem.Text).Select(x => x.GoalId).FirstOrDefault();
            //int b =Convert.ToInt32(Request.QueryString["ProjectId"]);
            int userId = Convert.ToInt32(Request.QueryString["userId"]);
            var projectdetails = db.ProjectDetails.Where(x => x.UserId == userId && x.ProjectId == b).FirstOrDefault();

            projectdetails.ProjectName = Txt_ProjectName.Text;
            projectdetails.ProjectEstimatedStartDate = Convert.ToDateTime(Txt_ProjectEstimatedStartDate.Text);
            projectdetails.ProjectEstimatedCompletionDate = Convert.ToDateTime(Txt_ProjectEstimatedCompletionDate.Text);
            projectdetails.ProjectDescription = Txt_ProjectDescription.Text;
            projectdetails.ProjectGoal = a;
            projectdetails.ExpectedBenefits = Txt_ExpectedBenefits.Text;
            projectdetails.StakeholdersActors = Txt_StakeHoldersActors.Text;
            projectdetails.RelatedBusinessProcesses = Txt_RelatedBusinessProcesses.Text;
            db.SaveChanges();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProjectId"] != null)
            {
                if (!Page.IsPostBack)
                {
                    int userId = Convert.ToInt32(Request.QueryString["userId"]);
                    int b = Convert.ToInt32(Request.QueryString["ProjectId"]);
                    int goalid = db.ProjectDetails.Where(x => x.UserId == userId && x.ProjectId == b).Select(x => x.ProjectGoal).FirstOrDefault();
                    var projectdetails = db.ProjectDetails.Where(x => x.UserId == userId && x.ProjectId == b).FirstOrDefault();

                    Txt_ProjectName.Text = projectdetails.ProjectName;
                    Txt_ProjectEstimatedStartDate.Text = projectdetails.ProjectEstimatedStartDate.ToString("yyyy-MM-dd");
                    Txt_ProjectEstimatedCompletionDate.Text = projectdetails.ProjectEstimatedCompletionDate.ToString("yyyy-MM-dd");
                    Txt_ProjectDescription.Text = projectdetails.ProjectDescription;
                    Ddl_ProjectGoals.SelectedValue = projectdetails.ProjectGoal.ToString();
                    Txt_ExpectedBenefits.Text = projectdetails.ExpectedBenefits;
                    Txt_StakeHoldersActors.Text = projectdetails.StakeholdersActors;
                    Txt_RelatedBusinessProcesses.Text = projectdetails.RelatedBusinessProcesses;
                    Btn_ProjectDetailNextPage.Enabled = true;
                    Btn_SubmitProjectDetails.Visible = false;
                    Btn_UpdateProjectDetails.Visible = true;
                    //Txt_ProjectName.Enabled = false;
                }
            }
            if (Request.QueryString["OldProjectId"] != null)
            {
                if (!Page.IsPostBack)
                {
                    int userId = Convert.ToInt32(Request.QueryString["userId"]);
                    int b = Convert.ToInt32(Request.QueryString["OldProjectId"]);
                    int goalid = db.ProjectDetails.Where(x => x.UserId == userId && x.ProjectId == b).Select(x => x.ProjectGoal).FirstOrDefault();
                    var projectdetails = db.ProjectDetails.Where(x => x.UserId == userId && x.ProjectId == b).FirstOrDefault();

                    Txt_ProjectName.Text = projectdetails.ProjectName;
                    Txt_ProjectEstimatedStartDate.Text = projectdetails.ProjectEstimatedStartDate.ToString("yyyy-MM-dd");
                    Txt_ProjectEstimatedCompletionDate.Text = projectdetails.ProjectEstimatedCompletionDate.ToString("yyyy-MM-dd");
                    Txt_ProjectDescription.Text = projectdetails.ProjectDescription;
                    Ddl_ProjectGoals.SelectedValue = projectdetails.ProjectGoal.ToString();
                    Txt_ExpectedBenefits.Text = projectdetails.ExpectedBenefits;
                    Txt_StakeHoldersActors.Text = projectdetails.StakeholdersActors;
                    Txt_RelatedBusinessProcesses.Text = projectdetails.RelatedBusinessProcesses;
                    Btn_ProjectDetailNextPage.Enabled = true;
                    Btn_SubmitProjectDetails.Visible = false;
                    Btn_UpdateProjectDetails.Visible = true;
                    //Txt_ProjectName.Enabled = false;
                }
            }
            PopulateDDL();
        }

        protected void Btn_SubmitProjectDetails_Click(object sender, EventArgs e)
        {
            SendData();
            Btn_ProjectDetailNextPage.Enabled = true;
            Btn_UpdateProjectDetails.Visible = true;
            Btn_SubmitProjectDetails.Visible = false;
            
            //Txt_ProjectName.Enabled = false;

        }

        protected void Btn_ProjectDetailNextPage_Click(object sender, EventArgs e)
        {
            if(Request.QueryString["OldProjectId"] != null)
            {
                Response.Redirect("QuestionsPage.aspx?userId=" + Request.QueryString["userId"] + "&OldProjectId=" + Request.QueryString["OldProjectId"]);
            }
            else
            {
                Response.Redirect("QuestionsPage.aspx?userId=" + Request.QueryString["userId"] + "&ProjectId=" + Request.QueryString["ProjectId"]);
            }
        }

        protected void Btn_UpdateProjectDetails_Click(object sender, EventArgs e)
        {
            if(Request.QueryString["OldProjectId"]!=null)
            {
                UpdateData(Convert.ToInt32(Request.QueryString["OldProjectId"]));
                string funcCall = "<script language='javascript'>funcUpdate();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);


            }
            else
            {
               UpdateData(Convert.ToInt32(Request.QueryString["ProjectId"]));
                string funcCall = "<script language='javascript'>funcUpdate();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);

            }

        }
    }
}