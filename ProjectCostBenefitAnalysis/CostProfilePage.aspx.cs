using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCostBenefitAnalysis
{
    public partial class BenefitProfilePage : System.Web.UI.Page
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
            //Txt_ProposedProduct.Text = String.Empty;
            //Txt_DateConducted.Text = String.Empty;
            //Txt_CompletedBy.Text = String.Empty;
            Ddl_CostCategory.SelectedValue = 20.ToString();
            Ddl_OpexCapex.SelectedValue = 2.ToString();
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
            
            var veriler = db.CostProfile.Where(x => x.UserId == userıd && x.ProjectId == id).Select(x => new { x.CostProfileId, x.ProposedProduct, x.DateConducte, x.CompletedBy, x.CostCategoryId, x.OpexCapex, x.Year1, x.Year2, x.Year3, x.Year4, x.Year5, x.Year6, x.Year7, x.Year8, x.Year9, x.Year10 }).ToList();
            GridView1.DataSource = veriler;
            GridView1.DataBind();
        }
        public void SendData(int id)
        {
            int projectId = id;
            int userId = Convert.ToInt32(Request.QueryString["UserId"]);
            CostProfile send = new CostProfile();
            send.ProposedProduct = db.ProjectDetails.Where(x => x.ProjectId == projectId).Select(x => x.ProjectName).FirstOrDefault();
            send.DateConducte = db.ProjectDetails.Where(x => x.ProjectId == projectId).Select(x => x.ProjectEstimatedStartDate).FirstOrDefault();
            send.CompletedBy = db.StandartUsers.Where(x => x.UserId == userId).Select(x => x.StandartUserUsername).FirstOrDefault();
            send.CostCategoryId = Convert.ToInt32(Ddl_CostCategory.SelectedItem.Value);
            send.OpexCapex = Convert.ToInt32(Ddl_OpexCapex.SelectedItem.Value);
            if (!String.IsNullOrEmpty(Txt_Year1.Text)) { send.Year1 = Convert.ToInt32(Txt_Year1.Text); }
            if (!String.IsNullOrEmpty(Txt_Year2.Text)) { send.Year2 = Convert.ToInt32(Txt_Year2.Text); }
            if (!String.IsNullOrEmpty(Txt_Year3.Text)) { send.Year3 = Convert.ToInt32(Txt_Year3.Text); }
            if (!String.IsNullOrEmpty(Txt_Year4.Text)) { send.Year4 = Convert.ToInt32(Txt_Year4.Text); }
            if (!String.IsNullOrEmpty(Txt_Year5.Text)) { send.Year5 = Convert.ToInt32(Txt_Year5.Text); }
            if (!String.IsNullOrEmpty(Txt_Year6.Text)) { send.Year6 = Convert.ToInt32(Txt_Year6.Text); }
            if (!String.IsNullOrEmpty(Txt_Year7.Text)) { send.Year7 = Convert.ToInt32(Txt_Year7.Text); }
            if (!String.IsNullOrEmpty(Txt_Year8.Text)) { send.Year8 = Convert.ToInt32(Txt_Year8.Text); }
            if (!String.IsNullOrEmpty(Txt_Year9.Text)) { send.Year9 = Convert.ToInt32(Txt_Year9.Text); }
            if (!String.IsNullOrEmpty(Txt_Year10.Text)) { send.Year10 = Convert.ToInt32(Txt_Year10.Text); }
            send.UserId = userId;
            send.ProjectId = projectId;
            db.CostProfile.Add(send);
            db.SaveChanges();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                var costcategory = db.CostCategory.ToList();
                Ddl_CostCategory.DataTextField = "CostCategoryName";
                Ddl_CostCategory.DataValueField = "CostCategoryId";
                Ddl_CostCategory.DataSource = costcategory;
                Ddl_CostCategory.DataBind();
            }
            if(Request.QueryString["OldProjectId"]!=null)
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

        protected void Ddl_CostCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ddl_OpexCapex.Enabled = true;
            if (Convert.ToInt32(Ddl_CostCategory.SelectedItem.Value) == 20)
            {
                Ddl_OpexCapex.Enabled = false;
                Ddl_OpexCapex.SelectedValue = 2.ToString();
                InvisibleAll();
            }
        }

        protected void Btn_CostProfileSubmit_Click(object sender, EventArgs e)
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

        protected void Ddl_OpexCapex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Ddl_OpexCapex.SelectedItem.Value) == 2)
            {
                InvisibleAll();
            }
            else
            {
                VisibleAll();
            }

        }

        protected void Btn_CostProfilePreviousPage_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                Response.Redirect("QuestionsPage.aspx?userId=" + Request.QueryString["userId"] + "&OldProjectId=" + Request.QueryString["OldProjectId"]);
            }
            else
            {
                Response.Redirect("QuestionsPage.aspx?userId=" + Request.QueryString["userId"] + "&ProjectId=" + Request.QueryString["ProjectId"]);
            }
        }

        protected void Btn_CostProfileNextPage_Click(object sender, EventArgs e)
        {
           if(Request.QueryString["OldProjectId"]!=null)
            {
                Response.Redirect("BenefitsProfilePage.aspx?userId=" + Request.QueryString["userId"] + "&OldProjectId=" + Request.QueryString["OldProjectId"]);
            }
            else
            {
                Response.Redirect("BenefitsProfilePage.aspx?userId=" + Request.QueryString["userId"] + "&ProjectId=" + Request.QueryString["ProjectId"]);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisibleAll();
            Btn_CostProfileSubmit.Visible = false;
            Btn_CostProfileUpdate.Visible = true;
            Btn_CostProfileClear.Visible = true;
            int costId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            var costprofile = db.CostProfile.Where(x => x.CostProfileId == costId).FirstOrDefault();
            Ddl_CostCategory.SelectedValue = costprofile.CostCategoryId.ToString();
            Ddl_OpexCapex.SelectedValue = costprofile.OpexCapex.ToString();
            Txt_Year1.Text = costprofile.Year1.ToString();
            Txt_Year2.Text = costprofile.Year2.ToString();
            Txt_Year3.Text = costprofile.Year3.ToString();
            Txt_Year4.Text = costprofile.Year4.ToString();
            Txt_Year5.Text = costprofile.Year5.ToString();
            Txt_Year6.Text = costprofile.Year6.ToString();
            Txt_Year7.Text = costprofile.Year7.ToString();
            Txt_Year9.Text = costprofile.Year9.ToString();
            Txt_Year10.Text = costprofile.Year10.ToString();

        }

        protected void Btn_CostProfileUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OldProjectId"] != null)
            {
                int projectId = Convert.ToInt32(Request.QueryString["OldProjectId"]);
                int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                int costId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                var costprofile = db.CostProfile.Where(x => x.UserId == userId && x.ProjectId == projectId && x.CostProfileId == costId).FirstOrDefault();
                costprofile.CostCategoryId = Convert.ToInt32(Ddl_CostCategory.SelectedValue);
                costprofile.OpexCapex = Convert.ToInt32(Ddl_OpexCapex.SelectedValue);
                if (!String.IsNullOrEmpty(Txt_Year1.Text)) { costprofile.Year1 = Convert.ToInt32(Txt_Year1.Text); } else { costprofile.Year1 = null; }
                if (!String.IsNullOrEmpty(Txt_Year2.Text)) { costprofile.Year2 = Convert.ToInt32(Txt_Year2.Text); } else { costprofile.Year2 = null; }
                if (!String.IsNullOrEmpty(Txt_Year3.Text)) { costprofile.Year3 = Convert.ToInt32(Txt_Year3.Text); } else { costprofile.Year3 = null; }
                if (!String.IsNullOrEmpty(Txt_Year4.Text)) { costprofile.Year4 = Convert.ToInt32(Txt_Year4.Text); } else { costprofile.Year4 = null; }
                if (!String.IsNullOrEmpty(Txt_Year5.Text)) { costprofile.Year5 = Convert.ToInt32(Txt_Year5.Text); } else { costprofile.Year5 = null; }
                if (!String.IsNullOrEmpty(Txt_Year6.Text)) { costprofile.Year6 = Convert.ToInt32(Txt_Year6.Text); } else { costprofile.Year6 = null; }
                if (!String.IsNullOrEmpty(Txt_Year7.Text)) { costprofile.Year7 = Convert.ToInt32(Txt_Year7.Text); } else { costprofile.Year7 = null; }
                if (!String.IsNullOrEmpty(Txt_Year8.Text)) { costprofile.Year8 = Convert.ToInt32(Txt_Year8.Text); } else { costprofile.Year8 = null; }
                if (!String.IsNullOrEmpty(Txt_Year9.Text)) { costprofile.Year9 = Convert.ToInt32(Txt_Year9.Text); } else { costprofile.Year9 = null; }
                if (!String.IsNullOrEmpty(Txt_Year10.Text)) { costprofile.Year10 = Convert.ToInt32(Txt_Year10.Text); } else { costprofile.Year10 = null; }
                db.SaveChanges();
                populateGridView(Convert.ToInt32(Request.QueryString["OldProjectId"]));
                string funcCall = "<script language='javascript'>funcUpdate();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
            }
            else 
            {
                int projectId = Convert.ToInt32(Request.QueryString["ProjectId"]);
                int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                int costId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                var costprofile = db.CostProfile.Where(x => x.UserId == userId && x.ProjectId == projectId && x.CostProfileId == costId).FirstOrDefault();
                costprofile.CostCategoryId = Convert.ToInt32(Ddl_CostCategory.SelectedValue);
                costprofile.OpexCapex = Convert.ToInt32(Ddl_OpexCapex.SelectedValue);
                if (!String.IsNullOrEmpty(Txt_Year1.Text)) { costprofile.Year1 = Convert.ToInt32(Txt_Year1.Text); } else { costprofile.Year1 = null; }
                if (!String.IsNullOrEmpty(Txt_Year2.Text)) { costprofile.Year2 = Convert.ToInt32(Txt_Year2.Text); } else { costprofile.Year2 = null; }
                if (!String.IsNullOrEmpty(Txt_Year3.Text)) { costprofile.Year3 = Convert.ToInt32(Txt_Year3.Text); } else { costprofile.Year3 = null; }
                if (!String.IsNullOrEmpty(Txt_Year4.Text)) { costprofile.Year4 = Convert.ToInt32(Txt_Year4.Text); } else { costprofile.Year4 = null; }
                if (!String.IsNullOrEmpty(Txt_Year5.Text)) { costprofile.Year5 = Convert.ToInt32(Txt_Year5.Text); } else { costprofile.Year5 = null; }
                if (!String.IsNullOrEmpty(Txt_Year6.Text)) { costprofile.Year6 = Convert.ToInt32(Txt_Year6.Text); } else { costprofile.Year6 = null; }
                if (!String.IsNullOrEmpty(Txt_Year7.Text)) { costprofile.Year7 = Convert.ToInt32(Txt_Year7.Text); } else { costprofile.Year7 = null; }
                if (!String.IsNullOrEmpty(Txt_Year8.Text)) { costprofile.Year8 = Convert.ToInt32(Txt_Year8.Text); } else { costprofile.Year8 = null; }
                if (!String.IsNullOrEmpty(Txt_Year9.Text)) { costprofile.Year9 = Convert.ToInt32(Txt_Year9.Text); } else { costprofile.Year9 = null; }
                if (!String.IsNullOrEmpty(Txt_Year10.Text)) { costprofile.Year10 = Convert.ToInt32(Txt_Year10.Text); } else { costprofile.Year10 = null; }
                db.SaveChanges();
                populateGridView(Convert.ToInt32(Request.QueryString["ProjectId"]));
                string funcCall = "<script language='javascript'>funcUpdate();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
            }
            
        }

        protected void Btn_CostProfileClear_Click(object sender, EventArgs e)
        {
            
            InvisibleAll();
            GridView1.SelectedIndex = -1;
            Btn_CostProfileUpdate.Visible = false;
            Btn_CostProfileSubmit.Visible = true;
            Btn_CostProfileClear.Visible = false;
            Ddl_CostCategory.SelectedValue = 20.ToString();
            Ddl_OpexCapex.SelectedValue = 2.ToString();
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