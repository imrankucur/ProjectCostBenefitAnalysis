using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCostBenefitAnalysis
{
    public partial class BenefitsProfilePage : System.Web.UI.Page
    {
        ProjectCostBenefitAnalysisEntities db = new ProjectCostBenefitAnalysisEntities();
        public void VisibleAll()
        {
            Txt_Year1.Visible = true;
            Txt_Year2.Visible = true;
            Txt_Year3.Visible = true;
            Txt_Year4.Visible = true;
            Txt_Year5.Visible = true;
            Txt_Year6.Visible = true;
            Txt_Year7.Visible = true;
            Txt_Year8.Visible = true;
            Txt_Year9.Visible = true;
            Txt_Year10.Visible = true;
            Lbl_Year1.Visible = true;
            Lbl_Year2.Visible = true;
            Lbl_Year3.Visible = true;
            Lbl_Year4.Visible = true;
            Lbl_Year5.Visible = true;
            Lbl_Year6.Visible = true;
            Lbl_Year7.Visible = true;
            Lbl_Year8.Visible = true;
            Lbl_Year9.Visible = true;
            Lbl_Year10.Visible = true;
        }
        public void InvisibleAll()
        {
            Txt_Year1.Visible = false;
            Txt_Year2.Visible = false;
            Txt_Year3.Visible = false;
            Txt_Year4.Visible = false;
            Txt_Year5.Visible = false;
            Txt_Year6.Visible = false;
            Txt_Year7.Visible = false;
            Txt_Year8.Visible = false;
            Txt_Year9.Visible = false;
            Txt_Year10.Visible = false;
            Lbl_Year1.Visible = false;
            Lbl_Year2.Visible = false;
            Lbl_Year3.Visible = false;
            Lbl_Year4.Visible = false;
            Lbl_Year5.Visible = false;
            Lbl_Year6.Visible = false;
            Lbl_Year7.Visible = false;
            Lbl_Year8.Visible = false;
            Lbl_Year9.Visible = false;
            Lbl_Year10.Visible = false;
        }
        public void EmptyAll()
        {
            Ddl_BenefitsCategory.SelectedValue = 8.ToString();
            Txt_Year1.Text = String.Empty;
            Txt_Year2.Text = String.Empty;
            Txt_Year3.Text = String.Empty;
            Txt_Year4.Text = String.Empty;
            Txt_Year5.Text = String.Empty;
            Txt_Year6.Text = String.Empty;
            Txt_Year7.Text = String.Empty;
            Txt_Year8.Text = String.Empty;
            Txt_Year9.Text = String.Empty;
            Txt_Year10.Text = String.Empty;
        }
        public void populateGridView(int id)
        {
            int userıd = Convert.ToInt32(Request.QueryString["UserId"]);

            var veriler = db.BenefitsProfile.Where(x => x.UserId == userıd && x.ProjectId == id).Select(x => new { x.BenefitsProfileId, x.ProposedProduct, x.DateConducted, x.CompletedBy, x.BenefitsCategoryId, x.Year1, x.Year2, x.Year3, x.Year4, x.Year5, x.Year6, x.Year7, x.Year8, x.Year9, x.Year10 }).ToList();
            GridView1.DataSource = veriler;
            GridView1.DataBind();
        }
        public void SendData(int id)
        {
            int projectId = id;
            int userId = Convert.ToInt32(Request.QueryString["UserId"]);
            BenefitsProfile send = new BenefitsProfile();
            send.ProposedProduct = db.ProjectDetails.Where(x => x.ProjectId == projectId).Select(x => x.ProjectName).FirstOrDefault();
            send.DateConducted = db.ProjectDetails.Where(x => x.ProjectId == projectId).Select(x => x.ProjectEstimatedStartDate).FirstOrDefault();
            send.CompletedBy = db.StandartUsers.Where(x => x.UserId == userId).Select(x => x.StandartUserUsername).FirstOrDefault();
            send.BenefitsCategoryId = Convert.ToInt32(Ddl_BenefitsCategory.SelectedItem.Value);
            if (!String.IsNullOrEmpty(Txt_Year1.Text)) { send.Year1 = Convert.ToInt32(Txt_Year1.Text); }
            if (!String.IsNullOrEmpty(Txt_Year2.Text)) { send.Year2 = Convert.ToInt32(Txt_Year2.Text); }
            if (!String.IsNullOrEmpty(Txt_Year3.Text)) { send.Year3 = Convert.ToInt32(Txt_Year3.Text); }
            if (!String.IsNullOrEmpty(Txt_Year4.Text)) { send.Year4 = Convert.ToInt32(Txt_Year4.Text); }
            if (!String.IsNullOrEmpty(Txt_Year5.Text)) { send.Year5 = Convert.ToInt32(Txt_Year5.Text); }
            if (!String.IsNullOrEmpty(Txt_Year6.Text)) { send.Year6 = Convert.ToInt32(Txt_Year6.Text); }
            if (!String.IsNullOrEmpty(Txt_Year7.Text)) { send.Year7 = Convert.ToInt32(Txt_Year7.Text); }
            if (!String.IsNullOrEmpty(Txt_Year8.Text)) { send.Year8 = Convert.ToInt32(Txt_Year8.Text); }
            if (!String.IsNullOrEmpty(Txt_Year9.Text)) { send.Year9 = Convert.ToInt32(Txt_Year9.Text); }
            if (!String.IsNullOrEmpty(Txt_Year10.Text)) { send.Year10 = Convert.ToInt32(Txt_Year10.Text);}
            send.UserId = userId;
            send.ProjectId = projectId;
            db.BenefitsProfile.Add(send);
            db.SaveChanges();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var benefitscategory = db.BenefitsCategory.ToList();
                Ddl_BenefitsCategory.DataTextField = "BenefitsCategoryName";
                Ddl_BenefitsCategory.DataValueField = "BenefitsCategoryId";
                Ddl_BenefitsCategory.DataSource = benefitscategory;
                Ddl_BenefitsCategory.DataBind();
            }
            if (Request.QueryString["OldProjectId"] != null)
            {
                int projectId = Convert.ToInt32(Request.QueryString["OldProjectId"]);
                int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                Lbl_ProposedProduct.Text = "Proposed Product/Initiative/Service: " + db.ProjectDetails.Where(x => x.ProjectId == projectId).Select(x => x.ProjectName).FirstOrDefault();
                Lbl_DateConducted.Text = "Date Conducted: " + db.ProjectDetails.Where(x => x.ProjectId == projectId).Select(x => x.ProjectEstimatedStartDate).FirstOrDefault();
                Lbl_CompletedBy.Text = "Completed By: " + db.StandartUsers.Where(x => x.UserId == userId).Select(x => x.StandartUserUsername).FirstOrDefault();
                populateGridView(projectId);

            }
            else
            {
                int projectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
                int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                Lbl_ProposedProduct.Text = "Proposed Product/Initiative/Service: " + db.ProjectDetails.Where(x => x.ProjectId == projectId).Select(x => x.ProjectName).FirstOrDefault();
                Lbl_DateConducted.Text = "Date Conducted: " + db.ProjectDetails.Where(x => x.ProjectId == projectId).Select(x => x.ProjectEstimatedStartDate).FirstOrDefault();
                Lbl_CompletedBy.Text = "Completed By: " + db.StandartUsers.Where(x => x.UserId == userId).Select(x => x.StandartUserUsername).FirstOrDefault();
                populateGridView(projectId);
            }

        }
        protected void Btn_BenefitsProfileSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                SendData(Convert.ToInt32(Request.QueryString["OldProjectId"]));
                populateGridView(Convert.ToInt32(Request.QueryString["OldProjectId"]));
                EmptyAll();
                InvisibleAll();
            }
            else
            {
                SendData(Convert.ToInt32(Request.QueryString["ProjectId"]));
                populateGridView(Convert.ToInt32(Request.QueryString["ProjectId"]));
                EmptyAll();
                InvisibleAll();
            }
            
        }
        protected void Ddl_BenefitsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Ddl_BenefitsCategory.SelectedItem.Value) == 8)
            {
                InvisibleAll();
            }
            else
            {
                VisibleAll();
            }
        }
        protected void Btn_BenefitsProfilePreviousPage_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                Response.Redirect("CostProfilePage.aspx?userId=" + Request.QueryString["userId"] + "&OldProjectId=" + Request.QueryString["OldProjectId"]);
            }
            else
            {
                Response.Redirect("CostProfilePage.aspx?userId=" + Request.QueryString["userId"] + "&ProjectId=" + Request.QueryString["ProjectId"]);
            }
        }

        protected void Btn_BenefitsProfileNextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserChoicePage.aspx?userId=" + Request.QueryString["userId"]);

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisibleAll();
            Btn_BenefitsProfileSubmit.Visible = false;
            Btn_BenefitsProfileUpdate.Visible = true;
            Btn_BenefitsProfileClear.Visible = true;
            int benefitId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            var benefitsprofile = db.BenefitsProfile.Where(x => x.BenefitsProfileId == benefitId).FirstOrDefault();
            Ddl_BenefitsCategory.SelectedValue = benefitsprofile.BenefitsCategoryId.ToString();
            Txt_Year1.Text = benefitsprofile.Year1.ToString();
            Txt_Year2.Text = benefitsprofile.Year2.ToString();
            Txt_Year3.Text = benefitsprofile.Year3.ToString();
            Txt_Year4.Text = benefitsprofile.Year4.ToString();
            Txt_Year5.Text = benefitsprofile.Year5.ToString();
            Txt_Year6.Text = benefitsprofile.Year6.ToString();
            Txt_Year7.Text = benefitsprofile.Year7.ToString();
            Txt_Year9.Text = benefitsprofile.Year9.ToString();
            Txt_Year10.Text = benefitsprofile.Year10.ToString();

        }
        protected void Btn_BenefitsProfileUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                int projectId = Convert.ToInt32(Request.QueryString["OldProjectId"]);
                int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                int benefitId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                var benefitsprofile = db.BenefitsProfile.Where(x => x.UserId == userId && x.ProjectId == projectId && x.BenefitsProfileId == benefitId).FirstOrDefault();
                benefitsprofile.BenefitsCategoryId = Convert.ToInt32(Ddl_BenefitsCategory.SelectedValue);
                if (!String.IsNullOrEmpty(Txt_Year1.Text)) { benefitsprofile.Year1 = Convert.ToInt32(Txt_Year1.Text); } else { benefitsprofile.Year1 = null; }
                if (!String.IsNullOrEmpty(Txt_Year2.Text)) { benefitsprofile.Year2 = Convert.ToInt32(Txt_Year2.Text); } else { benefitsprofile.Year2 = null; }
                if (!String.IsNullOrEmpty(Txt_Year3.Text)) { benefitsprofile.Year3 = Convert.ToInt32(Txt_Year3.Text); } else { benefitsprofile.Year3 = null; }
                if (!String.IsNullOrEmpty(Txt_Year4.Text)) { benefitsprofile.Year4 = Convert.ToInt32(Txt_Year4.Text); } else { benefitsprofile.Year4 = null; }
                if (!String.IsNullOrEmpty(Txt_Year5.Text)) { benefitsprofile.Year5 = Convert.ToInt32(Txt_Year5.Text); } else { benefitsprofile.Year5 = null; }
                if (!String.IsNullOrEmpty(Txt_Year6.Text)) { benefitsprofile.Year6 = Convert.ToInt32(Txt_Year6.Text); } else { benefitsprofile.Year6 = null; }
                if (!String.IsNullOrEmpty(Txt_Year7.Text)) { benefitsprofile.Year7 = Convert.ToInt32(Txt_Year7.Text); } else { benefitsprofile.Year7 = null; }
                if (!String.IsNullOrEmpty(Txt_Year8.Text)) { benefitsprofile.Year8 = Convert.ToInt32(Txt_Year8.Text); } else { benefitsprofile.Year8 = null; }
                if (!String.IsNullOrEmpty(Txt_Year9.Text)) { benefitsprofile.Year9 = Convert.ToInt32(Txt_Year9.Text); } else { benefitsprofile.Year9 = null; }
                if (!String.IsNullOrEmpty(Txt_Year10.Text)) { benefitsprofile.Year10 = Convert.ToInt32(Txt_Year10.Text); } else { benefitsprofile.Year10 = null; }
                db.SaveChanges();
                populateGridView(Convert.ToInt32(Request.QueryString["OldProjectId"]));
                string funcCall = "<script language='javascript'>funcUpdate();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
            }
            else
            {
                int projectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
                int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                int benefitId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                var benefitsprofile = db.BenefitsProfile.Where(x => x.UserId == userId && x.ProjectId == projectId && x.BenefitsProfileId == benefitId).FirstOrDefault();
                benefitsprofile.BenefitsCategoryId = Convert.ToInt32(Ddl_BenefitsCategory.SelectedValue);
                if (!String.IsNullOrEmpty(Txt_Year1.Text)) { benefitsprofile.Year1 = Convert.ToInt32(Txt_Year1.Text); } else { benefitsprofile.Year1 = null; }
                if (!String.IsNullOrEmpty(Txt_Year2.Text)) { benefitsprofile.Year2 = Convert.ToInt32(Txt_Year2.Text); } else { benefitsprofile.Year2 = null; }
                if (!String.IsNullOrEmpty(Txt_Year3.Text)) { benefitsprofile.Year3 = Convert.ToInt32(Txt_Year3.Text); } else { benefitsprofile.Year3 = null; }
                if (!String.IsNullOrEmpty(Txt_Year4.Text)) { benefitsprofile.Year4 = Convert.ToInt32(Txt_Year4.Text); } else { benefitsprofile.Year4 = null; }
                if (!String.IsNullOrEmpty(Txt_Year5.Text)) { benefitsprofile.Year5 = Convert.ToInt32(Txt_Year5.Text); } else { benefitsprofile.Year5 = null; }
                if (!String.IsNullOrEmpty(Txt_Year6.Text)) { benefitsprofile.Year6 = Convert.ToInt32(Txt_Year6.Text); } else { benefitsprofile.Year6 = null; }
                if (!String.IsNullOrEmpty(Txt_Year7.Text)) { benefitsprofile.Year7 = Convert.ToInt32(Txt_Year7.Text); } else { benefitsprofile.Year7 = null; }
                if (!String.IsNullOrEmpty(Txt_Year8.Text)) { benefitsprofile.Year8 = Convert.ToInt32(Txt_Year8.Text); } else { benefitsprofile.Year8 = null; }
                if (!String.IsNullOrEmpty(Txt_Year9.Text)) { benefitsprofile.Year9 = Convert.ToInt32(Txt_Year9.Text); } else { benefitsprofile.Year9 = null; }
                if (!String.IsNullOrEmpty(Txt_Year10.Text)) { benefitsprofile.Year10 = Convert.ToInt32(Txt_Year10.Text); } else { benefitsprofile.Year10 = null; }
                db.SaveChanges();
                populateGridView(Convert.ToInt32(Request.QueryString["ProjectId"]));
                string funcCall = "<script language='javascript'>funcUpdate();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
            }
           
        }
        protected void Btn_BenefitsProfileClear_Click(object sender, EventArgs e)
        {

            InvisibleAll();
            GridView1.SelectedIndex = -1;
            Btn_BenefitsProfileUpdate.Visible = false;
            Btn_BenefitsProfileSubmit.Visible = true;
            Btn_BenefitsProfileClear.Visible = false;
            Ddl_BenefitsCategory.SelectedValue = 8.ToString();
            Txt_Year1.Text = "";
            Txt_Year2.Text = "";
            Txt_Year3.Text = "";
            Txt_Year4.Text = "";
            Txt_Year5.Text = "";
            Txt_Year6.Text = "";
            Txt_Year7.Text = "";
            Txt_Year8.Text = "";
            Txt_Year9.Text = "";
            Txt_Year10.Text = "";

        }
    }
}