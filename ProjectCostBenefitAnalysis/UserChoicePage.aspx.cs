using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCostBenefitAnalysis
{
    public partial class UserChoicePage : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities db = new ProjectCostBenefitAnalysisEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                var userchoice = db.ProjectDetails.Where(x => x.UserId == userId).ToList();
                Ddl_UpdateExistingProject.DataTextField = "ProjectName";
                Ddl_UpdateExistingProject.DataValueField = "ProjectId";
                Ddl_UpdateExistingProject.DataSource = userchoice;
                Ddl_UpdateExistingProject.DataBind();
                Ddl_UpdateExistingProject.Items.Insert(0, new ListItem("Please Select a Project...", "Please Select a Project..."));

            }
        }

        protected void Btn_AddNewProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectDetailPage.aspx?userId=" + Request.QueryString["UserId"]);
        }

        protected void Ddl_UpdateExistingProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ProjectDetailPage.aspx?userId=" + Request.QueryString["userId"] + "&OldProjectId=" + Ddl_UpdateExistingProject.SelectedValue);
        }
    }
}